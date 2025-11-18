using BlogWebApi.DTOs.Comment;

namespace BlogWebApi.DTOs.Post
{
    /// <summary>
    /// DTO for returning post data
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// The unique identifier of the post
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the post
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The content of the post
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the post was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The list of comments associated with this post
        /// </summary>
        public IEnumerable<CommentDto> Comments { get; set; } = [];
    }
}
