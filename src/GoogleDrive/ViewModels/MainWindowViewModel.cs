using GoogleDrive.Core.Commands;
using GoogleDrive.Core.IoC;
using GoogleDrive.Core.Region;
using GoogleDrive.Models;
using ModernWpf.Controls;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GoogleDrive.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IRegionManager regionManager;

        public string WindowTitle => "Google Drive";
        public string NavigationTitle => "Workspaces";
        public IList<NavigationViewItem> MenuItems { get; set; } = new ObservableCollection<NavigationViewItem>();
        public NavigationViewItem SelectedItem { get; set; }
        public ICommand MenuSelectedCmd { get; set; }
        public ICommand WindowLoadedCmd { get; set; }

        public MainWindowViewModel()
        {
            this.regionManager = Container.Current.Resolve<IRegionManager>();
            this.MenuSelectedCmd = new RelayCommand<object>(this.OnMenuSelected);
            this.WindowLoadedCmd = new RelayCommand<object>(this.OnWindowLoaded);
            this.RegisterMenus();
        }

        private void RegisterMenus()
        {
            this.MenuItems.Add(new NavigationItem(this.OnOpenLocalDrive)
            {
                Icon = new SymbolIcon(Symbol.ProtectedDocument),
                Content = "My ThinkPad Laptop",
            });
            this.MenuItems.Add(new NavigationItem(this.OnOpenDrive)
            {
                Icon = new SymbolIcon(Symbol.SyncFolder),
                Content = "Google Drive",
            });

            this.SelectedItem = this.MenuItems[0];
        }

        private void OnWindowLoaded(object obj)
        {
            ((NavigationItem)this.SelectedItem).Invoke();
        }

        private void OnOpenDrive()
        {
            this.regionManager.RequestNavigate(RegionNames.MainContent, new Uri("RemoteDriveView", UriKind.Relative));
        }

        private void OnOpenLocalDrive()
        {
            this.regionManager.RequestNavigate(RegionNames.MainContent, new Uri("LocalDriveView", UriKind.Relative));
        }

        private void OnMenuSelected(object sender)
        {
            if (this.SelectedItem is NavigationItem menu)
            {
                menu.Invoke();
            }
            else
            {
                // Open Setting page
                var regionManager = Container.Current.Resolve<IRegionManager>();
                regionManager.RequestNavigate(RegionNames.MainContent, new Uri("SettingsView", UriKind.Relative));
            }
        }
    }
}
