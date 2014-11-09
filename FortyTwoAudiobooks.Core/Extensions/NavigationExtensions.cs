using System;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.Core.Extensions
{
    public static class NavigationExtensions
    {
        public static readonly String AddBook = "AddBook";

        public static readonly String MediaStorage = "MediaStorage";

        public static void NavigateToAddBook(this INavigationService service)
        {
            service.NavigateTo(AddBook);
        }

        public static void NavigateToMediaStorage(this INavigationService service)
        {
            service.NavigateTo(MediaStorage);
        }
    }
}
