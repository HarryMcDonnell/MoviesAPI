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

        [HttpGet]
        public IActionResult GETMovie(int MovieID = 0)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("MovieID", MovieID);
            return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters));
        }


        public IActionResult GETALLMovies()
        {
            return View(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null));
        }
        [HttpGet]
        public IActionResult ADDMovie(int MovieID = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ADDMovie(MovieModel movieModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MovieName", movieModel.MovieName);
            param.Add("@AgeRating", movieModel.AgeRating);
            param.Add("@Price", movieModel.Price);
            param.Add("@ReleaseDate", movieModel.ReleaseDate);
            param.Add("@Genre", movieModel.Genre);
            DapperORM.ExecuteWithoutReturn("CreateNewMovie", param);

            return RedirectToAction("GETALLMovies");

        }

        public ActionResult REMOVEMovie()
        {
            return View(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null));
        }
        [HttpGet]

        public ActionResult REMOVEMovie(int MovieID = 0)
        {
            if (MovieID == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieID", MovieID);
                DapperORM.ReturnList<MovieModel>("DeleteMovie", param).FirstOrDefault<MovieModel>();
                return RedirectToAction("GETALLMovies");

            }
        }

    }
}


