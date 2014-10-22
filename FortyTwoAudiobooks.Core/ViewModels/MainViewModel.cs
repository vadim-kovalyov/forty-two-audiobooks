using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Extensions;
using FortyTwoAudiobooks.Core.Model;
using FortyTwoAudiobooks.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBookService bookService;
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;
        private readonly Action<Action> dispatcherDelegate;

        private ObservableCollection<Book> recent;

        public ObservableCollection<Book> Recent
        {
            get { return recent; }
            set
            {
                Set(() => Recent, ref recent, value);
            }
        }

        private ObservableCollection<Book> collection;

        public ObservableCollection<Book> Collection
        {
            get { return collection; }
            set
            {
                Set(() => Collection, ref collection, value);
            }
        }

        private bool isLoaded;

        public bool IsLoaded
        {
            get { return isLoaded; }
            set
            {
                Set(() => IsLoaded, ref isLoaded, value);
            }
        }

        private bool isCollectionEmpty;

        public bool IsCollectionEmpty
        {
            get { return isCollectionEmpty; }
            set
            {
                Set(() => IsCollectionEmpty, ref isCollectionEmpty, value);
            }
        }

        public RelayCommand AddBookCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    navigationService.NavigateToAddBook();
                });
            }
        }

        public MainViewModel(IBookService bookService,
            INavigationService navigationService,
            IDialogService dialogService,
            Action<Action> dispatcherDelegate)
        {
            this.bookService = bookService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.dispatcherDelegate = dispatcherDelegate;
            recent = new ObservableCollection<Book>();
            collection = new ObservableCollection<Book>();
        }

        /// <summary>
        /// Creates and adds a few BookViewModel objects into the Items collection.
        /// </summary>
        public async Task LoadAsync()
        {
            var recentTask = bookService.GetRecentBooksAsync();
            var collectionTask = bookService.GetAllBooksAsync();

            await Task.WhenAll(recentTask, collectionTask);

            IsLoaded = true;
            Collection = await collectionTask;
            Recent = await recentTask;
            IsCollectionEmpty = Collection.Count == 0;
        }
    }
}