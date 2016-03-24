namespace TheNewTwitter.Users
{
    public class Post
    {
        public string Message { get; }
        public string User { get; }

        public Post(string user, string message)
        {
            User = user;
            Message = message;
        }

        public string ToUserFormat()
        {
            return $"{User} - {Message}";
        }
    }
}