namespace MyWallet.Views.UserControls
{
    partial class SummaryUC
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
            totalincomeLbl = new Label();
            label1 = new Label();
            balanceLbl = new Label();
            incomeValueLbl = new Label();
            expensevalueLbl = new Label();
            balanceValueLbl = new Label();
            SuspendLayout();
            // 
            // totalincomeLbl
            // 
            totalincomeLbl.AutoSize = true;
            totalincomeLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            totalincomeLbl.ForeColor = Color.Azure;
            totalincomeLbl.Location = new Point(40, 25);
            totalincomeLbl.Name = "totalincomeLbl";
            totalincomeLbl.Size = new Size(162, 32);
            totalincomeLbl.TabIndex = 0;
            totalincomeLbl.Text = "Total Income";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.Azure;
            label1.Location = new Point(679, 25);
            label1.Name = "label1";
            label1.Size = new Size(181, 32);
            label1.TabIndex = 1;
            label1.Text = "Total Expenses";
            // 
            // balanceLbl
            // 
            balanceLbl.AutoSize = true;
            balanceLbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            balanceLbl.ForeColor = Color.Azure;
            balanceLbl.Location = new Point(352, 88);
            balanceLbl.Name = "balanceLbl";
            balanceLbl.Size = new Size(196, 32);
            balanceLbl.TabIndex = 2;
            balanceLbl.Text = "Current balance";
            // 
            // incomeValueLbl
            // 
            incomeValueLbl.AutoSize = true;
            incomeValueLbl.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            incomeValueLbl.ForeColor = Color.Azure;
            incomeValueLbl.Location = new Point(40, 68);
            incomeValueLbl.Name = "incomeValueLbl";
            incomeValueLbl.Size = new Size(114, 28);
            incomeValueLbl.TabIndex = 3;
            incomeValueLbl.Text = "10000 UAH";
            // 
            // expensevalueLbl
            // 
            expensevalueLbl.AutoSize = true;
            expensevalueLbl.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            expensevalueLbl.ForeColor = Color.Azure;
            expensevalueLbl.Location = new Point(679, 68);
            expensevalueLbl.Name = "expensevalueLbl";
            expensevalueLbl.Size = new Size(114, 28);
            expensevalueLbl.TabIndex = 4;
            expensevalueLbl.Text = "10000 UAH";
            // 
            // balanceValueLbl
            // 
            balanceValueLbl.AutoSize = true;
            balanceValueLbl.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            balanceValueLbl.ForeColor = Color.Azure;
            balanceValueLbl.Location = new Point(352, 131);
            balanceValueLbl.Name = "balanceValueLbl";
            balanceValueLbl.Size = new Size(114, 28);
            balanceValueLbl.TabIndex = 5;
            balanceValueLbl.Text = "10000 UAH";
            // 
            // SummaryUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            Controls.Add(balanceValueLbl);
            Controls.Add(expensevalueLbl);
            Controls.Add(incomeValueLbl);
            Controls.Add(balanceLbl);
            Controls.Add(label1);
            Controls.Add(totalincomeLbl);
            Name = "SummaryUC";
            Size = new Size(900, 185);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label totalincomeLbl;
        private Label label1;
        private Label balanceLbl;
        private Label incomeValueLbl;
        private Label expensevalueLbl;
        private Label balanceValueLbl;
    }
}
