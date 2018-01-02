namespace OFE_Populate_Pass
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SetupButton = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SetupSheetLabel = new System.Windows.Forms.Label();
            this.ExtractStatusLabel = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReportLabel = new System.Windows.Forms.Label();
            this.ReportButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetupButton
            // 
            this.SetupButton.Location = new System.Drawing.Point(483, 42);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(75, 23);
            this.SetupButton.TabIndex = 1;
            this.SetupButton.Text = "Setup Sheet";
            this.SetupButton.UseVisualStyleBackColor = true;
            this.SetupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(483, 123);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 3;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(483, 181);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SetupSheetLabel
            // 
            this.SetupSheetLabel.AutoEllipsis = true;
            this.SetupSheetLabel.Location = new System.Drawing.Point(11, 16);
            this.SetupSheetLabel.Name = "SetupSheetLabel";
            this.SetupSheetLabel.Size = new System.Drawing.Size(461, 23);
            this.SetupSheetLabel.TabIndex = 4;
            // 
            // ExtractStatusLabel
            // 
            this.ExtractStatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtractStatusLabel.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.ExtractStatusLabel.Location = new System.Drawing.Point(186, 0);
            this.ExtractStatusLabel.Name = "ExtractStatusLabel";
            this.ExtractStatusLabel.Size = new System.Drawing.Size(258, 23);
            this.ExtractStatusLabel.TabIndex = 6;
            this.ExtractStatusLabel.Text = "Waiting for input files...";
            this.ExtractStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // status_lbl
            // 
            this.status_lbl.Font = new System.Drawing.Font("Baskerville Old Face", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_lbl.Location = new System.Drawing.Point(124, 0);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(73, 23);
            this.status_lbl.TabIndex = 7;
            this.status_lbl.Text = "Status:     ";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(483, 152);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetupSheetLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(2, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 43);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // ReportLabel
            // 
            this.ReportLabel.AutoEllipsis = true;
            this.ReportLabel.Location = new System.Drawing.Point(11, 16);
            this.ReportLabel.Name = "ReportLabel";
            this.ReportLabel.Size = new System.Drawing.Size(461, 23);
            this.ReportLabel.TabIndex = 5;
            // 
            // ReportButton
            // 
            this.ReportButton.Location = new System.Drawing.Point(483, 85);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(75, 23);
            this.ReportButton.TabIndex = 2;
            this.ReportButton.Text = "OFE Report";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReportLabel);
            this.groupBox2.Location = new System.Drawing.Point(2, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 46);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(570, 205);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.ExtractStatusLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.SetupButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OFE Populate Pass";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetupButton;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label SetupSheetLabel;
        private System.Windows.Forms.Label ExtractStatusLabel;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ReportLabel;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

