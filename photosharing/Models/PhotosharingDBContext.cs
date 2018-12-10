using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class PhotosharingDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public async Task<User> GetUser(string userId)
        {
            return await Users.FirstOrDefaultAsync(u => u.id.Equals(userId));
        }

        public PhotosharingDBContext(DbContextOptions<PhotosharingDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
