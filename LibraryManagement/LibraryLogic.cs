using System;

namespace LibraryManagement
{
    public class LibraryLogic
    {
        public List<Book> books;
        public List<Customer> customers;

        public LibraryLogic()
        {
            books = new List<Book>();
            customers = new List<Customer>();
        }

        public List<Book> GetBooks()
        {
            // Simply returns the books list
            return books;
        }
        
        public void AddBook(Book book)
        {
            // Check if ISBN already exists in books list
            foreach (Book b in books)
            {
                if (b.ISBN == book.ISBN)
                {
                    Console.WriteLine("Book already exists.");
                }
            }
            books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        public void RemoveBook(string isbn)
        {
            // Search for the book
            foreach (Book b in books)
            {
                if (b.ISBN == isbn)
                {
                    // Check if book status is "On Loan"
                    if (b.Status == "On Loan")
                    {
                        Console.WriteLine("Book is on loan.");
                    }

                    books.Remove(b);
                    Console.WriteLine("Book removed successfully.");
                    return;
                }
            }

            Console.WriteLine("Book not found.");
        }

        public List<Customer> GetCustomers()
        {
             // Simply returns the customers list
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            // Check if customer is already in the list (ID)
            foreach (Customer c in customers)
            {
                if (c.CustomerID == customer.CustomerID)
                {
                    Console.WriteLine("Customer already exists.");
                }
            }

            customers.Add(customer);
            Console.WriteLine("Customer added successfully.");
        }

        public void RemoveCustomer(string customerId)
        {
            // Find customer
            foreach (Customer c in customers)
            {
                if (c.CustomerID == customerId)
                {
                    // Check if customer have loaned books
                    if (c.LoanedBooks.Count > 0)
                    {
                        Console.WriteLine("Customer has loaned books.");
                    }

                    customers.Remove(c);
                    Console.WriteLine("Customer removed successfully.");
                    return;
                }
            }

            Console.WriteLine("Customer not found.");
        }

        public void LoanBook(string isbn, string customerId)
        {
            // Create 'empty' book and costumer
            Book? book = null;
            Customer? customer = null;

            // Check if book exists
            foreach (Book b in books)
            {
                if (b.ISBN == isbn)
                {
                    book = b;
                }
            }

            // Check if customer exsists
            foreach (Customer c in customers)
            {
                if (c.CustomerID == customerId)
                {
                    customer = c;
                }
            }

            // Handle exceptions if book or customer is not found or if book status is "On Loan"
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            if (book.Status == "On Loan")
            {
                Console.WriteLine("Book already loaned.");
                return;
            }

            book.SetStatus("On Loan");
            customer.AddLoan(book);
            Console.WriteLine($"\"{book.Title}\" loaned to {customer.Name} successfully.");
        }

        public void ReturnBook(string isbn, string customerId)
        {
            // First find the customer ....
            foreach (Customer customer in customers)
            {
                if (customer.CustomerID == customerId)
                {
                    // ... and then go through its loaned books to find ISBN
                    foreach (Book book in customer.LoanedBooks)
                    {
                        if (book.ISBN == isbn)
                        {
                            book.SetStatus("Available");
                            customer.RemoveLoan(isbn);
                            Console.WriteLine($"\"{book.Title}\" returned successfully.");
                            return;
                        }
                    }
                }
            }
            
            Console.WriteLine("Loan record not found.");
        }

        /*public string GetCustomerLoans()
        {
            // List of all loaned books and the customers that have loaned them?
        }
        */
    }
}
