using CloudTestApplication.Models;
using CloudTestApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Controllers
{
    public class LoginController : Controller
    {


        public IUserServices us { get; set; }

        public LoginController(IUserServices dataService)
        {
            us = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(User user)
        {
            //Check Database if the user is valid.
            System.Diagnostics.Debug.WriteLine(""+user.Username + " " + user.Password );
            if (us.isValid(user))
            {
                return View("LoginSuccess", user);
            } else
            {
                return View("LoginView");
            }
           
        }
        public IActionResult LoginView()
        {
            return View("LoginView");
        }

        public IActionResult RegisterUser()
        {
            return View(new User());
        }

        public IActionResult ProcessRegister(User user)
        {
            if (us.registerUser(user))
            {
                return View("LoginView");
            } else
            {
                return View("RegisterUser");
            }

            
        }

    }
}
