using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Connectors;
using FortyTwoAudiobooks.Model.Storage;
using GalaSoft.MvvmLight;

namespace FortyTwoAudiobooks.Core.ViewModels.Storage
{
    public class MediaStorageViewModel : ViewModelBase
    {
        private readonly LocalStorageConnector storageConnector;

        private ObservableCollection<MediaItem> tracks;

        public ObservableCollection<MediaItem> Tracks
        {
            get { return tracks; }
            set
            {
                Set(() => Tracks, ref tracks, value);
            }
        }

        private ObservableCollection<MediaItem> albums;

        public ObservableCollection<MediaItem> Albums
        {
            get { return albums; }
            set
            {
                Set(() => Albums, ref albums, value);
            }
        }

        private ObservableCollection<MediaItem> playlists;

        public ObservableCollection<MediaItem> Playlists
        {
            get { return playlists; }
            set
            {
                Set(() => Playlists, ref playlists, value);
            }
        }

        private ObservableCollection<MediaItem> artists;

        public ObservableCollection<MediaItem> Artists
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

        public MediaStorageViewModel(LocalStorageConnector storageConnector)
        {
            this.storageConnector = storageConnector;
            tracks = new ObservableCollection<MediaItem>();
            albums = new ObservableCollection<MediaItem>();
            playlists = new ObservableCollection<MediaItem>();
            artists = new ObservableCollection<MediaItem>();
        }

        public async Task LoadAsync()
        {
            var songsTask = storageConnector.GetSongs();
            var artistsTask = storageConnector.GetArtists();
            var albumsTasks = storageConnector.GetAlbums();
            var playlistsTasks = storageConnector.GetPlaylists();

            Tracks = await songsTask;
            Artists = await artistsTask;
            Albums = await albumsTasks;
            Playlists = await playlistsTasks;

            IsLoaded = true;
        }
    }
}
