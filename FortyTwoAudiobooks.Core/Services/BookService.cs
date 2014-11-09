using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FortyTwoAudiobooks.DataAccess;
using FortyTwoAudiobooks.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        private readonly ISettingsService settings;

        private ObservableCollection<Book> Books { get; set; }

        public BookService(IBookRepository bookRepository, ISettingsService settings)
        {
            this.bookRepository = bookRepository;
            this.settings = settings;

        }

        public async Task<ObservableCollection<Book>> GetRecentBooksAsync()
        {
            if (Books == null)
            {
                Books = await LoadBooksInternal();
            }

            IEnumerable<Book> recent = Books
                    .Where(b => b.LastPlayed != null)
                    .OrderBy(b => b.LastPlayed)
                    .Take(settings.RecentBooksCount);

            return new ObservableCollection<Book>(recent);
        }

        public async Task<ObservableCollection<Book>> GetAllBooksAsync()
        {
            if (Books == null)
            {
                Books = await LoadBooksInternal();
            }
            return Books;
        }

        public void CreateBook(Book book, bool availableOffline)
        {
            Books.Add(book);
        }

        private async Task<ObservableCollection<Book>> LoadBooksInternal()
        {
            IEnumerable<Book> books = await bookRepository.LoadBooksAsync();
            return new ObservableCollection<Book>(books);
        }
    }
}