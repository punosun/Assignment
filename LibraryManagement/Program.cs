using System;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new LibraryLogic();
    
            var book1 = new Book("Star", "Yokio Mishima", "9780241383476");
            var book2 = new Book("Pale Fire", "Vladimir Nabokov", "9780141185262");
            var book3 = new Book("The King in Yellow", "Robert W. Chambers", "9781840226447");
            var book4 = new Book("Blood Meridian", "Cormac McCarthy", "9780679641041");
    
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            var customer1 = new Customer("Adam Andersson", "001");
            var customer2 = new Customer("Bea Bengtsson", "002");
            var customer3 = new Customer("Cleas Carlsson", "003");
            var customer4 = new Customer("David Dean", "004");
    
            library.AddCustomer(customer1);
            library.AddCustomer(customer2);
            library.AddCustomer(customer3);
            library.AddCustomer(customer4);

            //********************************************
            //****** LIBRARY MANAGEMENT SYSTEM MENU ******
            //********************************************

            Console.Clear();
            Console.WriteLine("\n  📕 WELCOME TO LIBRARY MANAGEMENT SYSTEM!\n");

            bool continue_menu = true;
            while (continue_menu)
            {
                Console.WriteLine("   MENU\n" +
                                  "------------------------------------------\n" +
                                  " 1. View all books\n" +
                                  " 2. Register new book\n" +
                                  " 3. Delete book from system\n" +
                                  " 4. View all customers\n" +
                                  " 5. Register new customer\n" +
                                  " 6. Remove customer from system\n" +
                                  " 7. Loan a book to a customer\n" +
                                  " 8. Return a book\n" +
                                  " 9. Display customer information\n" +
                                  "10. Display books on loan\n" +
                                  " 0. Exit");
                Console.Write("Choose program to run (0-10): ");


                string input = Console.ReadLine()!;

                if (int.TryParse(input, out int run_prog))
                {
                    if (run_prog >= 0 && run_prog <= 9)
                    {
                        if (run_prog == 1)  { ViewBooks(); }
                        //if (run_prog == 2)  { RegisterBook(); }
                        //if (run_prog == 3)  { DeleteBook(); }
                        if (run_prog == 4)  { ViewCustomers(); }
                        if (run_prog == 5)  { RegisterCustomer(); }
                        if (run_prog == 6)  { RemoveCustomer(); }
                        if (run_prog == 7)  { LoanBookToCustomer(); }
                        if (run_prog == 8)  { ReturnBook(); }
                        if (run_prog == 9)  { DisplayCustomerInfo(); }
                        //if (run_prog == 10) { DisplayBooksOnLoan(); }
                        if (run_prog == 0)  { continue_menu = false; }
                    }
                    else
                    {
                        Console.WriteLine("Bad input, try again.");    
                    }
                }
                else
                {
                    Console.WriteLine("Bad input, try again.");
                }
                 Console.WriteLine();
            }

            // 1. VIEW ALL BOOKS
            void ViewBooks()
            {
                Console.Clear();
                Console.WriteLine("VIEW ALL BOOKS");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("Title                    Author                 ISBN                  Status    ");
                Console.WriteLine("--------------------------------------------------------------------------------");
    
                foreach (var book in library.GetBooks())
                {
                    if (book.Status == "Available")
                    {
                        Console.WriteLine($"{book.Title,-25}{book.Author,-23}{book.ISBN,-23}📗 {book.Status}");    
                    }
                    else
                    {
                        Console.WriteLine($"{book.Title,-25}{book.Author,-23}{book.ISBN,-23}📕 {book.Status}");
                    }
                    
                }
                Hold();
            }

            // 4. VIEW ALL CUSTOMERS
            void ViewCustomers()
            {
                Console.Clear();
                Console.WriteLine("VIEW ALL CUSTOMERS");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Name                          ID                                    ");
                Console.WriteLine("--------------------------------------------------------------------");
    
                foreach (var customer in library.GetCustomers())
                {
                    Console.WriteLine($"{customer.Name,-30}{customer.CustomerID,-25}");
                }
                Hold();
            }

            // 5. REGISTER NEW CUSTOMER
            void RegisterCustomer()
            {
                Console.Clear();
                Console.WriteLine("REGISTER NEW CUSTOMER");
                Console.WriteLine("--------------------------------------------------------------------");

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Enter Customer ID: ");
                string id = Console.ReadLine()!;

                // Validation: Check if they left it blank
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("Error: Name and ID cannot be empty.");
                }
                else
                {
                    // Create the object and add it to the library
                    Customer newCustomer = new Customer(name, id);
                    library.AddCustomer(newCustomer);
                    Console.WriteLine($"\n[SUCCESS] Customer '{name}' successfully registered!");
                }
                Hold();
            }

            // 6. REMOVE CUSTOMER FROM SYSTEM

            void RemoveCustomer()
            {
                Console.Clear();
                Console.WriteLine("REMOVE CUSTOMER FROM SYSTEM");
                Console.WriteLine("--------------------------------------------------------------------");

                Console.Write("Enter the ID of the customer to remove: ");
                string id = Console.ReadLine()!;

                var customer = library.GetCustomers().FirstOrDefault(c => c.CustomerID == id);

                if (customer == null)
                {
                    // Error Label
                    Console.WriteLine("\n[ERROR] No customer found with that ID.");
                }
                else
                {
                    if (customer.LoanedBooks.Count > 0)
                    {
                        // Warning Label
                        Console.WriteLine($"\n[WARNING] Cannot remove {customer.Name}. Return all books first.");
                    }
                    else
                    {
                        library.RemoveCustomer(id);
                        // Success Label
                        Console.WriteLine($"\n[SUCCESS] Customer '{customer.Name}' removed.");
                    }
                }
                Hold();
            }

            // 7. LOAN A BOOK TO A CUSTOMER
            void LoanBookToCustomer()
            {
                Console.Clear();
                Console.WriteLine("LOAN A BOOK TO A CUSTOMER");
                Console.WriteLine("--------------------------------------------------------------------");
                
                Console.Write("Enter book ISBN: ");
                string isbn_input = Console.ReadLine()!;
                
                Console.Write("Enter customer ID: ");
                string customerID = Console.ReadLine()!;
                
                library.LoanBook(isbn_input, customerID);
                Hold();
            }

            // 8. RETURN A BOOK AND MAKE IT AVAILABLE
            void ReturnBook()
            {
                Console.Clear();
                Console.WriteLine("RETURN A BOOK");
                Console.WriteLine("--------------------------------------------------------------------");
                
                Console.Write("Enter book ISBN: ");
                string isbn_input = Console.ReadLine()!;
                
                Console.Write("Enter customer ID: ");
                string customerID = Console.ReadLine()!;

                library.ReturnBook(isbn_input, customerID);
                Hold();
            }

            // 9. DISPLAY CUSTOMER INFORMATION
            void DisplayCustomerInfo()
            {
                Console.Clear();
                Console.WriteLine("DISPLAY CUSTOMER INFORMATION");
                Console.WriteLine("--------------------------------------------------------------------");
                
                Console.Write("Enter customer ID: ");
                string customerID = Console.ReadLine()!;
                Customer? customer = library.customers.FirstOrDefault(c => c.CustomerID == customerID);
                if (customer == null)
                {
                    Console.WriteLine("Customer not in the system.");
                    return;
                }
                Console.WriteLine(customer.GetInfo());
                Hold();
            }

            // 10. DISPLAY BOOKS ON LOAN
            /*
            void DisplayBooksOnLoan()
            {
                Console.Clear();
                Console.WriteLine("VIEW ALL BOOKS");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("Title                    Author                 ISBN                  Customer    ");
                Console.WriteLine("--------------------------------------------------------------------------------");
    
                foreach (var book in library.GetCustomerLoans())
                {
                    Console.WriteLine($"{book.Title,-25}{book.Author,-23}{book.ISBN,-23}{customer.Name}");    
                }
            }
            */

            // HOLD METHOD FOR SMOOTHER USER EXPERIENCE
            // GIVES USER TIME TO READ MESSAGE BEFORE RETURNING TO MENU
            static void Hold()
            {
                Console.Write("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}