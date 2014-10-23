using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;

namespace FortyTwoAudiobooks.Core.Services.Design
{
    public class DesignBookService : IBookService
    {
        public Task<ObservableCollection<Book>> GetRecentBooksAsync()
        {
            var result = new ObservableCollection<Book>();
            result.Add(new Book() { Source = "design one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "design two", Title = "Dictumst eleifend facilisi faucibus" });
            return Task.FromResult(result);
        }

        public Task<ObservableCollection<Book>> GetAllBooksAsync()
        {
            var result = new ObservableCollection<Book>();
            result.Add(new Book() { Source = "design one", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "design two", Title = "Dictumst eleifend facilisi faucibus" });
            result.Add(new Book() { Source = "design three", Title = "Habitant inceptos interdum lobortis" });
            result.Add(new Book() { Source = "design four", Title = "Nascetur pharetra placerat pulvinar" });
            result.Add(new Book() { Source = "design five", Title = "Maecenas praesent accumsan bibendum" });
            result.Add(new Book() { Source = "design six", Title = "Dictumst eleifend facilisi faucibus" });
            return Task.FromResult(result);
        }
    }
}