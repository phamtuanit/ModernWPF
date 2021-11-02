using GoogleDrive.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace GoogleDrive.ViewModels
{
    public class RecentPhotosViewModel : BindableBase
    {
        public ObservableCollection<ImageObject> Images { get; set; } = new ObservableCollection<ImageObject>();

        public RecentPhotosViewModel()
        {
            this.LoadPhotos();
        }

        private void LoadPhotos()
        {
            for (int i = 0; i < 8; i++)
            {
                this.Images.Add(new ImageObject($"/Assets/SampleMedia/LandscapeImage{i + 1}.jpg"));
            }

            for (int i = 7; i >= 0; i--)
            {
                this.Images.Add(new ImageObject($"/Assets/SampleMedia/LandscapeImage{i + 1}.jpg"));
            }
        }
    }
}
