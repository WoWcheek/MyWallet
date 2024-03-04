namespace MyWallet
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            sidePanel = new Panel();
            sideCalendar = new MonthCalendar();
            expensesBtn = new Button();
            incomeBtn = new Button();
            usernameLbl = new Label();
            logOutLbl = new Label();
            mainPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(sidePanel);
            mainPanel.Cursor = Cursors.Hand;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(989, 654);
            mainPanel.TabIndex = 0;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.PowderBlue;
            sidePanel.Controls.Add(logOutLbl);
            sidePanel.Controls.Add(sideCalendar);
            sidePanel.Controls.Add(expensesBtn);
            sidePanel.Controls.Add(incomeBtn);
            sidePanel.Controls.Add(usernameLbl);
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(232, 654);
            sidePanel.TabIndex = 1;
            // 
            // sideCalendar
            // 
            sideCalendar.BackColor = Color.Azure;
            sideCalendar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sideCalendar.ForeColor = Color.Navy;
            sideCalendar.Location = new Point(18, 307);
            sideCalendar.MaxSelectionCount = 2;
            sideCalendar.Name = "sideCalendar";
            sideCalendar.ShowTodayCircle = false;
            sideCalendar.TabIndex = 3;
            sideCalendar.TitleBackColor = Color.LightCyan;
            sideCalendar.TitleForeColor = Color.Navy;
            // 
            // expensesBtn
            // 
            expensesBtn.BackColor = Color.PowderBlue;
            expensesBtn.FlatAppearance.BorderSize = 0;
            expensesBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            expensesBtn.ForeColor = Color.Navy;
            expensesBtn.Location = new Point(0, 172);
            expensesBtn.Name = "expensesBtn";
            expensesBtn.Padding = new Padding(10, 0, 0, 0);
            expensesBtn.Size = new Size(232, 49);
            expensesBtn.TabIndex = 2;
            expensesBtn.Text = "My expenses";
            expensesBtn.TextAlign = ContentAlignment.MiddleLeft;
            expensesBtn.UseVisualStyleBackColor = false;
            // 
            // incomeBtn
            // 
            incomeBtn.BackColor = Color.PowderBlue;
            incomeBtn.FlatAppearance.BorderSize = 0;
            incomeBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            incomeBtn.ForeColor = Color.Navy;
            incomeBtn.Location = new Point(0, 117);
            incomeBtn.Name = "incomeBtn";
            incomeBtn.Padding = new Padding(10, 0, 0, 0);
            incomeBtn.Size = new Size(232, 49);
            incomeBtn.TabIndex = 1;
            incomeBtn.Text = "My incomes";
            incomeBtn.TextAlign = ContentAlignment.MiddleLeft;
            incomeBtn.UseVisualStyleBackColor = false;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Cursor = Cursors.Default;
            usernameLbl.Font = new Font("Segoe UI", 14F, FontStyle.Underline, GraphicsUnit.Point);
            usernameLbl.ForeColor = Color.Navy;
            usernameLbl.Location = new Point(12, 23);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(121, 32);
            usernameLbl.TabIndex = 0;
            usernameLbl.Text = "Username";
            // 
            // logOutLbl
            // 
            logOutLbl.AutoSize = true;
            logOutLbl.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            logOutLbl.ForeColor = Color.Navy;
            logOutLbl.Location = new Point(12, 595);
            logOutLbl.Name = "logOutLbl";
            logOutLbl.Size = new Size(96, 32);
            logOutLbl.TabIndex = 4;
            logOutLbl.Text = "Log out";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(982, 653);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MyWallet";
            mainPanel.ResumeLayout(false);
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel sidePanel;
        private Label usernameLbl;
        private Button incomeBtn;
        private Button expensesBtn;
        private MonthCalendar sideCalendar;
        private Label logOutLbl;
    }
}
