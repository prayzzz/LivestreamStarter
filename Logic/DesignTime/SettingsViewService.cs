using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class SettingsViewService : ISettingsViewService
    {
        public bool Validate(SettingsDto dto)
        {
            return true;
        }

        public void Save(SettingsDto dto)
        {
        }

        public SettingsDto GetSettings()
        {
            return new SettingsDto();
        }
    }
}