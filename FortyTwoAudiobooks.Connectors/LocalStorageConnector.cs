using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model.Storage;
using Microsoft.Xna.Framework.Media;

namespace FortyTwoAudiobooks.Connectors
{
    public class LocalStorageConnector
    {
        public Task<List<MediaItem>> GetSongs()
        {
            Task<List<MediaItem>> task = Task.Run(() =>
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

                return new List<MediaItem>(songs);
            });

            return task;
        }

        public Task<List<MediaItem>> GetArtists()
        {
            Task<List<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Artists.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }

                return new List<MediaItem>(result);
            });

            return task;
        }

        public Task<List<MediaItem>> GetPlaylists()
        {
            Task<List<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Playlists.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }

                return new List<MediaItem>(result);
            });

            return task;
        }

        public Task<List<MediaItem>> GetAlbums()
        {
            Task<List<MediaItem>> task = Task.Run(() =>
            {
                IEnumerable<MediaItem> result;
                using (MediaLibrary library = new MediaLibrary())
                {
                    result = library.Albums.Select(s => new MediaItem
                    {
                        Name = s.Name
                    });
                }

                return new List<MediaItem>(result);
            });

            return task;
        }
    }
}
