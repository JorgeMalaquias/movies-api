using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Comment must have at least 10 characters")]
        [MaxLength(325, ErrorMessage = "Comment can not be more than 325 characters")]
        public required string Content { get; set; }
        [Required]
        public required int MovieId { get; set; }
    }
}