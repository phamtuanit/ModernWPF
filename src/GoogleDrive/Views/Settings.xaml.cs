using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace GoogleDrive.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    [Export("SettingsView")]
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }
    }
}
