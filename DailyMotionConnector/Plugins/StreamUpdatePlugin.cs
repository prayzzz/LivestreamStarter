using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using BaseEntities;
using BaseEntities.Enum;

using DailyMotionConnector.Entities;
using DailyMotionConnector.ServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;
using Services.Listener;

namespace DailyMotionConnector.Plugins
{
    public class StreamUpdatePlugin : IStreamUpdateListener
    {
        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        private static IDailymotionService DailymotionService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDailymotionService>();
            }
        }

        public void Update(StreamModel model)
        {
            if (model == null || model.Channel != PluginInformations.Channel)
            {
                return;
            }

            DailymotionVideo stream;

            try
            {
                stream = DailymotionService.GetStreamInformations(model.Name);
            }
            catch (WebException ex)
            {
                Logger.Log(ex);
                return;
            }

            if (stream == null)
            {
                model.Status = StatusEnum.Offline;
                return;
            }

            EntityToModel(model, stream);
        }

        public void UpdateAll()
        {
            var modelsToUpdate = ServiceLocator.Current.GetInstance<IRepository>().GetQueryable<StreamModel>().Where(x => x.Channel == PluginInformations.Channel);
            var dailymotionVideosList = GetPartialList(modelsToUpdate, 20).Select(GetStreamInformations).ToList();

            if (!dailymotionVideosList.Any() || dailymotionVideosList[0] == null)
            {
                return;
            }

            foreach (var streamViewModel in modelsToUpdate)
            {
                streamViewModel.Status = StatusEnum.Offline;
                streamViewModel.Viewers = 0;
            }

            foreach (var dailymotionVideo in dailymotionVideosList.SelectMany(x => x.list))
            {
                var model = modelsToUpdate.FirstOrDefault(x => x.Name == dailymotionVideo.id);
                if (model == null)
                {
                    continue;
                }

                EntityToModel(model, dailymotionVideo);
            }
        }

        private static IEnumerable<IEnumerable<T>> GetPartialList<T>(IEnumerable<T> list, int count)
        {
            for (var i = 0; i < list.Count(); i = i + count)
            {
                yield return list.Skip(i).Take(count);
            }
        }

        private static void EntityToModel(StreamModel model, DailymotionVideo entity)
        {
            model.ChannelStatus = entity.description.Trim();

            model.Viewers = entity.audience;
            model.Status = StatusEnum.Online;
        }

        private static DailymotionVideos GetStreamInformations(IEnumerable<StreamModel> streamModels)
        {
            try
            {
                return DailymotionService.GetStreamInformations(streamModels.Select(x => x.Name));
            }
            catch (Exception e)
            {
                Logger.Log(e);
                return null;
            }
        }
    }
}