// View Models are used to offer data to a client 

namespace Buecherapp.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int? Rating { get; set; }

        public string Description {get; set;}

        public string ISBN { get; set; }

    }
}