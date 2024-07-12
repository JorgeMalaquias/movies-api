using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.Dtos.Comment;
using movies_api.Dtos.Genre;
using movies_api.Interfaces;
using movies_api.Mappers;

namespace movies_api.Controllers
{
    [Route("genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var genres = await _repository.GetManyAsync();
            return Ok(genres.Select(g => g.ToGenreDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var genre = await _repository.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre.ToGenreDetailedDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.GenreExists(dto.Name))
            {
                return Conflict("There's already a genre with this name");
            }
            var model = dto.ToGenreModelFromCreateDTO();
            var rating = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToGenreDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGenreRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.GenreExists(dto.Name))
            {
                return Conflict("There's already a movie with this name");
            }
            var model = dto.ToGenreModelFromUpdateDTO();
            var modelFromRepository = await _repository.UpdateAsync(id, model);
            if (modelFromRepository == null)
            {
                return NotFound();
            }
            return Ok(modelFromRepository.ToGenreDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await _repository.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}