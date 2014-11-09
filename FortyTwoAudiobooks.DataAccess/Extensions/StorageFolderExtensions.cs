using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace FortyTwoAudiobooks.DataAccess.Extensions
{
    public static class StorageFolderExtensions
    {
        public static Task<bool> FileExistsAsync(this StorageFolder folder, String fileName)
        {
            bool exists = File.Exists(Path.Combine(folder.Path, fileName));
            return Task.FromResult(exists);
        }
    }
}
