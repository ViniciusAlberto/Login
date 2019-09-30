using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Model
{
    public class User
    {
        public int IDUser { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string CPF { get; set; }


        public string Password { get; set; }
    }
}
