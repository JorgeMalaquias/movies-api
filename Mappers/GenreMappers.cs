using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Genre;
using movies_api.Dtos.Movie;
using movies_api.models;

namespace movies_api.Mappers
{
    public static class GenreMappers
    {
        public static Genre ToGenreModelFromCreateDTO(this CreateGenreRequestDto dto)
        {
            return new Genre
            {
                Name = dto.Name
            };
        }
        public static Genre ToGenreModelFromUpdateDTO(this UpdateGenreRequestDto dto)
        {
            return new Genre
            {
                Name = dto.Name
            };
        }
        public static GenreDto ToGenreDto(this Genre model)
        {
            return new GenreDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static GenreDetailedDto ToGenreDetailedDto(this Genre model)
        {
            return new GenreDetailedDto
            {
                Id = model.Id,
                Name = model.Name,
                //Movies = model.Movies.Any() ? (List<MovieDto>)model.Movies.Select(c => c.ToMovieDto()) : [],
            };
        }
    }
}