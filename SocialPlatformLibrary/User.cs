namespace SocialPlatform
{
    /// <summary>Хэрэглэгчийн энгийн загвар.</summary>
    public class User
    {
        /// <summary>Хэрэглэгчийн ID.</summary>
        public int Id { get; set; }

        /// <summary>Хэрэглэгчийн нэр.</summary>
        public required string Name { get; set; }

        /// <summary>Имэйл хаяг.</summary>
        public required string Email { get; set; }

        /// <summary>Нууц үг .</summary>
        public required string Password { get; set; }

        /// <summary>Хэрэглэгчийн нас.</summary>
        public required byte Age { get; init; }
        
    }
}
