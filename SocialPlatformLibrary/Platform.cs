using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using SocialPlatformLibrary;

namespace SocialPlatform;

/// <summary>
/// Нийтийн платформын үүсгэгч. Хэрэглэгч бүртгэх, контент үүсгэх, реакци/share үйлдлийг харуулах demo функцүүдтэй.
/// </summary>
public class Platform
{
    const int MaxUsers = 100;
    private int userCount = 0;
    public required string Name { get; set; }
    public string version { get; set; }
    private User[] users = new User[MaxUsers];

    // Агшин зуурын in-memory хадгалалт
    private readonly List<BaseContent> _contents = new();

    /// <summary>Бүх контентууд.</summary>
    public IReadOnlyList<BaseContent> Contents => _contents.AsReadOnly();

    /// <summary>
    /// Шинэ хэрэглэгч бүртгэж буцаана.
    /// Хязгаар хүрсэн үед null буцаана.
    /// </summary>
    public User? Signup(string name, string email, string password, byte age = 0)
    {
        if (userCount >= MaxUsers)
        {
            return null;
        }
        var user = new User { Name = name, Email = email, Password = password, Age = age };
        user.Id = userCount;
        users[userCount++] = user;
        return user;
    }

    /// <summary>Энгийн текст пост үүсгэнэ.</summary>
    public BaseContent CreateTextPost(User author, string content)
    {
        var post = new Post { Author = author, Content = content, Timestamp = DateTime.Now, Type = PostType.Post };
        _contents.Add(post);
        return post;
    }

    /// <summary>Reel (видео) үүсгэнэ.</summary>
    public Reel CreateReel(User author, string content, string videoUrl, TimeSpan duration)
    {
        var reel = new Reel { Author = author, Content = content, Timestamp = DateTime.Now, VideoUrl = videoUrl, Duration = duration };
        _contents.Add(reel);
        return reel;
    }

    /// <summary>Story үүсгэнэ (дуусаx хугацаатай).</summary>
    public Story CreateStory(User author, string content, TimeSpan visibleFor)
    {
        var story = new Story { Author = author, Content = content, Timestamp = DateTime.Now, ExpiresAt = DateTime.Now.Add(visibleFor) };
        _contents.Add(story);
        return story;
    }

    /// <summary>Контентыг id-ээр хайж реакци нэмж өгнө.</summary>
    public bool AddReaction(Guid contentId, User user, ReactionType reaction)
    {
        var c = _contents.FirstOrDefault(x => x.Id == contentId);
        if (c == null) return false;
        c.AddReaction(user, reaction);
        return true;
    }

    /// <summary>Контентыг share хийх: оригиналыг repost байдлаар хийнэ болон original дээр Share реакци нэмнэ.</summary>
    public bool ShareContent(Guid contentId, User user)
    {
        var orig = _contents.FirstOrDefault(x => x.Id == contentId);
        if (orig == null) return false;

        // Original дээр Share реакци бүртгэнэ
        orig.AddReaction(user, ReactionType.Share);

        // Шинэ пост болгон нэмэх (repost)
        var repost = new Post { Author = user, Content = $"Shared: {orig.Content}", Timestamp = DateTime.Now, Type = PostType.Post };
        _contents.Add(repost);
        return true;
    }

    /// <summary>Feed-г товч хэвлэх demo.</summary>
    public void PrintFeed()
    {
        Console.WriteLine($"--- {Name} feed ({_contents.Count} items) ---");
        foreach (var c in _contents)
        {
            var type = c.GetType().Name;
            var author = c.Author?.Name ?? "unknown";
            Console.WriteLine($"[{type}] {author}: {c.Content}");
            var counts = c.ReactionCounts;
            Console.WriteLine(" Reactions: " + string.Join(", ", counts.Select(kv => $"{kv.Key}:{kv.Value}")));
            if (c.Comments.Any())
            {
                Console.WriteLine(" Comments:");
                foreach (var cm in c.Comments)
                    Console.WriteLine($"  - {cm.Author.Name}: {cm.Content}");
            }
        }
    }
}
