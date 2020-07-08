using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MoviesAPI.Models;
using Dapper;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{

    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GETMovie(bool jsonData, int MovieID = 0) // we want the Movie Id to start with 0 so it starts from the beginning. it needs to have a value 
        {
            var dynamicParameters = new DynamicParameters(); //built in parameter bag.
            dynamicParameters.Add("@MovieID", MovieID); // @ knowing its from the input value. will work without.
            if (jsonData == true)
            {
                return Json(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters));
            }
            return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", dynamicParameters)); // 1st param is stored procedure, second is parameter bag
        }


        public IActionResult GETALLMovies(bool jsonData)
        {
            if (jsonData == true)
            {
                return Json(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null).ToList());
            }
            return View(DapperORM.ReturnList<MovieModel>("SelectAllMovies", null));

        }


        public IActionResult ADDMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ADDMovie(MovieModel movieModel) // takes data in the format of our MovieModel class
        {
            DynamicParameters param = new DynamicParameters(); //bag
            param.Add("@MovieName", movieModel.MovieName); // adding these to our bag
            param.Add("@AgeRating", movieModel.AgeRating);
            param.Add("@Price", movieModel.Price);
            param.Add("@ReleaseDate", movieModel.ReleaseDate);
            param.Add("@Genre", movieModel.Genre);
            DapperORM.ExecuteWithoutReturn("CreateNewMovie", param);

            return RedirectToAction("GETALLMovies"); // re direct to our get all movies page, to see it being added. Can we add it to our ADDMovie page underneath our form?

        }



        public ActionResult REMOVEMovie(int MovieID = 0)
        {
            if (MovieID <= 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieID", MovieID);
                DapperORM.ReturnList<MovieModel>("DeleteMovie", param).FirstOrDefault<MovieModel>();
                return RedirectToAction("GETALLMovies"); // to show its been removed
            }
        }


        public IActionResult UpdateMovie()
        {
            return View();
        }


        [HttpPost] // patch method
        public ActionResult UpdateMovie(MovieModel movieModel) // takes data in the format of our MovieModel class
        {
            DynamicParameters param = new DynamicParameters(); //bag
            param.Add("@MovieID", movieModel.MovieID);

            int IDexists = DapperORM.checkID(movieModel.MovieID);

            if (IDexists == 1)
            {
                param.Add("@MovieName", movieModel.MovieName); // adding these to our bag
                param.Add("@AgeRating", movieModel.AgeRating);
                param.Add("@Price", movieModel.Price);
                param.Add("@ReleaseDate", movieModel.ReleaseDate);
                param.Add("@Genre", movieModel.Genre);
                DapperORM.ExecuteWithoutReturn("UpdateMovieByID", param);
                return RedirectToAction("GETALLMovies");
            }
            else
            {
                ViewBag.Message = "Movie ID doesn't exist, please check listings again";
                return View();
            }
        }
        // re direct to our get all movies page, to see it being added. Can we add it to our ADDMovie page underneath our form?





        public IActionResult Error(int code)
        {
            Console.WriteLine($"User received Error {code}.");
            ViewBag.StatusCode = code;
            return View($"HandleErrors/Error");

            //if (code == 404)
            //{

            //    return View($"HandleErrors/Error{code}");
            //}
            //else
            //{
            //    return View("HandleErrors/Error");
            //}
        }
    }
    
}


