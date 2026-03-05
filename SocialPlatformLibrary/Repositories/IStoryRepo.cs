using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatform.Repositories
{
    public interface IStoryRepo
    {
        public Story CreateStory(StoryDTO story);
        public Story UpdateStory(StoryDTO story);
        public bool RemoveStory(StoryDTO story);
        public Story GetStoryById(Guid id);
        public List<Story> GetAllStories();
    }
}
