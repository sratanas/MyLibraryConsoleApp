namespace MyLibrary.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int  AuthorId { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
