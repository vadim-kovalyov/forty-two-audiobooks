using System;
using System.ComponentModel;

namespace FortyTwoAudiobooks.UI.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string source;

        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                if (value != source)
                {
                    source = value;
                    NotifyPropertyChanged("Source");
                }
            }
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