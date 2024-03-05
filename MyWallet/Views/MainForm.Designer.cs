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
            listPanel = new Panel();
            mainLineChart = new MindFusion.Charting.WinForms.LineChart();
            sidePanel = new Panel();
            homeBtn = new Button();
            logOutLbl = new Label();
            expensesBtn = new Button();
            incomeBtn = new Button();
            usernameLbl = new Label();
            mainPanel.SuspendLayout();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(listPanel);
            mainPanel.Controls.Add(mainLineChart);
            mainPanel.Controls.Add(sidePanel);
            mainPanel.Cursor = Cursors.Hand;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1383, 755);
            mainPanel.TabIndex = 0;
            // 
            // listPanel
            // 
            listPanel.AutoScroll = true;
            listPanel.BackColor = Color.CadetBlue;
            listPanel.Location = new Point(987, 23);
            listPanel.Name = "listPanel";
            listPanel.Size = new Size(383, 703);
            listPanel.TabIndex = 3;
            // 
            // mainLineChart
            // 
            mainLineChart.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            mainLineChart.LegendTitle = "Legend";
            mainLineChart.Location = new Point(238, 23);
            mainLineChart.Name = "mainLineChart";
            mainLineChart.Padding = new Padding(10);
            mainLineChart.ShowLegend = true;
            mainLineChart.ShowScatter = true;
            mainLineChart.ShowXCoordinates = false;
            mainLineChart.Size = new Size(705, 729);
            mainLineChart.SubtitleFontName = null;
            mainLineChart.SubtitleFontSize = null;
            mainLineChart.SubtitleFontStyle = null;
            mainLineChart.TabIndex = 2;
            mainLineChart.Text = "lineChart1";
            mainLineChart.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            mainLineChart.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            mainLineChart.Theme.UniformSeriesStrokeThickness = 2D;
            mainLineChart.TitleFontName = null;
            mainLineChart.TitleFontSize = null;
            mainLineChart.TitleFontStyle = null;
            mainLineChart.XAxisLabelRotationAngle = -60D;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.PowderBlue;
            sidePanel.Controls.Add(homeBtn);
            sidePanel.Controls.Add(logOutLbl);
            sidePanel.Controls.Add(expensesBtn);
            sidePanel.Controls.Add(incomeBtn);
            sidePanel.Controls.Add(usernameLbl);
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(232, 755);
            sidePanel.TabIndex = 1;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.PowderBlue;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            homeBtn.ForeColor = Color.Navy;
            homeBtn.Location = new Point(0, 141);
            homeBtn.Name = "homeBtn";
            homeBtn.Padding = new Padding(10, 0, 0, 0);
            homeBtn.Size = new Size(232, 49);
            homeBtn.TabIndex = 1;
            homeBtn.Text = "Home";
            homeBtn.TextAlign = ContentAlignment.MiddleLeft;
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // logOutLbl
            // 
            logOutLbl.AutoSize = true;
            logOutLbl.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            logOutLbl.ForeColor = Color.Navy;
            logOutLbl.Location = new Point(12, 694);
            logOutLbl.Name = "logOutLbl";
            logOutLbl.Size = new Size(96, 32);
            logOutLbl.TabIndex = 4;
            logOutLbl.Text = "Log out";
            // 
            // expensesBtn
            // 
            expensesBtn.BackColor = Color.PowderBlue;
            expensesBtn.FlatAppearance.BorderSize = 0;
            expensesBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            expensesBtn.ForeColor = Color.Navy;
            expensesBtn.Location = new Point(0, 251);
            expensesBtn.Name = "expensesBtn";
            expensesBtn.Padding = new Padding(10, 0, 0, 0);
            expensesBtn.Size = new Size(232, 49);
            expensesBtn.TabIndex = 3;
            expensesBtn.Text = "My expenses";
            expensesBtn.TextAlign = ContentAlignment.MiddleLeft;
            expensesBtn.UseVisualStyleBackColor = false;
            expensesBtn.Click += expensesBtn_Click;
            // 
            // incomeBtn
            // 
            incomeBtn.BackColor = Color.PowderBlue;
            incomeBtn.FlatAppearance.BorderSize = 0;
            incomeBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            incomeBtn.ForeColor = Color.Navy;
            incomeBtn.Location = new Point(0, 196);
            incomeBtn.Name = "incomeBtn";
            incomeBtn.Padding = new Padding(10, 0, 0, 0);
            incomeBtn.Size = new Size(232, 49);
            incomeBtn.TabIndex = 2;
            incomeBtn.Text = "My incomes";
            incomeBtn.TextAlign = ContentAlignment.MiddleLeft;
            incomeBtn.UseVisualStyleBackColor = false;
            incomeBtn.Click += incomeBtn_Click;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Segoe UI", 14F, FontStyle.Underline, GraphicsUnit.Point);
            usernameLbl.ForeColor = Color.Navy;
            usernameLbl.Location = new Point(12, 23);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(121, 32);
            usernameLbl.TabIndex = 0;
            usernameLbl.Text = "Username";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScrollMargin = new Size(50, 0);
            BackColor = Color.LightBlue;
            ClientSize = new Size(1382, 753);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label logOutLbl;
        private MindFusion.Charting.WinForms.LineChart mainLineChart;
        private Button homeBtn;
        private Panel listPanel;
    }
}
