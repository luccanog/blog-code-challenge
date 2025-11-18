namespace BlogWebApi.Models
{
    public class Post
    {
        public Guid Id { get; private set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        private Post() { }

        public Post(string title, string content, string author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            Author = author;
            CreatedAt = DateTime.UtcNow;
            Comments = new List<Comment>();
        }
    }
}
