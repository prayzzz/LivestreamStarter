using System.Collections.Generic;

using Common.Common;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class StreamsOverviewViewService : IStreamsOverviewViewService
    {
        public void DownloadStreamLists()
        {
        }

        public IEnumerable<StreamDto> GetOnlineStreams()
        {
            return new List<StreamDto>();
        }

        public void UpdateStreams()
        {
        }

        public void OpenInBrowser(int id)
        {
        }

        public IEnumerable<StreamDto> GetStreams()
        {
            return new List<StreamDto>();
        }

        public bool PlayStream(int id, Messages messages)
        {
            return true;
        }

        public IEnumerable<StreamDto> GetStreams(int gameId)
        {
            return new List<StreamDto>();
        }

        public void ApplyFilter(IList<StreamDto> streams)
        {
        }
    }
}