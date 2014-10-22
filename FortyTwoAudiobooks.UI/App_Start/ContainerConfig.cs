using System;
using System.Windows;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Core.Services.Design;
using FortyTwoAudiobooks.Core.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace FortyTwoAudiobooks.UI.App_Start
{
    class ContainerConfig
    {
        public static void Configure(Application app)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Services
            SimpleIoc.Default.Register<IBookService, BookService>();
            SimpleIoc.Default.Register<ISourceService, SourceService>();

            // View Models
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddBookViewModel>();

            // MVVM Light components
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            // Workaround for DispatcherHelper to be available in PCL.
            SimpleIoc.Default.Register<Action<Action>>(() => action => DispatcherHelper.CheckBeginInvokeOnUI(action));
        }

        public static void ConfigureDesigner()
        {
            SimpleIoc.Default.Register<IBookService, DesignBookService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}
