using System.Collections.Generic;

namespace Buecherapp.ViewModels
{
    public class GoogleBookItems
    {
        public IEnumerable<GoogleBook> Items { get; set; }
    }

    public class GoogleBook
    {
        public GoogleVolumeInfo VolumeInfo { get; set; }
    }

    public class GoogleVolumeInfo
    {
        public string Description { get; set; }
    }
}