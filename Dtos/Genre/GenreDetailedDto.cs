using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;

namespace movies_api.Dtos.Genre
{
    public class GenreDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public IEnumerable<MovieDto> Movies { get; set; } = [];
    }
}