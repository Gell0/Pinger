using MetroSet_UI.Forms;
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
    public partial class Form1 : MetroSetForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null; // Clear info-textbox.

            if (String.IsNullOrEmpty(txtIP.Text))//Check if txtIP is empty and ping itself.
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("127.0.0.1", 1000); //Basically - ping yourself.
                String Status = reply.Status.ToString(); // Get check result for reaching adress.
                String Adress = reply.Address.ToString(); // Get pinged IP.
                String Trip = reply.RoundtripTime.ToString(); // Get dealy in ms.
                String TTL = reply.Options.Ttl.ToString(); // Get TTL.
                String DF = reply.Options.DontFragment.ToString(); //Check if package fragmented.
                String Buffer = reply.Buffer.Length.ToString();// Check buffer length.
                string newLine = Environment.NewLine; // Well, that's really bad, but i'll fix this someday later... maybe... makes a new line in infobox.
                textBox1.Text = ("Pinging this machine..." + newLine + "Status: " + Status + newLine + "Pinged to: " + Adress + newLine + "Delay: " + Trip + " ms." + newLine + "TTL: " + TTL + newLine + "Fragmentation: " + DF + newLine + "Buffer Size: " + Buffer + " Bytes" + newLine + "Done . . .");
            }
            else // Else ping IP from txtIP textbox.
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
                catch (PingException)// There's always an exception if it can't reach entered adress.
                {
                    textBox1.Text = "Adress is unreachable. . ."; 
                }
                txtIP.Text = null; //Clear txtIP

            }
        }
    }
}
