using System.Collections.Generic;
using System.Linq;

using BaseEntities;

using Common.Common;
using Common.Enum;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Listener;

namespace Logic.ViewServices
{
    public class AddStreamViewService : ViewServiceBase, IAddStreamViewService
    {
        public IDictionary<int, string> GetChannels()
        {
            return Repository.GetQueryable<ChannelModel>().Where(x => x.IsAllowedAsFavorite).ToDictionary(x => x.Id, x => x.Name);
        }

        public IDictionary<int, string> GetGames()
        {
            return Repository.GetList<GameModel>().ToDictionary(x => x.Id, x => x.Name);
        }

        public bool Validate(AddStreamDto stream)
        {
            var result = true;

            if (string.IsNullOrEmpty(stream.Name))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(stream.DisplayName))
            {
                result = false;
            }

            if (stream.Channel == null && Repository.GetById<ChannelModel>(stream.Channel) != null)
            {
                result = false;
            }

            if (stream.Game == null && Repository.GetById<GameModel>(stream.Game) != null)
            {
                result = false;
            }

            if (!result)
            {
                return false;
            }

            return ValidateStreamName(stream);
        }

        public void Save(AddStreamDto dto)
        {
            Log(LogTypeEnum.Start, "adding stream '{0}'", dto.Name);

            SaveStreamInternal(dto);

            Log(LogTypeEnum.Stop, "adding stream '{0}'", dto.Name);
        }

        private static void SaveStreamInternal(AddStreamDto dto)
        {
            var existingModel = Repository.GetQueryable<StreamModel>().FirstOrDefault(x => x.Name == dto.Name);
            if (existingModel != null)
            {
                dto.Id = existingModel.Id;
                return;
            }

            var model = new StreamModel();
            model.Name = dto.Name;
            model.DisplayName = dto.DisplayName;
            model.IsFavorite = dto.IsFavorite;
            model.Channel = Repository.GetById<ChannelModel>(dto.Channel);
            model.Game = Repository.GetById<GameModel>(dto.Game);

            Repository.Add(model);
            dto.Id = model.Id;

            foreach (var instance in ServiceLocator.Current.GetAllInstances<IStreamUpdateListener>())
            {
                instance.Update(model);
            }
        }

        private static bool ValidateStreamName(AddStreamDto stream)
        {
            var result = true;
            var channel = Repository.GetById<ChannelModel>(stream.Channel);

            foreach (var instance in ServiceLocator.Current.GetAllInstances<IStreamLoadListener>())
            {
                if (!instance.CheckStreamName(channel, stream.Name))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}