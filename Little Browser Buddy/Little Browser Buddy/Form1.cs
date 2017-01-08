using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Little_Browser_Buddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init() {
            webBrowser1.ScriptErrorsSuppressed = true;
            string[] history = new string[26];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            Back.Enabled = false;
            Forward.Enabled = false;
            label1.Text = "Loading";
            string address = textBox1.Text;
            address = address.Replace("https://", " ");
            address = address.Replace("http://", " ");
            address = address.Trim();
            webBrowser1.Navigate("http://" + address);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label1.Text = "Success";
            button1.Enabled = true;
            textBox1.Enabled = true;
            Back.Enabled = true;
            Forward.Enabled = true;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }

        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            Back.Enabled = webBrowser1.CanGoBack;
        }
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            Back.Enabled = webBrowser1.CanGoForward;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
    }

}
