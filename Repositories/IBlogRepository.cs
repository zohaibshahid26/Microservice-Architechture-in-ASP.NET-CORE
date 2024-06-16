using Microservice_Architechture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice_Architechture.Repositories
{
    public interface IBlogRepository
    {
        Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogPosts();
        Task<ActionResult<BlogPost?>> GetBlogPostById(int id);
        void AddBlogPost(BlogPost post);
        void UpdateBlogPost(BlogPost post);
        void DeleteBlogPost(int id);
        bool BlogPostExists(int id);
    }
}
