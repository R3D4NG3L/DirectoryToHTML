using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryToHtml.Utils
{
    public class ExceptionHandler
    {
        /// <summary>
        /// Error Log Location
        /// </summary>
        static private string _errorLogFolder = Directory.GetCurrentDirectory() + "\\bin";

        /// <summary>
        /// Error Log File Location
        /// </summary>
        private string _errorLogFileLocation;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="FileName"></param>
        public ExceptionHandler(string FileName)
        {
            // Create Save Location
            Directory.CreateDirectory(_errorLogFolder);
            // Get File Name
            _errorLogFileLocation = _errorLogFolder + "\\Exceptions_" + FileName + ".log";
        }

        /// <summary>
        /// Log Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="ShowMsgBox"></param>
        public void Log(Exception ex, bool ShowMsgBox = true)
        {
            StreamWriter errorFile = new StreamWriter(_errorLogFileLocation, true);

            // Log on file
            errorFile.WriteLine("-------------------------------");
            errorFile.WriteLine("Date = {0}", DateTime.Now.ToString());
            errorFile.WriteLine("HelpLink = {0}", ex.HelpLink);
            errorFile.WriteLine("Source = {0}", ex.Source);
            errorFile.WriteLine("StackTrace =\r\n{0}", ex.StackTrace);
            errorFile.WriteLine("TargetSite = {0}", ex.TargetSite);
            errorFile.WriteLine("Message = {0}", ex.Message);

            // Show Message Box
            if (ShowMsgBox)
            {
                MessageBox.Show(ex.Message);
            }

            errorFile.Close();
        }

        /// <summary>
        /// Open Exception Log File
        /// </summary>
        public void OpenLogFile()
        {
            System.Diagnostics.Process.Start(_errorLogFileLocation);
        }
    }
}
