using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.Helpers
{
    public class MovieQuery : PaginationQuery
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int MonthNumber { get; set; } = 0;
        public int Year { get; set; } = 0;
        public string? StreamingName { get; set; }
        public string? GenreName { get; set; }
        public bool SortByRating { get; set; }
    }
}