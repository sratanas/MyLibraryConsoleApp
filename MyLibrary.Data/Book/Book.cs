using MyLibrary.Business;

namespace MyLibrary.Data
{



    public class Book : Media
    {
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Location Location { get; set; }


    }
}
