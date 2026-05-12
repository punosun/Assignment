using System;
using LibraryManagement;

namespace LibraryManagement;

public class Book
{

    public Book(string Title, string Author, string Isbn)
    {
        this.Title = Title;
        this.Author = Author;
        this.Isbn = Isbn;
        this.status = "Available";
    }

    public string Title;
    public string Author;
    public string Isbn; 
    public string Status;

    public string ISBN { get; set; }
    
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

    public class Book1
    {
        public string Title { get; set; }
        public bool IsAvailable { get; private set; }

        public Book1(string title)
        {
            Title = title;
            IsAvailable = true; // default status
        }


    }
    public string status = "available";

    public void SetStatus(string v)
    {
        
        status = "Available";

        if (status == "Available")
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
