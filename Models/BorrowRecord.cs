namespace LibrarySystem.Models
{
    public class BorrowRecord
    {
        public User User { get; }
        public Book Book { get; }
        public DateTime BorrowedAt { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnedAt { get; private set; }
        public bool IsReturned => ReturnedAt != null;

        private const int BorrowDays = 14;
        private const int FinePerDay = 10;

        public BorrowRecord(User user, Book book)
        {
            User = user;
            Book = book;
            BorrowedAt = DateTime.Now;
            DueDate = BorrowedAt.AddDays(BorrowDays);
        }

        public void MarkReturned()
        {
            ReturnedAt = DateTime.Now;
        }

        public bool IsOverdue()
        {
            return !IsReturned && DateTime.Now > DueDate;
        }

        public int CalculateFine()
        {
            if (!IsReturned) return 0;
            var overdueDays = (ReturnedAt.Value - DueDate).Days;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        public override string ToString()
        {
            return $"{Book.Title} borrowed on {BorrowedAt:yyyy-MM-dd}, due {DueDate:yyyy-MM-dd}, returned: {ReturnedAt?.ToString("yyyy-MM-dd") ?? "No"}";
        }
    }
}