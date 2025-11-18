namespace BlogWebApi.DTOs.Post
{
    /// <summary>
    /// DTO for returning post summary data in list views
    /// </summary>
    public class PostSummaryDto
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
        /// The number of comments associated with this post
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// The date and time when the post was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
