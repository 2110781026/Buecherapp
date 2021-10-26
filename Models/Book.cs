using System.ComponentModel.DataAnnotations;

namespace Buecherapp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        public int? Rating { get; set; }

        public bool IsRead { get; set; }

        public bool Owned { get; set; }

        public string CurrentlyLentTo { get; set; }

        [RegularExpression (@"^\d{10,13}$")]
        public string ISBN { get; set; }


    }

}
