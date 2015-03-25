using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWindowsMediaPlayer
{
    class Media
    {
        private string MediaUri;
        public static string[] allTypes = 
                                { 
                                    ".mpg", ".mpeg", ".m1v", ".mp2", ".mpa", 
                                    ".mpe", ".avi",".wmv", ".mp3", ".mp4",
                                    ".jpg", ".png", ".bmp", ".gif", ".mov"
                                };

        public Media(string value)
        {
            this.MediaUri = value;
        }

        public string getUri
        {
            get { return MediaUri; }
        }

        public override string ToString()
        {
            return MediaUri.Substring(MediaUri.LastIndexOf("\\") + 1);
        }

    }
}
