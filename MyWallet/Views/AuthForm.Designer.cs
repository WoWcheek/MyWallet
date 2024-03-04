namespace MyWallet.Views
{
    partial class AuthForm
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
            nameLbl = new Label();
            usernameTB = new TextBox();
            passwordTB = new TextBox();
            passwordLbl = new Label();
            registerBtn = new Button();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            nameLbl.ForeColor = Color.Navy;
            nameLbl.Location = new Point(12, 29);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(121, 31);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.BackColor = Color.AliceBlue;
            usernameTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            usernameTB.Location = new Point(12, 63);
            usernameTB.Name = "usernameTB";
            usernameTB.PlaceholderText = "Enter username...";
            usernameTB.Size = new Size(291, 34);
            usernameTB.TabIndex = 1;
            // 
            // passwordTB
            // 
            passwordTB.BackColor = Color.AliceBlue;
            passwordTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTB.Location = new Point(12, 151);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.PlaceholderText = "Enter password...";
            passwordTB.Size = new Size(291, 34);
            passwordTB.TabIndex = 3;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            passwordLbl.ForeColor = Color.Navy;
            passwordLbl.Location = new Point(12, 117);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(114, 31);
            passwordLbl.TabIndex = 2;
            passwordLbl.Text = "Password";
            // 
            // registerBtn
            // 
            registerBtn.BackColor = Color.AliceBlue;
            registerBtn.FlatAppearance.BorderSize = 0;
            registerBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            registerBtn.ForeColor = Color.Navy;
            registerBtn.Location = new Point(12, 223);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(142, 49);
            registerBtn.TabIndex = 4;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = false;
            registerBtn.Click += registerBtn_Click;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.AliceBlue;
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginBtn.ForeColor = Color.Navy;
            loginBtn.Location = new Point(161, 223);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(142, 49);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(315, 292);
            Controls.Add(loginBtn);
            Controls.Add(registerBtn);
            Controls.Add(passwordTB);
            Controls.Add(passwordLbl);
            Controls.Add(usernameTB);
            Controls.Add(nameLbl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AuthForm";
            Text = "AuthForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLbl;
        private TextBox usernameTB;
        private TextBox passwordTB;
        private Label passwordLbl;
        private Button registerBtn;
        private Button loginBtn;
    }
}