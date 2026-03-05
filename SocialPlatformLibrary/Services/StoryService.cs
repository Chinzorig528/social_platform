using SocialPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatform.Services;
public class StoryService
{
    IStoryRepo _repo;
    public StoryService(IStoryRepo repo)
    {
        _repo = repo;
    }
    public Story CreateStory(StoryDTO story)=> _repo.CreateStory(story);
    public Story UpdateStory(StoryDTO story) => _repo.UpdateStory(story);
    public bool RemoveStory(StoryDTO story) => _repo.RemoveStory(story);
    public Story GetStoryById(Guid id) => _repo.GetStoryById(id);
    public List<Story> GetAllStories() => _repo.GetAllStories();
}

