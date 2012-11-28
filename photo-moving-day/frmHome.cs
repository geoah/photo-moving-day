using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace photo_moving_day
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            txtPathSource.Text = Properties.Settings.Default.pathSource;
            txtPathDestination.Text = Properties.Settings.Default.pathDestination;
            chkMoveFiles.Checked = Properties.Settings.Default.moveFiles;
            chkGetCreationDateOnExifFail.Checked = Properties.Settings.Default.getCreationDateOnExifFail;
            chkCategorizeAll.Checked = Properties.Settings.Default.categorizeAllFiles;
            chkPathRecursive.Checked = Properties.Settings.Default.pathRecursive;
            chkOverwrite.Checked = Properties.Settings.Default.overwriteFiles;
        }

        private void begin()
        {
            txtPathDestination.Enabled = false;
            txtPathSource.Enabled = false;
            chkCategorizeAll.Enabled = false;
            chkGetCreationDateOnExifFail.Enabled = false;
            chkMoveFiles.Enabled = false;
            chkPathRecursive.Enabled = false;
            chkOverwrite.Enabled = false;
            btnStart.Text = "Stop";
            progressBar.Visible = true;
            bgWorker.RunWorkerAsync();
        }

        private void stop()
        {
            bgWorker.CancelAsync();
        }

        private void stopped()
        {
            txtPathDestination.Enabled = true;
            txtPathSource.Enabled = true;
            chkCategorizeAll.Enabled = true;
            chkGetCreationDateOnExifFail.Enabled = true;
            chkMoveFiles.Enabled = true;
            chkOverwrite.Enabled = true;
            chkPathRecursive.Enabled = true;
            btnStart.Text = "Start";
            progressBar.Visible = false;
            progressBar.Value = 0;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            String pathSource = txtPathSource.Text;
            String pathDestination = txtPathDestination.Text;
            Boolean filesMove = chkMoveFiles.Checked;
            Boolean filesGetCreated = chkGetCreationDateOnExifFail.Checked;
            Boolean filesCategorizeAll = chkCategorizeAll.Checked;
            Boolean pathRecursive = chkPathRecursive.Checked;

            if (pathSource == pathDestination)
            {
                MessageBox.Show("Source and destination folders are the same.");
                return;
            }
            if (Directory.Exists(pathSource)==false)
            {
                MessageBox.Show("Source folder does not exist.");
                return;
            }
            if (Directory.Exists(pathSource) == false)
            {
                MessageBox.Show("Destination folder does not exist.");
                return;
            }

            StreamWriter logFile = File.AppendText("log-"+DateTime.Now.ToString("yyyyMMdd-HHmmss")+".txt");

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            String[] fileEntries;
            if (pathRecursive == true)
            {
                fileEntries = Directory.GetFiles(pathSource, "*.*", SearchOption.AllDirectories);
            }
            else
            {
                fileEntries = Directory.GetFiles(pathSource, "*.*");
            }
            DialogResult dialogResult = MessageBox.Show("This will " + (chkMoveFiles.Checked ? "move" : "copy") + " " + (Properties.Settings.Default.categorizeAllFiles ? "all files" : "all images") + ".\r\n\r\nSource: " + Properties.Settings.Default.pathSource + "\r\nDestination: " + Properties.Settings.Default.pathDestination + "\r\n\r\nThere are " + fileEntries.Length.ToString() + " files present, this might take a while. Start?", "Photo Moving Day", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                logFile.WriteLine("Started on " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ".");
                logFile.WriteLine("Found a total of " + fileEntries.Length.ToString() + " files.");
                logFile.Flush();
                Int32 movedCount = 0;
                Int32 totalCount = 0;
                foreach (String filePath in fileEntries)
                {
                    if (worker.CancellationPending == true)
                    {
                        break;
                    }
                    try
                    {
                        DateTime datetimeTaken = (File.GetLastWriteTime(filePath) < File.GetCreationTime(filePath)) ? File.GetLastWriteTime(filePath) : File.GetCreationTime(filePath);
                        Image image = null;
                        try
                        {
                            image = new Bitmap(filePath);
                        }
                        catch (Exception excImage)
                        {
                            if (filesCategorizeAll == false)
                            {
                                throw excImage;
                            }
                        }
                        if (image != null)
                        {
                            try
                            {
                                datetimeTaken = GetDateTaken(image);
                            }
                            catch (Exception excDt)
                            {
                                if (filesGetCreated == false)
                                {
                                    throw excDt;
                                }
                            }
                            image.Dispose();
                        }
                        String pathDestinationFinal = Path.Combine(pathDestination, datetimeTaken.Year + "-" + datetimeTaken.Month.ToString().PadLeft(2, '0') + "-" + datetimeTaken.Day.ToString().PadLeft(2, '0'));
                        if (!Directory.Exists(pathDestinationFinal))
                        {
                            Directory.CreateDirectory(pathDestinationFinal);
                        }
                        String fileName = Path.GetFileName(filePath);
                        String pathDestinationFull = Path.Combine(pathDestinationFinal, fileName);
                        Boolean fileExistsInDestination = File.Exists(pathDestinationFull);
                        if (fileExistsInDestination == false || chkOverwrite.Checked == true)
                        {
                            if (fileExistsInDestination == true)
                            {
                                File.Delete(pathDestinationFull);
                            }
                            if (filesMove == true)
                            {
                                File.Move(filePath, pathDestinationFull);
                                logFile.WriteLine("Moved \"" + filePath + "\" to \"" + pathDestinationFull + "\"");
                            }
                            else
                            {
                                File.Copy(filePath, pathDestinationFull);
                                logFile.WriteLine("Copied \"" + filePath + "\" to \"" + pathDestinationFull + "\"");
                            }
                            movedCount += 1;
                        }
                        else
                        {
                            logFile.WriteLine("Warning: File \"" + filePath + "\" already exists as \"" + pathDestinationFull + "\"");
                        }
                    }
                    catch (Exception exc)
                    {
                        String error = "Error:  \"" + Path.GetFileName(filePath) + "\": " + exc.Message.ToString();
                        logFile.WriteLine(error);
                        logFile.Flush();
                        Debug.Print(error);
                    }
                    totalCount += 1;
                    double perc = (totalCount * 100) / fileEntries.Length;
                    bgWorker.ReportProgress((int)Math.Floor(perc));
                }
                String done = "Moved around " + movedCount.ToString() + " photos.";
                logFile.WriteLine(done);
                logFile.WriteLine("");
                MessageBox.Show(done);
                logFile.Close();
            }
            bgWorker.ReportProgress(100);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private DateTime GetDateTaken(Image targetImg)
        {
            //Property Item 36867 corresponds to the Date Taken
            PropertyItem propItem = targetImg.GetPropertyItem(36867);
            DateTime dtaken;

            //Convert date taken metadata to a DateTime object
            string sdate = Encoding.UTF8.GetString(propItem.Value).Trim();
            string secondhalf = sdate.Substring(sdate.IndexOf(" "), (sdate.Length - sdate.IndexOf(" ")));
            string firsthalf = sdate.Substring(0, 10);
            firsthalf = firsthalf.Replace(":", "-");
            sdate = firsthalf + secondhalf;
            dtaken = DateTime.Parse(sdate);
            return dtaken;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Application.Exit();
            stopped();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                txtPathSource.Text = folderBrowse.SelectedPath;
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {

            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                txtPathDestination.Text = folderBrowse.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.pathSource = txtPathSource.Text;
            Properties.Settings.Default.pathDestination = txtPathDestination.Text;
            Properties.Settings.Default.moveFiles = chkMoveFiles.Checked;
            Properties.Settings.Default.getCreationDateOnExifFail = chkGetCreationDateOnExifFail.Checked;
            Properties.Settings.Default.categorizeAllFiles = chkCategorizeAll.Checked;
            Properties.Settings.Default.pathRecursive = chkPathRecursive.Checked;
            Properties.Settings.Default.overwriteFiles = chkOverwrite.Checked;
            Properties.Settings.Default.Save();

            if (btnStart.Text == "Start")
            {
                begin();
            }
            else
            {
                stop();
            }
        }
    }
}
