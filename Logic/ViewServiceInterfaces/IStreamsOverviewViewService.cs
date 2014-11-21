using System.Collections.Generic;

using Common.Common;

using Logic.Dto;

namespace Logic.ViewServiceInterfaces
{
    public interface IStreamsOverviewViewService
    {
        void OpenInBrowser(int id);

        IEnumerable<StreamDto> GetStreams();

        bool PlayStream(int id, Messages messages);

        IEnumerable<StreamDto> GetStreams(int gameId);
    }
}