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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SimpleTcpServer sv;

        private void Form1_Load(object sender, EventArgs e)
        {
            sv = new SimpleTcpServer();
            sv.Delimiter = 0x13; //enter
            sv.StringEncoder = Encoding.UTF8;
            sv.DataReceived += Sv_DataReceived;
        }

        private void Sv_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtSTT.Invoke((MethodInvoker)delegate ()
           {
               txtSTT.Text += e.MessageString;
               e.ReplyLine(string.Format("You said: {0}", e.MessageString));

           });
        }

        private void button1_Click(object sender, EventArgs e)

        {
            txtSTT.Text += "Server Starting";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(textBoxHost.Text);
            sv.Start(ip, Convert.ToInt32(textBoxPort.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sv.IsStarted)
                sv.Stop();
        }
    }
}
