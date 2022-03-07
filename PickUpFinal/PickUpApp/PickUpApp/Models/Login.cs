using System;
using System.Collections.Generic;
using System.Text;

namespace PickUpApp.Models
{
    internal class Login
    {
        private string username;
        private string password;

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Boolean checkParametrs()
        {
            return username != null && password != null;
        }
    }
}
