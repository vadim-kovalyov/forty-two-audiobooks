using System.Collections.Generic;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model;

namespace FortyTwoAudiobooks.DataAccess
{
    public interface IBookRepository
    {
        Task SaveBooksAsync(IEnumerable<Book> books);

        Task<IEnumerable<Book>> LoadBooksAsync();
    }
}