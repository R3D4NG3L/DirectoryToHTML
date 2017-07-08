using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryToHtml.Config
{
    public partial class ConfigurationForm : Form
    {
        private Configuration config;

        public ConfigurationForm(Configuration conf)
        {
            config = conf;

            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = config;
        }

        /// <summary>
        /// Save Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
