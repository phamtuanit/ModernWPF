using GoogleDrive.Core.IoC;
using GoogleDrive.Region;
using GoogleDrive.Views;
using Prism.Ioc;
using Prism.Regions;

namespace GoogleDrive.ViewModels
{
    public class LocalDriveViewModel
    {
        public LocalDriveViewModel()
        {
            this.Init();
        }

        private void Init()
        {
            var regionManager = Container.Current.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(InternalRegionNames.RecentPhotos, typeof(RecentPhotos));
        }
    }
}
