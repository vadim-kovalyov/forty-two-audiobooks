using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;

namespace FortyTwoAudiobooks.Core.Services
{
    public interface ISourceService
    {
        Task<ObservableCollection<Source>> GetAvailableSources();
    }
}