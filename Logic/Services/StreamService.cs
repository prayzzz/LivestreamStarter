using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BaseEntities;
using BaseEntities.Enum;

using Common.Common;

using Logic.Dto;
using Logic.NewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.NewServices
{
    public class StreamService : IStreamService
    {
        private const string GameImagePathPattern = "pack://application:,,,/img/Games/{0}";

        private const string ChannelImagePathPattern = "pack://application:,,,/img/Channels/{0}";

        private static readonly ImageSource PreviewImage = new BitmapImage(new Uri(@"pack://application:,,,/img/Misc/picture.png", UriKind.RelativeOrAbsolute));

        private static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        public void ModelToDto(StreamModel model, StreamDto dto, bool loadImage = false)
        {
            dto.Id = model.Id;
            dto.DisplayName = model.DisplayName;
            dto.ChannelStatus = model.ChannelStatus;
            dto.Viewers = model.Viewers;
            dto.IsFavorite = model.IsFavorite;
            dto.IsAllowedAsFavorite = model.Channel.IsAllowedAsFavorite;
            dto.Game = model.Game.Id;
            dto.GameImage = GetImage(GameImagePathPattern, model.Game.ImagePath);
            dto.Channel = model.Channel.Id;
            dto.ChannelImage = GetImage(ChannelImagePathPattern, model.Channel.ImagePath);
            dto.Status = model.Status.ToString();

            dto.PreviewImage = !string.IsNullOrEmpty(model.PreviewImagePath) && loadImage ? GetExternalImage(model.PreviewImagePath) : PreviewImage;
        }

        public IEnumerable<StreamDto> ModelToDto(IEnumerable<StreamModel> models)
        {
            var list = new List<StreamDto>();

            foreach (var streamModel in models)
            {
                var dto = new StreamDto();
                this.ModelToDto(streamModel, dto);

                list.Add(dto);
            }

            return list;
        }

        public StreamDto ModelToDto(StreamModel models)
        {
            var dto = new StreamDto();
            ModelToDto(models, dto);
            return dto;
        }

        public bool PlayStream(int id, Messages messages)
        {
            var stream = Repository.GetById<StreamModel>(id);
            return ServiceLocator.Current.GetInstance<IStreamStarter>().StartStream(stream, QualityEnum.Source, messages);
        }

        private static ImageSource GetImage(string pattern, string path)
        {
            return new BitmapImage(new Uri(string.Format(pattern, path), UriKind.RelativeOrAbsolute));
        }

        private static ImageSource GetExternalImage(string exteralPath)
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(exteralPath, UriKind.Absolute);
            img.CacheOption = BitmapCacheOption.OnDemand;
            img.EndInit();

            return img;
        }
    }
}