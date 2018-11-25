using Challenge4_Practice.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge4_Practice.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        HomeViewModel homeViewModel = new HomeViewModel();

        public ActionResult Index()
        {
            if (User.Identity.GetUserId() != null)
            {
                string userId = User.Identity.GetUserId();
                homeViewModel.AspNetUser = db.AspNetUsers.SingleOrDefault(a => a.Id == userId);
            }
            else
            {
                homeViewModel.AspNetUser = new AspNetUser();
                homeViewModel.AspNetUser.EmailConfirmed = false;
            }
            
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}