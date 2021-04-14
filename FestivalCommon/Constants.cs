using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FestivalCommon
{
    public enum SortType { RemoveSort, AtoZ, ZtoA }

    public class Constants
    {
        public static string VERSION_TEXT
        {
            get
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                return string.Format("Version {0}.{1}.{2}", fvi.ProductMajorPart, fvi.ProductMinorPart, fvi.FileBuildPart);
            }
        }

        public static string SETTING_DATAGRIDVIEW_USER_ROOT_PATH
        {
            get
            {
                string path = string.Format("{0}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

                if (Directory.Exists(path))
                {
                    path = string.Format("{0}\\{1}", path, "Festival");
                }
                else
                {
                    path = string.Format("{0}\\DefaultConfig", Application.StartupPath);
                }

                return path;
            }
        }

        // Log datetime format
        public static string LOG_DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss";
        public static string DATE_TIME_FORMAT_SQL111 = "yyyyMMdd";
        public static string DATETIME_EXTENTION_TSV = DateTime.Now.ToString("yyyyMMdd") + ".tsv";
        public static string FILE_FILTER_TSV_EXTENSION = "(*.txt)|*.txt|(*.tsv)|*.tsv";
        public static string FILE_FILTER_TXT_EXTENTION = "(*.txt)|*.txt";

        public static string IMPORT_RECOMMEND_SONG_TMP_FILE_NAME = "Tmp.txt";
        // Table Name
        public static string WORK_TABLE_NAME_FESTCONTENT = string.Format("tbl_Wrk_Fesコンテンツ_{0}", Environment.MachineName).Replace("-", "_");
        public static string SONG_NUMBER_NAME_TABLE_TMP = string.Format("tbl_Wrk_Fes選曲番号_{0}", Environment.MachineName).Replace("-", "_");
        public static string RECORDABLE_LIST_TABLE_NAME = "tbl_Fes録音可能リスト";
        public static string TABLE_TOTAL_RANKING = "tbl_FesTotal_Ranking";
        public static string TABLE_KARAOKE_YEAR_RANKING = "tbl_Fes_Karaoke_Year_Ranking";
        public static string TABLE_SONG_ADD_DELETE_NAME = string.Format("WiiTmp.dbo.[tbl_Wrk_FesDISC搭載曲追加削除管理_{0}]", Environment.MachineName).Replace("-", "_");
        public static string FEST_RECOMMEND_SONG_TABLE_DBTMP = string.Format("##FesRecommendSongTmp_{0}", Environment.MachineName.Replace("-", "_"));
        public static string FES_SONG_DISC_MANAGEMENT_WORK_TABLE_DBTMP = string.Format("##SongDiscManagementTmp_{0}", Environment.MachineName.Replace("-", "_"));
        public static string FES_VIDEO_DISC_MANAGEMENT_WORK_TABLE_DBTMP = string.Format("##VideoDiscManagementTmp_{0}", Environment.MachineName.Replace("-", "_"));

        // Global variable in sql start with ##
        public static string FES_CHAPTER_MANAGEMENT_WORK_TABLE_DBTMP = string.Format("##FesChapterTableTmp{0}", Environment.MachineName.Replace("-", "_"));
        public static string FES_CONSTENT_TABLE_DBTMP = string.Format("##FesWorkTableTmp{0}", Environment.MachineName.Replace("-", "_"));
        public static string FES_VIDEO_ASSIGMENT_TABLE_DBTMP = string.Format("##FesVideoAssigmentTableTmp{0}", Environment.MachineName.Replace("-", "_"));

        public static string FES_TIEUP_TABLE_DBTMP = string.Format("##FesTieupTableTmp{0}", Environment.MachineName.Replace("-", "_"));
        public static string FES_SONG_WITH_DISC_TABLE_DBTMP = string.Format("##FesSongWithDiscTableTmp{0}", Environment.MachineName.Replace("-", "_"));



        public static string CONDITION_VALUE_NULL = "NULL";
        public static string CONDITION_VALUE_NOT_NULL = "NOT NULL";
        public static string CONDITION_VALUE_BLANK = string.Empty;

        public static string FES_CONTENT_EXPORT_TYPE_FES_COLLECTION_LIST = "Fes収集リスト";
        public static string FES_CONTENT_EXPORT_TYPE_SONG_LIST = "楽曲リスト";

        public static string TitleInputFileMatchingScreenText = "ファイル照合";
        public static string TitleInputFileMatchingKaraokeScreenText = "ファイル照合 カラオケ";
        public static string TitleInputSongSelectedNumberText = "選曲番号入力";
        public static string TitleInputSongSelectedNumberKaraokeText = "選曲番号入力　カラオケ";
        // File
        public static string OpenFileFilter = "TXT|*.txt|TSV|*.tsv|XLS|*.xls|CSV|*.csv";
        public static string SaveFileFilterTSV = "TXT|*.txt|TSV|*.tsv|CSV|*.csv";
        public static string SaveFileFilterExcel = "XLS|*.xls";
        public static string DefaultUploadFileTSV_Fes収集リスト = "list.txt";
        public static string DefaultUploadFileTSV_楽曲リスト = "楽曲リスト.txt";
        public static string DefaultUploadFileExcel_Fes収集リスト = "list.xls";
        public static string DefaultUploadFileExcel_楽曲リスト = "楽曲リスト.xls";
        public static string FesContentSoundRecordingFilter = "テキストファイル (*.txt)|*.txt";
        public static string FesContentUpdateItemFilter = "テキストファイル (*.xls)|*.xls";
        public static string FesRecommendSongImportFilter = "TSVファイル (*.txt)|*.txt|(*.tsv)|*.tsv";
        public static string FesSongWithDiscImportFilter = "TSVファイル (*.txt)|*.txt|(*.tsv)|*.tsv";
        public static string FesVideoAssigmentImportFilter = "テキストファイル (*.txt)|*.txt|(*.tsv)|*.tsv";

        // File Extention
        public static string EXTENTION_EXCEL = ".xls";
        public static string EXTENTION_TXT = ".txt";
        public static string EXTENTION_CSV = ".csv";
        public static string EXTENTION_TSV = ".tsv";

        public static string[] LIST_BOOLEAN = new string[2] { "True", "False" };
        public static string LOG_FILE_PATH_ERROR = Application.StartupPath + "//error.txt";

        public static string EXPASTE001 = "EXPASTE001";
        public static string EXPASTE002 = "EXPASTE002";
        public static string EXPASTE003 = "EXPASTE003";

        public static string ERROR_TITLE_MESSAGE = "ERROR_TITLE_MESSAGE";
        public static string ALERT_TITLE_MESSAGE = "ALERT_TITLE_MESSAGE";
        public static string INFO_TITLE_MESSAGE = "INFO_TITLE_MESSAGE";
        public static string MESSAGE_ERROR_FILE_NOT_FOUND = "MESSAGE_ERROR_FILE_NOT_FOUND";
        public static string MESSAGE_ERROR_UNKNOWN = "MESSAGE_ERROR_UNKNOWN";
        public static string MESSAGE_ERROR_OUTPUT_FAILED = "MESSAGE_ERROR_OUTPUT_FAILED";
        public static string MESSAGE_ERROR_NO_DATA = "MESSAGE_ERROR_NO_DATA";
        public static string MESSAGE_ERROR_NO_AUTHORITY = "MESSAGE_ERROR_NO_AUTHORITY";
        public static string MESSAGE_ERROR_ID_REQUIRED = "MESSAGE_ERROR_ID_REQUIRED";
        public static string MESSAGE_ERROR_DIGINO_REQUIRED = "MESSAGE_ERROR_DIGINO_REQUIRED";
        public static string MESSAGE_ERROR_DIGINO_NOT_FOUND = "MESSAGE_ERROR_DIGINO_NOT_FOUND";

        public static string UPDATE_MESSAGE = "UPDATE_MESSAGE";

        public static string MSGE000 = "E000";
        public static string MSGE001 = "E001";
        public static string MSGE002 = "E002";
        public static string MSGE003 = "E003";
        public static string MSGE004 = "E004";
        public static string MSGE005 = "E005";
        public static string MSGE006 = "E006";
        public static string MSGE007 = "E007";
        public static string MSGE008 = "E008";
        public static string MSGE009 = "E009";
        public static string MSGE010 = "E010";
        public static string MSGE011 = "E011";
        public static string MSGE012 = "E012";
        public static string MSGE013 = "E013";
        public static string MSGE014 = "E014";
        public static string MSGE015 = "E015";
        public static string MSGE016 = "E016";
        public static string MSGE017 = "E017";
        public static string MSGE018 = "E018";
        public static string MSGE019 = "E019";
        public static string MSGE020 = "E020";
        public static string MSGE021 = "E021";
        public static string MSGE022 = "E022";
        public static string MSGE023 = "E023";
        public static string MSGE024 = "E024";
        public static string MSGE025 = "E025";
        public static string MSGE026 = "E026";
        public static string MSGE027 = "E027";
        public static string MSGE028 = "E028";
        public static string MSGE044 = "E044";
        public static string MSGI000 = "I000";
        public static string MSGI001 = "I001";
        public static string MSGI006 = "I006";
        public static string MSGA000 = "A000";
        public static string MSGA001 = "A001";
        public static string MSGE038 = "E038";
        public static string MSGI002 = "I002";
        public static string MSGI003 = "I003";
        public static string MSGI004 = "I004";
        public static string MSGI005 = "I005";
        public static string MSGI007 = "I007";
        public static string MSGI008 = "I008";
        public static string MSGI009 = "I009";
        public static string MSGI010 = "I010";
        public static string MSGI011 = "I011";
        public static string MSGI012 = "I012";
        public static string MSGA003 = "A003";
        public static string MSGA004 = "A004";
        public static string MSGE030 = "E030";
        public static string MSGE031 = "E031";
        public static string MSGE032 = "E032";
        public static string MSGE029 = "E029";
        public static string MSGE034 = "E034";
        public static string MSGE035 = "E035";
        public static string MSGE033 = "E033";
        public static string MSGE040 = "E040";
        public static string MSGE045 = "E045";
        public static string MSGE046 = "E046";
        public static string MSGE047 = "E047";
        public static string MSGE048 = "E048";
        public static string MSGE049 = "E049";
        public static string MSGE050 = "E050";
        public static string MSGE051 = "E051";
        public static string MSGE052 = "E052";
        public static string MSGE053 = "E053";
        public static string MSGA002 = "A002";
        public static string MSGA005 = "A005";
        public static string MSGA006 = "A006";

    }


}
