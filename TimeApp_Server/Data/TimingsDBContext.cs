using Microsoft.EntityFrameworkCore;
using System.Xml;
using TimeApp_Server.Models;
namespace TimeApp_Server.Data
{
    public class TimingsDBContext : DbContext
    {
        public TimingsDBContext(DbContextOptions<TimingsDBContext> options) : base(options) { }


        public DbSet<Posts> UserTiming { get; set; } = null!;
        public DbSet<ClientDetails> ClientDetails { get; set; } = null!;



    }
}
