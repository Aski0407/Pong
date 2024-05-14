namespace PongClient
{
    partial class StartScreen
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
            startButton = new Button();
            welcomeMessage = new Label();
            scoreButton = new Button();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startButton.ForeColor = SystemColors.ControlText;
            startButton.Location = new Point(51, 217);
            startButton.Name = "startButton";
            startButton.Size = new Size(178, 53);
            startButton.TabIndex = 0;
            startButton.Text = "start game";
            startButton.UseVisualStyleBackColor = true;
            // 
            // welcomeMessage
            // 
            welcomeMessage.AutoSize = true;
            welcomeMessage.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeMessage.ForeColor = Color.Black;
            welcomeMessage.Location = new Point(-6, 101);
            welcomeMessage.Name = "welcomeMessage";
            welcomeMessage.Size = new Size(277, 40);
            welcomeMessage.TabIndex = 1;
            welcomeMessage.Text = "WECOME TO PONG";
            // 
            // scoreButton
            // 
            scoreButton.ForeColor = Color.Black;
            scoreButton.Location = new Point(186, 12);
            scoreButton.Name = "scoreButton";
            scoreButton.Size = new Size(75, 23);
            scoreButton.TabIndex = 2;
            scoreButton.Text = "score";
            scoreButton.UseVisualStyleBackColor = true;
            // 
            // StartScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 515);
            Controls.Add(scoreButton);
            Controls.Add(welcomeMessage);
            Controls.Add(startButton);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Blue;
            Name = "StartScreen";
            Text = "StartScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label welcomeMessage;
        private Button scoreButton;
    }
}