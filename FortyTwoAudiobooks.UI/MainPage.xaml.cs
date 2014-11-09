using System;
using System.Windows.Navigation;
using FortyTwoAudiobooks.Core.ViewModels;

namespace FortyTwoAudiobooks.UI
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;

            if (!viewModel.IsLoaded)
            {
                await viewModel.LoadAsync();
            }

            //if (viewModel.IsCollectionEmpty)
            //{
            //    MainPivot.Items.Remove(Recent);
            //}
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
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

        protected void Add_OnClick(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;
            viewModel.AddBookCommand.Execute(null);
        }
    }
}