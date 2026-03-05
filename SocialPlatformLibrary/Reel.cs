using SocialPlatformLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatform
{
    public class Reel : BaseContent
    {
        /// <summary>Видео файлын эсвэл урл-ыг заах мөр.</summary>
        public string? VideoUrl { get; set; }

        /// <summary>Видео тоглуулах хугацаа.</summary>
        public TimeSpan Duration { get; set; }
    }
}
