using System;

namespace Services.Interfaces
{
    public interface IPathService
    {
        string GetGoodGame(string name);

        string GetImagePath(Enum type);
    }
}