using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ProgramingJokes.Data
{
    public class JokesApi
    {
        public static Joke GetJoke()
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(
                $"https://official-joke-api.appspot.com/jokes/programming/random").Result;
            List<Joke> jokes = JsonConvert.DeserializeObject<List<Joke>>(json);
            return jokes[0];

        }
        public static List<Joke> GetJokes()
        {
            var jokesList = new List<Joke>();
            for (int i = 0; i < 6; i++)
            {
                IEnumerable<Joke> jokes = jokesList;
                var joke = GetJoke();

                if (!jokes.Any(jk => jk.JokeId == joke.JokeId))
                {
                    jokesList.Add(joke);
                }

            }

            return jokesList;
        }
    }
}
