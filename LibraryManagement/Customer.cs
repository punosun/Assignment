using System;
using System.Collections.Generic;
namespace LibraryManagement
{
    public class Customer
        //final version
    {
        // Data for each customer
        public string Name { get; set; }
        public string CustomerID { get; set; } 

        // List for 'Book' objects. 
        public List<Book> LoanedBooks { get; set; }

        // This runs when you create a new customer
        public Customer(string name, string id)
        {
            Name = name;
            CustomerID = id;
            LoanedBooks = new List<Book>();
        }

        // The options of a customer

        public void AddLoan(Book book)
        {
            // Adds a book to the customer's list
            LoanedBooks.Add(book);
        }

        public void RemoveLoan(string isbn)
        {
            Book? bookToRemove = LoanedBooks.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                LoanedBooks.Remove(bookToRemove);
            }
        }

        public string GetInfo()
        {
            // Returns a string with the customer's details and their books
            string info = $"ID: {CustomerID}, Name: {Name}\nBorrowed Books:";

            if (LoanedBooks.Count == 0)
            {
                info += " None";
            }
            else
            {
                foreach (var book in LoanedBooks)
                {
                    info += $"\n - {book.Title}";
                }
            }
            return info;
        }
    }
}
