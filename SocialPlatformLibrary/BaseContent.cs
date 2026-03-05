using SocialPlatform;
using SocialPlatformLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialPlatformLibrary;
public abstract class BaseContent : IReactions, IComments
{
    /// <summary>Постын ID.</summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>Хэрэглэгч тус бүрийн реакцыг хадгалах (userId -> ReactionType).</summary>
    protected Dictionary<int, ReactionType> _reactions = new Dictionary<int, ReactionType>();

    /// <summary>Постын комментуудын жагсаалт.</summary>
    protected List<Comment> _comments = new List<Comment>();

    /// <summary>Постын зохиогч.</summary>
    public required User Author { get; set; }

    /// <summary>Постын текст агуулга.</summary>
    public required string Content { get; set; }

    /// <summary>Постын үүссэн огноо, цаг.</summary>
    public DateTime Timestamp { get; set; }

    /// <summary>Нийт реакцийн тоо (бүх төрлийн нийлбэр).</summary>
    public int ReactionsCount => _reactions.Count;

    /// <summary>Реакцуудын тоог төрөл тус бүрээр буцаана.</summary>
    public Dictionary<ReactionType, int> ReactionCounts
    {
        get
        {
            var dict = new Dictionary<ReactionType, int>();
            foreach (ReactionType rt in Enum.GetValues(typeof(ReactionType)))
                dict[rt] = 0;
            foreach (var kv in _reactions)
            {
                dict[kv.Value]++;
            }
            return dict;
        }
    }

    /// <summary>Комментуудын жагсаалт.</summary>
    public List<Comment> Comments => _comments;

    /// <summary>Реакци нэмэх/солих (Like, Love, Share гэх мэт).</summary>
    public void AddReaction(User user, ReactionType reactionType)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        // Нэг хэрэглэгч зөвхөн нэг реакц өгнө — дээр нь бичвэл шинэ төрөл рүү солигдоно.
        _reactions[user.Id] = reactionType;
    }

    /// <summary>Реакци хасах (өгсөн төрлөөр шалган устгана).</summary>
    public void RemoveReaction(User user, ReactionType reactionType)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (_reactions.TryGetValue(user.Id, out var current) && current == reactionType)
            _reactions.Remove(user.Id);
    }

    /// <summary>Постод коммент нэмнэ.</summary>
    public Comment AddComment(User author, string content)
    {
        var comment = new Comment(author ?? throw new ArgumentNullException(nameof(author)),
                                  content ?? throw new ArgumentNullException(nameof(content)));

        _comments.Add(comment);
        return comment;
    }

    /// <summary>Тухайн хэрэглэгчийн комментийг устгана.</summary>
    public Comment? DeleteComment(User author)
    {
        if (author == null) throw new ArgumentNullException(nameof(author));
        var toRemove = _comments.Find(c => c.Author == author);
        if (toRemove is null) return null;
        _comments.Remove(toRemove);
        return toRemove;
    }
}

