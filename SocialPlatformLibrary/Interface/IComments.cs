using SocialPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatformLibrary.Interface
{
    /// <summary>
    /// Комментын интерфэйс: пост дээр коммент нэмэх, коммент жагсаалтыг авах.
    /// </summary>
    public interface IComments
    {
        /// <summary>Шинэ коммент нэмэх.</summary>
        Comment? AddComment(User author, string content);
        Comment? DeleteComment(User author);

        /// <summary>Комментуудын list.</summary>
        List<Comment> Comments { get; }
    }
}
