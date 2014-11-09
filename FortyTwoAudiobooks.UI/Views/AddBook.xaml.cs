using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using FortyTwoAudiobooks.Core.ViewModels;
using Microsoft.Phone.Controls;

namespace FortyTwoAudiobooks.UI.Views
{
    public partial class AddBook
    {
        public AddBook()
        {
            InitializeComponent();
        }

        // Load data for the ViewModel Items
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            AddBookViewModel viewModel = (AddBookViewModel)DataContext;

            if (!viewModel.IsLoaded)
            {
                await viewModel.LoadAsync();
            }

            //MediaLibrary library = new MediaLibrary();
            //var songs = library.Tracks.ToList();


            //String name = KnownFolders.MusicLibrary.DisplayName;
            //IReadOnlyList<StorageFolder> result = await Windows.Storage.KnownFolders.MusicLibrary.GetFoldersAsync();
            //var list = result.ToList();

        }

        private void Accounts_OnSelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            LongListSelector list = (LongListSelector)sender;

            if (list.SelectedItem != null)
            {
                AddBookViewModel model = (AddBookViewModel) DataContext;
                model.SelectAccount.Execute(null);

                list.SelectedItem = null;
            }
        }
    }
}