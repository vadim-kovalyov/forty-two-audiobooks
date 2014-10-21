using System;
using FortyTwoAudiobooks.Core.Extensions;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.UI.App_Start
{
    public class NavigationConfig
    {
        public static void Configure(NavigationService service)
        {
            service.Configure(NavigationExtensions.AddBook, new Uri("/Views/AddBook.xaml", UriKind.Relative));
        }
    }
}
