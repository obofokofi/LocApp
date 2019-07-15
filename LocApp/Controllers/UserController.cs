using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocApp.Models;

namespace LocApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create(int id=0)
        {
            UserInfo newuser = new UserInfo();
            return View(newuser);
        }
    }
}