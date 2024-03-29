﻿using System.Diagnostics;

namespace SeiFor
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void linkLabel_author_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://hk314.top/") { UseShellExecute = true });
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form f = Application.OpenForms["main"];  //查找是否打开过main窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                main fa = new();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }

        private void richTextBox_description_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.LinkText)) // For error CS8604, Possible null reference argument for parameter 'fileName' in 'ProcessStartInfo.ProcessStartInfo(string fileName)'
            {
                Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
            }
        }
    }
}