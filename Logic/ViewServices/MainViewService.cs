using BaseEntities;

using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Logic.ViewServices
{
    public class MainViewService : IMainViewService
    {
        private static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        public bool GetIsLogVisible()
        {
            return Repository.GetById<SettingsModel>(1).IsLogVisible;
        }
    }
}