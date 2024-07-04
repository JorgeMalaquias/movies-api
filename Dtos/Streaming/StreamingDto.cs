using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;

namespace movies_api.Dtos.Streaming
{
    public class StreamingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}