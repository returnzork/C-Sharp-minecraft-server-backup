using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            textBox1.Text = "Forcing server to save-all, then backing up";
            Thread.Sleep(50);
            System.Diagnostics.Process.Start(@"save-all.vbs");
            Thread.Sleep(5000);
            var drivepath = textBox2.Text;

            var date1 = string.Format("{0:MM-dd-yyyy@hh-mm tt}", DateTime.Now);
            System.IO.Directory.CreateDirectory(date1);

            FileSystem.CopyDirectory(drivepath, date1 + "\\");

            

            int loop = 6;
            
            while (loop >= 5)
            {

                


                string test;
                test = "20";
                int testa = Convert.ToInt32(test);
                int progress = 0;


                while (testa > 0)
                {
                    textBox1.Text = testa + " minutes remaining";
                    testa = testa - 1;
                    progressBar1.Value = progress + 5;
                    progress = progress + 5;
                    if (backgroundWorker1.CancellationPending){
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        break;
                    }
                    Thread.Sleep(10000);
                    

                }
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                var date = string.Format("{0:MM-dd-yyyy@hh-mm tt}", DateTime.Now);
                System.IO.Directory.CreateDirectory(date);
                System.Diagnostics.Process.Start(@"save-all.vbs");
                Thread.Sleep(500);

                FileSystem.CopyDirectory(drivepath, date + "\\");
            }

            backgroundWorker1.CancelAsync();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();

        }

       
    }
}