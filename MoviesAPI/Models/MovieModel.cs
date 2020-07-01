using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieModel
    {
        //public int Id { get; set; } primary key
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string AgeRating { get; set; }
        public float Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
    }

}

