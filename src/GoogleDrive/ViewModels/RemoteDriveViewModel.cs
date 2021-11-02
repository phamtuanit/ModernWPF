using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDrive.ViewModels
{
    public class RemoteDriveViewModel : BindableBase
    {
        public ObservableCollection<string> RecentFiles { get; set; } = new ObservableCollection<string>(); 
        public ObservableCollection<string> Folders { get; set; } = new ObservableCollection<string>();

        public RemoteDriveViewModel()
        {
            this.LoadRecentFile();
        }

        private void LoadRecentFile()
        {
            this.RecentFiles.Add("Business Report.xls");
            this.RecentFiles.Add("Weekly MOM.xls");
            this.RecentFiles.Add("Development_Phase_1_Report.ppt");


            this.Folders.Add("Document");
            this.Folders.Add("Pictures");
            this.Folders.Add("Programs");
        }
    }
}
