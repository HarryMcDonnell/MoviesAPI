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
            dynamicParameters.Add("MovieID", 1);
            return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters));
        }

        //[HttpGet]
        //public IActionResult GETMovie(int MovieID = 0)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult GETMovie(MovieModel movieModel)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@MovieID", movieModel.MovieID);
        //    DapperORM.ExecuteWithoutReturn("SelectMovieByID", param);

        //    return RedirectToAction("GETMovie");

        //}


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

            return RedirectToAction("ADDMovie");
            
        }
        public IActionResult REMOVEMovie()
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("MovieID", 1007);
            return View(DapperORM.ReturnList<MovieModel>("DeleteMovie", dynamicParameters));
        }
    }
}

