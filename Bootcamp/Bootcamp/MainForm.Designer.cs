namespace Bootcamp
{
    partial class MainForm
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
            this.SelectFilesbutton = new System.Windows.Forms.Button();
            this.GenerateReportbutton = new System.Windows.Forms.Button();
            this.ReportscomboBox = new System.Windows.Forms.ComboBox();
            this.SelectedFilesrichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedFileslabel = new System.Windows.Forms.Label();
            this.ChoiceFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectIdtextBox = new System.Windows.Forms.TextBox();
            this.SelecIdlabel = new System.Windows.Forms.Label();
            this.ReportdataGridView = new System.Windows.Forms.DataGridView();
            this.RangeDownPricetextBox = new System.Windows.Forms.TextBox();
            this.RangeUpPricetextBox = new System.Windows.Forms.TextBox();
            this.RangePricelabel = new System.Windows.Forms.Label();
            this.Rangelabel = new System.Windows.Forms.Label();
            this.DeletePathbutton = new System.Windows.Forms.Button();
            this.DeletePathcomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReportdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectFilesbutton
            // 
            this.SelectFilesbutton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectFilesbutton.Location = new System.Drawing.Point(12, 366);
            this.SelectFilesbutton.Name = "SelectFilesbutton";
            this.SelectFilesbutton.Size = new System.Drawing.Size(129, 28);
            this.SelectFilesbutton.TabIndex = 0;
            this.SelectFilesbutton.Text = "Dodaj plik";
            this.SelectFilesbutton.UseVisualStyleBackColor = true;
            this.SelectFilesbutton.Click += new System.EventHandler(this.SelectFilesbutton_Click);
            // 
            // GenerateReportbutton
            // 
            this.GenerateReportbutton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GenerateReportbutton.Location = new System.Drawing.Point(708, 604);
            this.GenerateReportbutton.Name = "GenerateReportbutton";
            this.GenerateReportbutton.Size = new System.Drawing.Size(129, 28);
            this.GenerateReportbutton.TabIndex = 1;
            this.GenerateReportbutton.Text = "Generuj raport";
            this.GenerateReportbutton.UseVisualStyleBackColor = true;
            this.GenerateReportbutton.Click += new System.EventHandler(this.GenerateReportbutton_Click);
            // 
            // ReportscomboBox
            // 
            this.ReportscomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReportscomboBox.FormattingEnabled = true;
            this.ReportscomboBox.Location = new System.Drawing.Point(12, 604);
            this.ReportscomboBox.Name = "ReportscomboBox";
            this.ReportscomboBox.Size = new System.Drawing.Size(690, 28);
            this.ReportscomboBox.TabIndex = 2;
            // 
            // SelectedFilesrichTextBox
            // 
            this.SelectedFilesrichTextBox.BackColor = System.Drawing.Color.Ivory;
            this.SelectedFilesrichTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectedFilesrichTextBox.Location = new System.Drawing.Point(12, 32);
            this.SelectedFilesrichTextBox.Name = "SelectedFilesrichTextBox";
            this.SelectedFilesrichTextBox.Size = new System.Drawing.Size(264, 328);
            this.SelectedFilesrichTextBox.TabIndex = 3;
            this.SelectedFilesrichTextBox.Text = "Brak wybranych plików";
            // 
            // SelectedFileslabel
            // 
            this.SelectedFileslabel.AutoSize = true;
            this.SelectedFileslabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectedFileslabel.Location = new System.Drawing.Point(12, 9);
            this.SelectedFileslabel.Name = "SelectedFileslabel";
            this.SelectedFileslabel.Size = new System.Drawing.Size(96, 19);
            this.SelectedFileslabel.TabIndex = 4;
            this.SelectedFileslabel.Text = "Wybrane pliki:";
            // 
            // ChoiceFileOpenFileDialog
            // 
            this.ChoiceFileOpenFileDialog.FileName = "openFileDialog1";
            // 
            // SelectIdtextBox
            // 
            this.SelectIdtextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectIdtextBox.Location = new System.Drawing.Point(12, 572);
            this.SelectIdtextBox.Name = "SelectIdtextBox";
            this.SelectIdtextBox.Size = new System.Drawing.Size(100, 26);
            this.SelectIdtextBox.TabIndex = 5;
            this.SelectIdtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectIdtextBox_KeyPress);
            // 
            // SelecIdlabel
            // 
            this.SelecIdlabel.AutoSize = true;
            this.SelecIdlabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelecIdlabel.Location = new System.Drawing.Point(12, 550);
            this.SelecIdlabel.Name = "SelecIdlabel";
            this.SelecIdlabel.Size = new System.Drawing.Size(74, 19);
            this.SelecIdlabel.TabIndex = 6;
            this.SelecIdlabel.Text = "Wskaż ID:";
            // 
            // ReportdataGridView
            // 
            this.ReportdataGridView.BackgroundColor = System.Drawing.Color.Ivory;
            this.ReportdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportdataGridView.Location = new System.Drawing.Point(282, 32);
            this.ReportdataGridView.Name = "ReportdataGridView";
            this.ReportdataGridView.ReadOnly = true;
            this.ReportdataGridView.Size = new System.Drawing.Size(555, 566);
            this.ReportdataGridView.TabIndex = 8;
            // 
            // RangeDownPricetextBox
            // 
            this.RangeDownPricetextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RangeDownPricetextBox.Location = new System.Drawing.Point(12, 513);
            this.RangeDownPricetextBox.Name = "RangeDownPricetextBox";
            this.RangeDownPricetextBox.Size = new System.Drawing.Size(100, 26);
            this.RangeDownPricetextBox.TabIndex = 9;
            this.RangeDownPricetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RangeDownPricetextBox_KeyPress);
            // 
            // RangeUpPricetextBox
            // 
            this.RangeUpPricetextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RangeUpPricetextBox.Location = new System.Drawing.Point(137, 513);
            this.RangeUpPricetextBox.Name = "RangeUpPricetextBox";
            this.RangeUpPricetextBox.Size = new System.Drawing.Size(100, 26);
            this.RangeUpPricetextBox.TabIndex = 10;
            this.RangeUpPricetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RangeUpPricetextBox_KeyPress);
            // 
            // RangePricelabel
            // 
            this.RangePricelabel.AutoSize = true;
            this.RangePricelabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RangePricelabel.Location = new System.Drawing.Point(69, 482);
            this.RangePricelabel.Name = "RangePricelabel";
            this.RangePricelabel.Size = new System.Drawing.Size(117, 19);
            this.RangePricelabel.TabIndex = 11;
            this.RangePricelabel.Text = "Przedział cenowy:";
            // 
            // Rangelabel
            // 
            this.Rangelabel.AutoSize = true;
            this.Rangelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rangelabel.Location = new System.Drawing.Point(117, 515);
            this.Rangelabel.Name = "Rangelabel";
            this.Rangelabel.Size = new System.Drawing.Size(14, 20);
            this.Rangelabel.TabIndex = 12;
            this.Rangelabel.Text = "-";
            // 
            // DeletePathbutton
            // 
            this.DeletePathbutton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeletePathbutton.Location = new System.Drawing.Point(147, 366);
            this.DeletePathbutton.Name = "DeletePathbutton";
            this.DeletePathbutton.Size = new System.Drawing.Size(129, 28);
            this.DeletePathbutton.TabIndex = 13;
            this.DeletePathbutton.Text = "Usuń plik";
            this.DeletePathbutton.UseVisualStyleBackColor = true;
            this.DeletePathbutton.Click += new System.EventHandler(this.DeletePathbutton_Click);
            // 
            // DeletePathcomboBox
            // 
            this.DeletePathcomboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeletePathcomboBox.FormattingEnabled = true;
            this.DeletePathcomboBox.Location = new System.Drawing.Point(147, 400);
            this.DeletePathcomboBox.Name = "DeletePathcomboBox";
            this.DeletePathcomboBox.Size = new System.Drawing.Size(129, 27);
            this.DeletePathcomboBox.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(849, 644);
            this.Controls.Add(this.DeletePathcomboBox);
            this.Controls.Add(this.DeletePathbutton);
            this.Controls.Add(this.Rangelabel);
            this.Controls.Add(this.RangePricelabel);
            this.Controls.Add(this.RangeUpPricetextBox);
            this.Controls.Add(this.RangeDownPricetextBox);
            this.Controls.Add(this.ReportdataGridView);
            this.Controls.Add(this.SelecIdlabel);
            this.Controls.Add(this.SelectIdtextBox);
            this.Controls.Add(this.SelectedFileslabel);
            this.Controls.Add(this.SelectedFilesrichTextBox);
            this.Controls.Add(this.ReportscomboBox);
            this.Controls.Add(this.GenerateReportbutton);
            this.Controls.Add(this.SelectFilesbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BootCamp";
            ((System.ComponentModel.ISupportInitialize)(this.ReportdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectFilesbutton;
        private System.Windows.Forms.Button GenerateReportbutton;
        private System.Windows.Forms.ComboBox ReportscomboBox;
        private System.Windows.Forms.RichTextBox SelectedFilesrichTextBox;
        private System.Windows.Forms.Label SelectedFileslabel;
        private System.Windows.Forms.OpenFileDialog ChoiceFileOpenFileDialog;
        private System.Windows.Forms.TextBox SelectIdtextBox;
        private System.Windows.Forms.Label SelecIdlabel;
        private System.Windows.Forms.DataGridView ReportdataGridView;
        private System.Windows.Forms.TextBox RangeDownPricetextBox;
        private System.Windows.Forms.TextBox RangeUpPricetextBox;
        private System.Windows.Forms.Label RangePricelabel;
        private System.Windows.Forms.Label Rangelabel;
        private System.Windows.Forms.Button DeletePathbutton;
        private System.Windows.Forms.ComboBox DeletePathcomboBox;
    }
}

