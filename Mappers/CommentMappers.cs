using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.Dtos.Comment;
using movies_api.Dtos.Movie;
using movies_api.models;
using movies_api.Models;

namespace movies_api.Mappers
{
    public static class CommentMappers
    {
        public static Comment ToCommentModelFromCreateDTO(this CreateCommentRequestDto dto)
        {
            return new Comment
            {
                Content = dto.Content,
                MovieId = dto.MovieId
            };
        }
        public static Comment ToCommentModelFromUpdateDTO(this UpdateCommentRequestDto dto)
        {
            return new Comment
            {
                Content = dto.Content,
                MovieId = dto.MovieId
            };
        }
        public static CommentDto ToCommentDto(this Comment model)
        {
            return new CommentDto
            {
                Id = model.Id,
                Content = model.Content,
                MovieId = model.MovieId
            };
        }
    }
}