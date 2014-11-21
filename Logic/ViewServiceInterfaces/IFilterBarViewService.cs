using System.Collections.Generic;

using Logic.Dto;

namespace Logic.ViewServiceInterfaces
{
    public interface IFilterBarViewService
    {
        IEnumerable<FilterBarDto> Get();

        void DtoToModel(FilterBarDto dto);
    }
}