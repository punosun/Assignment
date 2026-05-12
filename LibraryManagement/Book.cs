namespace LibraryManagement;

public class Book
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

{
    internal class Book
    {

        public Book(string title, string author, string isbn, string status)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.status = status;
        }

        public string title;
        public string author;
        public string isbn;
        public string status;

        public string getTitle()

        { return title; }
    
        public string getAuthor()

        { return author; }
       
        public string getIsbn()
        { return isbn; }
        
        public void GetDetails()
        {
            Console.WriteLine(" Title: " + title + ": " + " Author: " + author +  "  " + " ISBN: " + isbn + " ");
        }

        public void SetStatus() // Check if book is available or on loan
        { 

        }

        
    }


}
}
