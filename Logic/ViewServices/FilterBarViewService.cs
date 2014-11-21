using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BaseEntities;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.ViewServices
{
    public class FilterBarViewService : ViewServiceBase, IFilterBarViewService
    {
        private const string GameImagePathPattern = "pack://application:,,,/img/Games/{0}";

        public IEnumerable<FilterBarDto> Get()
        {
            return Repository.GetById<SettingsModel>(1).GameFilter.Select(ModelToDto).ToList();
        }

        public void DtoToModel(FilterBarDto dto)
        {
            Repository.GetById<SettingsModel>(1).GameFilter.First(x => x.Game.Id == dto.Id).IsAllowed = dto.IsAllowed;
        }

        private static FilterBarDto ModelToDto(GameFilterModel model)
        {
            var dto = new FilterBarDto();
            dto.Id = model.Game.Id;
            dto.Name = model.Game.Name;
            dto.Image = GetImage(GameImagePathPattern, model.Game.ImagePath);
            dto.IsAllowed = model.IsAllowed;

            return dto;
        }

        private static ImageSource GetImage(string pattern, string path)
        {
            return new BitmapImage(new Uri(string.Format(pattern, path), UriKind.RelativeOrAbsolute));
        }
    }
}