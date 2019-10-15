using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectoryToHtml.Utils;
using DirectoryToHtml.Config;

namespace DirectoryToHtml
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Exception Handler
        /// </summary>
        private ExceptionHandler ExHandler = new ExceptionHandler("Main");

        /// <summary>
        /// Configuration
        /// </summary>
        private Configuration conf = new Configuration();

        /// <summary>
        /// Background Worker
        /// </summary>
        private BackgroundWorker bgWorker = new BackgroundWorker();

        /// <summary>
        /// OnLoad Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_OnLoad(object sender, EventArgs e)
        {
            // Configure Background Worker
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = false;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

            // Get default configuration values
            ReloadConfiguration();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReloadConfiguration()
        {
            // Get Defualt conf values
            conf = conf.Get();

            // Set values to GUI
            txt_FolderSelected.Text = conf.selectedFolder;
            txt_SaveLocation.Text = conf.saveLocation;
        }

        /// <summary>
        /// Get Folder to Scan Location
        /// </summary>
        /// <param name="DefaultPath">Default Path</param>
        /// <returns></returns>
        private static string GetFolderSelected(string DefaultPath)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string fRes = "C:\\";
            fbd.SelectedPath = DefaultPath;


            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                fRes = fbd.SelectedPath;
            }
            else
            {
                if (result == DialogResult.OK)
                {
                    throw new Exception("An error occurred\nThe folder selected is invalid!");
                }
                // else
                // Nothing to do, the user has cancelled the operation
            }

            return fRes;
        }

        /// <summary>
        /// Get Save File Location
        /// </summary>
        /// <param name="defaultFileName">Default File Name</param>
        /// <param name="defaultPath">Default Path</param>
        /// <returns></returns>
        private static string GetSaveFileSelected(string defaultFileName, string defaultPath)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string fRes = "C:\\";
            sfd.InitialDirectory = defaultPath;
            sfd.FileName = defaultFileName;
            sfd.Filter = "HTML File (.html)|*.html|CSV File (.csv)|*.csv";
            sfd.Title = "Save a HTML / CSV File";


            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                fRes = sfd.FileName;
            }
            else
            {
                if (result != DialogResult.Cancel)
                {
                    throw new Exception("An error occurred\nThe file selected is invalid!");
                }
                // else
                // Nothing to do, the user has cancelled the operation
            }

            return fRes;
        }

        /// <summary>
        /// Folder to Scan on Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void folderToScan_OnClick(object sender, EventArgs e)
        {
            try
            {
                txt_FolderSelected.Text = GetFolderSelected(txt_FolderSelected.Text);
            }
            catch (Exception ex)
            {
                ExHandler.Log(ex);
            }
        }

        /// <summary>
        /// Save Location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveLocation_Click(object sender, EventArgs e)
        {
            try
            {
                txt_SaveLocation.Text = GetSaveFileSelected(txt_FolderSelected.Text.Substring(txt_FolderSelected.Text.LastIndexOf('\\') + 1),
                                                                txt_SaveLocation.Text);
            }
            catch (Exception ex)
            {
                ExHandler.Log(ex);
            }
        }

        /// <summary>
        /// On Form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conf.Save();
        }

        /// <summary>
        /// Folder Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_FolderSelected_TextChanged(object sender, EventArgs e)
        {
            conf.selectedFolder = txt_FolderSelected.Text;
        }

        /// <summary>
        /// Save Location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_SaveLocation_TextChanged(object sender, EventArgs e)
        {
            conf.saveLocation = txt_SaveLocation.Text;
        }

        /// <summary>
        /// Scan Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            btn_Scan.Enabled = false;
            bgWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Background Worker
        /// Do Work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Scan Folder
            ScanFolder sf = new ScanFolder(conf.selectedFolder, "*", conf);
            sf.NewScanFolderUpdate += OnNewScanFolderUpdate;
            sf.Scan(((BackgroundWorker)sender).CancellationPending);

            // Save to CSV
            if (conf.saveFormat_CSV)
            {
                Save2CSV s2csv = new Save2CSV(sf.Files, conf, txt_SaveLocation.Text);
                s2csv.Save();
                s2csv.Open();
            }

            // Save to HTML
            if (conf.saveFormat_HTML)
            {
                Save2HTML s2HTML = new Save2HTML(sf.Files, conf, txt_SaveLocation.Text);
                s2HTML.Save();
                s2HTML.Open();
            }
        }

        /// <summary>
        /// New file found!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNewScanFolderUpdate(object sender, ScanFolderUpdateEventArgs e)
        {
            // Total Files Number
            if (lbl_FilesNumber.InvokeRequired)
            {
                lbl_FilesNumber.BeginInvoke((MethodInvoker)delegate () 
                {
                    lbl_FilesNumber.Text = e.CurrentFileID + " / " + e.TotalFiles; ;
                });
            }
            else
            {
                lbl_FilesNumber.Text = e.CurrentFileID + " / " + e.TotalFiles; ;
            }

            // Total Folders Number
            if (lbl_FolderNumber.InvokeRequired)
            {
                lbl_FolderNumber.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbl_FolderNumber.Text = e.CurrentFolderID + " / " + e.TotalFolders;
                });
            }
            else
            {
                lbl_FolderNumber.Text = e.CurrentFolderID + " / " + e.TotalFolders;
            }

            // Current File Name
            if (lbl_CurrentFileName.InvokeRequired)
            {
                lbl_CurrentFileName.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbl_CurrentFileName.Text = e.CurrentFileName;
                });
            }
            else
            {
                lbl_CurrentFileName.Text = e.CurrentFileName;
            }

            // Estimated Time
            if (lbl_EstimatedTime.InvokeRequired)
            {
                lbl_EstimatedTime.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbl_EstimatedTime.Text = e.EstimatedTime.ToString(@"hh\:mm\:ss");
                });
            }
            else
            {
                lbl_EstimatedTime.Text = e.EstimatedTime.ToString(@"hh\:mm\:ss");
            }
        }


        /// <summary>
        /// Background Worker
        /// Run Worker Completed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #warning "To do"
            btn_Scan.Enabled = true;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationForm confForm = new ConfigurationForm(conf);

            confForm.ShowDialog();
        }
    }
}
