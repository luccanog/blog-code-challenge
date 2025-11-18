using BlogWebApi.DTOs.Comment;
using BlogWebApi.DTOs.Post;
using BlogWebApi.Models;
using BlogWebApi.Storage;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<PostSummaryDto>> GetAllPostsAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Select(p => new PostSummaryDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    CommentCount = p.Comments.Count,
                    CreatedAt = p.CreatedAt
                })
                .OrderByDescending(p => p.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public async Task<PostDto?> GetPostByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Posts
                 .Include(p => p.Comments)
                 .Select(p => new PostDto
                 {
                     Id = p.Id,
                     Title = p.Title,
                     Content = p.Content,
                     Author = p.Author,
                     CreatedAt = p.CreatedAt,
                     Comments = p.Comments.Select(c => new CommentDto
                     {
                         Id = c.Id,
                         Content = c.Content,
                         Author = c.Author,
                         CreatedAt = c.CreatedAt,
                     })
                 })
                 .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto, CancellationToken cancellationToken = default)
        {
            var post = new Post(createPostDto.Title, createPostDto.Content, createPostDto.Author);

            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author,
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

        public async Task<CommentDto?> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto, CancellationToken cancellationToken = default)
        {
            var postExists = await _context.Posts.AnyAsync(p => p.Id == postId, cancellationToken);

            if (!postExists)
            {
                return null;
            }

            var comment = new Comment(createCommentDto.Content, createCommentDto.Author, postId);

            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

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
