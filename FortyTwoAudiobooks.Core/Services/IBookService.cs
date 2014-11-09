using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public interface IBookService
    {
        Task<ObservableCollection<Book>> GetRecentBooksAsync();
        Task<ObservableCollection<Book>> GetAllBooksAsync();
    }
}