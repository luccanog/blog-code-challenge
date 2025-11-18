using System.ComponentModel.DataAnnotations;

namespace BlogWebApi.DTOs.Post
{
    /// <summary>
    /// DTO for creating a new post
    /// </summary>
    public class CreatePostDto
    {
        /// <summary>
        /// The title of the post
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The content of the post
        /// </summary>
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The author of the post
        /// </summary>
        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters")]
        public string Author { get; set; } = string.Empty;
    }
}
