namespace FestivalObjects
{
    public class RecommendSongMessage
    {
        public bool IsNotDigiNoKenkouSong { get; set; }
        public string NotRequiredRecord { get; set; }

        public string NotDigiNoRecommendSong { get; set; }
        public string DisplayOrderDuplicationRecordKenkouSong { get; set; }
        public string DisplayOrderDuplicationRecordRecommendSong { get; set; }
        public string WarningRecord { get; set; }
    }
}
