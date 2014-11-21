using System.Collections.Generic;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class AddStreamViewService : IAddStreamViewService
    {
        public IDictionary<int, string> GetChannels()
        {
            return new Dictionary<int, string>();
        }

        public IDictionary<int, string> GetGames()
        {
            return new Dictionary<int, string>();
        }

        public bool Validate(AddStreamDto stream)
        {
            return true;
        }

        public void Save(AddStreamDto dto)
        {
        }
    }
}