using TeamLiquidConnector.ServiceInterfaces;

namespace TeamLiquidConnector.Services
{
    internal class PathService : IPathService
    {
        private const string TeamLiquidLink = "http://www.teamliquid.net/video/streams/?xml=1&filter=live";

        private const string LiquidHearthLink = "http://www.liquidhearth.com/stream/?xml=1&filter=live";

        private const string LiquidDotaLink = "http://www.liquiddota.com/stream/?xml=1&filter=live";

        public string GetTeamLiquidLink()
        {
            return string.Format("{0}", TeamLiquidLink);
        }

        public string GetLiquidHearthLink()
        {
            return string.Format("{0}", LiquidHearthLink);
        }

        public string GetLiquidDotaLink()
        {
            return string.Format("{0}", LiquidDotaLink);
        }
    }
}