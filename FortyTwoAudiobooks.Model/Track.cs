using System;

namespace FortyTwoAudiobooks.Model
{
    public class Track
    {
        public Guid? TrackId { get; set; }

        public String Title { get; set; }

        public TimeSpan Length { get; set; }

        public Guid? StorageAccountId { get; set; }

        public string Uri { get; set; }
    }
}