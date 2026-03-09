using System;
using System.Collections.Generic;
using SocialPlatformLibrary;

namespace SocialPlatform.Repositories
{
    /// <summary>
    /// Постын репозиторийн интерфэйс.
    /// </summary>
    public interface IPostRepo
    {
        BaseContent CreatePost(BaseContent post);
        BaseContent? UpdatePost(BaseContent post);
        bool RemovePost(BaseContent post);
        BaseContent GetPostById(Guid id);
        List<BaseContent> GetAllPosts();
    }
}
