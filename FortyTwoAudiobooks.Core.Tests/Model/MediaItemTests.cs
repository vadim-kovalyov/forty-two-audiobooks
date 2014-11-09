using FortyTwoAudiobooks.Model.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortyTwoAudiobooks.Core.Tests.Model
{
    [TestClass]
    public class MediaItemTests
    {
        [TestMethod]
        public void GetIsArtistAvailable_ArtistIsProvided_ExpectedTrue()
        {
            MediaItem item = new MediaItem();
            item.Artist = "Famous Artist";

            // act
            bool isArtistAvailable = item.IsArtistAvailable;

            Assert.IsTrue(isArtistAvailable);
        }

        [TestMethod]
        public void GetIsArtistAvailable_ArtistIsUnknown_ExpectedFalse()
        {
            MediaItem item = new MediaItem();
            item.Artist = "Unknown";

            // act
            bool isArtistAvailable = item.IsArtistAvailable;

            Assert.IsFalse(isArtistAvailable);
        }

        [TestMethod]
        public void GetIsArtistAvailable_ArtistIsEmpty_ExpectedFalse()
        {
            MediaItem item = new MediaItem();

            // act
            bool isArtistAvailable = item.IsArtistAvailable;

            Assert.IsFalse(isArtistAvailable);
        }
    }
}
