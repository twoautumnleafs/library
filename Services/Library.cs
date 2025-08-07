using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public class Library
    {
        private readonly List<Book> books = new();
        private readonly List<User> users = new();
        private readonly List<Category> categories = new();

        public void AddBook(Book book) => books.Add(book);
        public void RegisterUser(User user) => users.Add(user);

        public void AddCategory(Category category) => categories.Add(category);

        public void ShowBooks()
        {
            foreach (var book in books)
            {
                var status = book.IsAvailable ? "Available" : "Borrowed";
                Console.WriteLine($"{book} - {status}");
            }
        }

        public void ShowCategories()
        {
            foreach (var c in categories)
                Console.WriteLine(c.Name);
        }

        public Book? GetBookByTitle(string title) =>
            books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        public User? GetUserByName(string name) =>
            users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public Category? GetCategoryByName(string name) =>
            categories.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}