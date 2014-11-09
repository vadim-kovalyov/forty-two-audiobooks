using System.Windows;
using FortyTwoAudiobooks.Core.ViewModels;
using FortyTwoAudiobooks.Core.ViewModels.Storage;
using Microsoft.Practices.ServiceLocation;

namespace FortyTwoAudiobooks.UI.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance
        {
            get
            {
                return (ViewModelLocator)Application.Current.Resources["ViewModelLocator"];
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddBookViewModel AddBookViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddBookViewModel>();
            }
        }

        public MediaStorageViewModel MediaStorageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MediaStorageViewModel>();
            }
        }
    }
}
