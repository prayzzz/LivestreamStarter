using Logic.Dto;

namespace Logic.ViewServiceInterfaces
{
    public interface ISettingsViewService
    {
        bool Validate(SettingsDto dto);

        void Save(SettingsDto dto);

        SettingsDto GetSettings();
    }
}