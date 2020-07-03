using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieModel
    {
        //[Range(1,9999)]
        public int MovieID { get; set; } //defined as primary key elsewhere

        //[StringLength(75, MinimumLength = 1)]
        public string MovieName { get; set; }

        //[StringLength(3,MinimumLength = 1)]
        public string AgeRating { get; set; }

        //[Range(0.00,99.99)]
        public float Price { get; set; }

        //[DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //[StringLength(50, MinimumLength = 1)]
        public string Genre { get; set; }
    }


}

