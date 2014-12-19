using System;
using System.Threading.Tasks;
using System.Windows.Navigation;
using FortyTwoAudiobooks.Core.ViewModels.Storage;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace FortyTwoAudiobooks.UI.Views.Storage
{
    public partial class MediaStorage
    {
        public MediaStorage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Pivot_OnLoadingPivotItem(object sender, PivotItemEventArgs e)
        {
            await LoadPivotItem(e.Item.Name);
        }

        private async Task LoadPivotItem(String name)
        {
            var model = (MediaStorageViewModel)DataContext;

            switch (name)
            {
                case "Tracks":
                    await model.LoadSongs();
                    break;
                case "Albums":
                    await model.LoadAlnums();
                    break;
                case "Playlists":
                    await model.LoadPlaylists();
                    break;
                case "Artists":
                    await model.LoadArtists();
                    break;
            }
        }

        private void Add_OnClick(object sender, EventArgs e)
        {
            var model = (MediaStorageViewModel)DataContext;
            model.AddItemsCommand.Execute(null);
        }
    }
}