using System.Collections.Generic;

using Common.Common;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class FavoriteStreamsViewService : IFavoriteStreamsViewService
    {
        public StreamDto GetStream(int id)
        {
            return new StreamDto();
        }

        public IEnumerable<StreamDto> GetFavoriteStreams()
        {
            return new List<StreamDto>();
        }

        public void OpenInBrowser(int id)
        {
        }

        public void FavStream(int id)
        {
        }

        public void GetStreamDtos(IList<StreamDto> streams)
        {
        }

        public bool PlayStream(int id, Messages messages)
        {
            return true;
        }

        public void UpdateStreams(IEnumerable<StreamDto> streams)
        {
        }

        public void UnfavStream(int id)
        {
        }

        IEnumerable<StreamDto> IFavoriteStreamsViewService.GetFavoriteStreams()
        {
            return new List<StreamDto>();
        }
    }
}