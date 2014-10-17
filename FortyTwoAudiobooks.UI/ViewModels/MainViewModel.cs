using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FortyTwoAudiobooks.Core.Model;
using FortyTwoAudiobooks.Core.Services;

namespace FortyTwoAudiobooks.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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
            this.Recent = new ObservableCollection<Book>();
            this.Collection = new ObservableCollection<Book>();
        }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few BookViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            Books recent = bookService.GetRecentBooks();
            Recent = new ObservableCollection<Book>(recent);

            Books collection = bookService.GetAllBooks();
            Collection = new ObservableCollection<Book>(collection);

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}