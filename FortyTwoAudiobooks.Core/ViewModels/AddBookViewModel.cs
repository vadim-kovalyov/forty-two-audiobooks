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
        private readonly StorageAccountService storageAccountService;

        private readonly INavigationService navigationService;

        public AddBookViewModel(StorageAccountService storageAccountService,
            INavigationService navigationService)
        {
            this.storageAccountService = storageAccountService;
            this.navigationService = navigationService;
            availableSources = new ObservableCollection<StorageAccount>();
        }

        private ObservableCollection<StorageAccount> availableSources;

        public ObservableCollection<StorageAccount> AvailableSources
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
                    navigationService.NavigateTo(NavigationExtensions.MediaStorage);
                });
            }
        }

        public async Task LoadAsync()
        {
            AvailableSources = await storageAccountService.GetAvailableStorageAccounts();
            isLoaded = true;
        }
    }
}
