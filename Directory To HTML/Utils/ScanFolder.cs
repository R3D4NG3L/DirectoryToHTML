using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace DirectoryToHtml.Utils
{
    public class ScanFolderUpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Total Folders Number
        /// </summary>
        public long TotalFolders = 0;
        /// <summary>
        /// Total Files Number
        /// </summary>
        public long TotalFiles = 0;
        /// <summary>
        /// Current File Number
        /// </summary>
        public long CurrentFileID;
        /// <summary>
        /// Current Folder Number
        /// </summary>
        public long CurrentFolderID;
        /// <summary>
        /// Current Folder Name under process
        /// </summary>
        public string CurrentFolderName;
        /// <summary>
        /// Current File Name under process;
        /// </summary>
        public string CurrentFileName;
        /// <summary>
        /// Estimated Time
        /// </summary>
        public TimeSpan EstimatedTime = new TimeSpan();
    }

    class ScanFolder
    {
        /// <summary>
        /// Files
        /// </summary>
        public List<FileInfoAdvanced> Files { get;}         // List that will hold the files and subfiles in path

        /// <summary>
        ///  Event Handler
        /// </summary>
        public event EventHandler<ScanFolderUpdateEventArgs> NewScanFolderUpdate;

        /// <summary>
        /// Directory to Scan
        /// </summary>
        private string Directory { get; }
        /// <summary>
        /// Search Pattern
        /// Usually: *
        /// </summary>
        private string SearchPattern { get; }
        /// <summary>
        /// Exception Handler
        /// </summary>
        private ExceptionHandler _exHandler = new ExceptionHandler("ScanFolder");

        /// <summary>
        /// Total Folders Number
        /// </summary>
        private long _totalFolders = 0;
        /// <summary>
        /// Total Files Number
        /// </summary>
        private long _totalFiles = 0;
        /// <summary>
        /// Current File ID
        /// </summary>
        private long _currentFileID = 0;
        /// <summary>
        /// Current Folder ID
        /// </summary>
        private long _currentFolderID = 0;

        /// <summary>
        /// Total Time Elapsed
        /// </summary>
        private Stopwatch _totalTime = new Stopwatch();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="searchPattern"></param>
        public ScanFolder(string directory, string searchPattern)
        {
            // List of Files
            Files = new List<FileInfoAdvanced>();

            // Get Values
            Directory = directory;
            SearchPattern = searchPattern;
        }

        /// <summary>
        /// Extract Informations
        /// </summary>
        public void Scan(bool cancellationToken)
        {
            DirectoryInfo dir = new DirectoryInfo(Directory);

            // Create new stopwatch.
            Stopwatch sw = new Stopwatch();

            // Reset Vars
            _currentFileID = _currentFolderID = _totalFiles = _totalFolders = 0;

            // Begin timing.
            sw.Start();

            // Start calculating time
            _totalTime.Restart();

            // Calculate Workload
            CalculateWorkload(dir, ref sw, cancellationToken);

            // Send Update Event
            SendUpdateEvent();

            // Scan all Folders and Subfolders
            _Scan(dir, ref sw, cancellationToken);

            // Stop calculating time
            _totalTime.Stop();

            // Stop Stopwatch
            sw.Stop();

            // Update Event
            SendUpdateEvent(_totalFiles, _totalFolders);
        }

        /// <summary>
        /// Send Update Event
        /// </summary>
        /// <param name="currentFileID"></param>
        /// <param name="currentFolderID"></param>
        /// <param name="CurrentFolderName"></param>
        /// <param name="CurrentFileName"></param>
        private void SendUpdateEvent(long currentFileID = 0, long currentFolderID = 0, string CurrentFolderName = "", string CurrentFileName = "")
        {
            ScanFolderUpdateEventArgs args = new ScanFolderUpdateEventArgs();

            args.TotalFolders = _totalFolders;
            args.TotalFiles = _totalFiles;
            args.CurrentFileID = currentFileID;
            args.CurrentFolderID = currentFolderID;
            args.CurrentFileName = CurrentFileName;
            args.CurrentFolderName = CurrentFolderName;

            // Calculate Estimated Time
            if (currentFileID > 0)
            {
                long ElapsedTicks = _totalTime.ElapsedTicks;
                long ElapsedTimePerFile = ElapsedTicks / currentFileID;
                long TotalTimeCalculated = ElapsedTimePerFile * _totalFiles;
                long EstimatedTimeToPass = TotalTimeCalculated - ElapsedTicks;

                args.EstimatedTime = TimeSpan.FromTicks(EstimatedTimeToPass);
            }
            else
            {
                // Impossible to calculate the estimated time
                args.EstimatedTime = new TimeSpan();
            }

            OnNewScanFolderUpdate(args);
        }

        /// <summary>
        /// Calculate Workload
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="cancellationToken"></param>
        private void CalculateWorkload(DirectoryInfo dir, ref Stopwatch sw, bool cancellationToken)
        {
            try
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (cancellationToken)
                    {
                        return;
                    }

                    // Update Counters
                    _totalFolders++;
                    _totalFiles += d.GetFiles().Length;

                    // Check if Update Event must be sent
                    if (sw.ElapsedMilliseconds >= 1000)
                    {
                        SendUpdateEvent();
                        sw.Restart();
                    }

                    // Go in Sub-Folders
                    CalculateWorkload(d, ref sw, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _exHandler.Log(ex, false);
            }
        }

        /// <summary>
        /// Get Information
        /// </summary>
        /// <param name="dir"></param>
        /// <param name=""></param>
        private void _Scan(DirectoryInfo dir, ref Stopwatch sw, bool cancellationToken)
        { 
            // --------------------------------
            // GET FILES FROM CURRENT DIRECTORY
            // --------------------------------
            try
            {
                foreach (FileInfo f in dir.GetFiles(SearchPattern))
                {
                    if (cancellationToken)
                    {
                        return;
                    }

                    string removeString = Directory;
                    string currentDir = f.DirectoryName + "\\";
                    int index = currentDir.IndexOf(removeString);
                    string cleanPath = (index < 0)
                        ? currentDir
                        : currentDir.Remove(index, removeString.Length);

                    FileInfoAdvanced fia = new FileInfoAdvanced(f, cleanPath);
                    Files.Add(fia);

                    _currentFileID++;

                    // Check if Update Event must be sent
                    if (sw.ElapsedMilliseconds >= 1000)
                    {
                        SendUpdateEvent(_currentFileID, _currentFolderID, dir.Name, fia.FileName);
                        sw.Restart();
                    }
                }
            }
            catch (Exception ex)
            {
                _exHandler.Log(ex, false);
            }

            // --------------------------------
            // SCAN SUB-DIRECTORIES
            // --------------------------------
            // process each directory
            // If I have been able to see the files in the directory I should also be able 
            // to look at its directories so I dont think I should place this in a try catch block
            try
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (cancellationToken)
                    {
                        return;
                    }

                    _currentFolderID++;
                    _Scan(d, ref sw, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _exHandler.Log(ex, false);
            }
        }

        /// <summary>
        /// Thrown Event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNewScanFolderUpdate(ScanFolderUpdateEventArgs e)
        {
			NewScanFolderUpdate?.Invoke(this, e);
		}
    }
}
