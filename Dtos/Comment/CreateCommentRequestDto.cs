using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        public string Content { get; set; } = String.Empty;
        public int? MovieId { get; set; }
    }
}