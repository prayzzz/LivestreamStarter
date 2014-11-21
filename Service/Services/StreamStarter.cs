using System.Diagnostics;

using BaseEntities;
using BaseEntities.Enum;

using Common.Common;
using Common.Enum;
using Common.Exceptions;

using Localization;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Services.Services
{
    public class StreamStarter : IStreamStarter
    {
        private static ILivestreamProcessManager ProcessManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILivestreamProcessManager>();
            }
        }

        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        public bool StartStream(StreamModel stream, QualityEnum quality, Messages messages)
        {
            if (stream.Channel.IsSupported)
            {
                if (stream.Status == StatusEnum.Offline)
                {
                    messages.Add(MessageTypeEnum.Error, CodeStrings.StreamIsOffline);
                    return false;
                }

                return StartStreamWithLivestreamer(stream, quality, messages);
            }

            this.OpenStreamInBrowser(stream);
            return false;
        }

        public void OpenStreamInBrowser(StreamModel stream)
        {
            if (!string.IsNullOrEmpty(stream.StreamLink))
            {
                Process.Start(stream.StreamLink);
            }
        }

        private static bool StartStreamWithLivestreamer(StreamModel stream, QualityEnum quality, Messages messages)
        {
            try
            {
                ProcessManager.StartStream(stream.StreamLink, quality);
                return true;
            }
            catch (SettingsException ex)
            {
                Logger.Log(ex);
                messages.Add(MessageTypeEnum.Error, ex.Message);
                return false;
            }
            catch (ProcessException ex)
            {
                Logger.Log(ex);
                messages.Add(MessageTypeEnum.Error, ex.Message);
                return false;
            }
        }
    }
}