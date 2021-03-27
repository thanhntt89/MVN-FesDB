using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Festival.DBTab
{
    public class TsvExportCollection
    {
        public List<TsvExportEntity> ExportList;

        public TsvExportCollection()
        {
            ExportList = new List<TsvExportEntity>();
        }

        public int Count
        {
            get
            {
                return ExportList.Count;
            }
        }

        public void Clear()
        {
            ExportList.Clear();
        }

        public void Add(TsvExportEntity exportEtntity)
        {
            ExportList.Add(exportEtntity);
        }

        public TsvExportEntity GetExportInfoByExportName(string exportName)
        {
            var exist = ExportList.Where(r => r.ExportModuleName.Equals(exportName)).FirstOrDefault();
            return exist;
        }

        public List<FileEntity> GetFiles()
        {
            List<FileEntity> files = new List<FileEntity>();
            foreach (TsvExportEntity item in ExportList)
            {
                files.AddRange(item.Files);
            }

            return files;
        }

        public List<FileEntity> GetFilesExport()
        {
            List<FileEntity> files = new List<FileEntity>();
            foreach (TsvExportEntity item in ExportList)
            {
                if (!string.IsNullOrEmpty(item.ExportModuleName))
                    files.AddRange(item.Files);
            }

            return files;
        }

        public int TotalFileUploaded
        {
            get
            {
                int toltal = 0;
                var list = GetFilesExport();
                toltal = list.Where(r => r.UploadTime != DateTime.MinValue && !r.IgNorUpload).ToList().Count;
                return toltal;
            }
        }

    }

    public class TsvExportEntity
    {
        public int TabIndex { get; set; }
        public string DateTimeExport { get; set; }
        public string ExportModuleName { get; set; }
        public string ExportModuleText { get; set; }
        public string LogModulePathFile { get; set; }

        public List<FileEntity> Files { get; set; }

        public int Count
        {
            get
            {
                return Files.Count;
            }
        }

        public FileEntity GetFileInfo(string fileExportId)
        {
            if (Files == null)
                return null;

            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            return exsit;
        }

        public void SetStatusContentWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsContentsWarnFlg = status;
            }
        }

        public void SetStatusStartSingingWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsStartSingWarnFlg = status;
            }
        }

        public void SetStatusDiscRecordSongWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsDiscRecordSongWarnFlg = status;
            }
        }

        public void SetStatusAddSongWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsAddSongWarnFlg = status;
            }
        }

        public void SetStatusImageAllotmentWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsImageAllotmentWarnFlg = status;
            }
        }

        public void SetStatusDiscAddDeleteSongWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsDiscAddDeleteSongWarnFlg = status;
            }
        }

        public void SetStatusRecommendProgramListWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsRecommendProgramListWarnFlg = status;
            }
        }

        public void SetStatusFileDelete(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsDeleted = status;
            }
        }

        public void SetStatusImageDiscAddDeleteWarningFlag(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsImageDiscAddDeleteWarnFlg = status;
            }
        }


        public void SetStatusFileFlagCheck(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsFlagCheck = status;
            }
        }

        public void SetStatusFilePreComp(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsPreComp = status;
            }
        }

        public void SetStatusFileOutputNewVer(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsOutputNewVer = status;
            }
        }

        public void SetStatusFileAddPlayTime(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsAddPlayTime = status;
            }
        }

        public void SetStatusFileUpdateTake(string fileExportId, bool status)
        {
            var exsit = Files.Where(r => r.FileExportId.ToLower().Equals(fileExportId.ToLower())).FirstOrDefault();
            if (exsit != null)
            {
                exsit.IsUpdateTake = status;
            }
        }
    }

    public class FileEntity
    {
        private string fileLocalPath = string.Empty;
        private string filServerPath = string.Empty;

        /// <summary>
        /// コンテンツ export
        /// </summary>
        public bool IsContentsWarnFlg { get; set; }

        /// <summary>
        /// 歌い出し export
        /// </summary>
        public bool IsStartSingWarnFlg { get; set; }

        /// <summary>
        /// DISC版収録曲 export
        /// </summary>
        public bool IsDiscRecordSongWarnFlg { get; set; }

        public bool IsAddSongWarnFlg { get; set; }

        public bool IsImageAllotmentWarnFlg { get; set; }

        public bool IsDiscAddDeleteSongWarnFlg { get; set; }

        public bool IsRecommendProgramListWarnFlg { get; set; }

        public bool IsImageDiscAddDeleteWarnFlg { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsFlagCheck { get; set; }
        public bool IsPreComp { get; set; }
        public bool IsOutputNewVer { get; set; }
        public bool IsAddPlayTime { get; set; }
        public bool IsUpdateTake { get; set; }
        public string FileExportId { get; set; }
        public bool FileNameExist
        {
            get
            {
                string tmpFileName = Path.GetFileNameWithoutExtension(this.FileNameLocal);
                return !string.IsNullOrEmpty(tmpFileName);
            }
        }
        public bool FolderWorkExist
        {
            get
            {
                return Directory.Exists(fileLocalPath);
            }
        }
        public string FileNameLocal
        {
            get; set;
        }
        public string FileLocalPath
        {
            get
            {
                return this.fileLocalPath + FileNameLocal;
            }
            set
            {
                this.fileLocalPath = value;
            }
        }
        public string FileServerPath
        {
            get
            {
                return this.filServerPath + FileNameServer;
            }
            set
            {
                this.filServerPath = value;
            }
        }

        public string FileNameServer { get; set; }

        public DateTime UploadTime { get; set; }
        public bool IgNorUpload { get; set; }
    }
}
