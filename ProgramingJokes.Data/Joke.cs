using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramingJokes.Data
{
    public class Joke
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("Id")]
        public int JokeId { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public List<UserLikedJokes> UserLikedJokes { get; set; }

    }
}
