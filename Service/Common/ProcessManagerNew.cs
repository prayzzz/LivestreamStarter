using System;
using System.Diagnostics;
using System.Linq;

using BaseEntities;

using Common.Args;
using Common.Common;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Services.Common
{
    public abstract class ProcessManagerNew
    {
        public event ProcessExited ProcessExited;

        public bool IsProcessRunning { get; protected set; }

        protected static SettingsModel Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>().GetQueryable<SettingsModel>().FirstOrDefault();
            }
        }

        protected static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        protected Process Process { get; set; }

        protected void OnProcessExit(object sender, EventArgs e)
        {
            this.IsProcessRunning = false;

            Process.CancelOutputRead();
            Process.CancelErrorRead();

            if (this.ProcessExited != null)
            {
                this.ProcessExited(this, new ProcessExitedArgs());
            }
        }
    }

}