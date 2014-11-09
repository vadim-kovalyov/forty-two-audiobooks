using System;
using FortyTwoAudiobooks.Core.Extensions;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.Core.Config
{
    public class NavigationConfig
    {
        public static void Configure(NavigationService service)
        {
            service.Configure(NavigationExtensions.AddBook, new Uri("/Views/AddBook.xaml", UriKind.Relative));
            service.Configure(NavigationExtensions.MediaStorage, new Uri("/Views/Storage/MediaStorage.xaml", UriKind.Relative));
        }
    }
}
