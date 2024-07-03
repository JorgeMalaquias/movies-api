using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Movie
{
    public class CreateMovieRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Title must not be empty")]
        public string Title { get; set; } = String.Empty;
        [Required]
        [Range(1, 12)]
        public int ReleasingMonth { get; set; }
        [Required]
        [Range(1900, 2024)]
        public int ReleasingYear { get; set; }
    }
}