using System;

using Services.Interfaces;

namespace Services.Services
{
    internal class PathService : IPathService
    {
        private const string GoodGameLink = "http://goodgame.ru/channel/";

        private const string ImagePath = "../img/";

        public string GetGoodGame(string name)
        {
            return string.Format("{0}{1}", GoodGameLink, name);
        }

        public string GetImagePath(Enum type)
        {
            return string.Format("{0}{1}.png", ImagePath, type);
        }
    }
}