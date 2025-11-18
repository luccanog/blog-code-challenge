using BlogWebApi.DTOs.Comment;
using BlogWebApi.DTOs.Post;
using BlogWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    /// <summary>
    /// Controller for managing blog posts
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Get all posts (paginated)
        /// </summary>
        /// <param name="skip">Number of posts to skip (default: 0)</param>
        /// <param name="take">Number of posts to take (default: 10)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of posts with their titles and comment count</returns>
        /// <response code="200">Returns the list of posts</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<PostSummaryDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PostSummaryDto>>> GetAllPosts(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10,
            CancellationToken cancellationToken = default)
        {
            var posts = await _postService.GetAllPostsAsync(skip, take, cancellationToken);
            return Ok(posts);
        }

        /// <summary>
        /// Get a specific post by ID
        /// </summary>
        /// <param name="id">The post ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The post with its comments</returns>
        /// <response code="200">Returns the post</response>
        /// <response code="404">If the post is not found</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostDto>> GetPostById(Guid id, CancellationToken cancellationToken)
        {
            var post = await _postService.GetPostByIdAsync(id, cancellationToken);

            if (post == null)
            {
                return NotFound(new { message = $"Post with ID {id} not found" });
            }

            return Ok(post);
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="createPostDto">The post data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created post</returns>
        /// <response code="201">Returns the newly created post</response>
        /// <response code="400">If the post data is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> CreatePost(
            [FromBody] CreatePostDto createPostDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _postService.CreatePostAsync(createPostDto, cancellationToken);

            return CreatedAtAction(
                nameof(GetPostById),
                new { id = post.Id },
                post
            );
        }

        /// <summary>
        /// Add a comment to a post
        /// </summary>
        /// <param name="id">The post ID</param>
        /// <param name="createCommentDto">The comment data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created comment</returns>
        /// <response code="201">Returns the newly created comment</response>
        /// <response code="400">If the comment data is invalid</response>
        /// <response code="404">If the post is not found</response>
        [HttpPost("{id:guid}/comments")]
        [ProducesResponseType(typeof(CommentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentDto>> AddCommentToPost(
            Guid id,
            [FromBody] CreateCommentDto createCommentDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _postService.AddCommentToPostAsync(id, createCommentDto, cancellationToken);

            if (comment == null)
            {
                return NotFound(new { message = $"Post with ID {id} not found" });
            }

            return CreatedAtAction(
                nameof(GetPostById),
                new { id = id },
                comment
            );
        }
    }
}
