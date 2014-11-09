using FortyTwoAudiobooks.Model.Storage;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace FortyTwoAudiobooks.Phone.Tests
{
    [TestClass]
    public class BookRepositiryTests
    {
        [TestMethod]
        public void TestPhone1()
        {
            MediaItem item = new MediaItem();
            item.Artist = "Famous Artist";

            // act
            bool isArtistAvailable = item.IsArtistAvailable;

            Assert.IsTrue(isArtistAvailable);
        }
    }
}
