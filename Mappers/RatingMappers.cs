using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Rating;
using movies_api.models;
using movies_api.Models;

namespace movies_api.Mappers
{
    public static class RatingMappers
    {
        public static Rating ToRatingFromCreateDto(this CreateRatingRequestDto dto)
        {
            return new Rating
            {
                RatingNumber = dto.RatingNumber,
                MovieId = dto.MovieId
            };
        }
        public static Rating ToRatingFromUpdateDto(this UpdateRatingRequestDto dto)
        {
            return new Rating
            {
                RatingNumber = dto.RatingNumber,
            };
        }
        public static RatingDto ToRatingDto(this Rating model)
        {
            return new RatingDto
            {
                Id = model.Id,
                RatingNumber = model.RatingNumber,
                Movie = model.Movie.ToMovieDto()
            };
        }
    }
}