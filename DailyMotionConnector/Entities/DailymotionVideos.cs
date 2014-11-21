namespace DailyMotionConnector.Entities
{
    public class DailymotionVideos
    {
        public int page { get; set; }
        public int limit { get; set; }
        public bool _explicit { get; set; }
        public bool has_more { get; set; }
        public DailymotionVideo[] list { get; set; }
    }

    public class DailymotionVideo
    {
        public int audience { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string id { get; set; }
    }
}
