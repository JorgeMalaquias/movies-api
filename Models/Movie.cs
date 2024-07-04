using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Models;

namespace movies_api.models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateOnly ReleasingDate { get; set; }

        public List<Streaming> Streamings { get; set; } = [];
        public List<Genre> Genres { get; set; } = [];
        public List<Rating> Ratings { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
    }
}