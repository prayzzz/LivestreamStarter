using Common.Common;

namespace Services.Interfaces
{
    public interface IStreamUpdateTimer
    {
        event StreamListLoaded StreamListLoaded;

        event StreamListUpdated StreamListUpdated;

        void Start(bool runImmediately);

        void Stop();
    }
}