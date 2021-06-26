using CloudTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Services
{
    public interface IUserServices
    {

        public bool isValid(User user);
        public bool registerUser(User user);


    }
}
