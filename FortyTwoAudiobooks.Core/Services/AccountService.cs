using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public class AccountService
    {
        public Task<ObservableCollection<Source>> GetAvailableSources()
        {
            var sources = new ObservableCollection<Source>();
            sources.Add(new Source() { Name = Source.MediaLibrary, Description = "this phone" });
            sources.Add(new Source() { Name = Source.Dropbox, Description = "vadim.kovalyov@gmail.com" });

            return Task.FromResult(sources);
        }
    }
}