namespace Backup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Details = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.copyfrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CopyTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timebetween = new System.Windows.Forms.TextBox();
            this.Between = new System.Windows.Forms.Label();
            this.appUpdater1 = new Microsoft.Samples.AppUpdater.AppUpdater(this.components);
            this.Compression = new System.Windows.Forms.CheckBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveTime = new System.Windows.Forms.CheckBox();
            this.delete = new System.Windows.Forms.CheckBox();
            this.errors = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.appUpdater1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(64, 244);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(321, 39);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Details
            // 
            this.Details.Location = new System.Drawing.Point(30, 171);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(400, 20);
            this.Details.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 20);
            this.button3.TabIndex = 5;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time until next backup:";
            // 
            // copyfrom
            // 
            this.copyfrom.Location = new System.Drawing.Point(12, 55);
            this.copyfrom.Name = "copyfrom";
            this.copyfrom.Size = new System.Drawing.Size(242, 20);
            this.copyfrom.TabIndex = 7;
            this.copyfrom.TextChanged += new System.EventHandler(this.copyfrom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Copy from:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 20);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CopyTo
            // 
            this.CopyTo.Location = new System.Drawing.Point(12, 95);
            this.CopyTo.Name = "CopyTo";
            this.CopyTo.Size = new System.Drawing.Size(242, 20);
            this.CopyTo.TabIndex = 11;
            this.CopyTo.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Copy to:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // timebetween
            // 
            this.timebetween.Location = new System.Drawing.Point(281, 55);
            this.timebetween.Name = "timebetween";
            this.timebetween.Size = new System.Drawing.Size(170, 20);
            this.timebetween.TabIndex = 14;
            // 
            // Between
            // 
            this.Between.AutoSize = true;
            this.Between.Location = new System.Drawing.Point(278, 39);
            this.Between.Name = "Between";
            this.Between.Size = new System.Drawing.Size(121, 13);
            this.Between.TabIndex = 15;
            this.Between.Text = "Time between backups:";
            this.Between.Click += new System.EventHandler(this.label4_Click);
            // 
            // appUpdater1
            // 
            this.appUpdater1.AutoFileLoad = true;
            this.appUpdater1.ChangeDetectionMode = Microsoft.Samples.AppUpdater.ChangeDetectionModes.ServerManifestCheck;
            this.appUpdater1.ShowDefaultUI = true;
            this.appUpdater1.UpdateUrl = "http://192.168.11.140/version.xml";
            // 
            // Compression
            // 
            this.Compression.AutoSize = true;
            this.Compression.Location = new System.Drawing.Point(272, 81);
            this.Compression.Name = "Compression";
            this.Compression.Size = new System.Drawing.Size(113, 17);
            this.Compression.TabIndex = 16;
            this.Compression.Text = "Use compression?";
            this.Compression.UseVisualStyleBackColor = true;
            this.Compression.CheckedChanged += new System.EventHandler(this.Compression_CheckedChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.helpToolStripMenuItem.Text = "Credits";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-18, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1723, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // SaveTime
            // 
            this.SaveTime.AutoSize = true;
            this.SaveTime.Location = new System.Drawing.Point(272, 127);
            this.SaveTime.Name = "SaveTime";
            this.SaveTime.Size = new System.Drawing.Size(195, 17);
            this.SaveTime.TabIndex = 18;
            this.SaveTime.Text = "Save time between backups to file?";
            this.SaveTime.UseVisualStyleBackColor = true;
            this.SaveTime.CheckedChanged += new System.EventHandler(this.SaveTime_CheckedChanged);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Location = new System.Drawing.Point(287, 104);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(164, 17);
            this.delete.TabIndex = 19;
            this.delete.Text = "Delete uncompressed folder?";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Visible = false;
            // 
            // errors
            // 
            this.errors.HideSelection = false;
            this.errors.Location = new System.Drawing.Point(12, 326);
            this.errors.Name = "errors";
            this.errors.Size = new System.Drawing.Size(418, 20);
            this.errors.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(467, 384);
            this.Controls.Add(this.errors);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.SaveTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Compression);
            this.Controls.Add(this.Between);
            this.Controls.Add(this.timebetween);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CopyTo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.copyfrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appUpdater1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox Details;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox copyfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CopyTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timebetween;
        private System.Windows.Forms.Label Between;
        private Microsoft.Samples.AppUpdater.AppUpdater appUpdater1;
        private System.Windows.Forms.CheckBox Compression;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SaveTime;
        private System.Windows.Forms.CheckBox delete;
        private System.Windows.Forms.TextBox errors;
    }
}

