using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FortyTwoAudiobooks.Core.Model;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Core.Tests.Extensions;
using FortyTwoAudiobooks.Core.ViewModels;
using GalaSoft.MvvmLight.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FortyTwoAudiobooks.Core.Tests.ViewModels
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public async Task LoadAsync_Executed_IsLoadedIsSetToTrue()
        {
            Mock<INavigationService> navigationServiceMock = new Mock<INavigationService>();
            Mock<IDialogService> dialogServiceMock = new Mock<IDialogService>();
            Mock<IBookService> bookServiceMock = new Mock<IBookService>();

            ObservableCollection<Book> recent = Builder<Book>.CreateListOfSize(2).BuildObservable();
            ObservableCollection<Book> collection = Builder<Book>.CreateListOfSize(10).BuildObservable();

            bookServiceMock.Setup(s => s.GetAllBooksAsync()).ReturnsAsync(collection);
            bookServiceMock.Setup(s => s.GetRecentBooksAsync()).ReturnsAsync(recent);

            MainViewModel model = new MainViewModel(bookServiceMock.Object, navigationServiceMock.Object,
                dialogServiceMock.Object);

            // act
            await model.LoadAsync();

            Assert.IsTrue(model.IsLoaded);
            Assert.AreEqual(recent, model.Recent);
            Assert.AreEqual(collection, model.Collection);
        }

        [TestMethod]
        public void LoadAsync_IsNotExecuted_IsLoadedIsSetToFalse()
        {
            Mock<INavigationService> navigationServiceMock = new Mock<INavigationService>();
            Mock<IDialogService> dialogServiceMock = new Mock<IDialogService>();
            Mock<IBookService> bookServiceMock = new Mock<IBookService>();

            MainViewModel model = new MainViewModel(bookServiceMock.Object, navigationServiceMock.Object,
                dialogServiceMock.Object);

            // act
            // nothing

            Assert.IsFalse(model.IsLoaded);
        }

        [TestMethod]
        public async Task LoadAsync_CollectionProvided_IsCollectionEmptyIsSetToFalse()
        {
            Mock<INavigationService> navigationServiceMock = new Mock<INavigationService>();
            Mock<IDialogService> dialogServiceMock = new Mock<IDialogService>();
            Mock<IBookService> bookServiceMock = new Mock<IBookService>();

            ObservableCollection<Book> recent = Builder<Book>.CreateListOfSize(2).BuildObservable();
            ObservableCollection<Book> collection = Builder<Book>.CreateListOfSize(10).BuildObservable();

            bookServiceMock.Setup(s => s.GetAllBooksAsync()).ReturnsAsync(collection);
            bookServiceMock.Setup(s => s.GetRecentBooksAsync()).ReturnsAsync(recent);

            MainViewModel model = new MainViewModel(bookServiceMock.Object, navigationServiceMock.Object,
                dialogServiceMock.Object);

            // act
            await model.LoadAsync();

            Assert.IsFalse(model.IsCollectionEmpty);
        }

        [TestMethod]
        public async Task LoadAsync_EmptyCollectionProvided_IsCollectionEmptyIsSetToTrue()
        {
            Mock<INavigationService> navigationServiceMock = new Mock<INavigationService>();
            Mock<IDialogService> dialogServiceMock = new Mock<IDialogService>();
            Mock<IBookService> bookServiceMock = new Mock<IBookService>();

            ObservableCollection<Book> recent = new ObservableCollection<Book>();
            ObservableCollection<Book> collection = new ObservableCollection<Book>();

            bookServiceMock.Setup(s => s.GetAllBooksAsync()).ReturnsAsync(collection);
            bookServiceMock.Setup(s => s.GetRecentBooksAsync()).ReturnsAsync(recent);

            MainViewModel model = new MainViewModel(bookServiceMock.Object, navigationServiceMock.Object,
                dialogServiceMock.Object);

            // act
            await model.LoadAsync();

            Assert.IsTrue(model.IsCollectionEmpty);
        }
    }
}
