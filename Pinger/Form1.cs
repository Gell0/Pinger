using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIP.Text))
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("127.0.0.1", 1000);
                String Status = reply.Status.ToString();
                String Adress = reply.Address.ToString();
                String Trip = reply.RoundtripTime.ToString();
                String TTL = reply.Options.Ttl.ToString();
                String DF = reply.Options.DontFragment.ToString();
                String Buffer = reply.Buffer.Length.ToString();
                string newLine = Environment.NewLine;
                textBox1.Text = ("Pinging this machine..." + newLine + "Status: " + Status + newLine + "Pinged to: " + Adress + newLine + "Delay: " + Trip + " ms." + newLine + "TTL: " + TTL + newLine + "Fragmentation: " + DF + newLine + "Buffer Size: " + Buffer + " Bytes" + newLine + "Done . . .");
            }
            else
            {
                try
                {
                    Ping ping1 = new Ping();
                    PingReply reply1 = ping1.Send(txtIP.Text, 1000);
                    string Status = reply1.Status.ToString();
                    String Adress = reply1.Address.ToString();
                    String Trip = reply1.RoundtripTime.ToString();
                    String TTL = reply1.Options.Ttl.ToString();
                    String DF = reply1.Options.DontFragment.ToString();
                    String Buffer = reply1.Buffer.Length.ToString();
                    string newLine = Environment.NewLine;
                    textBox1.Text = ("IPStatus: " + Status + newLine + "Adress: " + Adress + newLine + "RoundTripTime: " + Trip + newLine + "TTL: " + TTL + newLine + "Fragmentation: " + DF + newLine + "Buffer Size: " + Buffer + " Bytes" + newLine + "Done . . .");
                }
                catch (PingException)
                {
                    textBox1.Text = "Adress is unreachable. . .";
                }
               

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
