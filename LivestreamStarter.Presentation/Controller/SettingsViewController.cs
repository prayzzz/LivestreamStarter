using System;
using System.IO;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

using Microsoft.Win32;

namespace LivestreamStarter.Presentation.Controller
{
    public class SettingsViewController : ViewControllerBase<SettingsViewModel, ISettingsViewService>
    {
        public SettingsViewController()
        {
            this.SaveCommand = new RelayCommand(this.Save, this.CanSave);
            this.CancelCommand = new RelayCommand(this.Cancel);
            this.BrowseLivestreamerCommand = new RelayCommand(() => this.Browse(PathEnum.LiveStreamer));
            this.BrowseVlcCommand = new RelayCommand(() => this.Browse(PathEnum.Vlc));

            Messenger.Default.Register<ViewActionMessage>(this, this.HandleViewActionMessage);
        }

        private enum PathEnum
        {
            LiveStreamer,
            Vlc
        }

        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public RelayCommand BrowseLivestreamerCommand { get; set; }

        public RelayCommand BrowseVlcCommand { get; set; }

        public override void Initialize()
        {
        }

        public override void InitializeModel()
        {
            this.Model.Settings = this.Service.GetSettings();
        }

        private static string OpenFileDialog(string currentPath)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.DefaultExt = ".exe";
            fileDialog.Filter = "Application (.exe)|*.exe";

            if (File.Exists(currentPath))
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(currentPath);
                fileDialog.FileName = currentPath;
            }

            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            return currentPath;
        }

        private bool CanSave()
        {
            if (this.Model == null)
            {
                return false;
            }

            return this.Service.Validate(this.Model.Settings);
        }

        private void Cancel()
        {
            this.Close();
        }

        private void Save()
        {
            this.Service.Save(this.Model.Settings);

            this.Close();
        }

        private void Close()
        {
            Messenger.Default.Send(new ViewActionMessage(this.GetType(), ViewActionEnum.Close));
        }

        private void Browse(PathEnum control)
        {
            switch (control)
            {
                case PathEnum.LiveStreamer:
                    this.Model.Settings.LiveStreamerPath = OpenFileDialog(this.Model.Settings.LiveStreamerPath);
                    break;
                case PathEnum.Vlc:
                    this.Model.Settings.VlcPath = OpenFileDialog(this.Model.Settings.VlcPath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("control");
            }
        }

        private void HandleViewActionMessage(ViewActionMessage message)
        {
            if (message.ViewType != this.GetType())
            {
                return;
            }

            if (message.Action == ViewActionEnum.Open)
            {
                this.InitializeModel();
            }
        }
    }
}