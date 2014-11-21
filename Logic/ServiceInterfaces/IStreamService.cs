using System.Collections.Generic;

using BaseEntities;

using Common.Common;

using Logic.Dto;

namespace Logic.NewServiceInterfaces
{
    public interface IStreamService
    {
        void ModelToDto(StreamModel model, StreamDto dto, bool loadImage = false);

        IEnumerable<StreamDto> ModelToDto(IEnumerable<StreamModel> models);

        StreamDto ModelToDto(StreamModel models);

        bool PlayStream(int id, Messages messages);
    }
}