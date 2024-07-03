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
        public static Movie ToMovieDto(this Movie model)
        {
            return new Movie
            {
                Title = model.Title,
                ReleasingDate = model.ReleasingDate
            };
        }
    }
}