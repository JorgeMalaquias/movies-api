using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateOnly ReleasingDate { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}