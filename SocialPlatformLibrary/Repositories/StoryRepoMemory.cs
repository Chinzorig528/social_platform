using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatform.Repositories
{
    public class StoryRepoMemory : IStoryRepo
    {
        List<Story> stories = new List<Story>();
        public Story CreateStory(StoryDTO story)
        {
            var newStory = new Story()
            {
                Author = story.author,
                Content = story.content,
                Timestamp = DateTime.Now
            };
            stories.Add(newStory);
            return newStory;
        }

        public List<Story> GetAllStories()
        {
            throw new NotImplementedException();
        }

        public Story GetStoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStory(StoryDTO story)
        {
            throw new NotImplementedException();
        }

        public Story UpdateStory(StoryDTO story)
        {
            throw new NotImplementedException();
        }
    }
}
