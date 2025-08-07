using LibrarySystem.Models.Abstract;
using LibrarySystem.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class User : Person, IBorrowable
    {
        public List<BorrowRecord> BorrowedRecords { get; }

        public User(string name) : base(name)
        {
            BorrowedRecords = new List<BorrowRecord>();
        }

        public virtual void Borrow(Book book)
        {
            if (book.IsAvailable)
            {
                book.IsAvailable = false;
                var record = new BorrowRecord(this, book);
                BorrowedRecords.Add(record);
                Console.WriteLine($"{Name} borrowed {book.Title} (due {record.DueDate:yyyy-MM-dd})");
            }
            else
            {
                Console.WriteLine($"{book.Title} is not available.");
            }
        }

        public virtual void Return(Book book)
        {
            var record = BorrowedRecords.Find(r => r.Book == book && !r.IsReturned);
            if (record != null)
            {
                record.MarkReturned();
                book.IsAvailable = true;
                Console.WriteLine($"{Name} returned {book.Title}");

                if (record.IsOverdue())
                    Console.WriteLine($"⚠️ Overdue! Fine: {record.CalculateFine()} units");
            }
            else
            {
                Console.WriteLine($"{Name} doesn’t have {book.Title}");
            }
        }
    }
}