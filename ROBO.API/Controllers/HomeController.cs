﻿using Microsoft.AspNetCore.Mvc;

namespace ROBO.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
