using System;
using System.Collections.Generic;
namespace LibraryManagement;
{
    public class Customer
    {
        // Data for each customer
        public string Name { get; set; }
        public string CustomerID { get; set; } // Should be unique

        // List for 'Book' objects. 
        public List<Book> LoanedBooks { get; set; }

        // This runs when you create a "new" customer
        public Customer(string name, string id)
        {
            Name = name;
            CustomerID = id;
            LoanedBooks = new List<Book>();
        }

        // 3. The options of a customer

        public void AddLoan(Book book)
        {
            // Adds a book to the customer's list
            LoanedBooks.Add(book);
        }

        public void RemoveLoan(Book book)
        {
            // Removes a book from the list
            LoanedBooks.Remove(book);
        }

        public string GetInfo()
        {
            // Returns a string with the customer's details and their books
            string info = $"ID: {CustomerID}, Name: {Name}\nBorrowed Books:";

            foreach (var book in LoanedBooks)
            {
                info += $"\n - {book.Title}";
            }
            return info;
        }
    }
}
