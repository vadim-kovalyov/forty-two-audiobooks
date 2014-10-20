using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public interface IBookService
    {
        Task<Books> GetRecentBooksAsync();

        Task<Books> GetAllBooksAsync();
    }

    public class BookService : IBookService
    {
        public Task<Books> GetRecentBooksAsync()
        {
            var result = new Books();
            result.Add(new Book() { Source = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime two", Title = "Dictumst eleifend facilisi faucibus" });
            return Task.FromResult(result);
        }

        public Task<Books> GetAllBooksAsync()
        {
            var result = new Books();
            result.Add(new Book() { Source = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime two", Title = "Dictumst eleifend facilisi faucibus" });
            result.Add(new Book() { Source = "runtime three", Title = "Habitant inceptos interdum lobortis" });
            result.Add(new Book() { Source = "runtime four", Title = "Nascetur pharetra placerat pulvinar" });
            result.Add(new Book() { Source = "runtime five", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            return Task.FromResult(result);
        }
    }
}
