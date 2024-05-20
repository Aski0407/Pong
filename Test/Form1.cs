using PongClient;
using System.ComponentModel.Design.Serialization;

namespace Test
{
    public partial class Form1 : Form
    {
        private MyHttpClient client;
        public Form1()
        {
            InitializeComponent();
            this.client = new MyHttpClient("http://localhost:8080/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.client.Register("abc", "12345678");
        }
    }
}
