using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatform
{
    /// <summary>Story үүсгэхэд хэрэглэх DTO.</summary>
    public record StoryDTO(User author, string content);

    /// <summary>Reel үүсгэхэд хэрэглэх DTO .</summary>
    public record ReelDTO(User author, string content);

    /// <summary>Хэрэглэгч үүсгэхэд шаардлагатай DTO.</summary>
    public record UserDTO(string name, string email, string password);
}
