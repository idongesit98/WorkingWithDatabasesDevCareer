namespace WorkingWithDatabasesDevCareer.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary key
        public string Title { get; set; } = string.Empty; // Book title
        public string Author { get; set; } = string.Empty; // Author of the book
    }
}
