using System;

namespace FortyTwoAudiobooks.Core.Model
{
    public class Track
    {
        public String Title { get; set; }

        public TimeSpan Length { get; set; }

        public Source Source { get; set; }

        public string Uri { get; set; }
    }
}