using System;

using Common.Common;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.ViewMessages;

using Microsoft.Practices.ServiceLocation;

namespace LivestreamStarter.Presentation.Controller.Base
{
    public abstract class ViewControllerBase<TM, TS> : ControllerBase
        where TM : ViewModelBase, new()
    {
        protected ViewControllerBase()
        {
            this.Messages = new Messages();

            this.Model = new TM();
            this.Model.PropertyChanged += this.OnModelPropertyChanged;
        }

        public TM Model { get; private set; }

        protected Messages Messages { get; private set; }

        protected TS Service
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TS>();
            }
        }

        public virtual void Initialize()
        {
        }

        public virtual void InitializeModel()
        {
        }

        protected void ProcessErrorMessages()
        {
            if (!this.Messages.HasErrors)
            {
                return;
            }

            foreach (var error in this.Messages.GetErrors())
            {
                Messenger.Default.Send(new ErrorMessage(error));
            }

            this.Messages.Clear();
            Messenger.Default.Send(new ViewActionMessage(typeof(ErrorViewController), ViewActionEnum.Open));
        }

        protected void ExecuteActionWithOverlay(Action action)
        {
            this.BlockUi();

            action.Invoke();

            this.ReleaseUi();
        }

        protected void BlockUi()
        {
            Messenger.Default.Send(new ViewActionMessage(typeof(LoadingViewController), ViewActionEnum.Open));
        }

        protected void ReleaseUi()
        {
            Messenger.Default.Send(new ViewActionMessage(typeof(LoadingViewController), ViewActionEnum.Close));
        }
    }
}