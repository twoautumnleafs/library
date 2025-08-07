using LibrarySystem.Models;
using LibrarySystem.Services;

class Program
{
    static void Main()
    {
        var library = new Library();
        library.AddCategory(new Category("Science"));
        library.AddCategory(new Category("Mystery"));
        var fiction = new Category("Fiction");
        library.AddCategory(fiction);
        library.AddBook(new Book("1984", "George Orwell", "123456", fiction));
        library.AddBook(new Book("Brave New World", "Aldous Huxley", "789101", fiction));
        var librarian = new Librarian("Admin");

        while (true)
        {
            Console.WriteLine("\nLibrary System");
            Console.WriteLine("1. Login as User");
            Console.WriteLine("2. Login as Librarian");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            var roleChoice = Console.ReadLine();

            switch (roleChoice)
            {
                case "1":
                    RunUserMenu(library);
                    break;
                case "2":
                    RunLibrarianMenu(library, librarian);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void RunUserMenu(Library library)
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        var user = library.GetUserByName(name!);

        if (user == null)
        {
            Console.WriteLine("User not found. Please register with a librarian.");
            return;
        }

        while (true)
        {
            Console.WriteLine($"\nUser: {user.Name}");
            Console.WriteLine("1. Borrow a book");
            Console.WriteLine("2. Return a book");
            Console.WriteLine("3. My borrow history and fines");
            Console.WriteLine("4. View available books");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    var title = Console.ReadLine();
                    var book = library.GetBookByTitle(title!);

                    if (book != null)
                        user.Borrow(book);
                    else
                        Console.WriteLine("Book not found.");
                    break;

                case "2":
                    Console.Write("Enter book title: ");
                    var title2 = Console.ReadLine();
                    var book2 = library.GetBookByTitle(title2!);

                    if (book2 != null)
                        user.Return(book2);
                    else
                        Console.WriteLine("Book not found.");
                    break;

                case "3":
                    Console.WriteLine("Your Borrow Records:");
                    foreach (var record in user.BorrowedRecords)
                    {
                        Console.WriteLine(record);
                        if (record.IsReturned && record.CalculateFine() > 0)
                            Console.WriteLine($"⚠️ Fine: {record.CalculateFine()} units");
                    }
                    break;

                case "4":
                    library.ShowBooks();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void RunLibrarianMenu(Library library, Librarian librarian)
    {
        while (true)
        {
            Console.WriteLine($"\nLibrarian: {librarian.Name}");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Register a new user");
            Console.WriteLine("3. View categories");
            Console.WriteLine("4. View all books");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Book title: ");
                    var title = Console.ReadLine();
                    Console.Write("Author: ");
                    var author = Console.ReadLine();
                    Console.Write("ISBN: ");
                    var isbn = Console.ReadLine();
                    Console.Write("Category: ");
                    var categoryName = Console.ReadLine();

                    var category = library.GetCategoryByName(categoryName!);
                    if (category == null)
                    {
                        Console.WriteLine("Category not found. Creating a new one...");
                        category = new Category(categoryName!);
                        library.AddCategory(category);
                    }

                    var book = new Book(title!, author!, isbn!, category);
                    librarian.AddBook(library, book);
                    break;

                case "2":
                    Console.Write("New user's name: ");
                    var name = Console.ReadLine();
                    var newUser = new User(name!);
                    librarian.RegisterUser(library, newUser);
                    break;

                case "3":
                    Console.WriteLine("Categories:");
                    library.ShowCategories();
                    break;

                case "4":
                    library.ShowBooks();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}