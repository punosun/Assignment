using System;
using LibraryManagement;

namespace LibraryManagement;

public class Book
{
    // Parameters can't have the same name as properties - change to title, author, isbn (små bokstäver)
    public Book(string Title, string Author, string Isbn)
    {
        this.Title = Title;
        this.Author = Author;
        this.Isbn = Isbn;
        this.status = "Available";
    }

    public string Title;
    public string Author;
    public string Isbn;    // Should this be removed? There is already an ISBN (row 22)
    public string Status;

    public string ISBN { get; set; }  // These Get...() methods are not needed since all properties are public
    
    public string GetTitle()

    { return Title; }

    public string GetAuthor()

    { return Author; }

    public string GetIsbn()
    { return Isbn; }

    public void GetDetails()
    {
        Console.WriteLine(" Title: " + Title + ": " + " Author: " + Author + "  " + " ISBN: " + Isbn + " ");
    }

    /* Why another class? Is this a "test" class

    public class Book1
    {
        public string Title { get; set; }
        public bool IsAvailable { get; private set; }

        public Book1(string title)
        {
            Title = title;
            IsAvailable = true; // default status
        }
    }  */

    public string status = "available";  // Don't need this. Property already decleared in row 20

    public void SetStatus(string v)  // Parameter 'v' i not used anywhere in the method
    {
        status = "Available";

        if (status == "Available")  // This will always be true because you just set status to "Available"
        {
            Console.WriteLine($"{Title} is available.");
        }
        else
        {
            Console.WriteLine($"{Title} is on loan.");
        }
    }
    
    public string GetStatus()
    {
        return status;
    }
}


/*

// THIS IS ALL YOUR CLASS NEEDS:
// - 4 "STRING" PROPERTIES
// - 1 CONSTRUCTOR THAT TAKES 3 ARGUMENTS
// - 1 SetStatus METHOD THAT TAKES 1 STRING ARGUMENT
// - 1 GetDetails METHOD THAT RETURNS A STRING

using System;

namespace LibraryTest
{
    public class Book
    {   

        public string Title;
        public string Author;
        public string ISBN;          // Unique
        public string Status;        // "Available" or "On Loan"

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Status = "Available";
        }

        public void SetStatus(string status)
        {
            var list = new String[] {"Available", "On Loan"};
            
            if (list.Contains(status))
            {
                Status = status;                
            }
        }

        public string GetDetails()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Status: {Status}"
        }
    }
}
*/
