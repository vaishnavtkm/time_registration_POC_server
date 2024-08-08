using TimeApp_Server.Models;
using TimeApp_Server.Data;
using Microsoft.EntityFrameworkCore;
using TimeApp_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TimeApp_Server.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly TimingsDBContext _dbContext;

        public PostsRepository(TimingsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Posts>> GetAllPosts()
        {
            return await _dbContext.UserTiming.ToListAsync();
        }

        /* particular post */

        public async Task<Posts> GetPostsByIdAsync(int id)
        {
            return await _dbContext.UserTiming.FindAsync(id);
        }

        public async Task<ActionResult<Posts>> CreatePost(Posts post)
        {
            _dbContext.UserTiming.Add(post);
            await _dbContext.SaveChangesAsync();

            return post;
        }



        public async Task<Posts> DeletePostById(int id)
        {
            var post = await _dbContext.UserTiming.FindAsync(id);
            
            _dbContext.UserTiming.Remove(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Posts> UpdatePostAsync(int id, Posts posts)
        {
            var existingPost = await _dbContext.UserTiming.FirstOrDefaultAsync(u => u.Id == id);
            if (existingPost != null)
            {
                existingPost.From = posts.From;
                existingPost.To = posts.To;
                existingPost.Clientname = posts.Clientname;
                existingPost.Casenumber = posts.Casenumber;
                existingPost.Case = posts.Case;
                existingPost.Typeofwork = posts.Typeofwork;
                existingPost.Description = posts.Description;

                await _dbContext.SaveChangesAsync();
            }

            return existingPost;
        }

        public async Task<ClientDetails> GetClientByNameAsync(string clientname)
        {
            return await _dbContext.ClientDetails.FirstOrDefaultAsync(c => c.ClientName == clientname);
        }

        public async Task<ClientDetails> AddClientAsync(ClientDetails client)
        {
            _dbContext.ClientDetails.Add(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }
    }
}

