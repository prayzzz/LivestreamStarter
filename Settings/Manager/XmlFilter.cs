using System;
using System.Linq;

using LivestreamStarter.Enum;

namespace LivestreamStarter.Settings
{
    [Serializable]
    public class XmlFilter
    {
        public XmlFilter()
        {
            this.RaceFilter = this.GetDefaultItemsRaceEnum();
            this.ChannelFilter = this.GetDefaultItemsChannelEnum();
            this.StreamFilter = this.GetDefaultItemsStreamEnum();
        }

        public FilterItem[] RaceFilter { get; set; }

        public FilterItem[] ChannelFilter { get; set; }

        public FilterItem[] StreamFilter { get; set; }

        public FilterItem[] GetDefaultItemsRaceEnum()
        {
            return System.Enum.GetValues(typeof(RaceEnum)).Cast<RaceEnum>().Select(x => new FilterItem { Key = x.ToString(), Value = true }).ToArray();
        }

        public FilterItem[] GetDefaultItemsChannelEnum()
        {
            return System.Enum.GetValues(typeof(ChannelTypeEnum)).Cast<ChannelTypeEnum>().Select(x => new FilterItem { Key = x.ToString(), Value = true }).ToArray();
        }

        public FilterItem[] GetDefaultItemsStreamEnum()
        {
            return System.Enum.GetValues(typeof(StreamTypeEnum)).Cast<StreamTypeEnum>().Select(x => new FilterItem { Key = x.ToString(), Value = true }).ToArray();
        }
    }
}