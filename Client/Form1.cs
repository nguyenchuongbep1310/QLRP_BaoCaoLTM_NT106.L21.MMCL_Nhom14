using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient cl;

        private void Form1_Load(object sender, EventArgs e)
        {
            cl = new SimpleTcpClient();
            cl.StringEncoder = Encoding.UTF8;
            cl.DataReceived += Cl_DataReceived;
        }

        private void Cl_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtSTT.Invoke((MethodInvoker)delegate ()
            {
                txtSTT.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));

            });
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cl.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }
    }
}
