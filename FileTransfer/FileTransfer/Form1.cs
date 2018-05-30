using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading.Tasks;
using FileSerialization;

namespace FileTransfer
{
    public partial class Form1 : Form
    {
        private bool isSetFile = false;
        FileSender fileSender;
        Client client;
        String path;

        public Form1()
        {
            InitializeComponent();
            client = new Client();
            client.connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
        
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
                label2.Text = path;
                isSetFile = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isSetFile)
            {
                using (FileStream fileStream = File.OpenRead(path))
                {
                    String filename = Path.GetFileName(path);
                    byte[] data = File.ReadAllBytes(path);
                    fileSender = new FileSender(filename, data);
                }
                client.sendFile(fileSender);
                labelSend.Text = "Wyslano";
            }
        }
    }
}

