namespace PongClient
{
    partial class LoginForm
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
            dontHaveAcc = new Label();
            PassLabel = new Label();
            UserLabel = new Label();
            Password = new TextBox();
            Username = new TextBox();
            RegisterButton = new Button();
            LoginButton = new Button();
            label1 = new Label();
            RepeatPasswordLabel = new Label();
            RepeatPassword = new TextBox();
            SuspendLayout();
            // 
            // dontHaveAcc
            // 
            dontHaveAcc.AutoSize = true;
            dontHaveAcc.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dontHaveAcc.Location = new Point(69, 453);
            dontHaveAcc.Name = "dontHaveAcc";
            dontHaveAcc.Size = new Size(143, 17);
            dontHaveAcc.TabIndex = 24;
            dontHaveAcc.Text = "Don't have an account?";
            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PassLabel.Location = new Point(30, 204);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(67, 17);
            PassLabel.TabIndex = 23;
            PassLabel.Text = "Password:";
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLabel.ForeColor = Color.Black;
            UserLabel.Location = new Point(30, 137);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(70, 17);
            UserLabel.TabIndex = 22;
            UserLabel.Text = "Username:";
            // 
            // Password
            // 
            Password.BorderStyle = BorderStyle.None;
            Password.Location = new Point(30, 224);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(219, 18);
            Password.TabIndex = 21;
            // 
            // Username
            // 
            Username.BorderStyle = BorderStyle.None;
            Username.Location = new Point(30, 158);
            Username.Name = "Username";
            Username.Size = new Size(219, 18);
            Username.TabIndex = 20;
            Username.TextChanged += loginUsername_TextChanged;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.FromArgb(116, 86, 174);
            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.Location = new Point(69, 473);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(138, 35);
            RegisterButton.TabIndex = 19;
            RegisterButton.Text = "REGISTER";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(116, 86, 174);
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(69, 345);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(138, 35);
            LoginButton.TabIndex = 18;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(30, 49);
            label1.Name = "label1";
            label1.Size = new Size(164, 40);
            label1.TabIndex = 17;
            label1.Text = "Get Started";
            // 
            // RepeatPasswordLabel
            // 
            RepeatPasswordLabel.AutoSize = true;
            RepeatPasswordLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RepeatPasswordLabel.Location = new Point(30, 265);
            RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            RepeatPasswordLabel.Size = new Size(113, 17);
            RepeatPasswordLabel.TabIndex = 29;
            RepeatPasswordLabel.Text = "Repeat password:";
            // 
            // RepeatPassword
            // 
            RepeatPassword.BorderStyle = BorderStyle.None;
            RepeatPassword.Location = new Point(30, 285);
            RepeatPassword.Name = "RepeatPassword";
            RepeatPassword.Size = new Size(219, 18);
            RepeatPassword.TabIndex = 21;
            RepeatPassword.TextChanged += repeatPasswordText_TextChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 576);
            Controls.Add(RepeatPasswordLabel);
            Controls.Add(RepeatPassword);
            Controls.Add(dontHaveAcc);
            Controls.Add(PassLabel);
            Controls.Add(UserLabel);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(RegisterButton);
            Controls.Add(LoginButton);
            Controls.Add(label1);
            Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label dontHaveAcc;
        private Label PassLabel;
        private Label UserLabel;
        private TextBox Password;
        private TextBox Username;
        private Button RegisterButton;
        private Button LoginButton;
        private Label label1;
        private Label RepeatPasswordLabel;
        private TextBox RepeatPassword;
    }
}