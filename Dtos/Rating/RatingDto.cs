using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;
using movies_api.models;

namespace movies_api.Dtos.Rating
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int RatingNumber { get; set; }
        public int? MovieId { get; set; }
    }
}