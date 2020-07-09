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


        public IActionResult GETMovie(bool jsonData, int MovieID = 0)// we want the Movie Id to start with 0 so it starts from the beginning. it needs to have a value 
        {

            if (MovieID <= 0) //a catch so it cant be a blank 
            {
                return View();
            }
            else
            {
                ViewBag.MovieID = MovieID;
                int IDexists = DapperORM.checkID(MovieID);

                if (IDexists == 1)
                {
                    DynamicParameters param = new DynamicParameters(); //built in parameter bag.
                    param.Add("@MovieID", MovieID);// @ knowing its from the input value. will work without.
                    if (jsonData == true)
                    {
                        return Json(DapperORM.ReturnList<MovieModel>("SelectMovieByID", param));
                    }
                    return View(DapperORM.ReturnList<MovieModel>("SelectMovieByID", param)); // 1st param is stored procedure, second is parameter bag
                } else
                {
                    ViewBag.MovieID = 0;
                    ViewBag.Message = "Movie ID doesn't exist, please check the movie listings."; // catch if ID  doesn't exist.
                    return View();
                }
            }
        }

public IActionResult REMOVEMovie(int MovieID = 0)
        {
            if (MovieID <= 0) //a catch so it cant be a blank 
            { 
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieID", MovieID);
                int IDexists = DapperORM.checkID(MovieID);
                if (IDexists == 1)
                {
                    DapperORM.ExecuteWithoutReturn("DeleteMovie", param);
                    return RedirectToAction("GETALLMovies"); // to show its been removed
                }
                else
                {
                    ViewBag.Message = "Movie ID doesn't exist, please check the movie listings."; // catch if ID  doesn't exist.
                    return View();
                }
            }
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

        [HttpPost] //post method
        public IActionResult ADDMovie(MovieModel movieModel) // takes data in the format of our MovieModel class
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



        public IActionResult UpdateMovie()
        {
            return View();
        }

        [HttpPost] // patch method
        public IActionResult UpdateMovie(MovieModel movieModel) // takes data in the format of our MovieModel class
        {
            DynamicParameters param = new DynamicParameters(); //bag
            param.Add("@MovieID", movieModel.MovieID); // adding movie id to the bag
            int IDexists = DapperORM.checkID(movieModel.MovieID); //created a method in dapperORM to check if the Movie ID exists in the database
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
                ViewBag.Message = "Movie ID doesn't exist, please check the movie listings.";
                return View();
            }
        }


        public IActionResult Error(int code)
        {
            Console.WriteLine($"User received Error {code}.");
            ViewBag.StatusCode = code;
            return View($"HandleErrors/Error");
        }
    }
    
}


