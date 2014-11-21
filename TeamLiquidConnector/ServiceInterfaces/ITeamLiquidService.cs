using TeamLiquidConnector.Entities;

namespace TeamLiquidConnector.ServiceInterfaces
{
    internal interface ITeamLiquidService
    {
        TeamLiquidStreamList GetStreamList();
    }
}