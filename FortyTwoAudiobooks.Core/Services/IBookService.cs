using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortyTwoAudiobooks.Core.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public interface IBookService
    {
        Books GetRecentBooks();

        Books GetAllBooks();
    }

    public class BookService : IBookService
    {
        public Books GetRecentBooks()
        {
            var result = new Books();
            result.Add(new Book() { Source = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime two", Title = "Dictumst eleifend facilisi faucibus" });
            return result;
        }

        public Books GetAllBooks()
        {
            var result = new Books();
            result.Add(new Book() { Source = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime two", Title = "Dictumst eleifend facilisi faucibus" });
            result.Add(new Book() { Source = "runtime three", Title = "Habitant inceptos interdum lobortis" });
            result.Add(new Book() { Source = "runtime four", Title = "Nascetur pharetra placerat pulvinar" });
            result.Add(new Book() { Source = "runtime five", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            return result;
        }
    }
}
