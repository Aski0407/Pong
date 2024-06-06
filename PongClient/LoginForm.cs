namespace PongClient
{
    public partial class LoginForm : Form
    {
        private bool isLogin = true; //changes to false if the user presses on register
        private string password;
        private string username;
        private MyHttpClient client;
        public LoginForm()
        {
            InitializeComponent();
            RepeatPassword.Hide(); //defaults login
            RepeatPasswordLabel.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //describes what happens when the user presses the login button. if its set to login, sends the username and password to be checked. if its set to register
            if (!this.isLogin)
            {
                LoginButton.Text = "Register";
                dontHaveAcc.Text = "Already have an account?";
                

            }
            if (Username.Text == null || Password.Text == null)
            {
                MessageBox.Show("username or password cannot be blank");
            }
            else
            {
                this.username = Username.Text;
                this.password = Password.Text;
                client.Login(this.username, this.password);
            }

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (this.isLogin)
            {
                this.isLogin = false;
                RepeatPassword.Show();
                RepeatPasswordLabel.Show();
                RegisterButton.Text = "Login";
                dontHaveAcc.Text = "Don't have an account?";
            }
            this.isLogin = true;


        }

        private void LoginUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space); //makes sure spaces aren't registered
        }
        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }
        private void loginUsername_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }

        private void repeatPasswordText_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }

        private void FieldsValidation() //checks if the login button should be enabled based on password parameters
        {
            LoginButton.Enabled = !(RepeatPassword.Visible && RepeatPassword.Text.Length < 8) && Username.Text.Length > 0 && Password.Text.Length > 0;
        }
    }
}
