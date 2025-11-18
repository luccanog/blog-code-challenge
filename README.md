# Blog API

A RESTful API built with ASP.NET Core 8.0 for managing blog posts and comments.


## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd blog-code-challenge
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Run the Application

```bash
dotnet run --launch-profile https
```

### 4. Access Swagger UI

You can open Swagger UI and send HTTP requests

```
https://localhost:7118/swagger/index.html
```

## Project Structure

```
blog-code-challenge/
├── Controllers/          # API Controllers
│   └── PostsController.cs
├── Services/             # Business logic layer
│   ├── IPostService.cs
│   └── PostService.cs
├── Models/               # Domain entities
│   ├── Post.cs
│   └── Comment.cs
├── DTOs/                 # Data Transfer Objects
│   ├── Post/
│   │   ├── CreatePostDto.cs
│   │   ├── UpdatePostDto.cs
│   │   ├── PostDto.cs
│   │   └── PostSummaryDto.cs
│   └── Comment/
│       ├── CreateCommentDto.cs
│       ├── UpdateCommentDto.cs
│       └── CommentDto.cs
├── Storage/              # Database context
│   └── ApplicationDbContext.cs
├── Migrations/           # EF Core migrations
└── Program.cs            # Application entry point
```

## Architecture Highlights

### Clean Separation of Concerns
- **Controllers**: Handle HTTP concerns (routing, status codes, validation)
- **Services**: Contain all business logic and data access
- **DTOs**: Controllers never expose entity models directly
- **Entities**: Domain models with encapsulated business rules

- Entities use constructors to enforce invariants
- GUID generation is encapsulated within entities

- Data annotations on DTOs for request validation
- Model state validation in controllers
- Proper HTTP status codes (200, 201, 204, 400, 404)

## Database

The application uses SQLite with a file-based database (`blog.db`) for simplicity.

**Automatic Migrations**: The database is automatically updated on application startup. Any pending Entity Framework Core migrations are applied automatically, ensuring the database schema is always up to date.

## Future Enhancements

If I had more time, here are features and improvements we could implement:

### 1. Testing
No tests were added to this application as it is a very simple CRUD API without elaborate business logic beyond validating HTTP requests and inserting/querying the database. However, for a production application, unit and integration tests would be valuable.


### 2. Complete CRUD Operations
- **Edit Comments**: `PUT /api/posts/{postId}/comments/{commentId}` to allow authors to edit their comments
- **Delete Comments**: `DELETE /api/posts/{postId}/comments/{commentId}` to remove comments
- **Edit Posts**: `PUT /api/posts/{id}` to update post title and content
- **Delete Posts**: `DELETE /api/posts/{id}` to remove posts (with cascade delete for comments)

### 3. Authentication & Authorization
- **User Authentication**: Implement JWT-based authentication
- **User Management**: User registration and login endpoints
- **Authorization**:
  - Only post authors can edit/delete their posts
  - Only comment authors can edit/delete their comments
  - Admin role for moderation capabilities
- **User Profiles**: Associate posts and comments with user accounts
- **Author Information**: Include author details in post and comment responses

### 4. Search & Filtering
- **Elasticsearch Integration**:
  - Full-text search across post titles and content
  - Fuzzy matching and relevance scoring
  - Real-time indexing of new posts
  - Advanced search features (filters, facets, aggregations)
- **Search Endpoint**: `GET /api/posts/search?q=keyword`
- **Filtering**: Filter posts by date range, author, tag, etc.
- **Sorting**: Sort by date, popularity, comment count

### 5. Posts
- **Image Upload**: Support for uploading and displaying images
- **Tags/Categories**: Organize posts with tags and categories
- **Draft Posts**: Save posts as drafts before publishing
- **Post Scheduling**: Schedule posts for future publication

### 6. Social Features
- **Likes/Reactions**: Allow users to like posts and comments
- **Comment Threading**: Support nested comments (replies to comments)

### 7. API Enhancements
- **Rate Limiting**: Prevent abuse with rate limiting
- **CORS Configuration**: Configure CORS for frontend applications
- **Health Checks**: Add health check endpoints for monitoring
- **Logging**: Implement structured logging with Serilog
- **API Analytics**: Track API usage and performance metrics


