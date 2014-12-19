using System;
using GalaSoft.MvvmLight;

namespace FortyTwoAudiobooks.Core.ViewModels
{
    public class MediaItemViewModel : ViewModelBase
    {
        public String Name { get; set; }

        public String Artist { get; set; }

        public bool IsArtistAvailable
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Artist) && Artist != "Unknown";
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                Set(() => IsSelected, ref isSelected, value);
            }
        }
    }
}