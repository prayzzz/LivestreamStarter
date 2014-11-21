using System;

namespace TwitchConnector.Entities
{
    public class TwitchStreams
    {
        public int _total { get; set; }
        public Links _links { get; set; }
        public TwitchStream[] streams { get; set; }
        public TwitchStream stream { get; set; }
        public string error { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class TwitchStream
    {
        public long _id { get; set; }
        public string game { get; set; }
        public int viewers { get; set; }
        public Preview preview { get; set; }
        public Links _links { get; set; }
        public Channel channel { get; set; }
    }

    public class Preview
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string template { get; set; }
    }

    public class Channel
    {
        public bool? mature { get; set; }
        public object abuse_reported { get; set; }
        public string status { get; set; }
        public string display_name { get; set; }
        public string game { get; set; }
        public int delay { get; set; }
        public int _id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string primary_team_name { get; set; }
        public string primary_team_display_name { get; set; }
        public string logo { get; set; }
        public object banner { get; set; }
        public string video_banner { get; set; }
        public object background { get; set; }
        public string profile_banner { get; set; }
        public object profile_banner_background_color { get; set; }
        public string url { get; set; }
        public int views { get; set; }
        public int followers { get; set; }
        public Links _links { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string follows { get; set; }
        public string commercial { get; set; }
        public string stream_key { get; set; }
        public string chat { get; set; }
        public string features { get; set; }
        public string subscriptions { get; set; }
        public string editors { get; set; }
        public string teams { get; set; }
        public string videos { get; set; }
        public string featured { get; set; }
        public string summary { get; set; }
        public string followed { get; set; }
        public string next { get; set; }
    }
}