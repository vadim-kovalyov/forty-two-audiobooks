using System;
using System.IO.IsolatedStorage;

namespace FortyTwoAudiobooks.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private const int RecentBooksCountDefault = 3;

        private readonly IsolatedStorageSettings appSettings;

        public SettingsService()
        {
            appSettings = IsolatedStorageSettings.ApplicationSettings;
        }

        public virtual int RecentBooksCount
        {
            get
            {
                return SafeGet("RecentBooksCount", RecentBooksCountDefault);
            }
            set
            {
                appSettings["RecentBooksCount"] = value;
            }
        }

        private T SafeGet<T>(String key, T defaultValue)
        {
            if (appSettings.Contains(key))
            {
                return (T)appSettings[key];
            }
            return defaultValue;
        }
    }
}
