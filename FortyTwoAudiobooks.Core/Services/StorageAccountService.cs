using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public class StorageAccountService
    {
        public Task<ObservableCollection<StorageAccount>> GetAvailableStorageAccounts()
        {
            var sources = new ObservableCollection<StorageAccount>();
            sources.Add(new StorageAccount() { Name = StorageAccount.MediaLibrary, Description = "this phone" });
            sources.Add(new StorageAccount() { Name = StorageAccount.Dropbox, Description = "vadim.kovalyov@gmail.com" });

            return Task.FromResult(sources);
        }
    }
}