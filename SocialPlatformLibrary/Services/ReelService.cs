using System;
using System.Collections.Generic;
using SocialPlatform.Repositories;
using SocialPlatformLibrary;

namespace SocialPlatform.Services;
public class ReelService
{
    private readonly IPostRepo _repo;
    public ReelService(IPostRepo repo) => _repo = repo;

    public Reel CreateReel(ReelDTO dto)
    {
        var reel = new Reel
        {
            Author = dto.author,
            Content = dto.content,
            Timestamp = DateTime.Now,
            VideoUrl = string.Empty,
            Duration = TimeSpan.Zero
        };
        return (Reel)_repo.CreatePost(reel);
    }

    public Reel UpdateReel(Reel reel) => (Reel)_repo.UpdatePost(reel);
    public bool RemoveReel(Reel reel) => _repo.RemovePost(reel);
    public Reel GetReelById(Guid id) => (Reel)_repo.GetPostById(id);
    public List<BaseContent> GetAllReels() => _repo.GetAllPosts();
}
