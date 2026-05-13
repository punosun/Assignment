using System;
using LibraryManagement;

namespace LibraryManagement;

public class Book
{
    public string Title;
    public string Author;
    public string ISBN;
    public string Status;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Status = "Available";
    }
    
    public string GetDetails()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Status: {Status}";
    }
    
    public void SetStatus(string status)
    {
        var list = new String[] {"Available", "On Loan"};
            
        if (list.Contains(status))
        {
            Status = status;                
        }
    }    
}
