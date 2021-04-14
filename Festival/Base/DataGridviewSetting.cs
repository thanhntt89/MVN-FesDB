using FestivalCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Zuby.ADGV;

namespace Festival.Base
{
    public static class DataGridviewSetting
    {
        private static string folderPath = Constants.SETTING_DATAGRIDVIEW_USER_ROOT_PATH;
        private static string filePath = string.Empty;
        
        /// <summary>
        /// Loads columns information from the specified XML file
        /// </summary>
        /// <param name="dgv">DataGridView control instance</param>
        /// <param name="fileName">XML configuration file</param>
        public static void LoadConfiguration(this AdvancedDataGridView dgv)
        {           
            filePath = string.Format("{0}\\{1}.dat", folderPath, dgv.Name);

            dgv.IsLoadConfig = false;

            if (!File.Exists(filePath))
            {
                return;
            }
            try
            {
                List<ColumnInfo> columns;
                using (var streamReader = new StreamReader(filePath))
                {
                    var xmlSerializer = new XmlSerializer(typeof(List<ColumnInfo>));
                    columns = (List<ColumnInfo>)xmlSerializer.Deserialize(streamReader);
                }

                foreach (var column in columns)
                {
                    dgv.Columns[column.Name].DisplayIndex = column.DisplayIndex;
                    dgv.Columns[column.Name].Width = column.Width;
                    dgv.Columns[column.Name].Visible = column.Visible;
                    dgv.Columns[column.Name].Frozen = column.Frozen;
                }

                dgv.IsLoadConfig = true;
            }
            catch 
            {
               
            }
        }

        /// <summary>
        /// Saves columns information to the specified XML file
        /// </summary>
        /// <param name="dgv">DataGridView control instance</param>
        /// <param name="fileName">XML configuration file</param>
        public static void SaveConfiguration(this AdvancedDataGridView dgv)
        {           
            filePath = string.Format("{0}\\{1}.dat", folderPath, dgv.Name);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var columns = new List<ColumnInfo>();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                columns.Add(new ColumnInfo()
                {
                    Name = col.Name,
                    DisplayIndex = col.DisplayIndex,
                    Width = col.Width,
                    Visible = col.Visible,
                    Frozen = col.Frozen
                });
            }

            using (var streamWriter = new StreamWriter(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<ColumnInfo>));
                xmlSerializer.Serialize(streamWriter, columns);
            }
        }
    }

    [Serializable]
    public sealed class ColumnInfo
    {
        public string Name { get; set; }
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public bool Frozen { get; set; }
    }
}
