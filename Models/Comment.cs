namespace BlogWebApi.Models
{
    public class Comment
    {
        public Guid Id { get; private set; }

        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public Guid PostId { get; private set; }

        public Post Post { get; set; } = null!;

        private Comment() { }

        public Comment(string content, string author, Guid postId)
        {
            Id = Guid.NewGuid();
            Content = content;
            Author = author;
            PostId = postId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
