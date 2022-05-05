using System;
using System.Collections.Generic;

class Library {
    public string name { get; set; }
    public List<Book> books { get; set; }
    public int maxBooks { get; set; }

    public Library(string name, int maxBooks) {
        this.name = name;
        this.maxBooks = maxBooks;
        books = new List<Book>();
    }

    public void AddBook(Book book) {
        if(books.Count < maxBooks) {
            books.Add(book);
        }
    }

    public void List() {
        foreach(Book book in books) {
            Console.WriteLine(book.Print());
        }
    }

    public void FindByName(string name) {
        foreach(Book book in books) {
            if(book.Title.Contains(name)) {
                Console.WriteLine(book.Print());
            }
        }
    }

    public void ListAncientBooks() {
        foreach(Book book in books) {
            if(book is AncientBook) {
                Console.WriteLine(book.Print());
            }
        }
    }
}