using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Movie
{
    public class UpdateMoviePartialyRequestDto
    {

        [MaxLength(40, ErrorMessage = "Title can not be more than 40 characters")]
        public string? Title { get; set; }

        [Range(1, 12)]
        public int? ReleasingMonth { get; set; }

        [Range(1900, 2024)]
        public int? ReleasingYear { get; set; }
    }
}