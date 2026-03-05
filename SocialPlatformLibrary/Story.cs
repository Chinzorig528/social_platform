
using System;
using SocialPlatformLibrary;

namespace SocialPlatform;
public class Story : BaseContent
{
    /// <summary>
    /// Story дуусах огноо.
    /// </summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>Хугацаа дууссан эсэхийг шалгана.</summary>
    public bool IsExpired => DateTime.Now >= ExpiresAt;
}

