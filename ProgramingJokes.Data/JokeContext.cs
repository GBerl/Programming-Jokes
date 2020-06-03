using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramingJokes.Data
{
    public class JokeContext: DbContext
    {
        private string _connection;

        public JokeContext(string connection)
        {
            _connection = connection;
        }
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLikedJokes> UserLikedJokes { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<UserLikedJokes>()
                .HasKey(l => new { l.JokeId, l.UserId });

            modelBuilder.Entity<UserLikedJokes>()
                .HasOne(l => l.Joke)
                .WithMany(j => j.UserLikedJokes)
                .HasForeignKey(j => j.JokeId);

            modelBuilder.Entity<UserLikedJokes>()
                .HasOne(l => l.User)
                .WithMany(u => u.UserLikedJokes)
                .HasForeignKey(u => u.UserId);

        }
    }
}
