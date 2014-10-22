using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Model;
using FortyTwoAudiobooks.Core.Services;
using GalaSoft.MvvmLight;

namespace FortyTwoAudiobooks.Core.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private readonly ISourceService sourceService;

        public AddBookViewModel(ISourceService sourceService)
        {
            this.sourceService = sourceService;
            availableSources = new ObservableCollection<Source>();
        }

        private ObservableCollection<Source> availableSources;

        public ObservableCollection<Source> AvailableSources
        {
            get { return availableSources; }
            set
            {
                Set(() => AvailableSources, ref availableSources, value);
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

        public async Task LoadAsync()
        {
            AvailableSources = await sourceService.GetAvailableSources();
            isLoaded = true;
        }
    }
}
