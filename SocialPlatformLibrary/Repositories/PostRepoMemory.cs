using System;
using System.Collections.Generic;
using System.Linq;
using SocialPlatformLibrary;

namespace SocialPlatform.Repositories
{
    /// <summary>
    /// In-memory хэрэгжилт нь тест, хөгжүүлэлтийн үед ашиглана.
    /// </summary>
    public class PostRepoMemory : IPostRepo
    {
        private readonly List<BaseContent> _posts = new();

        public BaseContent CreatePost(BaseContent post)
        {
            post.Timestamp = DateTime.Now;
            _posts.Add(post);
            return post;
        }

        public List<BaseContent> GetAllPosts() => new List<BaseContent>(_posts);

        public BaseContent GetPostById(Guid id) => _posts.FirstOrDefault(p => p.Id == id);

        public bool RemovePost(BaseContent post) => _posts.RemoveAll(p => p.Id == post.Id) > 0;

        public BaseContent? UpdatePost(BaseContent post)
        {
            var idx = _posts.FindIndex(p => p.Id == post.Id);
            if (idx >= 0)
            {
                _posts[idx] = post;
                return post;
            }
            return null;
        }
    }
}
