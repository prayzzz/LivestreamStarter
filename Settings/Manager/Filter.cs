using System.Collections.Generic;

using LivestreamStarter.Enum;

namespace LivestreamStarter.Settings
{
    public class Filter
    {
        public Filter()
        {
            this.RaceFilter = new Dictionary<RaceEnum, bool>();
            this.ChannelFilter = new Dictionary<ChannelTypeEnum, bool>();
            this.StreamFilter = new Dictionary<StreamTypeEnum, bool>();

            this.FillDictionaries();
        }

        public Dictionary<RaceEnum, bool> RaceFilter { get; set; }

        public Dictionary<ChannelTypeEnum, bool> ChannelFilter { get; set; }

        public Dictionary<StreamTypeEnum, bool> StreamFilter { get; set; }

        public void FillDictionaries()
        {
            foreach (RaceEnum value in System.Enum.GetValues(typeof(RaceEnum)))
            {
                this.RaceFilter.Add(value, false);
            }

            foreach (ChannelTypeEnum value in System.Enum.GetValues(typeof(ChannelTypeEnum)))
            {
                this.ChannelFilter.Add(value, false);
            }

            foreach (StreamTypeEnum value in System.Enum.GetValues(typeof(StreamTypeEnum)))
            {
                this.StreamFilter.Add(value, false);
            }
        }
    }
}