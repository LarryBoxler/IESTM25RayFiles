
namespace IESTM25FileViewer
{
    partial class FormRayFileViewer
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openIESTM25FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.tabIESTM25File = new System.Windows.Forms.TabControl();
            this.tabHeader = new System.Windows.Forms.TabPage();
            this.richTextBoxHeader = new System.Windows.Forms.RichTextBox();
            this.tabFlags = new System.Windows.Forms.TabPage();
            this.checkedListBoxFlags = new System.Windows.Forms.CheckedListBox();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.richTextBoxDecription = new System.Windows.Forms.RichTextBox();
            this.tabSpectralTables = new System.Windows.Forms.TabPage();
            this.tabAdditionalText = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabRayData = new System.Windows.Forms.TabPage();
            this.flowLayoutSpectralTable = new System.Windows.Forms.FlowLayoutPanel();
            this.tabIESTM25File.SuspendLayout();
            this.tabHeader.SuspendLayout();
            this.tabFlags.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabSpectralTables.SuspendLayout();
            this.tabAdditionalText.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(26, 44);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(154, 31);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // openIESTM25FileDialog
            // 
            this.openIESTM25FileDialog.Filter = "TM25Files|*.TM25RAY";
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(212, 48);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(576, 22);
            this.textFileName.TabIndex = 1;
            // 
            // tabIESTM25File
            // 
            this.tabIESTM25File.Controls.Add(this.tabHeader);
            this.tabIESTM25File.Controls.Add(this.tabFlags);
            this.tabIESTM25File.Controls.Add(this.tabDescription);
            this.tabIESTM25File.Controls.Add(this.tabSpectralTables);
            this.tabIESTM25File.Controls.Add(this.tabAdditionalText);
            this.tabIESTM25File.Controls.Add(this.tabRayData);
            this.tabIESTM25File.Location = new System.Drawing.Point(26, 161);
            this.tabIESTM25File.Name = "tabIESTM25File";
            this.tabIESTM25File.SelectedIndex = 0;
            this.tabIESTM25File.Size = new System.Drawing.Size(1066, 487);
            this.tabIESTM25File.TabIndex = 2;
            // 
            // tabHeader
            // 
            this.tabHeader.Controls.Add(this.richTextBoxHeader);
            this.tabHeader.Location = new System.Drawing.Point(4, 25);
            this.tabHeader.Name = "tabHeader";
            this.tabHeader.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeader.Size = new System.Drawing.Size(1058, 458);
            this.tabHeader.TabIndex = 0;
            this.tabHeader.Text = "Header Info";
            this.tabHeader.UseVisualStyleBackColor = true;
            // 
            // richTextBoxHeader
            // 
            this.richTextBoxHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxHeader.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxHeader.Name = "richTextBoxHeader";
            this.richTextBoxHeader.Size = new System.Drawing.Size(846, 446);
            this.richTextBoxHeader.TabIndex = 0;
            this.richTextBoxHeader.Text = "";
            // 
            // tabFlags
            // 
            this.tabFlags.Controls.Add(this.checkedListBoxFlags);
            this.tabFlags.Location = new System.Drawing.Point(4, 25);
            this.tabFlags.Name = "tabFlags";
            this.tabFlags.Padding = new System.Windows.Forms.Padding(3);
            this.tabFlags.Size = new System.Drawing.Size(922, 458);
            this.tabFlags.TabIndex = 1;
            this.tabFlags.Text = "Data Flag Status";
            this.tabFlags.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxFlags
            // 
            this.checkedListBoxFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxFlags.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxFlags.FormattingEnabled = true;
            this.checkedListBoxFlags.Items.AddRange(new object[] {
            "Position Flag",
            "Direction Flag",
            "Radiant Flux / Stokes S0 Flag",
            "Wavelength Flag",
            "Luminous Flux / Y Tristimulus Flag",
            "Stokes Flag",
            "Tristimulus Flag",
            "Spectrum Index Flag"});
            this.checkedListBoxFlags.Location = new System.Drawing.Point(40, 20);
            this.checkedListBoxFlags.Name = "checkedListBoxFlags";
            this.checkedListBoxFlags.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedListBoxFlags.Size = new System.Drawing.Size(376, 242);
            this.checkedListBoxFlags.TabIndex = 0;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.richTextBoxDecription);
            this.tabDescription.Location = new System.Drawing.Point(4, 25);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(1058, 458);
            this.tabDescription.TabIndex = 2;
            this.tabDescription.Text = "Description Block";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDecription
            // 
            this.richTextBoxDecription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDecription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDecription.Location = new System.Drawing.Point(3, 6);
            this.richTextBoxDecription.Name = "richTextBoxDecription";
            this.richTextBoxDecription.Size = new System.Drawing.Size(630, 456);
            this.richTextBoxDecription.TabIndex = 0;
            this.richTextBoxDecription.Text = "";
            // 
            // tabSpectralTables
            // 
            this.tabSpectralTables.Controls.Add(this.flowLayoutSpectralTable);
            this.tabSpectralTables.Location = new System.Drawing.Point(4, 25);
            this.tabSpectralTables.Name = "tabSpectralTables";
            this.tabSpectralTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpectralTables.Size = new System.Drawing.Size(922, 458);
            this.tabSpectralTables.TabIndex = 3;
            this.tabSpectralTables.Text = "Spectral Tables";
            this.tabSpectralTables.UseVisualStyleBackColor = true;
            // 
            // tabAdditionalText
            // 
            this.tabAdditionalText.Controls.Add(this.richTextBox3);
            this.tabAdditionalText.Location = new System.Drawing.Point(4, 25);
            this.tabAdditionalText.Name = "tabAdditionalText";
            this.tabAdditionalText.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdditionalText.Size = new System.Drawing.Size(922, 313);
            this.tabAdditionalText.TabIndex = 4;
            this.tabAdditionalText.Text = "Additional Text Block";
            this.tabAdditionalText.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBox3.Location = new System.Drawing.Point(156, 72);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(582, 138);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "Not Implemented in TM25-13 Version";
            // 
            // tabRayData
            // 
            this.tabRayData.Location = new System.Drawing.Point(4, 25);
            this.tabRayData.Name = "tabRayData";
            this.tabRayData.Padding = new System.Windows.Forms.Padding(3);
            this.tabRayData.Size = new System.Drawing.Size(1058, 458);
            this.tabRayData.TabIndex = 5;
            this.tabRayData.Text = "Sample Ray Data";
            this.tabRayData.UseVisualStyleBackColor = true;
            // 
            // flowLayoutSpectralTable
            // 
            this.flowLayoutSpectralTable.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutSpectralTable.Name = "flowLayoutSpectralTable";
            this.flowLayoutSpectralTable.Size = new System.Drawing.Size(901, 446);
            this.flowLayoutSpectralTable.TabIndex = 0;
            // 
            // FormRayFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 672);
            this.Controls.Add(this.tabIESTM25File);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.buttonOpenFile);
            this.Name = "FormRayFileViewer";
            this.Text = "IES TM25-13 Ray File Viewer";
            this.tabIESTM25File.ResumeLayout(false);
            this.tabHeader.ResumeLayout(false);
            this.tabFlags.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabSpectralTables.ResumeLayout(false);
            this.tabAdditionalText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openIESTM25FileDialog;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.TabControl tabIESTM25File;
        private System.Windows.Forms.TabPage tabHeader;
        private System.Windows.Forms.RichTextBox richTextBoxHeader;
        private System.Windows.Forms.TabPage tabFlags;
        private System.Windows.Forms.CheckedListBox checkedListBoxFlags;
        private System.Windows.Forms.TabPage tabDescription;
        private System.Windows.Forms.RichTextBox richTextBoxDecription;
        private System.Windows.Forms.TabPage tabSpectralTables;
        private System.Windows.Forms.TabPage tabAdditionalText;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TabPage tabRayData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSpectralTable;
    }
}

