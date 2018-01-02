using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OFE_Populate_Pass
{
    public partial class Form1 : Form
    {
        private List<string> fileLines { get; set; }
        public object[,] ValueArray { get; set; }

        public Dictionary<string, string> rdHash;
        public Form1()
        {
            InitializeComponent();
            fileLines = new List<string>();
            rdHash = new Dictionary<string, string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if(rdHash.Count > 0)
            {
                rdHash.Clear();
            }
            if(fileLines.Count > 0 && ValueArray.Length > 0)
            {
                PopulateRdDictionary();
                LookupRefdes();
                CreateOutputFile();
                ExtractStatusLabel.Text = "Extraction Complete.";
                ExtractStatusLabel.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("One or more input files was not processed correctly.\nPlease check your input files and try again.", "File Read Error");
            }
        }

        private void LookupRefdes()
        {
            string value = null;
            for (int i = 1; i < ValueArray.GetLength(0) + 1; i++)
            {
                if (rdHash.TryGetValue(ValueArray[i, 1].ToString(), out value))
                {
                    ValueArray[i, 4] = value;
                }
                else
                {
                    ValueArray[i, 4] = "";
                }
            }
        }

        private bool IsValidOFE()
        {
            bool isValid = false;
            if(ValueArray != null && ValueArray.GetLength(0) >= 4)
            {
                if (ValueArray[1, 1].ToString().Equals("refdes") && ValueArray[1, 3].ToString().Equals("npins"))
                    isValid = true;
            }
            return isValid;
        }

        private void CreateOutputFile()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook m_ExpBook = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exportSheet = m_ExpBook.Worksheets[1];
            try
            {
                exportSheet.Cells.NumberFormat = "@";
                //copy to new Excel workbook and prompt user to save
                Excel.Range firstcell = exportSheet.Cells[1, 1];
                Excel.Range lastcell = exportSheet.Cells[ValueArray.GetLength(0), ValueArray.GetLength(1)];
                Excel.Range targetrange = exportSheet.Range[firstcell, lastcell];
                targetrange.Value = ValueArray;

                // Clean up.
                m_ExpBook.Close(true);
                Marshal.ReleaseComObject(m_ExpBook);
            }
            catch (Exception ex)
            {
                m_ExpBook.Close(true);
                Marshal.ReleaseComObject(m_ExpBook);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void PopulateRdDictionary()
        {
            Regex reEnd = new Regex("REFERENCE DESIGNATOR COUNT");
            Regex reContainsPassInfo = new Regex(@"Program:.*Date:.*Side:\s+(\b.*\b)");
            Regex reNoRefs = new Regex("No Ref Des|SMT 1|SMT 2");
            Regex rePartNumber = new Regex(@"\\par \S+\\tab");
            string pass = null;
            bool bGetRds = false;

            for(var i = 0; i < fileLines.Count; i++)
            {
                string line = fileLines[i];
                if (reEnd.Match(line).Success)
                    return;
                if (bGetRds)
                {
                    if (reNoRefs.Match(line).Success)
                        continue;
                    PopInitialRds(line, pass);
                    bGetRds = false;
                    ++i;
                    PopAdditionalRds(i, pass);
                    continue;
                }                

                Match matchpass = reContainsPassInfo.Match(line);
                if (matchpass.Success)
                {
                    pass = matchpass.Groups[1].Captures[0].Value;
                    continue;
                }

                if (rePartNumber.Match(line).Success)
                    bGetRds = true;
            }
        }

        private void PopInitialRds(string line, string pass)
        {
            string[] separator = new string[] { "\\tab " };
            char[] commasep = new char[] { ',' };
            string[] results = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if(results.Length > 3)
            {
                string[] temprds = results[3].Trim().Split(commasep, StringSplitOptions.RemoveEmptyEntries);
                foreach (string refdes in temprds)
                {
                    rdHash.Add(refdes, pass);
                }
            }      
        }

        private void PopAdditionalRds(int index, string pass)
        {
            Regex reEnd = new Regex("REFERENCE DESIGNATOR COUNT");
            Regex rePn = new Regex(@"\A\\par \S*\\tab");
            string[] tabsep = new string[] { "\\tab \\tab \\tab " };
            string[] commasep = new string[] { "," };
            for (var i = index; i < fileLines.Count; i++)
            {
                if (reEnd.Match(fileLines[i]).Success)
                    return;
                if (!fileLines[i].Contains("\\tab \\tab \\tab ") && rePn.Match(fileLines[i]).Success && !fileLines[i].Contains(@"BOM") && !fileLines[i].Contains(@"Listing Date"))
                    return;
                string[] refs = fileLines[i].Split(tabsep, StringSplitOptions.None);
                if(refs.Length > 1)
                {
                    refs[1] = refs[1].Trim();
                    string[] temprds = refs[1].Split(commasep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string refdes in temprds)
                    {
                        rdHash.Add(refdes, pass);
                    }
                }
            }

        }
        private void SetupButton_Click(object sender, EventArgs e)
        {     
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Title = "Load the Setup Sheet";
            fileDlg.Filter = "Setup Sheet (*.rtf)|*.rtf";
            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                SetupSheetLabel.ResetText();
                fileLines.Clear();
                string line = null;
                try
                {
                    using(StreamReader reader = new StreamReader(fileDlg.FileName))
                    {
                        while( (line = reader.ReadLine()) != null)
                        {
                            fileLines.Add(line);
                        }
                    }
                  
                    SetupSheetLabel.Text = fileDlg.FileName;

                    if (ReportLabel.Text.Length > 4)
                    {
                        ExtractStatusLabel.Text = "Ready to extract...";
                        ExtractStatusLabel.ForeColor = Color.DarkKhaki; 
                    }
                    else
                    {
                        ExtractStatusLabel.Text = "Waiting for input files...";
                        ExtractStatusLabel.ForeColor = Color.Red;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            fileDlg.Dispose();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {          
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Title = "Load the OFE Report";
            fileDlg.Filter = "OFE Report|*.xls;*.xlsx" ;
            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                ReportLabel.ResetText();
                if(ValueArray != null)
                {
                    Array.Clear(ValueArray, 1, ValueArray.Length);
                }         
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileDlg.FileName,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                try
                {
                    Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    ValueArray = xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    if (IsValidOFE())
                    {
                        ReportLabel.Text = fileDlg.FileName;
                        if (SetupSheetLabel.Text.Length > 4)
                        {
                            ExtractStatusLabel.Text = "Ready to extract...";
                            ExtractStatusLabel.ForeColor = Color.DarkKhaki;
                        }
                        else
                        {
                            ExtractStatusLabel.Text = "Waiting for input files...";
                            ExtractStatusLabel.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (ValueArray != null)
                        {
                            Array.Clear(ValueArray, 1, ValueArray.Length);
                        }
                        MessageBox.Show("The OFE Report does not appear to be in a valid format.\nPlease check the file and try again", "Invalid OFE Report Format");
                    }

                }
                catch (Exception ex)
                {
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    if(ValueArray != null)
                    {
                        Array.Clear(ValueArray, 1, ValueArray.Length);
                    }
                    MessageBox.Show("Problem loading OFE Report. Please check the file and try again.\n" + ex.Message, "ReportButton_Click()");
                }
            }
            fileDlg.Dispose();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fileLines.Clear();
            rdHash.Clear();
            if(ValueArray != null && ValueArray.Length > 0)
            {
                Array.Clear(ValueArray, 1, ValueArray.Length);
            }
            ExtractStatusLabel.Text = "Waiting for input files...";
            ExtractStatusLabel.ForeColor = Color.Red;
            SetupSheetLabel.ResetText();
            ReportLabel.ResetText();
        }
    }
}
