using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Genre
{
    public class CreateGenreRequestDto
    {
        [Required]
        public string Name { get; set; } = String.Empty;
    }
}