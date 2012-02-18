/*Version 1.5.1
 * 
 * fixed compression to the on launch copy
 * 
 * github.com/returnzork
 * 
 * http://minecraftcloud.x10.mx/
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

            if (System.IO.File.Exists("last.txt"))
            {
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader("last.txt");
                textBox2.Text = objReader.ReadToEnd();
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

            Thread.Sleep(50);

            if (System.IO.File.Exists("save-all.vbs"))
            {
                textBox1.Text = "Forving server to save-all, then backing up";
                Thread.Sleep(50);
                System.Diagnostics.Process.Start(@"save-all.vbs");
                Thread.Sleep(5000);
            }

            File.WriteAllText("last.txt", textBox2.Text);                     //writes the directory to save to a file (names last.txt)

            var drivepath = textBox2.Text;

            var date1 = string.Format("{0:MM-dd-yyyy@hh-mm-ss tt}", DateTime.Now);
            System.IO.Directory.CreateDirectory(date1);                      //creates the directory

            Thread.Sleep(50);

            this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 1; }));

            FileSystem.CopyDirectory(drivepath, date1 + "\\");               //copy the directory to the newly created one

            Thread.Sleep(500);



            using (ZipFile zip = new ZipFile())
            {
                string[] files = Directory.GetFiles(@date1);
                zip.AddFiles(files);
               


                zip.AddDirectory(date1 + "\\Players");                     
                zip.AddDirectory(@date1 + "\\data");
                zip.AddDirectory(@date1 + "\\region");

                zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                zip.Save(date1 + ".zip");
            }



            int loop = 6;
            
            while (loop >= 5)
            {
                

                int testa = 20;
                int progress = 0;


                while (testa > 0)                     //loop code for timer
                {


                    this.Invoke(new MethodInvoker(delegate { textBox1.Text = testa + " minutes remaining"; }));
                    testa = testa - 1;                  //subtracts 1 from the backup time
                    this.Invoke(new MethodInvoker(delegate { progressBar1.Value = progress + 5; }));  //adds a value of 5 to the progress bar

                    progress = progress + 5;            //updates variable so it adds 5 MORE every loop cycle


                    if (backgroundWorker1.CancellationPending)
                    {
                        this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));  //sets the progress bar to 0 when canceled
                        break;                          //this stops the backup timer when the cancel button is hit
                    }
                    Thread.Sleep(10000);
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
                }
                if (backgroundWorker1.CancellationPending)
                {
                    this.Invoke(new MethodInvoker(delegate { progressBar1.Value = 0; }));
                    break;
                }
                
                var date = string.Format("{0:MM-dd-yyyy@hh-mm-ss tt}", DateTime.Now);    //sets variable 'date' to Month(xx):Day:4 digit year(20xx)@hours-minutes-seconds AM/PM
                System.IO.Directory.CreateDirectory(date);                               //creates directory
                
                 if (System.IO.File.Exists("save-all.vbs"))                              //checks if the 'save-all.vbs' file is found, and if it is, it calls it and waits 5000 ms (5 seconds)
            {
                System.Diagnostics.Process.Start(@"save-all.vbs");
                Thread.Sleep(5000);
            }
                Thread.Sleep(50);
                FileSystem.CopyDirectory(drivepath, date + "\\");                  //copy the world directory contents to the backup dir
                Thread.Sleep(50);



                using (ZipFile zip = new ZipFile())
                {
                    string[] files = Directory.GetFiles(@date1);
                    zip.AddFiles(files);



                    zip.AddDirectory(@date + "\\Players");
                    zip.AddDirectory(@date + "\\data");
                    zip.AddDirectory(@date + "\\region");

                    zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                    zip.Save(date + ".zip");
                }



            }

            backgroundWorker1.CancelAsync();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();                                     //makes the break statement work, by sending the backgroundWorker thread a cancelation request
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
      
    }
}