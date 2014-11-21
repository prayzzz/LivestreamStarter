using System.Collections.Generic;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace Logic.DesignTime
{
    public class FilterBarViewService : IFilterBarViewService
    {
        public IEnumerable<FilterBarDto> Get()
        {
            return new List<FilterBarDto> { new FilterBarDto { Name = "Test1" }, new FilterBarDto { Name = "Test2" }, new FilterBarDto { Name = "Test2" } };
        }

        public void DtoToModel(FilterBarDto dto)
        {
        }
    }
}