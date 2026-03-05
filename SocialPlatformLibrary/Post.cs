using SocialPlatformLibrary;
using System;

namespace SocialPlatform;
/// <summary>
/// Ерөнхий постын класс. ContentBase-аас удамшина (төрөл: нийтлэг текст, зураг, видео гэх мэт).
/// </summary>
public class Post : BaseContent
{
    /// <summary>Постын төрөл (Reel, Story гэх мэт).</summary>
    public PostType Type { get; set; } = PostType.Reel;
}
