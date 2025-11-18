namespace BlogWebApi.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
