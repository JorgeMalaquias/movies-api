using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.Dtos.Rating;
using movies_api.Interfaces;
using movies_api.Mappers;

namespace movies_api.Controllers
{
    [Route("ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _repository;
        private readonly IMovieRepository _movieRepository;
        public RatingController(IRatingRepository repository, IMovieRepository movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var ratings = await _repository.GetManyAsync();
            return Ok(ratings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var rating = await _repository.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRatingRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _movieRepository.MovieExists(dto.MovieId))
            {
                return BadRequest("Movie not found");
            }
            var model = dto.ToRatingFromCreateDto();
            var rating = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToRatingDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRatingRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = dto.ToRatingFromUpdateDto();
            var modelFromRepository = await _repository.UpdateAsync(id, model);
            if (modelFromRepository == null)
            {
                return NotFound();
            }
            return Ok(modelFromRepository.ToRatingDto());
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