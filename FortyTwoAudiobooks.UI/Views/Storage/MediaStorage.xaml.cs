using System.Windows.Navigation;
using FortyTwoAudiobooks.Core.ViewModels.Storage;

namespace FortyTwoAudiobooks.UI.Views.Storage
{
    public partial class MediaStorage
    {
        public MediaStorage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var model = (MediaStorageViewModel) DataContext;
            await model.LoadAsync();
        }
    }
}