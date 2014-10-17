using FortyTwoAudiobooks.UI.Resources;

namespace FortyTwoAudiobooks.UI
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources appResources = new AppResources();

        private static Actions actions = new Actions();


        public AppResources AppResources
        {
            get
            {
                return appResources;
            }
        }

        public Actions Actions
        {
            get
            {
                return actions;
            }
        }
    }
}