﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramingJokes.Data
{
    public class AccountRepository
    {
        private string _connection;

        public AccountRepository(string connection)
        {
            _connection = connection;
        }

        public void AddUser(User user, string password)
        {
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            using (var context = new JokeContext(_connection))
            {
                user.HashedPassword = hashedpassword;
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public User Login(string email, string password)
        {
            User user = new User();

            using (var context = new JokeContext(_connection))
            {
                user = GetByEmail(email);
                if (BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
                { 
                    return user;
                }
                return null;
            }
        }
        public User GetByEmail(string email)
        {
            using (var context = new JokeContext(_connection))
            {
                var user = context.Users.Include(u => u.UserLikedJokes)
                      .FirstOrDefault(u => u.Email == email);

                return user;

            };
        }
    }
}
