using GoogleDrive.Core.Commands;
using ModernWpf;
using Prism.Mvvm;
using System.Windows.Input;
using System.Windows.Threading;

namespace GoogleDrive.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public ICommand ToggeThemeCmd { get; set; }

        public SettingsViewModel()
        {
            this.ToggeThemeCmd = new RelayCommand<object>(this.OnoggeTheme);
        }

        private void OnoggeTheme(object obj)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                }
                else
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                }
            });
        }
    }
}
