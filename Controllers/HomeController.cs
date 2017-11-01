using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restauranter.Models;

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;

        public HomeController(RestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Reviews")]

        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.reviews.ToList();
            ViewBag.reviews = AllReviews;
            return View();
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult Add(Review model)
        {
            if (ModelState.IsValid)
            {
                _context.reviews.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}
