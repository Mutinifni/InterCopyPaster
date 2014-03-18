using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            Programs.Connect(Path.GetFileName(fileName));
            Programs.ConnectFile(fileName);
            MessageBox.Show("File Sent"); 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Reciever.RecieveString();
            Reciever.Recieve(Reciever.Path + @"\" + Reciever.FileName); 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("File recieved..."); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string initText = Clipboard.GetText();
            Programs.Connect(initText); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reciever.RecieveString();
            Clipboard.Clear();
            Clipboard.SetText(Reciever.FileName);
            MessageBox.Show("Text Copied"); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = String.Empty;
            text = textBox2.Text;
            Programs.Connect(text); 
        }
    }
}
