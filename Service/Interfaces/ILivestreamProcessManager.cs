using BaseEntities;
using BaseEntities.Enum;

using Common.Common;
using Common.Exceptions;

namespace Services.Interfaces
{
    public interface ILivestreamProcessManager
    {
        event ProcessExited ProcessExited;

        bool IsProcessRunning { get; }

        /// <summary>
        /// The start stream.
        /// </summary>
        /// <param name="streamLink">
        /// The stream Link.
        /// </param>
        /// <param name="quality">
        /// The quality.
        /// </param>
        /// <exception cref="SettingsException">
        /// Paths not Available
        /// </exception>
        /// <exception cref="ProcessException">
        /// LiveStreamer already running
        /// </exception>
        void StartStream(string streamLink, QualityEnum quality);

        void Stop();
    }
}