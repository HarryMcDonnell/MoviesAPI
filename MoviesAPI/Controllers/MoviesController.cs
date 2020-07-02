using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MoviesAPI.Models;
using Dapper;
using System.Diagnostics;

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

        [HttpGet] //just want a get request not posting
        public IActionResult GETMovie(int MovieID = 0) // we want the Movie Id to start with 0 so it starts from the beginning. it needs to have a value 
        {
            var dynamicParameters = new DynamicParameters(); //built in parameter bag.
            dynamicParameters.Add("@MovieID", MovieID); // @ knowing its from the input value. will work without.
            return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters)); // built in store procedure
        }

        public IActionResult GETALLMovies() // dont need a get because it will always just display on the page. we just need to run it on the server
        {
            
            return View(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null)); // null is because we don't need to pass any inputs/parameters.
        }
    
        public IActionResult ADDMovie()
        {
            return View();
        }
        [HttpPost] // add movie form
        public ActionResult ADDMovie(MovieModel movieModel) //imported a new instance of our Movie Model and called it as a lowercase m.
        {
            DynamicParameters param = new DynamicParameters(); //bag
            param.Add("@MovieName", movieModel.MovieName); // adding these to our bag
            param.Add("@AgeRating", movieModel.AgeRating);
            param.Add("@Price", movieModel.Price);
            param.Add("@ReleaseDate", movieModel.ReleaseDate);
            param.Add("@Genre", movieModel.Genre);
            DapperORM.ExecuteWithoutReturn("CreateNewMovie", param); // store procedure

            return RedirectToAction("GETALLMovies"); // re direct to our get all movies page, to see it being added. Can we add it to our ADDMovie page underneath our form?

        }

        //public ActionResult REMOVEMovie() // not a get or post
        //{
        //    return View();
        //}

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
                return RedirectToAction("GETALLMovies"); // to show its been removed


            }
        }

    }
}


