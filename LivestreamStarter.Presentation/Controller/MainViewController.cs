using System;
using System.Collections.Generic;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class MainViewController : ViewControllerBase<MainViewModel, IMainViewService>
    {
        private readonly Dictionary<Type, Action<ViewActionEnum>> viewActionHandler;

        public MainViewController()
        {
            this.viewActionHandler = new Dictionary<Type, Action<ViewActionEnum>>();
            this.viewActionHandler.Add(typeof(SettingsViewController), this.HandleSettingsViewAction);
            this.viewActionHandler.Add(typeof(AboutViewController), this.HandleAboutViewAction);
            this.viewActionHandler.Add(typeof(AddStreamViewController), this.HandleAddStreamViewAction);
            this.viewActionHandler.Add(typeof(LoadingViewController), this.HandleLoadingViewAction);
            this.viewActionHandler.Add(typeof(ErrorViewController), this.HandleErrorViewAction);

            this.OpenAboutViewCommand = new RelayCommand(() => Messenger.Default.Send(new ViewActionMessage(typeof(AboutViewController), ViewActionEnum.Open)), () => this.IsOverlayNotVisible);
            this.OpenPathViewCommand = new RelayCommand(() => Messenger.Default.Send(new ViewActionMessage(typeof(SettingsViewController), ViewActionEnum.Open)), () => this.IsOverlayNotVisible);

            if (IsInDesignModeStatic)
            {
                this.Model.IsOverviewListSelected = true;
                this.Model.IsOverlayVisible = false;
            }
        }

        public bool IsOverlayNotVisible
        {
            get
            {
                return !this.Model.IsOverlayVisible;
            }
        }

        public RelayCommand OpenAboutViewCommand { get; set; }

        public RelayCommand OpenPathViewCommand { get; set; }

        public override void Initialize()
        {
            Messenger.Default.Register<ViewActionMessage>(this, this.HandleViewActionMessage);
        }

        public void Close()
        {
        }

        public override void InitializeModel()
        {
            this.Model.IsOverviewListSelected = true;
            this.Model.IsLogTabVisible = this.Service.GetIsLogVisible();
        }

        private void HandleViewActionMessage(ViewActionMessage message)
        {
            this.viewActionHandler[message.ViewType].Invoke(message.Action);
        }

        private void ShowViewWithOverlay(Action<MainViewModel> show, Func<bool> canExecute = null)
        {
            if (canExecute != null && !canExecute())
            {
                return;
            }

            this.ShowUiBlock();
            show(this.Model);
        }

        private void HideViewWithOverlay(Action<MainViewModel> hide)
        {
            this.HideUiBlock();
            hide(this.Model);
        }

        #region AboutView

        private void HandleAboutViewAction(ViewActionEnum action)
        {
            switch (action)
            {
                case ViewActionEnum.Open:
                    this.ShowViewWithOverlay(x => x.IsAboutViewVisible = true, () => this.IsOverlayNotVisible);
                    break;
                case ViewActionEnum.Close:
                    this.HideViewWithOverlay(x => x.IsAboutViewVisible = false);
                    break;
            }
        }

        #endregion

        #region SettingsView

        private void HandleSettingsViewAction(ViewActionEnum action)
        {
            switch (action)
            {
                case ViewActionEnum.Open:
                    this.ShowViewWithOverlay(x => x.IsSettingsViewVisible = true, () => this.IsOverlayNotVisible);
                    break;
                case ViewActionEnum.Close:
                    this.HideViewWithOverlay(x => x.IsSettingsViewVisible = false);
                    this.Model.IsLogTabVisible = this.Service.GetIsLogVisible();
                    break;
            }
        }

        #endregion

        #region AddStreamView

        private void HandleAddStreamViewAction(ViewActionEnum action)
        {
            switch (action)
            {
                case ViewActionEnum.Open:
                    this.ShowViewWithOverlay(x => x.IsAddStreamViewVisible = true, () => this.IsOverlayNotVisible);
                    break;
                case ViewActionEnum.Close:
                    this.HideViewWithOverlay(x => x.IsAddStreamViewVisible = false);
                    break;
            }
        }

        #endregion

        #region LoadingView

        private void HandleLoadingViewAction(ViewActionEnum action)
        {
            switch (action)
            {
                case ViewActionEnum.Open:
                    this.ShowViewWithOverlay(x => x.IsLoadingViewVisible = true, () => this.IsOverlayNotVisible);
                    break;
                case ViewActionEnum.Close:
                    this.HideViewWithOverlay(x => x.IsLoadingViewVisible = false);
                    break;
            }
        }

        #endregion

        #region ErrorView

        private void HandleErrorViewAction(ViewActionEnum action)
        {
            switch (action)
            {
                case ViewActionEnum.Open:
                    this.ShowViewWithOverlay(x => x.IsErrorViewVisible = true, () => this.IsOverlayNotVisible);
                    break;
                case ViewActionEnum.Close:
                    this.HideViewWithOverlay(x => x.IsErrorViewVisible = false);
                    break;
            }
        }

        #endregion

        #region Overlay

        private void ShowUiBlock(bool cancelVisible = false)
        {
            this.Model.IsOverlayVisible = true;
            this.Model.IsOverlayCancelVisible = cancelVisible;
        }

        private void HideUiBlock()
        {
            this.Model.IsOverlayVisible = false;
            this.Model.IsOverlayCancelVisible = false;
        }

        #endregion
    }
}