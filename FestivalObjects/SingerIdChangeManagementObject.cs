using System;

namespace FestivalObjects
{
    public class SingerIdChangeManagementObject
    {
        public string 履歴No { get; set; }
        public int? 変更前_歌手ID { get; set; }
        public string 変更前_歌手名 { get; set; }
        public string 変更前_歌手名検索用カナ { get; set; }
        public string 変更前_歌手名ソート用カナ { get; set; }
        public int? 変更後_歌手ID { get; set; }
        public string 変更後_歌手名 { get; set; }
        public string 変更後_歌手名検索用カナ { get; set; }
        public string 変更後_歌手名ソート用カナ { get; set; }
        public DateTime? 変更日時 { get; set; }
        public string 変更利用者ID { get; set; }
        public DateTime Time_Stamp { get; set; }
    }
}
