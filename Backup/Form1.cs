
/*Version 1.9
 * 
 * new error handling, + checkboxes for options
 * 
 * http://github.com/returnzork/
 * 
 * http://minecraftcloud.x10.mx
 * 
 * 
*/
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
using Ionic.Zip;
using System.Net;

namespace Backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errors.Visible = false;
            errortext.Visible = false;

            if (System.IO.File.Exists("last1.txt"))
            {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader("last1.txt");
                copyfrom.Text = objReader.ReadToEnd();
                objReader.Close();
            }
            else
            {
                if (System.IO.File.Exists("last.txt"))
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader("last.txt");
                    copyfrom.Text = objReader.ReadToEnd();
                    objReader.Close();
                    Thread.Sleep(50);
                    System.IO.File.Move("last.txt", "last1.txt");
                }
            }
            if (System.IO.File.Exists("last2.txt"))
            {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader("last2.txt");
                CopyTo.Text = objReader.ReadToEnd();
                objReader.Close();
            }
            if (System.IO.File.Exists("between.txt"))
            {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader("between.txt");
                timebetween.Text = objReader.ReadToEnd();
                objReader.Close();
            }
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
            var Copy2 = CopyTo.Text;

            var timetest = timebetween.Text;


            if (timetest == "")
            {
                MessageBox.Show("Time in between backups not set. Defaulting to 20 minutes");
                this.Invoke(new MethodInvoker(delegate { timebetween.Text = "20"; }));
            }

            var times = timebetween.Text;
            Thread.Sleep(50);

            int time = Convert.ToInt32(times);

            if (SaveTime.Checked)
            {
                File.WriteAllText("Between.txt", timebetween.Text);
            }

            Thread.Sleep(500);

            if (System.IO.File.Exists("save-all.vbs"))
            {
                Details.Text = "Forving server to save-all, then backing up";
                Thread.Sleep(50);
                System.Diagnostics.Process.Start(@"save-all.vbs");
                Thread.Sleep(5000);
            }

            File.WriteAllText("last1.txt", copyfrom.Text);                     //writes the directory to save to a file (names last.txt)
            Thread.Sleep(20);
            File.WriteAllText("last2.txt", CopyTo.Text);
            Thread.Sleep(20);


            var drivepath = copyfrom.Text;

            var date1 = string.Format("{0:MM-dd-yyyy@hh-mm-ss tt}", DateTime.Now);
            System.IO.Directory.CreateDirectory(Copy2 + date1);                      //creates the directory

            Thread.Sleep(50);
            //

            this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 1; }));

            FileSystem.CopyDirectory(drivepath, Copy2 + date1 + "\\");               //copy the directory to the newly created one

            Thread.Sleep(250);


            if (Compression.Checked)
            {
                using (ZipFile zip = new ZipFile())
                {
                    string[] files = Directory.GetFiles(@Copy2 + date1);
                    zip.AddFiles(files, "\\");

                    zip.ParallelDeflateThreshold = -1;               //fixes freezing when zipping the larger 'region' folder


                    zip.AddDirectory(@Copy2 + date1 + "\\Players\\", "Players\\");
                    zip.AddDirectory(@Copy2 + date1 + "\\data\\", "data\\");
                    zip.AddDirectory(@Copy2 + date1 + "\\region\\", "region\\");
                    zip.Save(Copy2 + date1 + ".zip");
                    if (delete.Checked)
                    {
                        Thread.Sleep(2000);
                        if (System.IO.File.Exists(@Copy2 + date1 + ".zip"))
                        {
                            System.IO.Directory.Delete(@Copy2 + date1 + "\\", true);
                        }
                        else
                        {
                            if (errors.Visible != true)
                            {
                                this.Invoke(new MethodInvoker(delegate { errors.Visible = true; }));
                            }
                            Thread.Sleep(15);
                            this.Invoke(new MethodInvoker(delegate { errors.Text = errors.Text + date1 + " zip file not found, non-compressed folder remaining." + "          "; }));
                        }
                    }
                }
            }


            int loop = 6;

            while (loop >= 5)
            {
                int testa = time;
                int progress = 0;


                while (testa > 0)                     //loop code for timer
                {


                    this.Invoke(new MethodInvoker(delegate { Details.Text = testa + " minutes remaining"; }));
                    testa = testa - 1;                  //subtracts 1 from the backup time
                    this.Invoke(new MethodInvoker(delegate { progressBar1.Value = progress + 5; }));  //adds a value of 5 to the progress bar

                    progress = progress + 5;            //updates variable so it adds 5 MORE every loop cycle


                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));  //sets the progress bar to 0 when canceled
                        break;                          //this stops the backup timer when the cancel button is hit
                    }
                    Thread.Sleep(10000);                            //waits 10 seconds, then checks if the cancel button has been pressed.
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;                         //checks every 10 seconds for a cancelation

                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;
                    }
                    Thread.Sleep(10000);
                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                        break;
                    }
                }


                if (backgroundWorker1.CancellationPending)
                {
                    this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                    break;
                }


                var date = string.Format("{0:MM-dd-yyyy@hh-mm-ss tt}", DateTime.Now);    //sets variable 'date' to Month(xx):Day:4 digit year(20xx)@hours-minutes-seconds AM/PM
                System.IO.Directory.CreateDirectory(Copy2 + date + "\\");                //creates directory

                if (System.IO.File.Exists("save-all.vbs"))                               //checks if the 'save-all.vbs' file is found, and if it is, it calls it and waits 5000 ms (5 seconds)
                {
                    System.Diagnostics.Process.Start(@"save-all.vbs");
                    Thread.Sleep(5000);
                }
                Thread.Sleep(50);
                FileSystem.CopyDirectory(drivepath, @Copy2 + date + "\\");               //copy the world directory contents to the backup dir
                Thread.Sleep(50);


                if (Compression.Checked)
                {

                    using (ZipFile zip = new ZipFile())
                    {
                        string[] files = Directory.GetFiles(@Copy2 + date);
                        zip.AddFiles(files, "\\");


                        zip.ParallelDeflateThreshold = -1;


                        zip.AddDirectory(@Copy2 + date + "\\Players", "\\Players");
                        zip.AddDirectory(@Copy2 + date + "\\data", "\\data");
                        zip.AddDirectory(@Copy2 + date + "\\region", "\\region");
                        zip.Save(Copy2 + date + ".zip");
                        if (delete.Checked)
                        {
                            Thread.Sleep(2000);
                            if (System.IO.File.Exists(@Copy2 + date + ".zip"))
                            {
                                System.IO.Directory.Delete(@Copy2 + date + "\\", true);
                            }
                            else
                            {
                                if (errortext.Visible != true)
                                {
                                    this.Invoke(new MethodInvoker(delegate { errortext.Visible = true; }));
                                }
                                if (errors.Visible != true)
                                {
                                    this.Invoke(new MethodInvoker(delegate { errors.Visible = true; }));
                                }
                                Thread.Sleep(15);
                                this.Invoke(new MethodInvoker(delegate { errors.Text = errors.Text + date1 + " zip file not found, non-compressed folder remaining." + "          "; }));
                            }
                        }
                    }

                }

                backgroundWorker1.CancelAsync();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();                                     //makes the break statement work, by sending the backgroundWorker thread a cancelation request
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Originaly created by Returnzork, http://minecraftcloud.x10.mx");
            MessageBox.Show("Written in C# (C-Sharp)");
            MessageBox.Show("Source code is available at: http://github.com/returnzork/C-Sharp-minecraft-server-backup");
            MessageBox.Show("Compression uses IonicZip");
            MessageBox.Show("IonicZip available at: http://dotnetzip.codeplex.com");
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Coming soon!");

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
        }

        private void Compression_CheckedChanged(object sender, EventArgs e)
        {

            if (Compression.Checked == true)
            {
                delete.Visible = true;
            }
            else
            {
                delete.Visible = false;
            }
        }

        private void copyfrom_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void SaveTime_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}