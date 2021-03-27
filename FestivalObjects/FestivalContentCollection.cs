using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FestivalObjects
{
    public class FestivalContentCollection
    {
        private List<FestivalContentEntity> contents;
        public FestivalContentCollection()
        {
            contents = new List<FestivalContentEntity>();
        }

        public void Add(FestivalContentEntity content)
        {
            contents.Add(content);
        }

        public List<FestivalContentEntity> GetContents()
        {
            return contents;
        }
    }

    public class FestivalContentEntity
    {
        [DisplayName("Coluumn1")]
        public bool colChoise { get; set; }
        public int colSongNumber { get; set; }
        public int colKaraokeNumber { get; set; }
        public int colParentKaraokeNo { get; set; }
        public string colSortingCode { get; set; }
        public string colDeliveryMark { get; set; }
        public string colArrangeCode { get; set; }
        public string colArrangeCodeCorrection { get; set; }
        public string colKaraokeArrageCode { get; set; }
        public string colArragementName { get; set; }
        public bool colKanaNullFlag { get; set; }
        public string colSongNameMary { get; set; }
        public string colCorrectSongName { get; set; }
        public string colSongNameKana { get; set; }
        public string colSongTitleKanaCorrection { get; set; }
        public string colSongNameSort { get; set; }
        public string colSongNameSortCorrection { get; set; }
        public string colSongNameSortAlphanumeric { get; set; }
        public string colSongNameSortingAlphanumericCorrection { get; set; }
        public string colMusicCa { get; set; }
        public string colSongNameKanaCa { get; set; }
        public string colJapanesseTitlePriorityFlag { get; set; }
        public string colJapanessTitle { get; set; }
        public string colJapananeseTitleKana { get; set; }
        public string colPuartistId { get; set; }
        public string colSingerIdSupplement { get; set; }
        public string colSingerName { get; set; }
        public string colSingerNameRevision { get; set; }
        public string colSingerNameKana { get; set; }
        public string colSingerNameKaraCorrection { get; set; }
        public string colSingerNameSort { get; set; }
        public string colSingerNameSortCorrection { get; set; }
        public string colSingerNameSortAlphabet { get; set; }
        public string colSingerNameSortAlphanumericCorrection { get; set; }
        public string colIntroType { get; set; }
        public string colIntroTypeCorrection { get; set; }
        public string colContryCode { get; set; }
        public string colSinging { get; set; }
        public string colPlayingTime { get; set; }
        public string colPerformanceTimeCorrection { get; set; }
        public string colSupportLevel { get; set; }
        public string colOriginalSongRatio { get; set; }
        public string colOriginalSongRatio2 { get; set; }
        public string colInfomationColumnJStyle { get; set; }
        public string colDeleteInformation { get; set; }
        public DateTime colReleaseDate { get; set; }
        public string colNewMusicBookHandingMonth { get; set; }
        public DateTime colSingingMayDate { get; set; }
        public DateTime colKaraokeCompletePakageDeadline { get; set; }
        public DateTime KaraokeCompletePackageDate { get; set; }
        public DateTime colFesUpDate { get; set; }
        public DateTime colFesServiceAnnouncementDate { get; set; }
        public DateTime colFesRightsServiceAnnouncementDate { get; set; }
        public bool colFesSearchDisplayAvailabilityFlag { get; set; }
        public bool colFesCancelFlag { get; set; }
        public DateTime colFesStopDate { get; set; }
        public string colFesDeleteInformation { get; set; }
        public string colFesDISCID_v1 { get; set; }
        public string colFesDISCID_v2 { get; set; }
        public string colFesNetUsageFlag_v1 { get; set; }
        public string colFesNetUsageFlag_v2 { get; set; }
        public bool colFesRecordabilityFlag { get; set; }
        public bool colFesRecordEnableDisableFlag { get; set; }
        public bool colFesPaidContentFlag { get; set; }
        public bool colChapterFlag { get; set; }
        public string colMusicCategoryClassification { get; set; }
        public string colUnpblishReason { get; set; }
        public DateTime colOrchFinishedProductionDate { get; set; }
        public DateTime colOrchSeviceAnnouncementDate { get; set; }
        public bool colOrchCancellationFlag { get; set; }
        public DateTime colOrchStopDate { get; set; }
        public string colOrchDeletionInformation { get; set; }
        public bool colOrchFlag { get; set; }
        public bool colOrchVideoRecordabilityFlag { get; set; }
        public bool colOrchAudioRecordabilityFlag { get; set; }
        public bool colOrchFreeDeliveryFlag { get; set; }
        public string colJVImageDivision { get; set; }
        public string colVideoGenre { get; set; }
        public string colFesVideoGenre { get; set; }
        public string colBackgroundVideoCode { get; set; }
        public string colCopyrightRemarks { get; set; }
        public string colRemarks { get; set; }
        public string colDelete { get; set; }
        public DateTime colRegisterDate { get; set; }
    }
}
