using System;

using BaseEntities;
using BaseEntities.Enum;

namespace Services.Interfaces
{
    public interface IProcessManager : IDisposable
    {
        bool IsProcessRunning { get; }

        void StartStream(Action<Exception> callback, string displayName, string streamLink, QualityEnum quality);

        void CheckForExistingStream();

        void ExitLivestreamer();
    }
}