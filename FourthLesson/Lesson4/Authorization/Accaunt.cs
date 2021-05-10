using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    class Accaunt
    {
        public Accaunt(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public string Password { get; set; }
        public string Login { get; set; }
    }
}
