using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.Core.Extensions
{
    public static class NavigationExtensions
    {
        public static readonly String AddBook = "AddBookKey";

        public static void NavigateToAddBook(this INavigationService service)
        {
            service.NavigateTo(AddBook);
        }
    }
}
