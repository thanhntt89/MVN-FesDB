namespace FestivalObjects
{
    public class FileExportEntity
    {
        public FileType FileType { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public int TotalRecord { get; set; }
        public string FunctionName { get; set; }
        public string Content { get; set; }

        public string ExportType { get; set; }
        public bool IncludeHeader { get; set; }

        /// <summary>
        /// Expert data with filter apply
        /// </summary>
        public bool IsExportWithFilter { get; set; }
    }

    public enum FileType { Excel, TSV, TXT, CSV }
}
