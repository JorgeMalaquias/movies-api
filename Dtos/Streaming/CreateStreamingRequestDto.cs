using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.Dtos.Streaming
{
    public class CreateStreamingRequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name can not be more than 20 characters")]
        public string Name { get; set; } = String.Empty;
    }
}