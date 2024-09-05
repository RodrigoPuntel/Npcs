using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Npcs
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Relação 1:N entre User e Task
            modelBuilder.Entity<Task>()
                        .HasRequired(t => t.User)
                        .WithMany(u => u.Tasks)
                        .HasForeignKey(t => t.UserId);

            // Relação 1:N opcional entre Category e Task
            modelBuilder.Entity<Task>()
                        .HasOptional(t => t.Category)
                        .WithMany(c => c.Tasks)
                        .HasForeignKey(t => t.CategoryId);

            base.OnModelCreating(modelBuilder);

        }

    }
}