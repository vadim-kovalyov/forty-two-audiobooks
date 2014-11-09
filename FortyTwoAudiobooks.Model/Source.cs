using System;

namespace FortyTwoAudiobooks.Model
{
    public enum SourceEnum
    {
        LocalStorage = 0,
        MediaLibrary = 1,
        OneDrive = 2,
        Dropbox = 3,
    }

    public class Source
    {
        public static readonly String LocalStorage = "Local Storage";

        public static readonly String MediaLibrary = "Media Library";

        public static readonly String Dropbox = "Dropbox";

        public static readonly String OneDrive = "OneDrive";

        public static readonly String GoogleDrive = "Google Drive";

        public String Name { get; set; }

        public String Description { get; set; }
    }
}