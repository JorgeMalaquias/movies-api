using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;
using movies_api.models;

namespace movies_api.Mappers
{
    public static class MovieMappers
    {
        public static Movie ToMovieModelFromCreateDTO(this CreateMovieRequestDto dto)
        {
            return new Movie
            {
                Title = dto.Title,
                ReleasingDate = new DateOnly(dto.ReleasingYear, dto.ReleasingMonth, 1)
            };
        }
        public static Movie ToMovieModelFromUpdateDTO(this UpdateMovieRequestDTO dto)
        {
            return new Movie
            {
                Title = dto.Title,
                ReleasingDate = new DateOnly(dto.ReleasingYear, dto.ReleasingMonth, 1)
            };
        }
        public static MovieDto ToMovieDto(this Movie model)
        {
            return new MovieDto
            {
                Id = model.Id,
                Title = model.Title,
                ReleasingDate = model.ReleasingDate

            };
        }
    }
}