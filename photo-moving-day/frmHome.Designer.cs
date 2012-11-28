namespace photo_moving_day
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPathSource = new System.Windows.Forms.TextBox();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectDestination = new System.Windows.Forms.Button();
            this.chkMoveFiles = new System.Windows.Forms.CheckBox();
            this.chkGetCreationDateOnExifFail = new System.Windows.Forms.CheckBox();
            this.chkCategorizeAll = new System.Windows.Forms.CheckBox();
            this.chkPathRecursive = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 212);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(215, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // txtPathSource
            // 
            this.txtPathSource.Location = new System.Drawing.Point(15, 25);
            this.txtPathSource.Name = "txtPathSource";
            this.txtPathSource.Size = new System.Drawing.Size(262, 20);
            this.txtPathSource.TabIndex = 1;
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Location = new System.Drawing.Point(283, 25);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(26, 20);
            this.btnSelectSource.TabIndex = 2;
            this.btnSelectSource.Text = "...";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source path";
            // 
            // txtPathDestination
            // 
            this.txtPathDestination.Location = new System.Drawing.Point(15, 64);
            this.txtPathDestination.Name = "txtPathDestination";
            this.txtPathDestination.Size = new System.Drawing.Size(262, 20);
            this.txtPathDestination.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination path";
            // 
            // btnSelectDestination
            // 
            this.btnSelectDestination.Location = new System.Drawing.Point(283, 64);
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size(26, 20);
            this.btnSelectDestination.TabIndex = 2;
            this.btnSelectDestination.Text = "...";
            this.btnSelectDestination.UseVisualStyleBackColor = true;
            this.btnSelectDestination.Click += new System.EventHandler(this.btnSelectDestination_Click);
            // 
            // chkMoveFiles
            // 
            this.chkMoveFiles.AutoSize = true;
            this.chkMoveFiles.Location = new System.Drawing.Point(16, 92);
            this.chkMoveFiles.Name = "chkMoveFiles";
            this.chkMoveFiles.Size = new System.Drawing.Size(149, 17);
            this.chkMoveFiles.TabIndex = 5;
            this.chkMoveFiles.Text = "Move files instead of copy";
            this.chkMoveFiles.UseVisualStyleBackColor = true;
            // 
            // chkGetCreationDateOnExifFail
            // 
            this.chkGetCreationDateOnExifFail.AutoSize = true;
            this.chkGetCreationDateOnExifFail.Location = new System.Drawing.Point(16, 138);
            this.chkGetCreationDateOnExifFail.Name = "chkGetCreationDateOnExifFail";
            this.chkGetCreationDateOnExifFail.Size = new System.Drawing.Size(287, 17);
            this.chkGetCreationDateOnExifFail.TabIndex = 6;
            this.chkGetCreationDateOnExifFail.Text = "Use file creation date when Exif contains no date taken";
            this.chkGetCreationDateOnExifFail.UseVisualStyleBackColor = true;
            // 
            // chkCategorizeAll
            // 
            this.chkCategorizeAll.AutoSize = true;
            this.chkCategorizeAll.Location = new System.Drawing.Point(16, 161);
            this.chkCategorizeAll.Name = "chkCategorizeAll";
            this.chkCategorizeAll.Size = new System.Drawing.Size(212, 17);
            this.chkCategorizeAll.TabIndex = 7;
            this.chkCategorizeAll.Text = "Categorize all files, not just photographs";
            this.chkCategorizeAll.UseVisualStyleBackColor = true;
            // 
            // chkPathRecursive
            // 
            this.chkPathRecursive.AutoSize = true;
            this.chkPathRecursive.Location = new System.Drawing.Point(16, 184);
            this.chkPathRecursive.Name = "chkPathRecursive";
            this.chkPathRecursive.Size = new System.Drawing.Size(224, 17);
            this.chkPathRecursive.TabIndex = 8;
            this.chkPathRecursive.Text = "Search for files recursively in source folder";
            this.chkPathRecursive.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(237, 212);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(16, 115);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(197, 17);
            this.chkOverwrite.TabIndex = 10;
            this.chkOverwrite.Text = "Overwrite file if it exists in destination";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 245);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkPathRecursive);
            this.Controls.Add(this.chkCategorizeAll);
            this.Controls.Add(this.chkGetCreationDateOnExifFail);
            this.Controls.Add(this.chkMoveFiles);
            this.Controls.Add(this.txtPathDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectDestination);
            this.Controls.Add(this.btnSelectSource);
            this.Controls.Add(this.txtPathSource);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo Moving Day";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        protected System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowse;
        private System.Windows.Forms.TextBox txtPathSource;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.CheckBox chkMoveFiles;
        private System.Windows.Forms.CheckBox chkGetCreationDateOnExifFail;
        private System.Windows.Forms.CheckBox chkCategorizeAll;
        private System.Windows.Forms.CheckBox chkPathRecursive;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkOverwrite;
    }
}

