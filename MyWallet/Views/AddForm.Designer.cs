namespace MyWallet.Views
{
    partial class AddForm
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
            categoryLbl = new Label();
            categoryCB = new ComboBox();
            descriptionLbl = new Label();
            descriptionTB = new TextBox();
            amountLbl = new Label();
            amountNumeric = new NumericUpDown();
            calendar = new MonthCalendar();
            dateLbl = new Label();
            mainBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)amountNumeric).BeginInit();
            SuspendLayout();
            // 
            // categoryLbl
            // 
            categoryLbl.AutoSize = true;
            categoryLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            categoryLbl.ForeColor = Color.Navy;
            categoryLbl.Location = new Point(12, 16);
            categoryLbl.Name = "categoryLbl";
            categoryLbl.Size = new Size(118, 32);
            categoryLbl.TabIndex = 0;
            categoryLbl.Text = "Category";
            // 
            // categoryCB
            // 
            categoryCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            categoryCB.AutoCompleteSource = AutoCompleteSource.ListItems;
            categoryCB.BackColor = Color.Azure;
            categoryCB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            categoryCB.FormattingEnabled = true;
            categoryCB.Location = new Point(163, 15);
            categoryCB.Name = "categoryCB";
            categoryCB.Size = new Size(251, 36);
            categoryCB.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            descriptionLbl.AutoSize = true;
            descriptionLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            descriptionLbl.ForeColor = Color.Navy;
            descriptionLbl.Location = new Point(12, 83);
            descriptionLbl.Name = "descriptionLbl";
            descriptionLbl.Size = new Size(146, 32);
            descriptionLbl.TabIndex = 2;
            descriptionLbl.Text = "Description";
            // 
            // descriptionTB
            // 
            descriptionTB.BackColor = Color.Azure;
            descriptionTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionTB.Location = new Point(12, 118);
            descriptionTB.MaxLength = 256;
            descriptionTB.Multiline = true;
            descriptionTB.Name = "descriptionTB";
            descriptionTB.PlaceholderText = "Your description goes here...";
            descriptionTB.Size = new Size(402, 118);
            descriptionTB.TabIndex = 3;
            // 
            // amountLbl
            // 
            amountLbl.AutoSize = true;
            amountLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            amountLbl.ForeColor = Color.Navy;
            amountLbl.Location = new Point(12, 274);
            amountLbl.Name = "amountLbl";
            amountLbl.Size = new Size(189, 32);
            amountLbl.TabIndex = 4;
            amountLbl.Text = "Money amount";
            // 
            // amountNumeric
            // 
            amountNumeric.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            amountNumeric.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            amountNumeric.Location = new Point(222, 274);
            amountNumeric.Margin = new Padding(2);
            amountNumeric.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            amountNumeric.Name = "amountNumeric";
            amountNumeric.Size = new Size(192, 34);
            amountNumeric.TabIndex = 5;
            // 
            // calendar
            // 
            calendar.Location = new Point(222, 335);
            calendar.MaxSelectionCount = 1;
            calendar.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            calendar.Name = "calendar";
            calendar.TabIndex = 6;
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            dateLbl.ForeColor = Color.Navy;
            dateLbl.Location = new Point(12, 429);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(203, 32);
            dateLbl.TabIndex = 7;
            dateLbl.Text = "Transaction date";
            // 
            // mainBtn
            // 
            mainBtn.BackColor = Color.SteelBlue;
            mainBtn.Cursor = Cursors.Hand;
            mainBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mainBtn.ForeColor = Color.AliceBlue;
            mainBtn.Location = new Point(87, 570);
            mainBtn.Name = "mainBtn";
            mainBtn.Size = new Size(242, 53);
            mainBtn.TabIndex = 8;
            mainBtn.Text = "Execute";
            mainBtn.UseVisualStyleBackColor = false;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(424, 629);
            Controls.Add(mainBtn);
            Controls.Add(dateLbl);
            Controls.Add(calendar);
            Controls.Add(amountNumeric);
            Controls.Add(amountLbl);
            Controls.Add(descriptionTB);
            Controls.Add(descriptionLbl);
            Controls.Add(categoryCB);
            Controls.Add(categoryLbl);
            Name = "AddForm";
            Text = "AddForm";
            ((System.ComponentModel.ISupportInitialize)amountNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label categoryLbl;
        private ComboBox categoryCB;
        private Label descriptionLbl;
        private TextBox descriptionTB;
        private Label amountLbl;
        private NumericUpDown amountNumeric;
        private MonthCalendar calendar;
        private Label dateLbl;
        private Button mainBtn;
    }
}