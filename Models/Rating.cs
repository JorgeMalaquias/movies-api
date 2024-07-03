using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }
        public int RatingNumber { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}