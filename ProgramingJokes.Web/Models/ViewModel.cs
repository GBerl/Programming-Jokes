using ProgramingJokes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramingJokes.Web.Models
{
    public class ViewModel:User
    {
        public string Password { get; set; }
    }
}
