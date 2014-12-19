using System.Threading.Tasks;
using FortyTwoAudiobooks.Connectors;
using FortyTwoAudiobooks.Core.ViewModels.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FortyTwoAudiobooks.Core.Tests.ViewModels
{
    [TestClass]
    public class MediaStorageViewModelTests
    {
        [TestMethod]
        public async Task LoadAsync_Executed_IsLoadedIsSetToTrue()
        {
            Mock<LocalStorageConnector> localStorageConnectorMock = new Mock<LocalStorageConnector>();

            MediaStorageViewModel model = new MediaStorageViewModel(localStorageConnectorMock.Object);

            // act
            await model.LoadSongs();

            Assert.IsTrue(model.IsLoaded);
        }

        [TestMethod]
        public void LoadAsync_IsNotExecuted_IsLoadedIsSetToFalse()
        {
            Mock<LocalStorageConnector> localStorageConnectorMock = new Mock<LocalStorageConnector>();

            MediaStorageViewModel model = new MediaStorageViewModel(localStorageConnectorMock.Object);

            // act
            // nothing

            Assert.IsFalse(model.IsLoaded);
        }
    }
}
