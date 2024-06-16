using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microservice_Architechture.Models;
using Microservice_Architechture.Repositories;
using Microservice_Architechture.DTOs;

namespace Microservice_Architechture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogRepository _repository;

        public BlogPostsController(IBlogRepository repository)
        {
            _repository = repository;
        }
       
        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            return await _repository.GetAllBlogPosts();
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost?>> GetBlogPost(int id)
        {
            var blogPost = await _repository.GetBlogPostById(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public  IActionResult PutBlogPost(int id, BlogPostDTO blogPostDTO)
        {
            var blogPost = new BlogPost
            {
                PostId = id,
                Title = blogPostDTO.Title,
                Content = blogPostDTO.Content,
                Author = blogPostDTO.Author,
                CategoryId = blogPostDTO.CategoryId
            };
            if (id != blogPost.PostId)
            {
                return BadRequest();
            }
            try
            {
                _repository.UpdateBlogPost(blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        [HttpPost]
        public ActionResult<BlogPost> PostBlogPost(BlogPostDTO blogPostDto)
        {
            var blogPost = new BlogPost
            {
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                Author = blogPostDto.Author,
                CategoryId = blogPostDto.CategoryId
            };
            blogPost.CreatedAt = DateTime.Now;
            _repository.AddBlogPost(blogPost);
            return CreatedAtAction("GetBlogPost", new { id = blogPost.PostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var blogPost = await _repository.GetBlogPostById(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _repository.DeleteBlogPost(id);
            return NoContent();
        }

        private bool BlogPostExists(int id)
        {
            return _repository.BlogPostExists(id);
        }
    }
}
