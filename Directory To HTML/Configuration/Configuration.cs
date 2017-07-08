using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DirectoryToHtml.Utils;
using System.ComponentModel;

namespace DirectoryToHtml.Config
{
    public class Configuration
    {
        /*
         * CONFIGURATION METHODS
         */
        /// <summary>
        /// Select Folder
        /// Remembers the last selected folder
        /// </summary>
        public string selectedFolder;
        /// <summary>
        /// Save Location
        /// Remebers the last saved location
        /// </summary>
        public string saveLocation;
        /// <summary>
        /// Save in HTML
        /// </summary>
        [Category("Save Format")]
        [DisplayName("HTML")]
        [Description("Enables / Disables HTML Save Format")]
        public bool saveFormat_HTML { get; set; }
        /// <summary>
        /// Save in CSV
        /// </summary>
        [Category("Save Format")]
        [DisplayName("CSV")]
        [Description("Enables / Disables CSV Save Format")]
        public bool saveFormat_CSV { get; set; }
        /// <summary>
        /// Print FileName
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("File Name")]
        [Description("Enables / Disables File Name")]
        public bool enable_fileName { get; set; }
        /// <summary>
        /// Print Folder Name
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Folder Name")]
        [Description("Enables / Disables Folder Name")]
        public bool enable_folderName { get; set; }
        /// <summary>
        /// Auto-choses the size type
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Auto-Size")]
        [Description("Enables / Disables Auto-Size functionality")]
        public bool enable_AutoSizeType { get; set; }
        /// <summary>
        /// Size in Byte
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Size in Byte")]
        [Description("Enables / Disables the size in Byte")]
        public bool enable_sizeByte { get; set; }
        /// <summary>
        /// Size in KiB
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Size in KiB")]
        [Description("Enables / Disables the size in Kib")]
        public bool enable_sizeKiB { get; set; }
        /// <summary>
        /// Size in MiB
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Size in MiB")]
        [Description("Enables / Disables the size in MiB")]
        public bool enable_sizeMiB { get; set; }
        /// <summary>
        /// Size in GiB
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Size in GiB")]
        [Description("Enables / Disables the size in GiB")]
        public bool enable_sizeGiB { get; set; }
        /// <summary>
        /// Creation Date
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Creation Date")]
        [Description("Enables / Disables the creation date")]
        public bool enable_creationDate { get; set; }
        /// <summary>
        /// Last modification date
        /// </summary>
        [Category("Save Settings")]
        [DisplayName("Last Modification Date")]
        [Description("Enables / Disables the last modification date")]
        public bool enable_lastModificationDate { get; set; }

        [Category("Save Settings")]
        [DisplayName("Order By")]
        [Description("Choose how the information will be ordered")]
        public OrderBy_e OrderBy { get; set; }

        /// <summary>
        /// OrderBy Possibilities
        /// </summary>
        public enum OrderBy_e
        {
            [Description("Default")]
            Default,
            [Description("Creation Date")]
            CreationDate,
            [Description("Last Modification Date")]
            LastModificationDate,
            [Description("Size")]
            Size,
            [Description("File Name")]
            FileName,
            [Description("Folder Name")]
            FolderName,
        }

        /*
         * INTERNAL METHODS
         */
        /// <summary>
        /// Configuration Save Location
        /// </summary>
        static private string cfgFileLocation = Directory.GetCurrentDirectory() + "\\bin\\Configuration.xml";

        /// <summary>
        /// Exception Handler
        /// </summary>
        static private ExceptionHandler ExHandler = new ExceptionHandler("Configuration");

        /// <summary>
        /// Constructor
        /// </summary>
        public Configuration()
        {
            // DEFAULT VALUES
            selectedFolder = "C:\\";
            saveLocation = "C:\\FolderContent.csv";
            saveFormat_HTML = true;
            saveFormat_CSV = false;
            enable_fileName = true;
            enable_folderName = true;
            enable_AutoSizeType = true;
            enable_sizeByte = false;
            enable_sizeKiB = false;
            enable_sizeMiB = false;
            enable_sizeGiB = false;
            enable_creationDate = true;
            enable_lastModificationDate = false;

            // Create Save Location
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\bin");
        }

        /// <summary>
        /// Save Current Configuration
        /// </summary>
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            TextWriter writer = new StreamWriter(cfgFileLocation);

            serializer.Serialize(writer, this);

            writer.Close();
        }

        /// <summary>
        /// Get saved configuration
        /// </summary>
        /// <returns>Get saved configuration</returns>
        public Configuration Get()
        {


            Configuration fRes = new Configuration();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                XmlReader reader = XmlReader.Create(cfgFileLocation);

                fRes = (Configuration)serializer.Deserialize(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                // Something happened, maybe is the first run of the program and the configuration has never been saved, lets save
                // a default configuration
                this.Save();
                fRes = this;
                ExHandler.Log(ex, false);
            }

            return fRes;
        }
    }
}
