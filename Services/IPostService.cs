using BlogWebApi.DTOs.Comment;
using BlogWebApi.DTOs.Post;

namespace BlogWebApi.Services
{
    /// <summary>
    /// Service interface for managing posts
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Get all posts with summary information
        /// </summary>
        /// <returns>List of all posts with title and comment count</returns>
        Task<List<PostSummaryDto>> GetAllPostsAsync();

        /// <summary>
        /// Get a post by ID
        /// </summary>
        /// <param name="id">The post ID</param>
        /// <returns>The post if found, null otherwise</returns>
        Task<PostDto?> GetPostByIdAsync(Guid id);

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="createPostDto">The post data</param>
        /// <returns>The created post</returns>
        Task<PostDto> CreatePostAsync(CreatePostDto createPostDto);

        /// <summary>
        /// Add a comment to a post
        /// </summary>
        /// <param name="postId">The post ID</param>
        /// <param name="createCommentDto">The comment data</param>
        /// <returns>The created comment if the post exists, null otherwise</returns>
        Task<CommentDto?> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto);
    }
}
