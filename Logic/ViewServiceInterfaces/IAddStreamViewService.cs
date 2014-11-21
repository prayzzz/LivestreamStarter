using System.Collections.Generic;

using Logic.Dto;

namespace Logic.ViewServiceInterfaces
{
    public interface IAddStreamViewService
    {
        IDictionary<int, string> GetChannels();

        IDictionary<int, string> GetGames();

        bool Validate(AddStreamDto stream);

        void Save(AddStreamDto dto);
    }
}