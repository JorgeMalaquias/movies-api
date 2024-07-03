using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Rating
{
    public class CreateRatingRequestDto
    {
        [Required]
        [Range(1, 5, ErrorMessage = "RatingNumber must be a integer value from 1 to 5")]
        public int RatingNumber { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}