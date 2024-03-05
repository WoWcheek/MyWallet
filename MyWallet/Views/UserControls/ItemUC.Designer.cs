namespace MyWallet.Views.UserControls
{
    partial class ItemUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            categoryLbl = new Label();
            descriptionLbl = new Label();
            amountLbl = new Label();
            dateLbl = new Label();
            deleteBtn = new Button();
            SuspendLayout();
            // 
            // categoryLbl
            // 
            categoryLbl.AutoSize = true;
            categoryLbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            categoryLbl.ForeColor = Color.Navy;
            categoryLbl.Location = new Point(3, 11);
            categoryLbl.MaximumSize = new Size(250, 27);
            categoryLbl.Name = "categoryLbl";
            categoryLbl.Size = new Size(148, 25);
            categoryLbl.TabIndex = 0;
            categoryLbl.Text = "Category name";
            // 
            // descriptionLbl
            // 
            descriptionLbl.AutoSize = true;
            descriptionLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLbl.ForeColor = Color.Navy;
            descriptionLbl.Location = new Point(3, 46);
            descriptionLbl.Name = "descriptionLbl";
            descriptionLbl.Size = new Size(96, 23);
            descriptionLbl.TabIndex = 1;
            descriptionLbl.Text = "Description";
            // 
            // amountLbl
            // 
            amountLbl.AutoSize = true;
            amountLbl.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            amountLbl.ForeColor = Color.Navy;
            amountLbl.Location = new Point(240, 13);
            amountLbl.MaximumSize = new Size(110, 0);
            amountLbl.Name = "amountLbl";
            amountLbl.Size = new Size(95, 23);
            amountLbl.TabIndex = 2;
            amountLbl.Text = "10000 UAH";
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Enabled = false;
            dateLbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateLbl.ForeColor = Color.Navy;
            dateLbl.Location = new Point(3, 85);
            dateLbl.Name = "dateLbl";
            dateLbl.RightToLeft = RightToLeft.Yes;
            dateLbl.Size = new Size(46, 23);
            dateLbl.TabIndex = 3;
            dateLbl.Text = "Date";
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.LightCoral;
            deleteBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            deleteBtn.ForeColor = Color.Maroon;
            deleteBtn.Location = new Point(240, 82);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(95, 29);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // ItemUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            Controls.Add(deleteBtn);
            Controls.Add(dateLbl);
            Controls.Add(amountLbl);
            Controls.Add(descriptionLbl);
            Controls.Add(categoryLbl);
            Name = "ItemUC";
            Size = new Size(350, 120);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label categoryLbl;
        private Label descriptionLbl;
        private Label amountLbl;
        private Label dateLbl;
        private Button deleteBtn;
    }
}
