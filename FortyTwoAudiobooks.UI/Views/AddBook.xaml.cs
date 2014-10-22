using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Navigation;
using Windows.Storage;
using FortyTwoAudiobooks.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace FortyTwoAudiobooks.UI.Views
{
    public partial class AddBook : PhoneApplicationPage
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
            //var songs = library.Songs.ToList();


            //String name = KnownFolders.MusicLibrary.DisplayName;
            //IReadOnlyList<StorageFolder> result = await Windows.Storage.KnownFolders.MusicLibrary.GetFoldersAsync();
            //var list = result.ToList();

        }
    }
}