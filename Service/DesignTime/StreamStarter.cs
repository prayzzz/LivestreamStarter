using BaseEntities;
using BaseEntities.Enum;

using Common.Common;

using Services.Interfaces;

namespace Services.DesignTime
{
    public class StreamStarter : IStreamStarter
    {
        public bool StartStream(StreamModel stream, QualityEnum quality, Messages messages)
        {
            return true;
        }

        public void StartStreamAsync(StreamModel stream, QualityEnum quality)
        {
        }

        public void OpenStreamInBrowser(StreamModel stream)
        {
        }
    }
}