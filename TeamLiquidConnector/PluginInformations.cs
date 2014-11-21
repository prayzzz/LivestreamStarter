using System;

namespace TeamLiquidConnector
{
    public static class PluginInformations
    {
        static PluginInformations()
        {
            PluginId = Guid.NewGuid();
        }

        public static Guid PluginId { get; set; }
    }
}