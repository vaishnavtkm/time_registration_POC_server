using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TimeApp_Server.Data;
using TimeApp_Server.Models;
using TimeApp_Server.Interfaces;
namespace TimeApp_Server.Managers
{
    public class PostsManager : ControllerBase
    {
        private readonly IPostsRepository _postsRepository;

        public PostsManager(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

/* all posts*/

        public async Task<IEnumerable<Posts>> GetAllPosts()
        {
              return await _postsRepository.GetAllPosts();
        }

/* particular post */

        public async Task<Posts> GetPostsByIdAsync(int id)
        {
            return await _postsRepository.GetPostsByIdAsync(id);
        }
        
        public async Task<ActionResult<Posts>> CreatePosts(Posts post)
        {
            var created_post = await _postsRepository.CreatePost(post);

            return CreatedAtAction("GetPosts", new { id = post.Id }, created_post);
        }



        public async Task<IActionResult> DeletePostById(int id)
        {
            var post =  await _postsRepository.DeletePostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        
        public async Task<Posts> UpdatePostAsync(int id, Posts posts)
        {
            var post =  await _postsRepository.UpdatePostAsync(id,posts);
            if (post == null)
            {
                return null;
            }

            return post;
        }


/*second table entries*/
        public async Task<ClientDetails> GetClientByNameAsync(string clientname)
        {
            return await _postsRepository.GetClientByNameAsync( clientname);
        }

        public async Task<ClientDetails> AddClientAsync(ClientDetails client)
        {
            return await _postsRepository.AddClientAsync(client);
        }
    }
}
