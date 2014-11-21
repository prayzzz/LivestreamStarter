using Common;

using GalaSoft.MvvmLight.Ioc;

using Services.Listener;

using TeamLiquidConnector.Plugins;
using TeamLiquidConnector.ServiceInterfaces;
using TeamLiquidConnector.Services;

namespace TeamLiquidConnector
{
    public class TeamLiquidConnector : IConnector
    {
        public void Register()
        {
            SimpleIoc.Default.Register<IPathService, PathService>();
            SimpleIoc.Default.Register<ITeamLiquidService, TeamLiquidService>();
            SimpleIoc.Default.Register<IStreamLoadListener>(() => new StreamLoadPlugin(), "TeamLiquid");
        }
    }
}