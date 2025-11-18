using System.ComponentModel.DataAnnotations;

namespace BlogWebApi.DTOs.Comment
{
    /// <summary>
    /// DTO for creating a new comment
    /// </summary>
    public record CreateCommentDto
    {
        /// <summary>
        /// The content of the comment
        /// </summary>
        [Required(ErrorMessage = "Content is required")]
        [StringLength(500, ErrorMessage = "Content cannot exceed 500 characters")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The author of the comment
        /// </summary>
        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        public string Author { get; set; } = string.Empty;
    }
}
