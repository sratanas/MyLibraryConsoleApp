namespace MyLibrary.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IsFemale { get; set; }

        public string FullAuthorName => $"{FirstName} {LastName}";

    }
}
