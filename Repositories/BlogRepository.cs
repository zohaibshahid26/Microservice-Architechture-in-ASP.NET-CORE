using Microservice_Architechture.Data;
using Microservice_Architechture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservice_Architechture.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
        public void AddBlogPost(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
        }
        public void DeleteBlogPost(int id)
        { 
            var post = _context.BlogPosts.Find(id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }
        }
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogPosts()
        {
            return await _context.BlogPosts.ToListAsync();
        }
        public async Task<ActionResult<BlogPost?>> GetBlogPostById(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }
        public void UpdateBlogPost(BlogPost post)
        {
            _context.BlogPosts.Update(post);
            _context.SaveChanges();
        }

        public bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.PostId == id);
        }
    }
}