using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TimeApp_Server.Data;
using TimeApp_Server.Interfaces;
using TimeApp_Server.Managers;
using TimeApp_Server.Models;
using TimeApp_Server.ViewModels;

namespace TimeApp_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {


        private readonly PostsManager _postsManager;

        private readonly IMapper _mapper;

        public PostsController(PostsManager postsManager, IMapper mapper )
        {
            _postsManager = postsManager;
            _mapper = mapper;
        }

        // GET: api/Posts

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            var posts = await _postsManager.GetAllPosts();


            var postsView = _mapper.Map<IEnumerable<ReadPostsView>>(posts);
            return Ok(postsView);

        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostsView>> GetPost(int id)
        {

            var post = await _postsManager.GetPostsByIdAsync(id);

           /* var posts = await _context.User_Timing.FindAsync(id);*/

            if (post == null)
            {
                return NotFound();
            }
            var postView = _mapper.Map<PostsView>(post);

            return Ok(postView);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, [FromBody] Posts posts)
        {
            Posts result = new Posts();
            try
            {
                result = await _postsManager.UpdatePostAsync(id, posts);

                if (result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Posts>> CreatePost(PostsView postView)
        {
            var post = _mapper.Map<Posts>(postView);


            var existingClient = await _postsManager.GetClientByNameAsync(post.Clientname);
            if (existingClient == null)
            {
                // If the client name does not exist, add it to the ClientDetails table
                var newClient = new ClientDetails { ClientName = post.Clientname };
                await _postsManager.AddClientAsync(newClient);
            }


            var result = await _postsManager.CreatePosts(post);
            return Ok(result);
        }


        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosts(int id)
        {
            var result = await _postsManager.DeletePostById(id);

            return result;
        }

        
    }
}
