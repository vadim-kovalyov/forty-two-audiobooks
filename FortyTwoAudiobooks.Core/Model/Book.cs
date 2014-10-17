using System;
using System.Collections.ObjectModel;

namespace FortyTwoAudiobooks.Core.Model
{
    public class Book
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public String Source { get; set; }

        /// <summary>
        /// Gets or sets a Book's path or location within Book Source.
        /// </summary>
        public string Uri { get; set; }

        public Collection<Track> Tracks { get; set; }

        public Book()
        {
            Tracks = new Collection<Track>();
        }
    }
}
