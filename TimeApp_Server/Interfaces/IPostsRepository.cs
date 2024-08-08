using TimeApp_Server.Models;
using TimeApp_Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TimeApp_Server.Interfaces
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Posts>> GetAllPosts();
        Task<Posts> GetPostsByIdAsync(int id);
        Task<ActionResult<Posts>> CreatePost(Posts post);
        Task<Posts> UpdatePostAsync(int id, Posts posts);
        Task<Posts> DeletePostById(int id);
        Task<ClientDetails> GetClientByNameAsync(string name);
        Task<ClientDetails> AddClientAsync(ClientDetails client);
    }
}

