using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MoviesAPI.Models;
using Dapper;

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
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("MovieID", 3);
            return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters));
        }
        public IActionResult GETALLMovies()
        {
            return View(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null));
        }
        public IActionResult ADDMovie()
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("MovieName", "Shrek");
            dynamicParameters.Add("AgeRating", "12A");
            dynamicParameters.Add("Price", 17.99);
            dynamicParameters.Add("ReleaseDate", "2020-10-01");
            dynamicParameters.Add("Genre", "Horror");
            return View(DapperORM.ReturnList<MovieModel>("CreateNewMovie", dynamicParameters));
        }
        public IActionResult REMOVEMovie()
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("MovieID", 1007);
            return View(DapperORM.ReturnList<MovieModel>("DeleteMovie", dynamicParameters));
        }
    }
}

