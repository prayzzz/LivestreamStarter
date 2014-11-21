using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

using BaseEntities;
using BaseEntities.Enum;

using Common.Common;

using Logic.Dto;
using Logic.NewServiceInterfaces;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public class StreamsOverviewViewService : ViewServiceBase, IStreamsOverviewViewService
    {
        private static IStreamService StreamService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IStreamService>();
            }
        }

        public void OpenInBrowser(int id)
        {
            var stream = Repository.GetById<StreamModel>(id);
            ServiceLocator.Current.GetInstance<IStreamStarter>().OpenStreamInBrowser(stream);
        }

        public IEnumerable<StreamDto> GetStreams()
        {
            var models = GetFilteredStreamModels();
            return models.Select(StreamService.ModelToDto);
        }

        public bool PlayStream(int id, Messages messages)
        {
            return StreamService.PlayStream(id, messages);
        }

        public IEnumerable<StreamDto> GetStreams(int gameId)
        {
            var models = Repository.GetQueryable<StreamModel>().Where(x => x.Status == StatusEnum.Online && x.Game.Id == gameId);
            return models.Select(StreamService.ModelToDto);
        }

        private static IList<StreamModel> GetFilteredStreamModels()
        {
            var allowedGames = Repository.GetById<SettingsModel>(1).GameFilter.Where(x => x.IsAllowed).Select(x => x.Game);
            return Repository.GetQueryable<StreamModel>().Where(x => x.Status == StatusEnum.Online && allowedGames.Contains(x.Game)).OrderByDescending(x => x.Viewers).ToList();
        }
    }
}