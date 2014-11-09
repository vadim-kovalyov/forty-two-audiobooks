using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Core.Tests.Extensions;
using FortyTwoAudiobooks.DataAccess;
using FortyTwoAudiobooks.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FortyTwoAudiobooks.Core.Tests.Services
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public async Task GetRecentBooks_10BooksAvailable_3MostRecentIsExpected()
        {
            const int numberOfRecent = 3;
            Mock<IBookRepository> repositoryMock = new Mock<IBookRepository>();
            Mock<ISettingsService> settingsMock = new Mock<ISettingsService>();

            ObservableCollection<Book> collection = Builder<Book>.CreateListOfSize(10)
                .All().With(b => b.LastPlayed = DateTime.Now)
                .BuildObservable();
            repositoryMock.Setup(r => r.LoadBooksAsync()).ReturnsAsync(collection);
            settingsMock.SetupGet(s => s.RecentBooksCount).Returns(numberOfRecent);

            BookService service = new BookService(repositoryMock.Object, settingsMock.Object);

            // act
            ObservableCollection<Book> recent = await service.GetRecentBooksAsync();

            Assert.AreEqual(numberOfRecent, recent.Count);
        }
    }
}
