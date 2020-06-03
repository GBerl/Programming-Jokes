using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramingJokes.Data
{
    public class JokeRepository
    {
        private string _connection;

        public JokeRepository(string connection)
        {
            _connection = connection;
        }

        public void AddJokes(List<Joke> jokes)
        {
            using (var context = new JokeContext(_connection))
            {
                var alljokes = context.Jokes.ToList();
                foreach (Joke j in jokes)
                {
                    if (!alljokes.Any(jk => jk.JokeId == j.JokeId))
                    {
                        context.Jokes.Add(j);

                    }

                }
                context.SaveChanges();

            }
        }

        public List<Joke> GetAllJokes()
        {
            using (var context = new JokeContext(_connection))
            {
                return context.Jokes.Include(jk => jk.UserLikedJokes).ToList();

            }
        }
        public UserLikedJokes GetLike(int id, string email)
        {
            using (var context = new JokeContext(_connection))
            {
                var userId = context.Users
                    .FirstOrDefault(u => u.Email == email).Id;
                var jokeId = context.Jokes.FirstOrDefault(j => j.JokeId == id).Id;

                UserLikedJokes liked = context.UserLikedJokes
                    .FirstOrDefault(ul => ul.JokeId == jokeId && ul.UserId == userId);
                return liked;
            }
        }

        public void UpdateLike(int id, bool liked, string email)
        {
            using (var context = new JokeContext(_connection))
            {
                var userLike = new UserLikedJokes
                {
                    UserId = context.Users
                   .FirstOrDefault(u => u.Email == email).Id,

                    JokeId = context.Jokes
                    .FirstOrDefault(j => j.JokeId == id).Id,

                    Liked = liked,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                };


                if (context.UserLikedJokes.
                    Any(ul=>ul.UserId==userLike.UserId&& ul.JokeId==userLike.JokeId))
                {
                    context.UserLikedJokes.Attach(userLike);
                    context.Entry(userLike).State = EntityState.Modified;
                    
                }
                else
                {
                    context.UserLikedJokes.Add(userLike);
                }
                context.SaveChanges();
            }

        }
    }

}
