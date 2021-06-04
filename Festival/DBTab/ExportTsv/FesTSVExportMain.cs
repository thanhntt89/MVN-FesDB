using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Festival.DBTab.ExportTsv
{
    public partial class FesTSVExportMain : FormBase
    {
        private string logFilePathFestivalTSV = Properties.Settings.Default.FEST_TSV_LOG_PATH_ログファイル;
        private int totalCheckBox = 0;
        private int countChecked = 0;
        private string FILE_EXTENSION = string.Empty;
        private FesTsvExportBussiness fesExportBusiness;

        public FesTSVExportMain()
        {
            InitializeComponent();
            InitListExport();
            fesExportBusiness = new FesTsvExportBussiness();
            InitLayoutMain();
        }

        private void InitLayoutMain()
        {
            System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;

            if (this.Height > screenSize.Height)
            {
                this.Height = screenSize.Height;
            }
            if (this.Width > screenSize.Width)
            {
                this.Width = screenSize.Width;
            }
        }

        private void CreateFolderWork()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EXPORT_LOCAL_FOLDER_WORK))
                    return;

                // Delete All file in work folder
                Utils.DeleteAllFileInFolder(EXPORT_LOCAL_FOLDER_WORK);

                if (!Directory.Exists(EXPORT_LOCAL_FOLDER_WORK))
                {
                    Directory.CreateDirectory(EXPORT_LOCAL_FOLDER_WORK);
                }
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
            }
        }

        private void InitListExport()
        {
            exportCollection.Clear();

            FILE_EXTENSION = Properties.Settings.Default.TSV_EXTENSION_ファイル拡張子;

            if (chkSerialNumberOutput.Checked)
            {
                FILE_EXTENSION = FILE_EXTENSION.Replace(".", "");
                FILE_EXTENSION = string.Format("_" + numSerial.Value + ".{0}", FILE_EXTENSION);
            }

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = chkContents.Text,
                ExportModuleName = chkContents.Checked ? chkContents.Name : string.Empty,
                TabIndex = 1,
                //LogModulePathFile = Properties.Settings.Default.FES_EXPORT_CONTENT_INIT_LOG_PATH,
                // List file Export
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId = ExportFesContants.コンテンツ,
                        FileNameLocal = string.IsNullOrEmpty( Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_コンテンツ)? string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_コンテンツ + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                 new FileEntity()
                 {
                     FileExportId = ExportFesContants.コンテンツ_V2,
                     FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_V2_コンテンツ_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_V2_コンテンツ_V2 + FILE_EXTENSION,
                     LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                 },
                  new FileEntity()
                 {
                     FileExportId = ExportFesContants.TSV出力演奏時間Null補正対象,
                     FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FES_EXPORT_LOG_PATH_SERVER_FILE_CONTENT_EMPTY)?string.Empty: Path.GetFileName(Properties.Settings.Default.FES_EXPORT_LOG_PATH_SERVER_FILE_CONTENT_EMPTY),
                     LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue,
                        FileServerPath = Properties.Settings.Default.FES_EXPORT_LOG_PATH_SERVER_FILE_CONTENT_EMPTY
                 }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = chkSinger.Text,
                ExportModuleName = chkSinger.Checked ? chkSinger.Name : string.Empty,
                TabIndex = 2,
                // List file export of module
                Files = new List<FileEntity>()
            {
                    new FileEntity()
                    {
                        FileExportId = ExportFesContants.歌手,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_歌手)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_歌手 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.楽曲名英数読み,
                ExportModuleName = chkSongNameEnglishNumber.Checked ? chkSongNameEnglishNumber.Name : string.Empty,
                TabIndex = 3,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.楽曲名英数読み,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SONG_NAME_ENGLISH_NUMBER_楽曲名英数読み)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SONG_NAME_ENGLISH_NUMBER_楽曲名英数読み + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.楽曲名英数読み_V2,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SONG_NAME_ENGLISH_NUMBER_V2_楽曲名英数読み_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SONG_NAME_ENGLISH_NUMBER_V2_楽曲名英数読み_V2 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.歌い出し,
                ExportModuleName = chkStartSinging.Checked ? chkStartSinging.Name : string.Empty,
                TabIndex = 4,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.歌い出し,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_START_SINGING_歌い出し)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_START_SINGING_歌い出し + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.コンテンツランキング用,
                ExportModuleName = chkContentRanking.Checked ? chkContentRanking.Name : string.Empty,
                TabIndex = 5,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.コンテンツランキング用,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_RANKING_コンテンツランキング用)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_CONTENT_RANKING_コンテンツランキング用 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.年代別ランキング,
                ExportModuleName = chkRankingByAge.Checked ? chkRankingByAge.Name : string.Empty,
                TabIndex = 6,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.年代別ランキング,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_RANKING_BY_AGE_年代別ランキング)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_RANKING_BY_AGE_年代別ランキング + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.個別映像割付情報,
                ExportModuleName = chkIndividualVideoAllocationInformation.Checked ? chkIndividualVideoAllocationInformation.Name : string.Empty,
                TabIndex = 7,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.個別映像割付情報,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_ALLOCATION_個別映像割付情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_ALLOCATION_個別映像割付情報 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.ディスク追加削除曲,
                ExportModuleName = chkDiscAddedDeletedSongs.Checked ? chkDiscAddedDeletedSongs.Name : string.Empty,
                TabIndex = 8,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.ディスク追加削除曲,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADD_REMOVE_DIS_SONG_ディスク追加削除曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADD_REMOVE_DIS_SONG_ディスク追加削除曲 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.健康王国おすすめ曲,
                ExportModuleName = chkHealthyKingdomRecommendedSong.Checked ? chkHealthyKingdomRecommendedSong.Name : string.Empty,
                TabIndex = 9,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.健康王国おすすめ曲,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_HEALTHY_KINGDOM_RECOMMENDED_SONG_健康王国おすすめ曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_HEALTHY_KINGDOM_RECOMMENDED_SONG_健康王国おすすめ曲 + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.おすすめプログラムリスト,
                ExportModuleName = chkRecommendedProgramList.Checked ? chkRecommendedProgramList.Name : string.Empty,
                TabIndex = 10,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.おすすめプログラムリスト,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMENDED_PROGRAM_LIST_おすすめプログラムリスト)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMENDED_PROGRAM_LIST_おすすめプログラムリスト + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.収集リスト,
                ExportModuleName = chkCollectionList.Checked ? chkCollectionList.Name : string.Empty,
                TabIndex = 11,
                Files = new List<FileEntity>()
                {
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.収集リスト,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_COLLECTION_LIST_収集リスト)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_COLLECTION_LIST_収集リスト + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.サービス情報,
                ExportModuleName = chkServiceInformation.Checked ? chkServiceInformation.Name : string.Empty,
                TabIndex = 12,
                Files = new List<FileEntity>()
            {
                new FileEntity()
                {
                    FileExportId=ExportFesContants.サービス情報,
                    FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SERVICE_サービス情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SERVICE_サービス情報 + FILE_EXTENSION,
                    LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                },
                 new FileEntity()
                {
                    FileExportId=ExportFesContants.サービス情報_V2,
                    FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SERVICE_V2_サービス情報_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SERVICE_V2_サービス情報_V2 + FILE_EXTENSION,
                    LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                }
            }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.ジャンル情報,
                ExportModuleName = chkGenreInformation.Checked ? chkGenreInformation.Name : string.Empty,
                TabIndex = 13,
                Files = new List<FileEntity>()
            {
                new FileEntity()
                {
                    FileExportId=ExportFesContants.ジャンル情報,
                    FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_ジャンル情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_ジャンル情報 + FILE_EXTENSION,
                    LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                },
                 new FileEntity()
                {
                    FileExportId=ExportFesContants.ジャンル情報_V2,
                    FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_V2_ジャンル情報_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_V2_ジャンル情報_V2 + FILE_EXTENSION,
                    LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                }
            }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.歌手名英数読み,
                ExportModuleName = chkReadingSingerName.Checked ? chkReadingSingerName.Name : string.Empty,
                TabIndex = 14,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.歌手名英数読み,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_NAME_歌手名英数読み)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_NAME_歌手名英数読み + FILE_EXTENSION,
                        LocalFolderPath = EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.歌手ID変更履歴,
                ExportModuleName = chkSingerIDChangeHistory.Checked ? chkSingerIDChangeHistory.Name : string.Empty,
                TabIndex = 15,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.歌手ID変更履歴,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_ID_CHANGE_HISTORY_歌手ID変更履歴)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_ID_CHANGE_HISTORY_歌手ID変更履歴 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.歌手ランキング,
                ExportModuleName = chkSingerRanking.Checked ? chkSingerRanking.Name : string.Empty,
                TabIndex = 16,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.歌手ランキング,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_RANKING_歌手ランキング)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_SINGER_RANKING_歌手ランキング + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.更新日付,
                ExportModuleName = chkUpdateDate.Checked ? chkUpdateDate.Name : string.Empty,
                TabIndex = 17,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.更新日付,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_UPDATE_DATE_更新日付)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_UPDATE_DATE_更新日付 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.個別映像DISC収録情報,
                ExportModuleName = chkIndividualVideoDiscRecordingInformation.Checked ? chkIndividualVideoDiscRecordingInformation.Name : string.Empty,
                TabIndex = 18,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.個別映像DISC収録情報,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_DIS_RECORDING_個別映像DISC収録情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_DIS_RECORDING_個別映像DISC収録情報 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.個別映像DISC収録情報_V2,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_DIS_RECORDING_V2_個別映像DISC収録情報_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_INVIDUAL_VIDEO_DIS_RECORDING_V2_個別映像DISC収録情報_V2 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.個別映像ディスク追加削除情報,
                ExportModuleName = chkIndividualVideoDiscAdditionDeletionInformation.Checked ? chkIndividualVideoDiscAdditionDeletionInformation.Name : string.Empty,
                TabIndex = 19,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.個別映像ディスク追加削除情報,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_INDIVIDUAL_VIDEO_DISC_ADDITIONAL_DELETION_個別映像ディスク追加削除情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_INDIVIDUAL_VIDEO_DISC_ADDITIONAL_DELETION_個別映像ディスク追加削除情報 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.チャプター追加削除曲,
                ExportModuleName = chkAddDeleteChapterSongs.Checked ? chkAddDeleteChapterSongs.Name : string.Empty,
                TabIndex = 20,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.チャプター追加削除曲,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADD_REMOVE_CHAPTER_SONG_チャプター追加削除曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADD_REMOVE_CHAPTER_SONG_チャプター追加削除曲 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.おすすめプログラム名,
                ExportModuleName = chkRecommendedProgramName.Checked ? chkRecommendedProgramName.Name : string.Empty,
                TabIndex = 21,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.おすすめプログラム名,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMENDED_PROGRAM_おすすめプログラム名)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMENDED_PROGRAM_おすすめプログラム名 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.タイアップ情報,
                ExportModuleName = chkTieupInformation.Checked ? chkTieupInformation.Name : string.Empty,
                TabIndex = 22,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.タイアップ情報,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_タイアップ情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_タイアップ情報 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.タイアップ情報_V2,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_V2_タイアップ情報_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_V2_タイアップ情報_V2 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.ジャンルリスト,
                ExportModuleName = chkGenreList.Checked ? chkGenreList.Name : string.Empty,
                TabIndex = 23,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.ジャンルリスト,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_LIST_ジャンルリスト)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_LIST_ジャンルリスト + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.ジャンルリスト大,
                        FileNameLocal =string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_LARGE_LIST_ジャンルリスト大)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_LARGE_LIST_ジャンルリスト大 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                       new FileEntity()
                    {
                        FileExportId=ExportFesContants.ジャンルリスト中,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_IN_LIST_ジャンルリスト中)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_IN_LIST_ジャンルリスト中 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                       new FileEntity()
                    {
                        FileExportId=ExportFesContants.ジャンル説明文,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_DESCRIPTION_ジャンル説明文)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_GENRE_DESCRIPTION_ジャンル説明文 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                 }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.おすすめ曲,
                ExportModuleName = chkRecommendedSong.Checked ? chkRecommendedSong.Name : string.Empty,
                TabIndex = 24,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.おすすめ曲,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMEND_SONG_おすすめ曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_RECOMMEND_SONG_おすすめ曲 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.DISC版収録曲,
                ExportModuleName = chkDISCVersionSongs.Checked ? chkDISCVersionSongs.Name : string.Empty,
                TabIndex = 25,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.DISC版収録曲,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_DISC_VERSION_SONG_DISC版収録曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_DISC_VERSION_SONG_DISC版収録曲 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.DISC版収録曲_V2,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_DISC_VERSION_SONG_V2_DISC版収録曲_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_DISC_VERSION_SONG_V2_DISC版収録曲_V2 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.タイアップランキング,
                ExportModuleName = chkTieupRanking.Checked ? chkTieupRanking.Name : string.Empty,
                TabIndex = 26,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.タイアップランキング,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_RANKING_タイアップランキング)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_RANKING_タイアップランキング + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    },
                     new FileEntity()
                    {
                        FileExportId=ExportFesContants.タイアップランキング_V2,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_RANKING_V2_タイアップランキング_V2)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_TIEUP_RANKING_V2_タイアップランキング_V2 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });
            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.追加曲,
                ExportModuleName = chkAdditionalSongs.Checked ? chkAdditionalSongs.Name : string.Empty,
                TabIndex = 27,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.追加曲,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADDITION_SONG_追加曲)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_ADDITION_SONG_追加曲 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            exportCollection.Add(new TsvExportEntity
            {
                ExportModuleText = ExportFesContants.パッケージID情報,
                ExportModuleName = chkPackageIDInformation.Checked ? chkPackageIDInformation.Name : string.Empty,
                TabIndex = 28,
                Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.パッケージID情報,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_PACKAGE_ID_INFO_パッケージID情報)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_PACKAGE_ID_INFO_パッケージID情報 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
            });

            // コンテンツランキング用 OR 歌手ランキング OR タイアップランキング
            if (chkContentRanking.Checked || chkSingerRanking.Checked || chkTieupRanking.Checked)
                exportCollection.Add(new TsvExportEntity
                {
                    ExportModuleText = ExportFesContants.ランキング集計期間,
                    ExportModuleName = ExportFesContants.ランキング集計期間,
                    TabIndex = 28,
                    Files = new List<FileEntity>()
                {
                    new FileEntity()
                    {
                        FileExportId=ExportFesContants.ランキング集計期間,
                        FileNameLocal = string.IsNullOrEmpty(Properties.Settings.Default.FILE_NAME_FES_EXPORT_RANKING_AGGREGATION_PERIOD_ランキング集計期間)?string.Empty: Properties.Settings.Default.FILE_NAME_FES_EXPORT_RANKING_AGGREGATION_PERIOD_ランキング集計期間 + FILE_EXTENSION,
                        LocalFolderPath=EXPORT_LOCAL_FOLDER_WORK,
                        UploadTime = DateTime.MinValue
                    }
                }
                });
        }

        private void LoadCheckTabIndex()
        {
            if (exportCollection.Count == 0)
                return;

            foreach (Control ctrl in panelMain.Controls)
            {
                CheckBox chk = ctrl as CheckBox;
                if (chk == null)
                    continue;

                chk.Checked = true;

                if (chk.Name == chkCollectionList.Name)
                {
                    chk.Checked = false;
                }
                else
                    countChecked++;

                var exist = exportCollection.GetExportInfoByExportName(ctrl.Name);
                if (exist != null)
                {
                    chk.TabIndex = exist.TabIndex;
                    chk.CheckedChanged += Chk_CheckedChanged;

                }
            }

            totalCheckBox = countChecked;
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSelectAll.Checked)
            {
                countChecked = 0;
            }

            CheckBox chk = sender as CheckBox;
            if (chk == null)
            {
                return;
            }
            if (chk.Checked)
            {
                countChecked++;
            }
            else
            {
                if (countChecked > 0)
                    countChecked--;
            }

            if (countChecked == totalCheckBox)
            {
                chkSelectAll.CheckState = CheckState.Checked;
            }
            else if (countChecked > 0)
            {
                chkSelectAll.CheckState = CheckState.Indeterminate;
            }
            else if (countChecked == 0)
            {
                chkSelectAll.CheckState = CheckState.Unchecked;
            }
        }

        private void btnImportRanking_Click(object sender, EventArgs e)
        {
            FesTsvImportRanking fesTsvImportRanking = new FesTsvImportRanking();
            fesTsvImportRanking.ShowDialog();
        }

        private void btnTSVOutput_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessExport();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                LogException(error);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void btnConfirmLog_Click(object sender, EventArgs e)
        {
            OpenLog();
        }

        private void OpenLog()
        {
            try
            {
                if (!File.Exists(this.logFilePathFestivalTSV))
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE010), "ログファイル", this.logFilePathFestivalTSV), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Utils.OpenFileByNotepad(this.logFilePathFestivalTSV);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                LogException(error);

                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FesTSVExport_Load(object sender, EventArgs e)
        {
            LoadCheckTabIndex();
            LoadColor();
            LoadInit();
        }

        private void LoadColor()
        {
            lblImportRankingList.ForeColor = Color.Blue;
            label1.ForeColor = Color.Blue;
            lblConfirmDate.ForeColor = Color.Blue;
            lblCheckDataOutput.ForeColor = Color.Blue;
            lblConfirmNumberOfOutputFile.ForeColor = Color.Blue;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.CheckState == CheckState.Indeterminate)
                return;
            foreach (Control ctrl in panelMain.Controls)
            {
                CheckBox chk = ctrl as CheckBox;
                if (chk == null)
                    continue;
                {
                    chk.Checked = chkSelectAll.Checked;
                }
            }
        }

        private void LoadInit()
        {
            txtOutputPath.Text = Properties.Settings.Default.FES_EXPORT_FORLDER_SERVER_出力パス;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.FES_EXPORT_加算日))
                dtServicesDate.Value = DateTime.Now.AddDays(int.Parse(Properties.Settings.Default.FES_EXPORT_加算日));
            else
                dtServicesDate.Value = DateTime.Now;

        }

        private bool Valid()
        {
            if (!chkSelectAll.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE014), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkSelectAll.Focus();
                return false;
            }

            if (chkSongNameEnglishNumber.Checked && !chkContents.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE021), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkContents.Focus();
                return false;
            }

            if (chkReadingSingerName.Checked && !chkSinger.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE022), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkSinger.Focus();
                return false;
            }

            if (chkContentRanking.Checked && !chkContents.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE023), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkContents.Focus();
                return false;
            }

            if (chkSingerRanking.Checked && !chkSinger.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE024), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkSinger.Focus();
                return false;
            }

            if (chkTieupRanking.Checked && !chkTieupInformation.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE025), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkTieupInformation.Focus();
                return false;
            }

            if (chkSingerIDChangeHistory.Checked && (!chkSinger.Checked || !chkContents.Checked))
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE045), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkContents.Focus();
                return false;
            }

            if (chkAdditionalSongs.Checked && !chkServiceInformation.Checked)
            {
                MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGE046), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkContents.Focus();
                return false;
            }

            try
            {
                // おすすめ曲チェック
                DataTable dt = fesExportBusiness.SelectCountFesRecommendSong();
                if (dt.Rows[0][0] == null || dt.Rows.Count == 0 || int.Parse(dt.Rows[0][0].ToString()) == 0)
                {
                    MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGA003), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                // Rankingチェック
                DataTable dt2 = fesExportBusiness.SelectCountFesKaraokeYearRanking();
                if (dt2.Rows[0][0] == null || dt2.Rows.Count == 0 || int.Parse(dt2.Rows[0][0].ToString()) == 0)
                {
                    MessageBox.Show(GetResources.GetResourceMesssageTsv(Constants.MSGA004), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);
            }

            // 出力先が存在しない

            return true;
        }

        private void ProcessExport()
        {
            if (!Valid())
            {
                return;
            }

            // ログファイルを削除													
            DeleteLogFile();

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += ExportTSV_RunWorkerCompleted;
            bgwProcess.DoWork += ExportTSV_DoWork;
            bgwProcess.RunWorkerAsync();

            this.ShowWating();
        }

        private void ExportTSV_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Add log
            AddLog("【表示楽曲TSV出力開始】" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), MODULE_FES_TSV_EXPORT);
            // Process  csv              
            ExportExecute();
            // Add log
            AddLog("【表示楽曲TSV出力終了】" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), MODULE_FES_TSV_EXPORT);
        }

        private void ExportTSV_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= ExportTSV_RunWorkerCompleted;
                bgwProcess.DoWork -= ExportTSV_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
        }

        private void ExportExecute()
        {
            InitListExport();

            // Create folder work
            CreateFolderWork();

            // Create folder in server
            Utils.CreateDirectory(Properties.Settings.Default.FES_EXPORT_出力パス_V1);
            Utils.CreateDirectory(Properties.Settings.Default.FES_EXPORT_出力パス_V2);
            Utils.CreateDirectory(Properties.Settings.Default.FES_EXPORT_出力パス_V2_HDD);

            string dateTime = dtServicesDate.Value.ToString("yyyyMMdd");

            //0. Exception 
            ExportException(dateTime);

            //1. コンテンツ 2 Files
            if (chkContents.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkContents.Name);
                if (existItem == null)
                    return;

                existItem.DateTimeExport = dateTime;

                ExportContents(existItem);
            }


            //2.サービス情報  2 Files
            if (chkServiceInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkServiceInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportServiceInformation(existItem);
            }

            //3.ジャンル情報  2 Files
            if (chkGenreInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkGenreInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportGenreInformation(existItem);
            }

            //4.ジャンルリスト 3 Files
            if (chkGenreList.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkGenreList.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportGenreList(existItem);
            }

            //5.タイアップ情報 2 Files
            if (chkTieupInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkTieupInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportTieupInformation(existItem);
            }

            //6. 歌手 1 Files
            if (chkSinger.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkSinger.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportSinger(existItem);
            }

            //7.楽曲名英数読み 2 Files
            if (chkSongNameEnglishNumber.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkSongNameEnglishNumber.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportSongNameEnglishNumber(existItem);
            }

            //8.歌手名英数読み  1 Files
            if (chkReadingSingerName.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkReadingSingerName.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportReadingSingerName(existItem);
            }

            //9.おすすめ曲 1 Files
            if (chkRecommendedSong.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkRecommendedSong.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportRecommendedSong(existItem);
            }

            //10.歌い出し 1 Files
            if (chkStartSinging.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkStartSinging.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportStartSinging(existItem);
            }

            //11.歌手ID変更履歴  1 Files
            if (chkSingerIDChangeHistory.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkSingerIDChangeHistory.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportSingerIDChangeHistory(existItem);
            }

            //12.DISC版収録曲 2 Files
            if (chkDISCVersionSongs.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkDISCVersionSongs.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportDISCVersionSong(existItem);
            }

            //13.コンテンツランキング用  1 Files
            if (chkContentRanking.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkContentRanking.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportContentRanking(existItem);
            }

            //14.歌手ランキング  1 Files
            if (chkSingerRanking.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkSingerRanking.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportSingerRanking(existItem);
            }

            //15.タイアップランキング 2 Files
            if (chkTieupRanking.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkTieupRanking.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportTieupRanking(existItem);
            }

            //16.年代別ランキング  1 Files
            if (chkRankingByAge.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkRankingByAge.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportRankingByAge(existItem);
            }


            //17.更新日付  1 Files
            if (chkUpdateDate.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkUpdateDate.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportUpdateDate(existItem);
            }

            //18.ランキング集計期間
            if (chkContentRanking.Checked || chkRankingByAge.Checked || chkTieupRanking.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(ExportFesContants.ランキング集計期間);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportException(existItem);
            }

            //19.追加曲 1 Files
            if (chkAdditionalSongs.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkAdditionalSongs.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportAdditionalSong(existItem);
            }

            //20.個別映像割付情報  1 Files
            if (chkIndividualVideoAllocationInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkIndividualVideoAllocationInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportIndividualVideoAllocationInformation(existItem);
            }

            //21.個別映像DISC収録情報  2 Files
            if (chkIndividualVideoDiscRecordingInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkIndividualVideoDiscRecordingInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportIndividualVideoDiscRecordingInformation(existItem);
            }

            //22.パッケージID情報 1 Files
            if (chkPackageIDInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkPackageIDInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportPackageIDInformation(existItem);
            }


            //23.ディスク追加削除曲  1 Files
            if (chkDiscAddedDeletedSongs.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkDiscAddedDeletedSongs.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportDiscAddedDeletedSong(existItem);
            }

            //24.個別映像ディスク追加/削除情報  1 Files
            if (chkIndividualVideoDiscAdditionDeletionInformation.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkIndividualVideoDiscAdditionDeletionInformation.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportIndividualVideoDiscAdditionDeletionInformation(existItem);
            }

            //25.健康王国おすすめ曲  1 Files
            if (chkHealthyKingdomRecommendedSong.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkHealthyKingdomRecommendedSong.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportHealthyKingdomRecommendedSong(existItem);
            }

            //26.チャプター追加/削除曲 1 Files
            if (chkAddDeleteChapterSongs.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkAddDeleteChapterSongs.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportAddDeleteChapterSong(existItem);
            }


            //27.おすすめプログラムリスト  1 Files
            if (chkRecommendedProgramList.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkRecommendedProgramList.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportRecommendedProgramList(existItem);
            }


            //28.おすすめプログラム名 1 Files
            if (chkRecommendedProgramName.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkRecommendedProgramName.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportRecommendedProgramName(existItem);
            }

            //29.収集リスト  1 Files
            if (chkCollectionList.Checked)
            {
                var existItem = exportCollection.GetExportInfoByExportName(chkCollectionList.Name);
                if (existItem == null)
                    return;
                existItem.DateTimeExport = dateTime;
                ExportCollectionList(existItem);
            }

            // Create path file in server
            UploadFileToServer(exportCollection);

            // Display process
            DispayErrorByFlag(exportCollection);

            this.ClosedWaiting();

            Invoke(new Action(() =>
            {
                if (exportCollection.TotalFileUploaded > 0)
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGI001), Properties.Settings.Default.FES_EXPORT_FORLDER_SERVER_出力パス), GetResources.GetResourceMesssageTsv(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void DispayErrorByFlag(TsvExportCollection exportCollection)
        {
            if (exportCollection == null)
                return;

            TsvExportEntity contentExport = exportCollection.GetExportInfoByExportName(chkContents.Name);
            if (contentExport != null)
            {
                var file = contentExport.GetFileInfo(ExportFesContants.コンテンツ);
                if (file != null && file.IsContentsWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + " TSVに歌手IDが空のレコードがあります。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);

                var file2 = contentExport.GetFileInfo(ExportFesContants.コンテンツ_V2);
                if (file2 != null && file2.IsAddPlayTime && File.Exists(file2.FileServerPath))
                    MessageBox.Show(file2.FileServerPath + " TSVに歌手IDが空のレコードがあります。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 歌いだし
            TsvExportEntity startSinging = exportCollection.GetExportInfoByExportName(chkStartSinging.Name);
            if (startSinging != null)
            {
                var file = startSinging.GetFileInfo(ExportFesContants.歌い出し);
                if (file != null && file.IsStartSingWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + " TSVに歌いだしが空のレコードがあります。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // フリーズ警告
            TsvExportEntity additionSong = exportCollection.GetExportInfoByExportName(chkAdditionalSongs.Name);
            if (additionSong != null)
            {
                var file = startSinging.GetFileInfo(ExportFesContants.追加曲);
                if (file != null && file.IsAddSongWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + " 【フリーズ警告】直近6回の発表曲が3000件を超えています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Fes映像DISC管理
            TsvExportEntity individualVideo = exportCollection.GetExportInfoByExportName(chkIndividualVideoAllocationInformation.Name);
            if (individualVideo != null)
            {
                var file = individualVideo.GetFileInfo(ExportFesContants.個別映像割付情報);
                if (file != null && file.IsImageAllotmentWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + " Fes映像DISC管理に存在しない不正な背景映像コードが設定されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (file != null && file.IsDeleted && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + " Fes映像DISC追加削除管理に存在しない不正な背景映像コードが設定されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // DISC版収録曲
            TsvExportEntity disRecordSong = exportCollection.GetExportInfoByExportName(chkDISCVersionSongs.Name);
            if (disRecordSong != null)
            {
                var file = disRecordSong.GetFileInfo(ExportFesContants.DISC版収録曲);
                if (file != null && file.IsDiscRecordSongWarnFlg && File.Exists(file.FileServerPath))
                {
                    MessageBox.Show(file.FileServerPath + " DISCに搭載されていない曲があります。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var file2 = disRecordSong.GetFileInfo(ExportFesContants.DISC版収録曲_V2);
                if (file2 != null && file2.IsOutputNewVer && File.Exists(file.FileServerPath))
                {
                    MessageBox.Show(file2.FileServerPath + " DISCに搭載されていない曲があります。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //ディスク追加削除曲
            TsvExportEntity disAddDeleteSong = exportCollection.GetExportInfoByExportName(chkDiscAddedDeletedSongs.Name);
            if (disAddDeleteSong != null)
            {
                var file = disAddDeleteSong.GetFileInfo(ExportFesContants.ディスク追加削除曲);
                if (file != null && file.IsDiscAddDeleteSongWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + "  前回出力時よりデータの内容が変更・削除されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ディスク追加削除曲 V2
            TsvExportEntity disIndividualVideoAddDeleteSong = exportCollection.GetExportInfoByExportName(chkIndividualVideoDiscAdditionDeletionInformation.Name);
            if (disIndividualVideoAddDeleteSong != null)
            {
                var file = disIndividualVideoAddDeleteSong.GetFileInfo(ExportFesContants.個別映像ディスク追加削除情報);
                if (file != null && file.IsImageDiscAddDeleteWarnFlg && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + "  前回出力時よりデータの内容が変更・削除されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //チャプター追加削除曲
            TsvExportEntity addDeleteChapterSong = exportCollection.GetExportInfoByExportName(chkAddDeleteChapterSongs.Name);
            if (addDeleteChapterSong != null)
            {
                var file = addDeleteChapterSong.GetFileInfo(ExportFesContants.チャプター追加削除曲);
                if (file != null && file.IsFlagCheck && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + "  チャプターの設定がFesコンテンツとチャプター追加削除で不一致です。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (file != null && file.IsPreComp && File.Exists(file.FileServerPath))
                    MessageBox.Show(file.FileServerPath + "  前回出力時よりデータの内容が変更・削除されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // おすすめプログラムリスト
            TsvExportEntity recommendSongProgam = exportCollection.GetExportInfoByExportName(chkRecommendedProgramList.Name);
            if (recommendSongProgam != null)
            {
                var file = recommendSongProgam.GetFileInfo(ExportFesContants.おすすめプログラムリスト);
                if (file != null && file.IsRecommendProgramListWarnFlg)
                    MessageBox.Show(file.FileServerPath + "   おすすめ曲管理に存在しない不正なプログラムIDが設定されています。", GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create file path in server
        /// </summary>
        /// <param name="exportCollection"></param>
        private void UploadFileToServer(TsvExportCollection exportCollection)
        {
            try
            {
                if (exportCollection == null)
                    return;

                string serverFileNames = string.Empty;
                string localFileNames = string.Empty;
                string serverPath = string.Empty;

                // Valid V1
                serverPath = Properties.Settings.Default.FES_EXPORT_出力パス_V1;
                localFileNames = Properties.Settings.Default.FES_EXPORT_出力ファイルリスト_V1;
                serverFileNames = Properties.Settings.Default.FES_EXPORT_出力対象ファイルリネーム後名称_V1;

                if (ValidFileServerPath(serverPath, localFileNames, serverFileNames, exportCollection))
                {  // Execute copy file to server
                    ExecuteCopyFileToServer(exportCollection);
                }

                // Server file list
                serverFileNames = Properties.Settings.Default.FES_EXPORT_出力対象ファイルリネーム後名称_V2;
                // Local files list
                localFileNames = Properties.Settings.Default.FES_EXPORT_出力ファイルリスト_V2;
                // Server path
                serverPath = Properties.Settings.Default.FES_EXPORT_出力パス_V2;

                // Valid V2
                if (ValidFileServerPath(serverPath, localFileNames, serverFileNames, exportCollection))
                {  // Execute copy file to server
                    ExecuteCopyFileToServer(exportCollection);
                }

                // Valid V2HDD
                localFileNames = Properties.Settings.Default.FES_EXPORT_出力ファイルリスト_V2_HDD;
                serverFileNames = Properties.Settings.Default.FES_EXPORT_出力対象ファイルリネーム後名称_V2_HDD;
                serverPath = Properties.Settings.Default.FES_EXPORT_出力パス_V2_HDD;

                if (ValidFileServerPath(serverPath, localFileNames, serverFileNames, exportCollection))
                {
                    // Execute copy file to server
                    ExecuteCopyFileToServer(exportCollection);
                }
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
            }
        }

        /// <summary>
        /// Valid file and update new file server path
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="localFileNameList"></param>
        /// <param name="serverFileNameList"></param>
        /// <param name="exportCollection"></param>
        /// <returns></returns>
        private bool ValidFileServerPath(string serverPath, string localFileNameList, string serverFileNameList, TsvExportCollection exportCollection)
        {
            if (exportCollection == null || string.IsNullOrWhiteSpace(serverPath) || string.IsNullOrWhiteSpace(localFileNameList) || string.IsNullOrWhiteSpace(serverFileNameList))
                return false;

            List<string> LocalNameList = localFileNameList.Split(';').ToList();
            List<string> ServerNameList = serverFileNameList.Split(';').ToList();

            string serverFilePathUpdate = string.Empty;

            string fileExist = string.Empty;
            string fileWithExtention = string.Empty;

            string serverFileName = string.Empty;
            string localPath = string.Empty;

            int index = 0;

            var copyList = exportCollection.GetFilesExport();
            List<string> fileUpload = new List<string>();

            foreach (string localName in LocalNameList)
            {
                // File name in local with extention
                fileWithExtention = string.Format("{0}{1}", localName, FILE_EXTENSION);

                fileUpload.Add(fileWithExtention);

                // File name in server with extenttion
                serverFileName = string.Format("{0}{1}", index < ServerNameList.Count ? ServerNameList[index] : string.Empty, FILE_EXTENSION);

                // Check file exist on server
                serverFilePathUpdate = Properties.Settings.Default.FES_EXPORT_FORLDER_SERVER_出力パス + string.Format("{0}{1}", serverPath, serverFileName);

                localPath = EXPORT_LOCAL_FOLDER_WORK + fileWithExtention;

                if (File.Exists(serverFilePathUpdate) && File.Exists(localPath))
                {
                    fileExist += serverFileName + "\n";
                }

                // Update new server path to upload
                foreach (FileEntity fileInfo in copyList)
                {
                    if (fileInfo.FileNameLocal.Equals(fileWithExtention))
                    {
                        fileInfo.FileServerPath = string.IsNullOrEmpty(serverFileName) ? string.Empty : serverFilePathUpdate;
                        break;
                    }
                }

                index++;
            }

            // Reset upload file
            SetFileUploadStatus(fileUpload, exportCollection, true);

            if (!string.IsNullOrEmpty(fileExist))
            {
                fileExist = Path.GetDirectoryName(serverFilePathUpdate) + "\n" + fileExist;

                DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGA001), fileExist), GetResources.GetResourceMesssageTsv(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rst != DialogResult.Yes)
                {
                    // Set cancell upload file
                    SetFileUploadStatus(fileUpload, exportCollection, false);

                    return false;
                }
            }

            return true;
        }

        private void SetFileUploadStatus(List<string> listFileUpload, TsvExportCollection exportCollection, bool isUpload)
        {
            var copyList = exportCollection.GetFilesExport();

            foreach (string localName in listFileUpload)
            {
                foreach (FileEntity fileInfo in copyList)
                {
                    if (fileInfo.FileNameLocal.Equals(localName))
                    {
                        fileInfo.UploadTime = isUpload ? DateTime.MinValue : DateTime.Now;
                        fileInfo.IgNorUpload = !isUpload;
                    }
                }
            }
        }

        private void ExecuteCopyFileToServer(TsvExportCollection exportCollection)
        {
            try
            {
                var copyList = exportCollection.GetFilesExport();

                foreach (FileEntity file in copyList)
                {
                    if (string.IsNullOrEmpty(file.FileServerPath) || file.UploadTime != DateTime.MinValue || file.IgNorUpload)
                        continue;
                    if (Directory.Exists(Path.GetDirectoryName(file.FileServerPath)) && File.Exists(file.LocalFolderPath))
                    {
                        File.Copy(file.LocalFolderPath, file.FileServerPath, true);

                        file.UploadTime = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
            }
        }

        /// <summary>
        /// パッケージID情報
        /// </summary>
        /// <param name="existItem"></param>
        private void ExportPackageIDInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // おすすめプログラム名
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.パッケージID情報);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesPackageIdTable(exportInfo.DateTimeExport);

                exportTable = fesExportBusiness.SelectFesPackageIdAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    IsHeader = false,
                    FunctionName = ExportFesContants.パッケージID情報,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// おすすめ曲
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportRecommendedSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // おすすめプログラム名
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.おすすめ曲);

                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.TruncateFesRecommendSong();

                //Call SetFesRecommendSong
                exportTable = fesExportBusiness.SetFesRecommendSong(exportInfo.DateTimeExport);
                if (exportTable == null || exportTable.Rows.Count == 0)
                {
                    return;
                }

                string now_ymd = DateTime.Now.ToString("yyyyMMdd");

                //最終取込パスからファイル名取得し、パス生成
                string recommendSongFilePath = string.Format(Properties.Settings.Default.FES_EXPORT_RECOMEND_SONG_LOCAL_PATH_おすすめ曲 + "{0}_TBLInsert{1}", now_ymd, Constants.EXTENTION_TXT);

                // Create file with 20 columns
                TsvConvert.CreateRecommendSongFile(recommendSongFilePath, exportTable);

                //ワークテーブルの内容削除
                fesExportBusiness.TruncadeRecommendSong();

                // Copy Recommend file to server                
                string server_filePath = string.Format(Properties.Settings.Default.FES_EXPORT_RECOMEND_SONG_SERVER_PATH_読替おすすめ曲取込配置ファイル, Properties.Settings.Default.CONNECT_Server);

                // Copy file to server
                File.Copy(recommendSongFilePath, server_filePath, true);

                // Bulk insert
                fesExportBusiness.BulkInsertRecommendSong(server_filePath);

                // Delete file in server おすすめ曲取込ファイルがあれば削除
                File.Delete(server_filePath);

                exportTable = fesExportBusiness.SelectFesRecomendSongAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    IsHeader = false,
                    FunctionName = ExportFesContants.おすすめ曲,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// おすすめプログラム名
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportRecommendedProgramName(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // おすすめプログラム名
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.おすすめプログラム名);

                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesRecommendProgramNameTable();

                exportTable = fesExportBusiness.SelectFesRecommendProgramNameAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    IsHeader = false,
                    FunctionName = ExportFesContants.おすすめプログラム名,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// チャプター追加削除曲
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportAddDeleteChapterSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // チャプター追加削除曲
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.チャプター追加削除曲);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesChapterAddDeleteSongTable();

                    exportTable = fesExportBusiness.SelectFesChapterAddDeleteSongAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.チャプター追加削除曲,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                //チャプターフラグ整合性チェック
                exportTable = fesExportBusiness.SelectFesChapterAddDeleteChapterSong();

                if (exportTable != null && exportTable.Rows.Count > 0)
                {
                    string strChapterAddDeleteSongCheckPath_FlagCheck = Properties.Settings.Default.FES_EXPORT_チャプター追加削除曲フラグチェックファイルパス;
                    exportInfo.SetStatusFileFlagCheck(ExportFesContants.チャプター追加削除曲, true);

                    fesExportBusiness.ExportChapterAddDeleteSongFlagTimeCheck(strChapterAddDeleteSongCheckPath_FlagCheck, exportTable);
                }



                //前回チャプター追加/削除曲TSV取込
                string strFilePath_Before = Properties.Settings.Default.FES_EXPORT_前回チャプター追加削除曲TSVパス;
                //前回ファイルがない場合は取込処理をしない
                if (!File.Exists(strFilePath_Before))
                {
                    return;
                }

                string strFilePath_Server = Properties.Settings.Default.FES_EXPORT_チャプター追加削除曲取込ファイル;

                fesExportBusiness.TruncateFesLastChapterAddRemoveSong();
                File.Copy(strFilePath_Before, strFilePath_Server, true);
                FileUtils.ConvertUTF8toShiftjis(strFilePath_Server);
                fesExportBusiness.BulkInsertFesLastChapterAddRemoveSong(strFilePath_Server);

                File.Delete(strFilePath_Before);
                File.Delete(strFilePath_Server);

                exportTable = fesExportBusiness.SelectFesChapterAddRemoveChapterSong();

                if (exportTable != null && exportTable.Rows.Count > 0)
                {
                    string strChapterAddDeleteSongCheckPath_PreComp = Properties.Settings.Default.FES_EXPORT_チャプター追加削除曲前回チェックファイルパス;

                    exportInfo.SetStatusFilePreComp(ExportFesContants.チャプター追加削除曲, true);

                    fesExportBusiness.ExportChapterAddDeleteSongLastTimeCheck(strChapterAddDeleteSongCheckPath_PreComp, exportTable);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 個別映像ディスク追加削除情報
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportIndividualVideoDiscAdditionDeletionInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 個別映像ディスク追加削除情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.個別映像ディスク追加削除情報);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesImageDiscAddDeleteTable();

                exportTable = fesExportBusiness.SelectFesImageDiscAddDeleteAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    IsHeader = false,
                    FunctionName = ExportFesContants.個別映像ディスク追加削除情報,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                string strFilePath_Before = Properties.Settings.Default.FES_EXPORT_前回個別映像ディスク追加削除情報TSVパス;

                //Check file exist
                if (!File.Exists(strFilePath_Before))
                {
                    return;
                }

                // Truncade table tbl_Fes前回DISC追加削除曲]
                fesExportBusiness.TruncateFesPreviousIndividualVideoDiscAddionalDeletedInfomation();

                // Copy file to server
                string strFilePath_Server = Properties.Settings.Default.FES_EXPORT_個別映像ディスク追加削除情報取込ファイル;
                File.Copy(strFilePath_Before, strFilePath_Server, true);
                // Bulk insert
                FileUtils.ConvertUTF8toShiftjis(strFilePath_Server);
                fesExportBusiness.BulkInsertFesPreviousIndividualVideoDiscAddionalDeletedInfomation(strFilePath_Server);

                try
                {
                    File.Delete(strFilePath_Before);
                    File.Delete(strFilePath_Server);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity()
                    {
                        LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                        ErrorMessage = ex.Message,
                        ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                        FilePath = this.logExceptionPath
                    };

                    this.LogException(error);
                }

                //SelectFesAddRemoveSong
                exportTable = fesExportBusiness.SelectFesChapterAddDeleteManagement();

                if (exportTable != null && exportTable.Rows.Count > 0)
                {
                    exportInfo.SetStatusImageDiscAddDeleteWarningFlag(ExportFesContants.個別映像ディスク追加削除情報, true);
                    string filePath = Properties.Settings.Default.FES_EXPORT_個別映像ディスク追加削除情報チェックファイルパス;
                    fesExportBusiness.ExportChapterAddDeleteSongLastTimeCheck(filePath, exportTable);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 個別映像DISC収録情報
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportIndividualVideoDiscRecordingInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 個別映像DISC収録情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.個別映像DISC収録情報);
                exportInfo.ExportModuleText = ExportFesContants.個別映像DISC収録情報;
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesImageDiskTable();
                    exportTable = fesExportBusiness.SelectFesImageDiskAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = exportInfo.ExportModuleText,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.個別映像DISC収録情報_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesImageDiskTableAutoByAddDelete();

                    exportTable = fesExportBusiness.SelectFesImageDiskAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.個別映像DISC収録情報_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 歌手ランキング
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportSingerRanking(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 個別映像DISC収録情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.歌手ランキング);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }
                fesExportBusiness.CreateFesSingerRankTable();
                exportTable = fesExportBusiness.SelectFesSingerRankAll();
                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    FunctionName = ExportFesContants.歌手ランキング,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);
                //更新日時TSV出力用に出力日時をテーブルに保存	
                // ワークテーブルの内容削除
                fesExportBusiness.TruncateUpdateDateSinger();
                // Update singer_ranking 更新
                fesExportBusiness.UpdateUpdateDateSingerTable();
                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 歌手ID変更履歴 hailt
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportSingerIDChangeHistory(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 前回ファイルがない場合は取込処理をしない
                string strFilePath_Before = Properties.Settings.Default.FES_EXPORT_歌手変更履歴取得元コンテンツTSVパス;
                exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, CheckSingerIDChangeHistory(strFilePath_Before));
                //前回歌手TSV取込
                PreviousSingerTSVImport(exportInfo);
                //前回コンテンツTSV取込
                PreviousContentTSVImport(exportInfo);
                //tbl_Fes歌手ID変更履歴更新
                FesSingerIdChangeHistoryUpdate(exportInfo);
                // 個別映像DISC収録情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.歌手ID変更履歴);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }
                fesExportBusiness.CreateFesSingerIDChangeHistryTable();
                exportTable = fesExportBusiness.SelectFesSingerIDChangeHistryAll();
                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,
                    FunctionName = ExportFesContants.歌手ID変更履歴,
                    LogPathFile = logFesTsvExportPath
                };
                TsvConvert.ExportToTSV(fileInfo);
                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// tbl_Fes歌手ID変更履歴更新
        /// </summary>
        /// <param name="exportInfo"></param>
        private void FesSingerIdChangeHistoryUpdate(TsvExportEntity exportInfo)
        {
            try
            {
                if (!exportInfo.GetFileInfo(ExportFesContants.歌手ID変更履歴).IsUpdateTake)
                {
                    return;
                }

                fesExportBusiness.InsertFesSingerIdChangeHistoryUpdate();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
            }
        }

        /// <summary>
        /// 前回コンテンツTSV取込
        /// </summary>
        /// <param name="exportInfo"></param>
        private void PreviousContentTSVImport(TsvExportEntity exportInfo)
        {
            try
            {
                string strFilePath_Before = Properties.Settings.Default.FES_EXPORT_歌手変更履歴取得元コンテンツTSVパス;
                if (!File.Exists(strFilePath_Before) || !exportInfo.GetFileInfo(ExportFesContants.歌手ID変更履歴).IsUpdateTake)
                {
                    exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, false);
                    return;
                }
                exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, true);
                string strFilePath_Server = Properties.Settings.Default.FES_EXPORT_コンテンツ取込配置ファイル;
                fesExportBusiness.TruncateFesLastContent();
                File.Copy(strFilePath_Before, strFilePath_Server, true);
                FileUtils.ConvertUTF8toShiftjis(strFilePath_Server);

                fesExportBusiness.BulkInsertFesLastContent(strFilePath_Server);
                File.Delete(strFilePath_Before);
                File.Delete(strFilePath_Server);
            }
            catch (Exception ex)
            {
                exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, false);

                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
            }
        }

        /// <summary>
        /// //前回歌手TSV取込
        /// </summary>
        /// <param name="exportInfo"></param>
        private void PreviousSingerTSVImport(TsvExportEntity exportInfo)
        {
            try
            {
                string strFilePath_Before = Properties.Settings.Default.FES_EXPORT_歌手変更履歴取得元歌手TSVパス;

                if (!File.Exists(strFilePath_Before) || !exportInfo.GetFileInfo(ExportFesContants.歌手ID変更履歴).IsUpdateTake)
                {
                    exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, false);
                    return;
                }

                exportInfo.SetStatusFileUpdateTake(ExportFesContants.歌手ID変更履歴, true);
                string strFilePath_Server = Properties.Settings.Default.FES_EXPORT_歌手取込配置ファイル;
                fesExportBusiness.TruncateFesLastSinger();
                File.Copy(strFilePath_Before, strFilePath_Server, true);
                FileUtils.ConvertUTF8toShiftjis(strFilePath_Server);

                fesExportBusiness.BulkInsertFesLastSinger(strFilePath_Server);
                File.Delete(strFilePath_Before);
                File.Delete(strFilePath_Server);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
            }
        }

        private bool CheckSingerIDChangeHistory(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            var dataAll = File.ReadAllLines(filePath);
            var countTotalLine = dataAll.Count();
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length == 0 ||
                (fileInfo.Length > 0
                && !dataAll.Where(dat => !String.IsNullOrWhiteSpace(dat.Trim())).Any())
            )
            {
                return false;
            }

            int comLumns = dataAll[0].Split('\t').Count();
            var dataRow = dataAll[0].Split('\t');
            if (comLumns != 13)
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssageTsv(Constants.MSGE040)), GetResources.GetResourceMesssageTsv(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// おすすめプログラムリスト
        /// </summary>
        /// <param name="existItem"></param>
        private void ExportRecommendedProgramList(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.おすすめプログラムリスト);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesRecommendProgramListTable(exportInfo.DateTimeExport);
                exportTable = fesExportBusiness.SelectFesRecommendProgramListAll();
                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,

                    FunctionName = ExportFesContants.おすすめプログラムリスト,
                    LogPathFile = logFesTsvExportPath
                };
                TsvConvert.ExportToTSV(fileInfo);
                exportTable = fesExportBusiness.SelectProgramId();
                if (exportTable == null || exportTable.Rows.Count == 0)
                    return;
                if (exportTable != null && exportTable.Rows.Count > 0)
                {
                    exportInfo.SetStatusRecommendProgramListWarningFlag(ExportFesContants.おすすめプログラムリスト, true);
                    string filePath = Properties.Settings.Default.FES_EXPORT_おすすめプログラムリストチェックファイルパス;
                    fesExportBusiness.ExportRecommendSong(filePath, exportTable);
                }
                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 健康王国おすすめ曲
        /// </summary>
        /// <param name="existItem"></param>
        private void ExportHealthyKingdomRecommendedSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.健康王国おすすめ曲);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesHealthyKingdomRecommendSongTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesHealthyKingdomRecommendSongAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        FunctionName = ExportFesContants.健康王国おすすめ曲,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// ディスク追加/削除曲
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportDiscAddedDeletedSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.ディスク追加削除曲);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesDiscSongAddDeleteTable();

                    exportTable = fesExportBusiness.SelectFesDiscSongAddDeleteAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.ディスク追加削除曲,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                string filePath = Properties.Settings.Default.FES_EXPORT_LOCAL_PATH_前回ディスク追加削除曲TSVパス;

                //Check file exist
                if (!File.Exists(filePath))
                {
                    return;
                }

                // Truncade table tbl_Fes前回DISC追加削除曲]
                fesExportBusiness.TruncadeFesLastTimeDiscAddDeletedSongTable();

                // Copy file to server
                string serverFile = Properties.Settings.Default.FES_EXPORT_SERVER_PATH_ディスク追加削除曲取込ファイル;

                File.Copy(filePath, serverFile, true);
                // Bulk 
                FileUtils.ConvertUTF8toShiftjis(serverFile);
                fesExportBusiness.BulkInsertFesLastTimeDiscAddDeletedSongTable(serverFile);

                try
                {
                    File.Delete(filePath);
                    File.Delete(serverFile);
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity()
                    {
                        LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                        ErrorMessage = ex.Message,
                        ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                        FilePath = this.logExceptionPath
                    };

                    this.LogException(error);
                }

                exportTable = fesExportBusiness.SelectFesDISCAddRemoveSong();

                if (exportTable != null && exportTable.Rows.Count > 0)
                {
                    exportInfo.SetStatusDiscAddDeleteSongWarningFlag(ExportFesContants.ディスク追加削除曲, true);

                    string filePathExport = Properties.Settings.Default.FES_EXPORT_ディスク追加削除曲チェックファイルパス;

                    fesExportBusiness.ExportChapterAddDeleteSongLastTimeCheck(filePathExport, exportTable);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        //個別映像割付情報
        private void ExportIndividualVideoAllocationInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.個別映像割付情報);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesImageAllotmentTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesImageAllotmentAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.個別映像割付情報,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);

                    // 背景映像コード整合性チェック
                    string strImageAllotmentCheckPath = Properties.Settings.Default.FES_EXPORT_背景映像コードチェックファイルパス_V1;
                    if (!string.IsNullOrEmpty(strImageAllotmentCheckPath))
                    {
                        exportTable = fesExportBusiness.SelectFesVideoAllocationWarning();

                        if (exportTable != null && exportTable.Rows.Count > 0)
                        {
                            exportInfo.SetStatusImageAllotmentWarningFlag(ExportFesContants.個別映像割付情報, true);
                            StringBuilder logContent = new StringBuilder();

                            logContent.AppendLine(string.Format("下記のデジドコNoは、個別映像DISC収録情報の設定上、使用できない背景映像コードを設定しています。({0}) \n デジドコNo", DateTime.Now));

                            foreach (DataRow row in exportTable.Rows)
                            {
                                if (row[0] != null)
                                    logContent.AppendLine("[" + row[0].ToString() + "][" + row[1].ToString() + "]");
                            }

                            LogWriter.Write(strImageAllotmentCheckPath, logContent.ToString());
                        }
                    }

                    // 個別映像ディスク追加削除情報整合性チェック
                    string strImageAllotmentCheckPath_AddDelete = Properties.Settings.Default.FES_EXPORT_背景映像コードチェックファイルパス_V2;
                    if (!string.IsNullOrEmpty(strImageAllotmentCheckPath_AddDelete))
                    {
                        exportTable = fesExportBusiness.SelectFesVideoAllocationDeleted();

                        if (exportTable != null && exportTable.Rows.Count > 0)
                        {
                            exportInfo.SetStatusFileDelete(ExportFesContants.個別映像割付情報, true);

                            StringBuilder logContent = new StringBuilder();

                            logContent.AppendLine(string.Format("下記のデジドコNoは、個別映像DISC収録情報の設定上、使用できない背景映像コードを設定しています。({0}) \n デジドコNo", DateTime.Now));

                            foreach (DataRow row in exportTable.Rows)
                            {
                                if (row[0] != null)
                                    logContent.AppendLine("[" + row[0].ToString() + "][" + row[1].ToString() + "]");
                            }

                            LogWriter.Write(strImageAllotmentCheckPath_AddDelete, logContent.ToString());
                        }
                    }
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// コンテンツランキング用
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportContentRanking(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.コンテンツランキング用);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesContentsRankTable();

                exportTable = fesExportBusiness.SelectFesContentsRankAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,

                    FunctionName = ExportFesContants.コンテンツランキング用,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                // 更新日時TSV出力用に出力日時をテーブルに保存
                // ワークテーブルの内容削除
                fesExportBusiness.TruncateFesUpdateContentTable();

                // WUcontents_ranking 更新
                fesExportBusiness.UpdateFesUpdateContentTable();

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// ジャンル情報
        /// </summary>
        private void ExportException(string dateTime)
        {
            try
            {
                fesExportBusiness.CreateFesGenreTable(dateTime);
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
            }
        }

        // ランキング集計期間
        private void ExportException(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.ランキング集計期間);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesRankSumDurationTable();

                    exportTable = fesExportBusiness.SelectFesRankSumDurationAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.ランキング集計期間,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// コンテンツ
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportContents(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();
            try
            {
                // コンテンツ
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.コンテンツ);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesContentsTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesContentsAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.コンテンツ,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);

                    exportTable = fesExportBusiness.GetFesService();

                    if (exportTable.Rows.Count > 0)
                    {
                        exportInfo.SetStatusContentWarningFlag(ExportFesContants.コンテンツ, true);
                        StringBuilder logContent = new StringBuilder();

                        logContent.AppendLine(string.Format("{0} TSVの下記のデジドコNoは、歌手IDが空です。({1}) \n デジドコNo", exportInfo.GetFileInfo(ExportFesContants.コンテンツ).LocalFolderPath, DateTime.Now));

                        foreach (DataRow row in exportTable.Rows)
                        {
                            if (row[0] != null)
                                logContent.AppendLine(row[0].ToString());
                        }

                        LogWriter.Write(exportInfo.LogModulePathFile, logContent.ToString());
                    }
                }

                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.コンテンツ_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    // コンテンツ_V2
                    fesExportBusiness.CreateFesContentsTableAddPlayTime(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesContentsAllAddPlayTime();

                    FileExportTsvEntity fileInfo2 = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,

                        FunctionName = ExportFesContants.コンテンツ_V2,
                        LogPathFile = logFesTsvExportPath,
                        IsWriteLog = true,
                        LogPathFile1 = string.IsNullOrWhiteSpace(Properties.Settings.Default.FES_EXPORT_LOG_PATH_SERVER_FILE_CONTENT_EMPTY) ? string.Empty : string.Format("{0}/{1}", EXPORT_LOCAL_FOLDER_WORK, Path.GetFileName(Properties.Settings.Default.FES_EXPORT_LOG_PATH_SERVER_FILE_CONTENT_EMPTY))
                    };

                    TsvConvert.ExportToTSV(fileInfo2);

                    exportTable = fesExportBusiness.GetFesContentAddPlayTime();

                    if (exportTable.Rows.Count > 0)
                    {
                        exportInfo.SetStatusFileAddPlayTime(ExportFesContants.コンテンツ_V2, true);

                        StringBuilder logContent = new StringBuilder();

                        logContent.AppendLine(string.Format("{0} TSVの下記のデジドコNoは、歌手IDが空です。（{1} ）デジドコNo", exportInfo.GetFileInfo(ExportFesContants.コンテンツ_V2).LocalFolderPath, DateTime.Now));

                        foreach (DataRow row in exportTable.Rows)
                        {
                            if (row[0] != null)
                                logContent.AppendLine(row[0].ToString());
                        }

                        LogWriter.Write(exportInfo.LogModulePathFile, logContent.ToString());
                    }
                }

                exportTable = null;

                GC.Collect();

            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 歌手
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportSinger(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.歌手);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesSingerTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesSingerAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.歌手,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 楽曲名英数読み
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportSongNameEnglishNumber(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 楽曲名英数読み
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.楽曲名英数読み);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesSongNameEisuuTable();

                    exportTable = fesExportBusiness.SelectFesSongNameEisuuAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.楽曲名英数読み,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.楽曲名英数読み_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesSongNameEisuuTableAddEisuuHosei();

                    exportTable = fesExportBusiness.SelectFesSongNameEisuuAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,

                        FunctionName = ExportFesContants.楽曲名英数読み_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 歌い出し
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportStartSinging(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 歌い出し
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.歌い出し);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesSingStartTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesSingStartAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.歌い出し,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);

                    exportTable = fesExportBusiness.SelectFesSing();

                    if (exportTable.Rows.Count > 0)
                    {
                        exportInfo.SetStatusStartSingingWarningFlag(ExportFesContants.歌い出し, true);
                        StringBuilder logContent = new StringBuilder();

                        logContent.AppendLine(string.Format("{0} TSVの下記のデジドコNoは、歌手IDが空です。({1}) \n デジドコNo", exportInfo.GetFileInfo(ExportFesContants.歌い出し).FileServerPath, DateTime.Now));

                        foreach (DataRow row in exportTable.Rows)
                        {
                            if (row[0] != null)
                                logContent.AppendLine(row[0].ToString());
                        }

                        LogWriter.Write(Properties.Settings.Default.FES_EXPORT_歌いだしチェックファイルパス, logContent.ToString());
                    }
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 年代別ランキング
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportRankingByAge(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 歌手
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.年代別ランキング);
                if (fileV1 == null || !fileV1.FileNameExist || !fileV1.FolderWorkExist)
                {
                    return;
                }

                fesExportBusiness.CreateFesAgeDistinctionTable(exportInfo.DateTimeExport);


                // 年代順に書き換え SetFesKaraokeYearRanking
                fesExportBusiness.SetKaraokeYearRanking();

                exportTable = fesExportBusiness.SelectFesAgeDistinctionAll();

                FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                {
                    DataExport = exportTable,
                    FilePath = fileV1.LocalFolderPath,

                    FunctionName = ExportFesContants.年代別ランキング,
                    LogPathFile = logFesTsvExportPath
                };

                TsvConvert.ExportToTSV(fileInfo);

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 収集リスト
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportCollectionList(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 収集リスト
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.収集リスト);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFileGetListTable();

                    exportTable = fesExportBusiness.SelectFileGetListAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.収集リスト,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// サービス情報
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportServiceInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // サービス情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.サービス情報);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesServiceTable(exportInfo.DateTimeExport);

                    exportTable = fesExportBusiness.SelectFesServiceAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.サービス情報,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // サービス情報V2
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.サービス情報_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    string day = Properties.Settings.Default.FES_EXPORT_DATE_TIME_IN_PUT_最新追加フラグ設定基準日数;

                    fesExportBusiness.CreateFesServiceTableAddNewAddFlag(exportInfo.DateTimeExport, day);

                    exportTable = fesExportBusiness.SelectFesServiceAllAddNewAddFlag();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,

                        FunctionName = ExportFesContants.サービス情報_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// ジャンル情報
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportGenreInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // サービス情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.ジャンル情報);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesGenreAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V1);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,

                        FunctionName = ExportFesContants.ジャンル情報,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // サービス情報V2
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.ジャンル情報_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesGenreAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,

                        FunctionName = ExportFesContants.ジャンル情報_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 歌手名英数読み
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportReadingSingerName(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 収集リスト
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.歌手名英数読み);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesSingerEisuuTable();

                    exportTable = fesExportBusiness.SelectFesSingerEisuuAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.歌手名英数読み,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 更新日付
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportUpdateDate(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 収集リスト
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.更新日付);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesUpdateTable();

                    exportTable = fesExportBusiness.SelectFesUpdateAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.更新日付,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// タイアップ情報
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportTieupInformation(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // タイアップ情報
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.タイアップ情報);
                // タイアップ情報V2
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.タイアップ情報_V2);

                // 「Workタイアップ情報」又は「Workタイアップ情報_V2」は空白ではない場合
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist || fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                    fesExportBusiness.CreateFesTieupTable(exportInfo.DateTimeExport);

                //タイアップ情報
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {

                    exportTable = fesExportBusiness.SelectFesTieupAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V1);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.タイアップ情報,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                //タイアップ情報_V2
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesTieupAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.タイアップ情報_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// ジャンルリスト
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportGenreList(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // ジャンルリスト
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.ジャンルリスト);
                // ジャンルリスト大
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.ジャンルリスト大);
                // ジャンルリスト中
                var fileV3 = exportInfo.GetFileInfo(ExportFesContants.ジャンルリスト中);


                // 「Workタイアップ情報」又は「Workタイアップ情報_V2」は空白ではない場合
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist || fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist || fileV3 != null && fileV2.FileNameExist && fileV3.FolderWorkExist)
                    fesExportBusiness.CreateFesGenreListTable();

                // ジャンル説明文
                var fileV4 = exportInfo.GetFileInfo(ExportFesContants.ジャンル説明文);
                // 「Workジャンル説明文」は空白ではない場合：
                if (fileV4 != null && fileV4.FolderWorkExist && fileV4.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesGenreDescriptionTable();
                }

                //Export v1: ジャンルリスト
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesGenreListAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V1);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.ジャンルリスト,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // Export V2: ジャンルリスト大
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesLClassGenreListAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.ジャンルリスト大,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // Export V3: ジャンルリスト中
                if (fileV3 != null && fileV3.FileNameExist && fileV3.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesMClassGenreListAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV3.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.ジャンルリスト中,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // Export V4: ジャンル説明文
                if (fileV4 != null && fileV4.FileNameExist && fileV4.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesGenreDescriptionAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV4.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.ジャンル説明文,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// DISC版収録曲
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportDISCVersionSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // DISC版収録曲
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.DISC版収録曲);
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    fesExportBusiness.CreateFesDiscRecordSongTable(exportInfo.DateTimeExport, Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V1);

                    exportTable = fesExportBusiness.SelectFesDiscRecordSongAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.DISC版収録曲,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);

                    //Get FesDISCversionsongs
                    exportTable = fesExportBusiness.GetFesDisVersionSongV1();

                    if (exportTable.Rows.Count > 0)
                    {
                        exportInfo.SetStatusDiscRecordSongWarningFlag(ExportFesContants.DISC版収録曲, true);
                        StringBuilder logContent = new StringBuilder();

                        logContent.AppendLine(string.Format("{0}  TSVの下記のデジドコNoは、DISCに搭載されていません。（{1}）デジドコNo \n[ディスクID]", exportInfo.GetFileInfo(ExportFesContants.DISC版収録曲).FileServerPath, DateTime.Now));

                        foreach (DataRow row in exportTable.Rows)
                        {
                            if (row[0] != null)
                                logContent.AppendLine("[" + row[0].ToString() + "][" + row[1].ToString() + "]");
                        }

                        LogWriter.Write(Properties.Settings.Default.FES_EXPORT_DISC_版収録曲チェックファイルパス_V1, logContent.ToString());
                    }
                }

                // DISC版収録曲V2
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.DISC版収録曲_V2);
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    // コンテンツ_V2
                    fesExportBusiness.CreateFesDiscRecordSongTable(exportInfo.DateTimeExport, Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    exportTable = fesExportBusiness.SelectFesDiscRecordSongAll();

                    FileExportTsvEntity fileInfo2 = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.DISC版収録曲_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo2);

                    exportTable = fesExportBusiness.GetFesDisVersionSongV2();

                    if (exportTable.Rows.Count > 0)
                    {
                        exportInfo.SetStatusFileOutputNewVer(ExportFesContants.DISC版収録曲_V2, true);

                        StringBuilder logContent = new StringBuilder();

                        logContent.AppendLine(string.Format("{0}  TSVの下記のデジドコNoは、DISCに搭載されていません。（{1}）デジドコNo \n[ディスクID]", exportInfo.GetFileInfo(ExportFesContants.DISC版収録曲_V2).FileServerPath, DateTime.Now));

                        foreach (DataRow row in exportTable.Rows)
                        {
                            if (row[0] != null)
                                logContent.AppendLine("[" + row[0].ToString() + "][" + row[1].ToString() + "]");
                        }

                        LogWriter.Write(Properties.Settings.Default.FES_EXPORT_DISC_版収録曲チェックファイルパス_V2, logContent.ToString());
                    }

                    exportTable = null;

                    GC.Collect();
                }

            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// タイアップランキング
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportTieupRanking(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // タイアップランキング
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.タイアップランキング);
                // タイアップランキング_V2
                var fileV2 = exportInfo.GetFileInfo(ExportFesContants.タイアップランキング_V2);

                // 「Workタイアップランキング」又は「Workタイアップランキング_V2」は空白ではない場合：
                if (fileV1 != null && fileV1.FolderWorkExist || fileV2 != null && fileV2.FolderWorkExist)
                    fesExportBusiness.CreateFesTieupRankTable();

                // タイアップランキング
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesTieupRankAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V1);

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.タイアップランキング,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);
                }

                // タイアップランキング_V2
                if (fileV2 != null && fileV2.FileNameExist && fileV2.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesTieupRankAll(Properties.Settings.Default.FES_EXPORT_VERSION_NUMBER_V2);

                    FileExportTsvEntity fileInfo2 = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV2.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.タイアップランキング_V2,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo2);

                    // 「Workタイアップランキング」又は「Workタイアップランキング_V2」は空白ではない場合：    
                    // ワークテーブルの内容削除
                    fesExportBusiness.TruncateFesUpdateDateTimeTieUp();

                    //tieup_ranking更新
                    fesExportBusiness.UpdateFesUpdateDateTimeTieUp();
                }

                exportTable = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };

                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        /// <summary>
        /// 追加曲
        /// </summary>
        /// <param name="exportInfo"></param>
        private void ExportAdditionalSong(TsvExportEntity exportInfo)
        {
            DataTable exportTable = new DataTable();

            try
            {
                // 追加曲
                var fileV1 = exportInfo.GetFileInfo(ExportFesContants.追加曲);
                if (fileV1 != null && fileV1.FolderWorkExist)
                    fesExportBusiness.CreateFesAddSongTable();

                // タイアップランキング
                if (fileV1 != null && fileV1.FileNameExist && fileV1.FolderWorkExist)
                {
                    exportTable = fesExportBusiness.SelectFesAddSongAll();

                    FileExportTsvEntity fileInfo = new FileExportTsvEntity()
                    {
                        DataExport = exportTable,
                        FilePath = fileV1.LocalFolderPath,
                        IsHeader = false,
                        FunctionName = ExportFesContants.追加曲,
                        LogPathFile = logFesTsvExportPath
                    };

                    TsvConvert.ExportToTSV(fileInfo);

                    int numberCheck = 0;
                    int.TryParse(Properties.Settings.Default.FES_EXPORT_ADDITION_SONG_LAST_6_DAYS_MAX_NUMBER_CHECK.ToString(), out numberCheck);

                    // 直近６日3000件チェック
                    exportTable = fesExportBusiness.SelectFesServices();
                    if (exportTable.Rows.Count > 0 && int.Parse(exportTable.Rows[0][0].ToString()) > numberCheck)
                    {
                        exportInfo.SetStatusAddSongWarningFlag(ExportFesContants.追加曲, true);
                    }
                }
                exportTable = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = this.logExceptionPath
                };
                this.LogException(error);
                this.AddLog(string.Format("--- {0} -> {1}：出力失敗", DateTime.Now.ToString(), exportInfo.ExportModuleText), MODULE_FES_TSV_EXPORT);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.O))
            {
                btnTSVOutput_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.R))
            {
                btnImportRanking_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
