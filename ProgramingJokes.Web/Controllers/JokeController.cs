using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramingJokes.Data;
using ProgramingJokes.Web.Models;

namespace ProgramingJokes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private string _connection;
        public JokeController(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("Con");
        }
        [HttpGet]
        [Route("getjokes")]
        public List<Joke> GetJokes()
        {
            var repo = new JokeRepository(_connection);
            var jokes = JokesApi.GetJokes();
            repo.AddJokes(jokes);
            return jokes;
        }

        [HttpGet]
        [Route("getalljokes")]
        public List<Joke> GetAllJokes()
        {
            var repo = new JokeRepository(_connection);
            return repo.GetAllJokes();

        }
        [HttpGet]
        [Route("getlike")]
        public UserLikedJokes GetLike(int id)
        {
            var repo = new JokeRepository(_connection);
            return repo.GetLike(id, User.Identity.Name);

        }

        [Authorize]
        [HttpPost]
        [Route("updatelike")]
        public void UpdateLike(LikeJoke likeJoke)
        {
            var repo = new JokeRepository(_connection);
            repo.UpdateLike(likeJoke.Id, likeJoke.Liked, User.Identity.Name);

        }
    }
}