using INTELLISTOCKS.MODELS.note;
using INTELLISTOCKS.MODELS.task;
using Microsoft.EntityFrameworkCore;

namespace INTELLISTOCKS.MODELS.db
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        
        public DbSet<Note> Note { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TasksMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}