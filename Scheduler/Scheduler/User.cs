using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class User
    {
        private String userName;
        private String name;
        private String lastName;

        public User() { } 

        public User(String userName)
        {
            this.userName = userName;
        }

        public string getUserName()
        {
            return userName;
        }

        public void setUsername(string username)
        {
            userName = username;
        }
    }
}
