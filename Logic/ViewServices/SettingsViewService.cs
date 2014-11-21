using System.IO;

using BaseEntities;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public class SettingsViewService : ISettingsViewService
    {
        private static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        public bool Validate(SettingsDto dto)
        {
            if (dto == null)
            {
                return false;
            }

            if (!File.Exists(dto.VlcPath))
            {
                return false;
            }

            if (!File.Exists(dto.LiveStreamerPath))
            {
                return false;
            }

            return true;
        }

        public void Save(SettingsDto dto)
        {
            var settings = Repository.GetById<SettingsModel>(dto.Id);

            DtoToModel(settings, dto);
        }

        public SettingsDto GetSettings()
        {
            var settings = Repository.GetById<SettingsModel>(1);
            var dto = new SettingsDto();

            ModelToDto(dto, settings);

            return dto;
        }

        private static void ModelToDto(SettingsDto dto, SettingsModel model)
        {
            dto.Id = model.Id;
            dto.LiveStreamerPath = model.LivestreamerPath;
            dto.VlcPath = model.VlcPath;
            dto.IsLogVisible = model.IsLogVisible;
        }

        private static void DtoToModel(SettingsModel model, SettingsDto dto)
        {
            model.LivestreamerPath = dto.LiveStreamerPath;
            model.VlcPath = dto.VlcPath;
            model.IsLogVisible = dto.IsLogVisible;
        }
    }
}
