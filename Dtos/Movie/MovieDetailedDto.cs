using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Comment;
using movies_api.Dtos.Genre;
using movies_api.Dtos.Rating;
using movies_api.Dtos.Streaming;

namespace movies_api.Dtos.Movie
{
    public class MovieDetailedDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateOnly ReleasingDate { get; set; }
        public float? RatingAverage { get; set; }
        public int NumberOfRatings { get; set; }
        public int NumberOfComments { get; set; }
        public List<StreamingDto> Streamings { get; set; } = [];
        public List<GenreDto> Genres { get; set; } = [];
        public List<CommentDto> Comments { get; set; } = [];

    }
}