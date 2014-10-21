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
}
