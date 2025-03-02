using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    [Table("Genres")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}