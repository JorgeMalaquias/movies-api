using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using movies_api.Dtos.Movie;
using movies_api.Interfaces;
using movies_api.Mappers;

namespace movies_api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = dto.ToMovieModelFromCreateDTO();
            var movie = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToMovieDto());
        }
    }
}