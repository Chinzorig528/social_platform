using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SocialPlatformLibrary.Interface;

namespace SocialPlatform;
public class Comment : IComments
{
    /// <summary>Комментийн ID.</summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>Коммент бичсэн хэрэглэгч.</summary>
    public required User Author { get; set; }

    /// <summary>Комментийн агуулга (текст).</summary>
    public required string Content { get; set; }

    /// <summary>Комментийн бичсэн огноо, цаг.</summary>
    public DateTime Timestamp { get; set; }

    public List<Comment> Comments { get; } = new();

    // Single constructor that sets required members.
    [SetsRequiredMembers]
    public Comment(User author, string content)
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Content = content ?? throw new ArgumentNullException(nameof(content));
        Timestamp = DateTime.Now;
    }

    public Comment AddComment(User author, string content)
    {
        var comment = new Comment(author, content);
        Comments.Add(comment);
        return comment;
    }

    public Comment DeleteComment(User author)
    {
        var toRemove = Comments.Find(c => c.Author == author);
        if (toRemove is null)
            throw new InvalidOperationException("No comment found for the specified author.");
        Comments.Remove(toRemove);
        return toRemove;
    }
}
