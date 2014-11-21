using System;
using System.Threading.Tasks;
using System.Windows.Threading;

using Common.Args;
using Common.Common;
using Common.Enum;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;
using Services.Listener;

namespace Services.Common
{
    public class StreamUpdateTimer : IStreamUpdateTimer
    {
        private static readonly TimeSpan RefreshStreamsIntervall = new TimeSpan(0, 5, 0);

        private static DispatcherTimer streamUpdateTimer;

        public StreamUpdateTimer()
        {
            this.Initialize();
        }

        public event StreamListLoaded StreamListLoaded;

        public event StreamListUpdated StreamListUpdated;

        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        public void Start(bool runImmediately)
        {
            streamUpdateTimer.Start();

            if (runImmediately)
            {
                this.LoadAndUpdateStreams();
            }
        }

        public void Stop()
        {
            streamUpdateTimer.Stop();
        }

        private void Initialize()
        {
            streamUpdateTimer = new DispatcherTimer();
            streamUpdateTimer.Tick += (s, a) => this.LoadAndUpdateStreams();
            streamUpdateTimer.Interval = RefreshStreamsIntervall;
        }

        private async void LoadAndUpdateStreams()
        {
            await Task.Run(() => this.LoadStreams());
            await Task.Run(() => this.UpdateStreams());
        }

        private void LoadStreams()
        {
            Logger.Log(LogTypeEnum.Start, "loading streams");

            foreach (var instance in ServiceLocator.Current.GetAllInstances<IStreamLoadListener>())
            {
                instance.Load();
            }

            Logger.Log(LogTypeEnum.Stop, "loading streams");

            this.OnStreamListLoaded();
        }

        private void UpdateStreams()
        {
            Logger.Log(LogTypeEnum.Start, "updating streams");

            foreach (var instance in ServiceLocator.Current.GetAllInstances<IStreamUpdateListener>())
            {
                instance.UpdateAll();
            }

            Logger.Log(LogTypeEnum.Stop, "updating streams");

            this.OnStreamListUpdated();
        }

        private void OnStreamListLoaded()
        {
            if (this.StreamListLoaded != null)
            {
                this.StreamListLoaded(this, new StreamListLoadedArgs());
            }
        }

        private void OnStreamListUpdated()
        {
            if (this.StreamListUpdated != null)
            {
                this.StreamListUpdated(this, new StreamListUpdatedArgs());
            }
        }
    }
}