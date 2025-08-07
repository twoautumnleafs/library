namespace LibrarySystem.Models
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        public Category Category { get; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn, Category category)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Category = category;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} [{Category.Name}] (ISBN: {ISBN})";
        }
    }
}