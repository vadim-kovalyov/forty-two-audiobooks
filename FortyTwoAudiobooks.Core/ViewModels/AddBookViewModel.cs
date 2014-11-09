using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FortyTwoAudiobooks.Core.Extensions;
using FortyTwoAudiobooks.Core.Services;
using FortyTwoAudiobooks.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace FortyTwoAudiobooks.Core.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private readonly AccountService accountService;

        private readonly INavigationService navigationService;

        public AddBookViewModel(AccountService accountService,
            INavigationService navigationService)
        {
            this.accountService = accountService;
            this.navigationService = navigationService;
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

        public RelayCommand SelectAccount
        {
            get
            {
                return new RelayCommand(() =>
                {
                    navigationService.NavigateToMediaStorage();
                });
            }
        }

        public async Task LoadAsync()
        {
            AvailableSources = await accountService.GetAvailableSources();
            isLoaded = true;
        }
    }
}
