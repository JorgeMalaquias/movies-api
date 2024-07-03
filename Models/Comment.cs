using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}