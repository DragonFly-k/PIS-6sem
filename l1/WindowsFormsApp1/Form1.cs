using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var x = textBox1.Text;
            var y = textBox2.Text;

            var formContent = new FormUrlEncodedContent(new[]{new KeyValuePair<string, string>("x", x),new KeyValuePair<string, string>("y", y)});

            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:49743/sum", formContent);
            textBox3.Text = await res.Content.ReadAsStringAsync();
        }

    }
}
