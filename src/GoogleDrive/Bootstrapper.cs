using GoogleDrive.Authentication.Business;
using GoogleDrive.Authentication.Views;
using GoogleDrive.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace GoogleDrive
{
    class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Core.IoC.Container.Current = Container;
            var shell = Container.Resolve<MainWindow>();
            shell.Loaded += OnShellLoaded;
            shell.Hide();

            return shell;
        }

        private void OnShellLoaded(object sender, RoutedEventArgs e)
        {
            var authenticator = Container.Resolve<IAuthenticator>();
            authenticator.LoadUserInfo();
            if (!authenticator.IsAuthenticated())
            {
                var window = (Window)sender;
                if (!this.ShowLoginDialog(window))
                {
                    window.Close();
                }
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.SetupRegions(containerRegistry);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\" };
        }

        private bool ShowLoginDialog(Window main)
        {
            var loginDialog = new Login()
            {
                Owner = main,
            };
            loginDialog.ShowDialog();
            return Container.Resolve<IAuthenticator>().IsAuthenticated();
        }

        private void SetupRegions(IContainerRegistry containerRegistry)
        {
            // MainWindow content
            containerRegistry.RegisterForNavigation(typeof(Settings), "SettingsView");
            containerRegistry.RegisterForNavigation(typeof(LocalDrive), "LocalDriveView");
            containerRegistry.RegisterForNavigation(typeof(RemoteDrive), "RemoteDriveView");
        }
    }
}
