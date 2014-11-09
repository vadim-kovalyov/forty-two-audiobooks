using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model.Storage;
using Microsoft.Xna.Framework.Media;

namespace FortyTwoAudiobooks.Connectors
{
    public class LocalStorageConnector
    {
        public async Task<ObservableCollection<MediaItem>> GetSongs()
        {
            Task<ObservableCollection<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> songs;
                using (MediaLibrary library = new MediaLibrary())
                {
                    songs = library.Songs.Select(s => new MediaItem
                    {
                        Name = s.Name,
                        Artist = s.Artist.Name
                    });
                }
                return new ObservableCollection<MediaItem>(songs);

            });

            return await task;
        }

        public async Task<ObservableCollection<MediaItem>> GetArtists()
        {
            Task<ObservableCollection<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Artists.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }
                return new ObservableCollection<MediaItem>(result);

            });

            return await task;
        }

        public async Task<ObservableCollection<MediaItem>> GetPlaylists()
        {
            Task<ObservableCollection<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Playlists.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }
                return new ObservableCollection<MediaItem>(result);

            });

            return await task;
        }

        public async Task<ObservableCollection<MediaItem>> GetAlbums()
        {
            Task<ObservableCollection<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Albums.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }
                return new ObservableCollection<MediaItem>(result);

            });

            return await task;
        }
    }
}
