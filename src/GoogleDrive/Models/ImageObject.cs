namespace GoogleDrive.Models
{
    public class ImageObject
    {
        public string Location { get; private set; }

        public ImageObject(string location)
        {
            this.Location = location;
        }
    }
}
