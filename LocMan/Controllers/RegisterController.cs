using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocMan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocMan.Controllers
{
    public class RegisterController : Controller
    {
        private readonly LocDbContext _context;

        public RegisterController(LocDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult UserRegister()
        {
            UserInfo newuser = new UserInfo();
            return View(newuser);
        }

        [HttpPost]
        public IActionResult UserRegister(UserInfo user)
        {
            //var ab = _context.UserInfo.Add(user);
            using (LocDbContext db =new LocDbContext())
            {
                bool iac = true;
                user.IsActive = iac;

                db.UserInfo.Add(user);
                db.SaveChanges();
            ModelState.Clear();
            ViewBag.SuccessMsg = user.Username + " successfully created.";
            }
            return View("UserRegister",new UserInfo()); //change the view here to the details page for district and region
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            UserInfo user = new UserInfo();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserLogin(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var loginuser = (from userlist in _context.UserInfo
                                 where userlist.Username == user.Username && userlist.UserPass == user.UserPass
                                 select new {
                                     userlist.UserInfoId,
                                     userlist.Username
                                 }).ToList();
                //_context 
            }

            return RedirectToAction("Welcome","Home");
            //return View("SeeDistrict");
        }
    }
}