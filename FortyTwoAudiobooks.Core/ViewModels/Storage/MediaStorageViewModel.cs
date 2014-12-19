using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Connectors;
using FortyTwoAudiobooks.Model.Storage;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FortyTwoAudiobooks.Core.ViewModels.Storage
{
    public class MediaStorageViewModel : ViewModelBase
    {
        private readonly LocalStorageConnector storageConnector;

        private ObservableCollection<MediaItemViewModel> tracks;

        public ObservableCollection<MediaItemViewModel> Tracks
        {
            get { return tracks; }
            set
            {
                Set(() => Tracks, ref tracks, value);
            }
        }

        private ObservableCollection<MediaItemViewModel> albums;

        public ObservableCollection<MediaItemViewModel> Albums
        {
            get { return albums; }
            set
            {
                Set(() => Albums, ref albums, value);
            }
        }

        private ObservableCollection<MediaItemViewModel> playlists;

        public ObservableCollection<MediaItemViewModel> Playlists
        {
            get { return playlists; }
            set
            {
                Set(() => Playlists, ref playlists, value);
            }
        }

        private ObservableCollection<MediaItemViewModel> artists;

        public ObservableCollection<MediaItemViewModel> Artists
        {
            get { return artists; }
            set
            {
                Set(() => Artists, ref artists, value);
            }
        }

        private bool isLoaded;

        public bool IsLoaded
        {
            get { return isLoaded; }
            set
            {
                Set(() => IsLoaded, ref isLoaded, value);
            }
        }

        public RelayCommand AddItemsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var selected = Tracks.Where(t => t.IsSelected).ToList();
                });
            }
        }

        public MediaStorageViewModel(LocalStorageConnector storageConnector)
        {
            this.storageConnector = storageConnector;
            tracks = new ObservableCollection<MediaItemViewModel>();
            albums = new ObservableCollection<MediaItemViewModel>();
            playlists = new ObservableCollection<MediaItemViewModel>();
            artists = new ObservableCollection<MediaItemViewModel>();
        }

        public async Task LoadAlnums()
        {
            IsLoaded = false;

            var albumsTasks = storageConnector.GetAlbums();
            Albums = ToViewModelCollection(await albumsTasks);

            IsLoaded = true;
        }

        public async Task LoadArtists()
        {
            IsLoaded = false;

            var artistsTask = storageConnector.GetArtists();
            Artists = ToViewModelCollection(await artistsTask);

            IsLoaded = true;
        }

        public async Task LoadPlaylists()
        {
            IsLoaded = false;

            var playlistsTasks = storageConnector.GetPlaylists();
            Playlists = ToViewModelCollection(await playlistsTasks);

            IsLoaded = true;
        }

        public async Task LoadSongs()
        {
            IsLoaded = false;

            var songsTask = storageConnector.GetSongs();
            Tracks = ToViewModelCollection(await songsTask);

            IsLoaded = true;
        }

        private ObservableCollection<MediaItemViewModel> ToViewModelCollection(IEnumerable<MediaItem> items)
        {
            var result = items.Select(i => new MediaItemViewModel
            {
                Name = i.Name,
                Artist = i.Artist
            });

            return new ObservableCollection<MediaItemViewModel>(result);
        }
    }
}
