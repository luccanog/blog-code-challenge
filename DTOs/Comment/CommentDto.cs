namespace BlogWebApi.DTOs.Comment
{
    /// <summary>
    /// DTO for returning comment data
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// The unique identifier of the comment
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The content of the comment
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The author of the comment
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the comment was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The ID of the post this comment belongs to
        /// </summary>
        public Guid PostId { get; set; }
    }
}
