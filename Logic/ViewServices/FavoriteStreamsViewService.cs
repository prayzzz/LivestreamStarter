using System.Collections.Generic;
using System.Linq;

using BaseEntities;

using Common.Common;
using Common.Enum;

using Logic.Dto;
using Logic.NewServiceInterfaces;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public class FavoriteStreamsViewService : ViewServiceBase, IFavoriteStreamsViewService
    {
        private static IStreamService StreamService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IStreamService>();
            }
        }

        public StreamDto GetStream(int id)
        {
            var model = Repository.GetById<StreamModel>(id);

            var dto = new StreamDto();
            StreamService.ModelToDto(model, dto);
            return dto;
        }

        public IEnumerable<StreamDto> GetFavoriteStreams()
        {
            Log(LogTypeEnum.Start, "loading favorites");

            var streams = StreamService.ModelToDto(Repository.GetQueryable<StreamModel>().Where(x => x.IsFavorite));

            Log(LogTypeEnum.Stop, "loading favorites");

            return streams;
        }

        public void OpenInBrowser(int id)
        {
            var stream = Repository.GetById<StreamModel>(id);
            ServiceLocator.Current.GetInstance<IStreamStarter>().OpenStreamInBrowser(stream);
        }

        public void FavStream(int id)
        {
            Repository.GetById<StreamModel>(id).IsFavorite = true;
        }

        public void GetStreamDtos(IList<StreamDto> streams)
        {
            foreach (var model in Repository.GetQueryable<StreamModel>().Where(x => x.IsFavorite).OrderByDescending(x => x.Viewers))
            {
                var dto = streams.FirstOrDefault(x => x.Id == model.Id);

                if (dto != null)
                {
                    StreamService.ModelToDto(model, dto, true);
                }
                else
                {
                    dto = new StreamDto();
                    StreamService.ModelToDto(model, dto, true);
                    streams.Add(dto);
                }
            }
        }

        public bool PlayStream(int id, Messages messages)
        {
            return StreamService.PlayStream(id, messages);
        }

        public void UnfavStream(int id)
        {
            Repository.GetById<StreamModel>(id).IsFavorite = false;
        }
    }
}