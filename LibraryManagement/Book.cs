using System;
using LibraryManagement;

namespace LibraryManagement;

public class Book(string title, string author, string isbn)
{
    public string Title = title;
    public string Author = author;
    public string ISBN = isbn;    // Should this be removed? There is already an ISBN (row 22)
    public string Status = "Available";
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
