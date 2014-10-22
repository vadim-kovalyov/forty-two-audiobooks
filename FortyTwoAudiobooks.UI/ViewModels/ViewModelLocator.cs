using System.Windows;
using FortyTwoAudiobooks.Core.ViewModels;
using FortyTwoAudiobooks.UI.App_Start;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace FortyTwoAudiobooks.UI.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ContainerConfig.ConfigureDesigner();
            }
        }

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
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        public AddBookViewModel AddBookViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddBookViewModel>();
            }
        }
    }
}
