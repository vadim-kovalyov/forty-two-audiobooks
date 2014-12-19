using System;
using System.Collections.ObjectModel;

namespace FortyTwoAudiobooks.Model
{
    public class Book
    {
        public Guid? BookId { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public Guid? StorageAccountId { get; set; }

        public String StorageAccountName { get; set; }

        public DateTime? LastPlayed { get; set; }

        public bool IsOffline { get; set; }

        /// <summary>
        /// Gets or sets a Book's path or location within account.
        /// </summary>
        public string Uri { get; set; }

        public Collection<Track> Tracks { get; set; }

        public Book()
        {
            Tracks = new Collection<Track>();
        }
    }
}
