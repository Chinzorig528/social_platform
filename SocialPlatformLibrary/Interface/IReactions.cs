using SocialPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatformLibrary.Interface
{
    /// <summary>
    /// Реакцийн интерфэйс: постод лайк өгөх/хасах үйлдлүүд.
    /// </summary>
    public interface IReactions
    {
        void AddReaction(User user, ReactionType reactionType);
        void RemoveReaction(User user, ReactionType reactionType);
    }
}
