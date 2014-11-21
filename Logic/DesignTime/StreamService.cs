using System.Collections.Generic;

using BaseEntities;

using Common.Common;

using Logic.Dto;
using Logic.NewServiceInterfaces;

namespace Logic.DesignTime
{
    public class StreamService : IStreamService
    {
        public void ModelToDto(StreamModel model, StreamDto dto, bool loadImage = false)
        {
        }

        public IEnumerable<StreamDto> ModelToDto(IEnumerable<StreamModel> models)
        {
            return new List<StreamDto>();
        }

        public StreamDto ModelToDto(StreamModel models)
        {
            return new StreamDto();
        }

        public bool PlayStream(int id, Messages messages)
        {
            return true;
        }
    }
}