using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Streaming
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}