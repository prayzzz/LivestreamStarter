using BaseEntities;
using BaseEntities.Enum;

using Common.Common;

namespace Services.Interfaces
{
    public interface IStreamStarter
    {
        bool StartStream(StreamModel stream, QualityEnum quality, Messages messages);

        void OpenStreamInBrowser(StreamModel stream);
    }
}