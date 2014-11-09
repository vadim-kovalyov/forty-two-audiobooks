using System;

namespace FortyTwoAudiobooks.Model.Storage
{
    public class MediaItem
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

        public bool Selected { get; set; }
    }
}