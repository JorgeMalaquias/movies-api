using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Movie;
using movies_api.Dtos.Streaming;
using movies_api.models;

namespace movies_api.Mappers
{
    public static class StreamingMappers
    {
        public static Streaming ToStreamingModelFromCreateDTO(this CreateStreamingRequestDto dto)
        {
            return new Streaming
            {
                Name = dto.Name
            };
        }
        public static Streaming ToStreamingModelFromUpdateDTO(this UpdateStreamingRequestDto dto)
        {
            return new Streaming
            {
                Name = dto.Name
            };
        }
        public static StreamingDetailedDto ToStreamingDetailedDto(this Streaming model)
        {
            return new StreamingDetailedDto
            {
                Id = model.Id,
                Name = model.Name,
                //Movies = model.Movies.Any() ? (List<MovieDto>)model.Movies.Select(m => m.ToMovieDto()) : [],

            };
        }
        public static StreamingDto ToStreamingDto(this Streaming model)
        {
            return new StreamingDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}