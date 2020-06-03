using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramingJokes.Data;
using ProgramingJokes.Web.Models;

namespace ProgramingJokes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private string _connection;
        public AccountController(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("Con");
        }
        [HttpPost]
        [Route("adduser")]
        public void AddUser(ViewModel vm)
        {
            var repo = new AccountRepository(_connection);
            repo.AddUser(vm, vm.Password);
        }

        [HttpPost]
        [Route("login")]
        public User Login(ViewModel vm)
        {
            var repo = new AccountRepository(_connection);

            var claims = new List<Claim>
            {
                new Claim("user", vm.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();

            return repo.Login(vm.Email, vm.Password);


        }

        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }

        [HttpGet]
        [Route("getuser")]
        public User GetUser()
        {
            var repo = new AccountRepository(_connection);

            if (User.Identity.IsAuthenticated)
            {

                return repo.GetByEmail(User.Identity.Name);

            }

            return null;
        }

    
}
}