using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMajesticNetwork___Learn
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.textBox1.KeyPress += new
            System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            String getreq = Get("http://192.168.68.100:8081/chat?custom=True&personality=You%20are%20incredibly%20smart%20in%20every%20subject.%20There%20is%20nothing%20you%20dont%20know.%20You%20are%20smart%20in%20math,%20science,%20english,%20english%20literature,%20biology,%20literally%20everything.&chat=" + textBox1.Text);

            richTextBox1.Text = getreq;
            textBox1.Text = string.Empty;

        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                String getreq = Get("http://192.168.68.100:8081/chat?custom=True&personality=You%20are%20incredibly%20smart%20in%20every%20subject.%20There%20is%20nothing%20you%20dont%20know.%20You%20are%20smart%20in%20math,%20science,%20english,%20english%20literature,%20biology,%20literally%20everything.&chat=" + textBox1.Text);

                richTextBox1.Text = getreq;
                textBox1.Text = string.Empty;
            }
        }
        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
