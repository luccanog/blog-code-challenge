namespace BlogWebApi.Models
{
    public class Post
    {
        public Guid Id { get; private set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        private Post() { }

        public Post(string title, string content)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            Comments = new List<Comment>();
        }
    }
}
