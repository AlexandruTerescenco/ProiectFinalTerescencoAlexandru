using Proiect_Final_TerescencoAlexandru.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect_Final_TerescencoAlexandru.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Game)
                .HasForeignKey(c => c.game_Id)
                .IsRequired();
            
            modelBuilder.Entity<Screenshot>()
                .HasOne(g => g.Game)
                .WithOne(g => g.Screenshot)
                .HasForeignKey<Game>(g => g.screenshot_id)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.user_Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
