namespace LibrarySystem.Models.Interfaces
{
    public interface IBorrowable
    {
        void Borrow(Book book);
        void Return(Book book);
    }
}