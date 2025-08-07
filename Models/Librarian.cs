using LibrarySystem.Models.Abstract;
using LibrarySystem.Services;

namespace LibrarySystem.Models
{
    public class Librarian : Person
    {
        public Librarian(string name) : base(name) { }

        public void AddBook(Library library, Book book)
        {
            library.AddBook(book);
        }

        public void RegisterUser(Library library, User user)
        {
            library.RegisterUser(user);
        }
    }
}