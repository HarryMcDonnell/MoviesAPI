using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult GETMovie()
        {
            return View();
        }
        public IActionResult GETALLMovies()
        {
            return View();
        }
        public IActionResult ADDMovie()
        {
            return View();
        }
        public IActionResult REMOVEMovie()
        {
            return View();
        }
    }
}
