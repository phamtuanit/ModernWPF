using GoogleDrive.Authentication.Business;
using GoogleDrive.Core.Commands;
using GoogleDrive.Core.IoC;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoogleDrive.Authentication.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string password;
        private IAuthenticator authenticator;

        public ICommand LoginCmd { get; set; }
        public ICommand CancelCmd { get; set; }
        public ICommand PasswordChangeCmd { get; set; }
        public string Username { get; set; }

        public LoginViewModel()
        {
            this.authenticator = Container.Current.Resolve<IAuthenticator>();
            this.LoginCmd = new RelayCommand<object>(this.OnLogin);
            this.CancelCmd = new RelayCommand<object>(this.OnCancel);
            this.PasswordChangeCmd = new RelayCommand<object>(this.OnPasswordChanged);
        }

        private void OnPasswordChanged(object sender)
        {
            this.password = ((PasswordBox)sender).Password;
        }

        private void OnLogin(object sender)
        {
            if (this.authenticator.Login(this.Username, this.password))
            {
                ((Window)sender).Close();
            } // ELSE - TODO: to be done later
        }

        private void OnCancel(object sender)
        {
            //Application.Current.Shutdown(0);
            Environment.Exit(0);
        }
    }
}
