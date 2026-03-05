namespace SocialPlatform;
internal class Program
{
    static void Main(string[] args)
    {
        // Жишээ: платформ үүсгэж хэрэглэгч нэмэх, пост/стори оруулах, like/share хийх
        Platform platform = new() { Name = "SocialPlatform", version = "1.0" };

        // Хэрэглэгч үүсгэх (signup ашиглана)
        var alice = platform.Signup("Alice", "alice@example.com", "pwd", 25) ?? throw new Exception("signup failed");
        var bob = platform.Signup("Bob", "bob@example.com", "pwd", 30) ?? throw new Exception("signup failed");
        var carol = platform.Signup("Carol", "carol@example.com", "pwd", 22) ?? throw new Exception("signup failed");

        // Alice текст пост оруулна
        var post = platform.CreateTextPost(alice, "Hello from Alice!");
        // Bob story оруулна
        var story = platform.CreateStory(bob, "Bob's short story", TimeSpan.FromHours(24));

        // Carol болон Bob пост дээр реакци өгнө
        platform.AddReaction(post.Id, carol, ReactionType.Like);
        platform.AddReaction(post.Id, bob, ReactionType.Love);

        // Carol постыг share хийнэ (repost болон оригинал дээр Share реакц бүртгэнэ)
        platform.ShareContent(post.Id, carol);

        // Carol коммент бичнэ
        post.AddComment(carol, "Nice post, Alice!");

        // Feed-г хэвлэ
        platform.PrintFeed();

    }
}
