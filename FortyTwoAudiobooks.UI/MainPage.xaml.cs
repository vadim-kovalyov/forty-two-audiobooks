using System.Windows.Navigation;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Core.ViewModels;
using Microsoft.Phone.Controls;

namespace FortyTwoAudiobooks.UI
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly MainViewModel viewModel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //BuildLocalizedApplicationBar();

            viewModel = new MainViewModel(new BookService());
        }

        // Load data for the ViewModel Items
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = viewModel;

            if (!viewModel.IsLoaded)
            {
                await viewModel.LoadAsync();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}