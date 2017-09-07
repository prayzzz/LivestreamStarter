using System.IO;
using System.IO.Compression;
using System.Net;
using System.Xml.Serialization;

using Microsoft.Practices.ServiceLocation;

using MoreLinq;

using TeamLiquidConnector.Entities;
using TeamLiquidConnector.ServiceInterfaces;

namespace TeamLiquidConnector.Services
{
    using System.Linq;

    internal class TeamLiquidService : ITeamLiquidService
    {
        private static IPathService PathService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPathService>();
            }
        }

        public TeamLiquidStreamList GetStreamList()
        {
            var list = RequestStreamList(PathService.GetTeamLiquidLink());
            list.Streams = list.Streams.Concat(RequestStreamList(PathService.GetLiquidDotaLink()).Streams).ToList();
            list.Streams = list.Streams.Concat(RequestStreamList(PathService.GetLiquidHearthLink()).Streams).ToList();

            list.Streams = list.Streams.DistinctBy(x => x.Channel.Name).ToList();

            return list;
        }

        private static TeamLiquidStreamList RequestStreamList(string link)
        {
            var webRequest = WebRequest.Create(link) as HttpWebRequest;

            if (webRequest == null)
            {
                return null;
            }

            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
            TeamLiquidStreamList streamList;

            using (var webResponse = webRequest.GetResponse())
            {
                using (var stream = new StreamReader(new GZipStream(webResponse.GetResponseStream(), CompressionMode.Decompress)))
                {
                    var serializer = new XmlSerializer(typeof(TeamLiquidStreamList));
                    streamList = serializer.Deserialize(stream) as TeamLiquidStreamList;
                }
            }

            return streamList;
        }
    }
}