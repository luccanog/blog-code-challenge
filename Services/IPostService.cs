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
        /// Get all posts with summary information (paginated)
        /// </summary>
        /// <param name="skip">Number of posts to skip</param>
        /// <param name="take">Number of posts to take</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of posts with title and comment count</returns>
        Task<List<PostSummaryDto>> GetAllPostsAsync(int skip, int take, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a post by ID
        /// </summary>
        /// <param name="id">The post ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The post if found, null otherwise</returns>
        Task<PostDto?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="createPostDto">The post data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created post</returns>
        Task<PostDto> CreatePostAsync(CreatePostDto createPostDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a comment to a post
        /// </summary>
        /// <param name="postId">The post ID</param>
        /// <param name="createCommentDto">The comment data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created comment if the post exists, null otherwise</returns>
        Task<CommentDto?> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto, CancellationToken cancellationToken = default);
    }
}
