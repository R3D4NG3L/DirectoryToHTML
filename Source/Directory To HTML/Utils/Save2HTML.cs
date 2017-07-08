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
    internal class Save2HTML
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
        private string _destinationFile;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fia"></param>
        /// <param name="cfg"></param>
        public Save2HTML(List<FileInfoAdvanced> fia, Configuration cfg, string df)
        {
            _listFileInfo = fia;
            _configuration = cfg;
            string DestFileWithoutExtension = df.Substring(0, df.LastIndexOf('.'));

            _destinationFile = DestFileWithoutExtension + ".html";
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

                string fileNameWithoutPath = _destinationFile.Substring(_destinationFile.LastIndexOf('\\') + 1);
                string fileNameWithouthExtension = fileNameWithoutPath.Substring(0, fileNameWithoutPath.LastIndexOf('.'));

                // Add Header
                AddHeader(file, fileNameWithouthExtension);

                // Add Body
                AddBody(file, _listFileInfo);
            } // End Using StreamWriter
        } // End of Save Function

        /// <summary>
        /// Add Header
        /// </summary>
        /// <param name="sw"></param>
        private void AddHeader(StreamWriter sw, string FileName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"<!doctype html>
<!--[if lt IE 7 ]> <html lang='en' class='no-js ie6'> <![endif]-->
<!--[if IE 7 ]>    <html lang='en' class='no-js ie7'> <![endif]-->
<!--[if IE 8 ]>    <html lang='en' class='no-js ie8'> <![endif]-->
<!--[if IE 9 ]>    <html lang='en' class='no-js ie9'> <![endif]-->
<!--[if (gt IE 9)|!(IE)]><!--> <html lang='en' class='no-js'> <!--<![endif]-->
<head>
    <meta charset='utf-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1'>

    <title>{0}</title>
    <meta name='author' content='Davide Garino - gTechSolutions.it'>
    <link rel='stylesheet' href='/assets/css/style.css'>
	<style type='text/css'> 
		.list {{
		  font-family:sans-serif;
		}}
		td {{
		  padding:10px; 
		  border:solid 1px #eee;
		}}
		input {{
		  border:solid 1px #ccc;
		  border-radius: 5px;
		  padding:7px 14px;
		  margin-bottom:10px
		}}
		input:focus {{
		  outline:none;
		  border-color:#aaa;
		}}
		.sort {{
		  padding:8px 30px;
		  border-radius: 6px;
		  border:none;
		  display:inline-block;
		  color:#fff;
		  text-decoration: none;
		  background-color: #28a8e0;
		  height:30px;
		}}
		.sort:hover {{
		  text-decoration: none;
		  background-color:#1b8aba;
		}}
		.sort:focus {{
		  outline:none;
		}}
		.sort:after {{
		  display:inline-block;
		  width: 0;
		  height: 0;
		  border-left: 5px solid transparent;
		  border-right: 5px solid transparent;
		  border-bottom: 5px solid transparent;
		  content:'';
		  position: relative;
		  top:-10px;
		  right:-5px;
		}}
		.sort.asc:after {{
		  width: 0;
		  height: 0;
		  border-left: 5px solid transparent;
		  border-right: 5px solid transparent;
		  border-top: 5px solid #fff;
		  content:'';
		  position: relative;
		  top:4px;
		  right:-5px;
		}}
		.sort.desc:after {{
		  width: 0;
		  height: 0;
		  border-left: 5px solid transparent;
		  border-right: 5px solid transparent;
		  border-bottom: 5px solid #fff;
		  content:'';
		  position: relative;
		  top:-4px;
		  right:-5px;
		}}
		.paginationTop li, .paginationBelow li {{
		  text-align: center;
		  display: inline-block;
		  padding: 5px;
		}}
		hr {{
			border-top: 1px solid #8c8b8b;
			text-align: center;
		}}
		hr:after {{
			content: '§';
			display: inline-block;
			position: relative;
			top: -14px;
			padding: 0 10px;
			background: #f0f0f0;
			color: #8c8b8b;
			font-size: 18px;
			-webkit-transform: rotate(60deg);
			-moz-transform: rotate(60deg);
			transform: rotate(60deg);
		}}
		#items table {{
			width: 100%;
		}}
		
		.header {{
			text-align: center;
		}}

		.footer {{
			text-align: center;
			font-style: italic;
		}}", FileName).AppendLine();

            if (!_configuration.enable_sizeByte)
            {
                sb.AppendLine(@"		.Size-B, .Size_B_header {
        display: none;
        }");
            }

            sb.AppendLine(@"     </style>
</head>
<body>");

            sw.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Add Javascript Code
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="lst"></param>
        private void AddJavascript(StreamWriter sw)
        {
            StringBuilder sb = new StringBuilder();

            // Var Options
            sb.AppendLine(@"          <script type='text/javascript'>
        var fuzzyOptions = {
			searchClass: 'fuzzy-search',
            location: 0,
            distance: 100,
            threshold: 0.2,
            multiSearch: true
        };

        var paginationTopOptions = {
			name: 'paginationTop',
			paginationClass: 'paginationTop',
			outerWindow: 2
		};
		
		var paginationBelowOptions = {
			name: 'paginationBelow',
			paginationClass: 'paginationBelow',
			outerWindow: 2
		};

        var options = {
                valueNames: [");
            // -- Folder Name
            if (_configuration.enable_folderName)
            {
                sb.Append("                 'Folder',\r\n");
            }
            // -- File Name
            if (_configuration.enable_fileName)
            {
                sb.Append("                 'FileName',\r\n");
            }
            // -- Size
            if (_configuration.enable_AutoSizeType)
            {
                sb.Append("                 'Size',\r\n");
            }
            // -- Bytes
            sb.Append("                 'Size-B',\r\n");
            // -- KiB
            if (_configuration.enable_sizeKiB)
            {
                sb.Append("                 'Size-KiB',\r\n");
            }
            // -- MiB
            if (_configuration.enable_sizeMiB)
            {
                sb.Append("                 'Size-MiB',\r\n");
            }
            // -- GiB
            if (_configuration.enable_sizeGiB)
            {
                sb.Append("                 'Size-GiB',\r\n");
            }
            // -- Creation Date
            if (_configuration.enable_creationDate)
            {
                sb.Append("                 'Creation-Date', { name: 'creationdate-timestamp', attr: 'data-creationdate-timestamp' },\r\n");
            }
            // -- Last Modification Date
            if (_configuration.enable_lastModificationDate)
            {
                sb.Append("                 'Last-Modification-Date', { name: 'lastmodificationdate-timestamp', attr: 'data-lastmodificationdate-timestamp' },\r\n");
            }

            sb.AppendLine(@"                ],
                plugins: [ ListFuzzySearch() ],");

            if (_listFileInfo.Count > 1000)
            {
                sb.AppendLine(@"                page: 1000,
				plugins: [ ListPagination(paginationTopOptions),
						   ListPagination(paginationBelowOptions)]");
            }

            sb.AppendLine(@"            };
            var userList = new List('items', options);
        </script>
</head>
<body>");

            sw.WriteLine(sb.ToString());
        }

        /// <summary>
        /// HTML Body
        /// </summary>
        /// <param name="sw"></param>
        private void AddBody(StreamWriter sw, List<FileInfoAdvanced> ListfileInfoAdv)
        {
            StringBuilder sb = new StringBuilder();

            long totalSize = 0;
            string MeasureUnit = "Bytes";

            foreach (FileInfoAdvanced f in ListfileInfoAdv)
            {
                totalSize += f.SizeByte;
            }

            if (totalSize > 1024)
            {
                // Express in KiB
                MeasureUnit = "KiB";
                totalSize /= 1024;

                if (totalSize > 1024)
                {
                    // Express in MiB
                    MeasureUnit = "MiB";
                    totalSize /= 1024;

                    if (totalSize > 1024)
                    {
                        // Express in GiB
                        MeasureUnit = "GiB";
                        totalSize /= 1024;
                    }
                }
            }

            // Header
            sb.AppendFormat(@"    <div class='header'>
        <h3>Last Update: {0}</h3>
        <h2>Total Size: {1} {2}</h2>
        <h3>Total Elements: {3}</h3>
    </div>
    <hr>
    <br/>", DateTime.Now, totalSize, MeasureUnit, ListfileInfoAdv.Count).AppendLine();

            // List
            sb.AppendLine(@"    <div id='items'>
        <div class='header'>
            <!--<input class='search' placeholder='Search' />-->
            <input type='text' class='fuzzy-search' />");

            // -- Folder Name
            if (_configuration.enable_folderName)
            {
                sb.AppendLine(@"            <button class='sort' data-sort='Folder'>
                Sort by Folder
            </button>");
            }
            // -- File Name
            if (_configuration.enable_fileName)
            {
                sb.AppendLine(@"            <button class='sort' data-sort='FileName'>
                Sort by File Name
            </button>");
            }
            // -- Size
            // -- Bytes
            sb.AppendLine(@"            <button class='sort' data-sort='Size-B'>
                Sort by Size
            </button>");
            // -- Creation Date
            if (_configuration.enable_creationDate)
            {
                sb.AppendLine(@"            <button class='sort' data-sort='creationdate-timestamp'>
                Sort by Creation Date
            </button>");
            }
            // -- Last Modification Date
            if (_configuration.enable_lastModificationDate)
            {
                sb.AppendLine(@"            <button class='sort' data-sort='lastmodificationdate-timestamp'>
                Sort by Last Modification Date
            </button>");
            }

            //---------- TABLE -----------------
            sb.AppendLine(@"         <br/><br/><br/>
            </div>
            <ul class='paginationTop'></ul>
            <table>");
            // Header
            // -- Folder Name
            if (_configuration.enable_folderName)
            {
                sb.AppendFormat("             <th class='{0}_header'>{0}</th>", "Folder").AppendLine();
            }
            // -- File Name
            if (_configuration.enable_fileName)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "FileName", "File Name").AppendLine();
            }
            // -- Size
            if (_configuration.enable_AutoSizeType)
            {
                sb.AppendFormat("             <th class='{0}_header'>{0}</th>", "Size").AppendLine();
            }

            // -- Bytes
            sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Size_B", "Size (B)").AppendLine();
            // -- KiB
            if (_configuration.enable_sizeKiB)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Size_KiB", "Size (KiB)").AppendLine();
            }
            // -- MiB
            if (_configuration.enable_sizeMiB)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Size_NiB", "Size (MiB)").AppendLine();
            }
            // -- GiB
            if (_configuration.enable_sizeGiB)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Size_GiB", "Size (GiB)").AppendLine();
            }
            // -- Creation Date
            if (_configuration.enable_creationDate)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Creation_Date", "Creation Date").AppendLine();
            }
            // -- Last Modification Date
            if (_configuration.enable_lastModificationDate)
            {
                sb.AppendFormat("             <th class='{0}_header'>{1}</th>", "Last_Modification_Date", "Last Modification Date").AppendLine();
            }

            sb.AppendLine("             <tbody class='list'>");

            // --------------  DATA -------------------
            foreach (FileInfoAdvanced f in ListfileInfoAdv)
            {
                sb.AppendLine("                <tr>");

                // -- Folder Name
                if (_configuration.enable_folderName)
                {
                    sb.AppendFormat("                   <td class='Folder'>{0}</td>", f.FolderName).AppendLine();
                }
                // -- File Name
                if (_configuration.enable_fileName)
                {
                    sb.AppendFormat("                   <td class='FileName'>{0}</td>", f.FileName).AppendLine();
                }
                // -- Size
                if (_configuration.enable_AutoSizeType)
                {
                    if (f.SizeGiB > 1)
                    {
                        sb.AppendFormat("                   <td class='Size'>{0} GiB</td>", f.SizeGiB.ToString("0.00")).AppendLine();
                    }
                    else if (f.SizeMiB > 1)
                    {
                        sb.AppendFormat("                   <td class='Size'>{0} MiB</td>", f.SizeMiB.ToString("0.00")).AppendLine();
                    }
                    else if (f.SizeKiB > 1)
                    {
                        sb.AppendFormat("                   <td class='Size'>{0} KiB</td>", f.SizeKiB.ToString("0.00")).AppendLine();
                    }
                    else
                    {
                        sb.AppendFormat("                   <td class='Size'>{0} B</td>", f.SizeByte.ToString("0.00")).AppendLine();
                    }
                }
                // -- Bytes
                sb.AppendFormat("                   <td class='Size-B'>{0}</td>", f.SizeByte.ToString("0")).AppendLine();
                // -- KiB
                if (_configuration.enable_sizeKiB)
                {
                    sb.AppendFormat("                   <td class='Size-KiB'>{0}</td>", f.SizeKiB.ToString("0.00")).AppendLine();
                }
                // -- MiB
                if (_configuration.enable_sizeMiB)
                {
                    sb.AppendFormat("                   <td class='Size-MiB'>{0}</td>", f.SizeMiB.ToString("0.00")).AppendLine();
                }
                // -- GiB
                if (_configuration.enable_sizeGiB)
                {
                    sb.AppendFormat("                   <td class='Size-GiB'>{0}</td>", f.SizeGiB.ToString("0.00")).AppendLine();
                }
                // -- Creation Date
                if (_configuration.enable_creationDate)
                {
                    sb.AppendFormat("                   <td class='Creation-Date creationdate-timestamp' data-creationdate-timestamp='{0}'>{1}</td>", f.CreationDate.Ticks, f.CreationDate).AppendLine();
                }
                // -- Last Modification Date
                if (_configuration.enable_lastModificationDate)
                {
                    sb.AppendFormat("                   <td class='Creation-Date lastmodificationdate-timestamp' data-lastmodificationdate-timestamp='{0}'>{1}</td>", f.CreationDate.Ticks, f.CreationDate).AppendLine();
                }

                sb.AppendLine("                </tr>");
            }

            sb.AppendLine(@"             </tbody>
            </table>
			<ul class='paginationBelow'></ul>
        </div>
        <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js'></script>
		<script src='http://listjs.com/assets/javascripts/list.min.js'></script>
		<script src='https://cdnjs.cloudflare.com/ajax/libs/list.fuzzysearch.js/0.1.0/list.fuzzysearch.js'></script>
		<script src='https://cdnjs.cloudflare.com/ajax/libs/list.pagination.js/0.1.1/list.pagination.min.js'></script>");


         sw.WriteLine(sb.ToString());

            // Add Javascrript
            AddJavascript(sw);

            sb.Clear();
sb.AppendLine(@"        <hr>
		<div class='footer'>
			Generated with Directory To HTML<br>
			Further details in <a href='http://www.gTechSolutions.it'>gTechSolutions.it</a>
		</div>
    </body>
</html>");

            sw.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Open Generated File
        /// </summary>
        public void Open()
        {
            System.Diagnostics.Process.Start(_destinationFile);
        }
    }
}
