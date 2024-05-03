using Microsoft.EntityFrameworkCore;

namespace CameraAPI.Models
{
    public class CameraContext : DbContext
    {
        public CameraContext(DbContextOptions<CameraContext> options) : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }
    }
}
