using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;
using FortyTwoAudiobooks.Core.Services;
using GalaSoft.MvvmLight;

namespace FortyTwoAudiobooks.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBookService bookService;

        public ObservableCollection<Book> Recent { get; private set; }

        public ObservableCollection<Book> Collection { get; private set; }

        public MainViewModel()
            : this(new BookService())
        {

        }

        public MainViewModel(IBookService bookService)
        {
            this.bookService = bookService;
            Recent = new ObservableCollection<Book>();
            Collection = new ObservableCollection<Book>();
        }

        private bool isLoaded;

        public bool IsLoaded
        {
            get { return isLoaded; }
            set
            {
                this.Set(() => IsLoaded, ref isLoaded, value);
            }
        }

        /// <summary>
        /// Creates and adds a few BookViewModel objects into the Items collection.
        /// </summary>
        public async Task LoadAsync()
        {
            await Task.Delay(4000);

            var recentTask = bookService.GetRecentBooksAsync();
            var collectionTask = bookService.GetAllBooksAsync();

            await Task.WhenAll(recentTask, collectionTask)
                .ContinueWith(t =>
                {
                    IsLoaded = true;
                });

            Recent = await recentTask;
            Collection = await collectionTask;
        }
    }
}