using BaseEntities.Enum;

using Common.Common;

using Services.Interfaces;

namespace Services.DesignTime
{
    public class LivestreamProcessManager : ILivestreamProcessManager
    {
        public event ProcessExited ProcessExited;

        public bool IsProcessRunning { get; private set; }

        public void StartStream(string streamLink, QualityEnum quality)
        {
        }

        public void Stop()
        {
        }
    }
}