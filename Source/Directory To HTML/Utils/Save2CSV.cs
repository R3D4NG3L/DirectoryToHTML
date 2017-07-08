using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryToHtml.Utils;
using System.IO;
using DirectoryToHtml.Config;

namespace DirectoryToHtml.Utils
{
    internal class Save2CSV
    {
        /// <summary>
        /// File Info to Save
        /// </summary>
        private List<FileInfoAdvanced> _listFileInfo;

        /// <summary>
        /// Configuration
        /// </summary>
        private Configuration _configuration;

        /// <summary>
        /// Destination File
        /// </summary>
        string _destinationFile;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fia"></param>
        /// <param name="cfg"></param>
        public Save2CSV(List<FileInfoAdvanced> fia, Configuration cfg, string df)
        {
            _listFileInfo = fia;
            _configuration = cfg;

            string DestFileWithoutExtension = df.Substring(0, df.LastIndexOf('.'));

            _destinationFile = DestFileWithoutExtension + ".csv";
        }

        /// <summary>
        /// Save to CSV
        /// </summary>
        public void Save()
        {
            // Order the List
            switch (_configuration.OrderBy)
            {
                case Configuration.OrderBy_e.CreationDate:
                    _listFileInfo = _listFileInfo.OrderByDescending(x => x.CreationDate).ToList();
                    break;
                case Configuration.OrderBy_e.LastModificationDate:
                    _listFileInfo = _listFileInfo.OrderByDescending(x => x.ModificationDate).ToList();
                    break;
                case Configuration.OrderBy_e.Size:
                    _listFileInfo = _listFileInfo.OrderByDescending(x => x.SizeByte).ToList();
                    break;
                case Configuration.OrderBy_e.FileName:
                    _listFileInfo = _listFileInfo.OrderByDescending(x => x.FileName).ToList();
                    break;
                case Configuration.OrderBy_e.FolderName:
                    _listFileInfo = _listFileInfo.OrderByDescending(x => x.FolderName).ToList();
                    break;
                case Configuration.OrderBy_e.Default:
                default:
                    // Nothing to do
                    break;
            }

            using (StreamWriter file = new StreamWriter(_destinationFile, false))
            {
                StringBuilder sb = new StringBuilder();

                // Header
                // -- Folder Name
                if (_configuration.enable_folderName)
                {
                    sb.Append("Folder;");
                }
                // -- File Name
                if (_configuration.enable_fileName)
                {
                    sb.Append("File Name;");
                }
                // -- Size
                if (_configuration.enable_AutoSizeType)
                {
                    sb.Append("Size;");
                }
                else
                {
                    // -- Bytes
                    if (_configuration.enable_sizeByte)
                    {
                        sb.Append("Size (B);");
                    }
                    // -- KiB
                    if (_configuration.enable_sizeKiB)
                    {
                        sb.Append("Size (KiB);");
                    }
                    // -- MiB
                    if (_configuration.enable_sizeMiB)
                    {
                        sb.Append("Size (MiB);");
                    }
                    // -- GiB
                    if (_configuration.enable_sizeGiB)
                    {
                        sb.Append("Size (GiB);");
                    }
                }
                // -- Creation Date
                if (_configuration.enable_creationDate)
                {
                    sb.Append("Creation Date;");
                }
                // -- Last Modification Date
                if (_configuration.enable_lastModificationDate)
                {
                    sb.Append("Last Modification Date;");
                }

                file.WriteLine(sb.ToString());

                // Data
                foreach (FileInfoAdvanced f in _listFileInfo)
                {
                    sb.Clear();

                    // -- Folder Name
                    if (_configuration.enable_folderName)
                    {
                        sb.Append(f.FolderName + ";");
                    }
                    // -- File Name
                    if (_configuration.enable_fileName)
                    {
                        sb.Append(f.FileName + ";");
                    }
                    // -- Size
                    if (_configuration.enable_AutoSizeType)
                    {
                        if (f.SizeGiB > 1)
                        {
                            sb.Append(f.SizeGiB.ToString("0.00") + " GiB;");
                        }
                        else if (f.SizeMiB > 1)
                        {
                            sb.Append(f.SizeMiB.ToString("0.00") + " MiB;");
                        }
                        else if (f.SizeKiB > 1)
                        {
                            sb.Append(f.SizeKiB.ToString("0.00") + " KiB;");
                        }
                        else
                        {
                            sb.Append(f.SizeByte.ToString("0.00") + " B;");
                        }
                    }
                    else
                    {
                        // -- Bytes
                        if (_configuration.enable_sizeByte)
                        {
                            sb.Append(f.SizeByte.ToString("0.00") + ";");
                        }
                        // -- KiB
                        if (_configuration.enable_sizeKiB)
                        {
                            sb.Append(f.SizeKiB.ToString("0.00") + ";");
                        }
                        // -- MiB
                        if (_configuration.enable_sizeMiB)
                        {
                            sb.Append(f.SizeMiB.ToString("0.00") + ";");
                        }
                        // -- GiB
                        if (_configuration.enable_sizeGiB)
                        {
                            sb.Append(f.SizeGiB.ToString("0.00") + ";");
                        }
                    }
                    // -- Creation Date
                    if (_configuration.enable_creationDate)
                    {
                        sb.Append(String.Format("{0:d}", f.CreationDate) + ";");
                    }
                    // -- Last Modification Date
                    if (_configuration.enable_lastModificationDate)
                    {
                        sb.Append(String.Format("{0:d}", f.ModificationDate) + ";");
                    }

                    file.WriteLine(sb.ToString());
                }

                sb.Clear();

            } // End Using StreamWriter
        } // End of Save Function

        /// <summary>
        /// Open Generated File
        /// </summary>
        public void Open()
        {
            System.Diagnostics.Process.Start(_destinationFile);
        }
    }
}
