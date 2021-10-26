// View Models are used to offer data to a client 

using System.ComponentModel.DataAnnotations;

namespace Buecherapp.ViewModels{

    public class BookEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int? Rating { get; set; }

        public bool? IsRead { get; set; }

        public bool? Owned { get; set; }

        public string CurrentlyLentTo { get; set; }

        [RegularExpression (@"^\d{10,13}$")]
        public string ISBN { get; set; }


    }

}