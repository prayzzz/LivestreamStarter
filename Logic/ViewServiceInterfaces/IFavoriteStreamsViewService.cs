using System.Collections.Generic;

using Common.Common;

using Logic.Dto;

namespace Logic.ViewServiceInterfaces
{
    public interface IFavoriteStreamsViewService
    {
        StreamDto GetStream(int id);

        void UnfavStream(int id);

        IEnumerable<StreamDto> GetFavoriteStreams();

        void OpenInBrowser(int id);

        void FavStream(int id);

        void GetStreamDtos(IList<StreamDto> streams);

        bool PlayStream(int id, Messages messages);
    }
}