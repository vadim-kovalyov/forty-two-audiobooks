using System;
using System.Windows;
using Windows.Storage;
using FortyTwoAudiobooks.Connectors;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Core.ViewModels;
using FortyTwoAudiobooks.Core.ViewModels.Storage;
using FortyTwoAudiobooks.DataAccess;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace FortyTwoAudiobooks.Core.Config
{
    public class ContainerConfig
    {
        public static void Configure(Application app)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Data Access
            SimpleIoc.Default.Register(() => ApplicationData.Current.LocalFolder);
            SimpleIoc.Default.Register<IBookRepository, BookRepository>();

            // Services
            SimpleIoc.Default.Register<IBookService, BookService>();
            SimpleIoc.Default.Register<ISettingsService, SettingsService>();
            SimpleIoc.Default.Register<AccountService>();

            // Connectors
            SimpleIoc.Default.Register<LocalStorageConnector>();

            // View Models
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<MediaStorageViewModel>();

            // MVVM Light components
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            // Workaround for DispatcherHelper to be available in PCL.
            SimpleIoc.Default.Register<Action<Action>>(() => action => DispatcherHelper.CheckBeginInvokeOnUI(action));
        }
    }
}
