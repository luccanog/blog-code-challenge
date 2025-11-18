using BlogWebApi.DTOs.Comment;
using BlogWebApi.DTOs.Post;
using BlogWebApi.Models;
using BlogWebApi.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogWebApi.Services
{
    /// <summary>
    /// Service for managing posts
    /// </summary>
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostSummaryDto>> GetAllPostsAsync()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Select(p => new PostSummaryDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    CommentCount = p.Comments.Count,
                    CreatedAt = p.CreatedAt
                })
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<PostDto?> GetPostByIdAsync(Guid id)
        {
           return await _context.Posts
                .Include(p => p.Comments)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    Comments = p.Comments.Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                        Author = c.Author,
                        CreatedAt = c.CreatedAt,
                    })
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto)
        {
            var post = new Post(createPostDto.Title, createPostDto.Content);

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Comments = post.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    Author = c.Author,
                    CreatedAt = c.CreatedAt,
                })
            };
        }

        public async Task<CommentDto?> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto)
        {
            var postExists = await _context.Posts.AnyAsync(p => p.Id == postId);

            if (!postExists)
            {
                return null;
            }

            var comment = new Comment(createCommentDto.Content, createCommentDto.Author, postId);

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                Author = comment.Author,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
