using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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