using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;
using movies_api.models;

namespace movies_api.Dtos.Genre
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<MovieDto> Movies { get; set; } = [];
    }
}