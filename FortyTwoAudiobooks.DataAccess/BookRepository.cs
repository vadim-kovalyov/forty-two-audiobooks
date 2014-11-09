using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using FortyTwoAudiobooks.DataAccess.Extensions;
using FortyTwoAudiobooks.Model;
using Newtonsoft.Json;

namespace FortyTwoAudiobooks.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly StorageFolder localFolder;

        private const String BookStorageFileName = "books.v1.db";

        private const String AccountStorageFileName = "accounts.v1.db";

        public BookRepository(StorageFolder localFolder)
        {
            this.localFolder = localFolder;
            Initialize().Wait();
        }

        private async Task Initialize()
        {
            if (!await localFolder.FileExistsAsync(AccountStorageFileName))
            {
                await localFolder.CreateFileAsync(AccountStorageFileName, CreationCollisionOption.ReplaceExisting);
            }

            if (!await localFolder.FileExistsAsync(BookStorageFileName))
            {
                await localFolder.CreateFileAsync(BookStorageFileName, CreationCollisionOption.ReplaceExisting);
            }
        }

        public async Task SaveBooksAsync(IEnumerable<Book> books)
        {
            String json = JsonConvert.SerializeObject(books);

            var file = await localFolder.CreateFileAsync(BookStorageFileName, CreationCollisionOption.ReplaceExisting);

            using (Stream stream = await file.OpenStreamForWriteAsync())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(json);
            }
        }

        public async Task<IEnumerable<Book>> LoadBooksAsync()
        {
            var file = await localFolder.GetFileAsync(BookStorageFileName);

            using (Stream stream = await file.OpenStreamForWriteAsync())
            using (StreamReader reader = new StreamReader(stream))
            {
                String content = await reader.ReadToEndAsync();
                IEnumerable<Book> result = JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
                return result;
            }
        }
    }
}
