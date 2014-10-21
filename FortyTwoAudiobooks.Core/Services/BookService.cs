using System.Linq;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public class BookService : IBookService
    {
        private readonly Books books;

        public BookService()
        {
            books = new Books();
            books.Add(new Book() { Source = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            books.Add(new Book() { Source = "runtime two", Title = "Dictumst eleifend facilisi faucibus" });
            books.Add(new Book() { Source = "runtime three", Title = "Habitant inceptos interdum lobortis" });
            books.Add(new Book() { Source = "runtime four", Title = "Nascetur pharetra placerat pulvinar" });
            books.Add(new Book() { Source = "runtime five", Title = "Maecenas praesent accumsan bibendum" });
            books.Add(new Book() { Source = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            books.Add(new Book() { Source = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
        }

        public async Task<Books> GetRecentBooksAsync()
        {
            var result = new Books();
            result.Add(books.FirstOrDefault());
            result.Add(books.LastOrDefault());

            await Task.Delay(1000);

            return await Task.FromResult(result);
        }

        public Task<Books> GetAllBooksAsync()
        {
            return Task.FromResult(books);
        }
    }
}