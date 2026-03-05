using System;
using System.Collections.Generic;
using SocialPlatform.Repositories;
using SocialPlatformLibrary;

namespace SocialPlatform.Services;
public class PostService
{
    private readonly IPostRepo _repo;
    public PostService(IPostRepo repo) => _repo = repo;
    public BaseContent CreatePost(BaseContent post) => _repo.CreatePost(post);
    public BaseContent? UpdatePost(BaseContent post) => _repo.UpdatePost(post);
    public bool RemovePost(BaseContent post) => _repo.RemovePost(post);
    public BaseContent GetPostById(Guid id) => _repo.GetPostById(id);
    public List<BaseContent> GetAllPosts() => _repo.GetAllPosts();
}
