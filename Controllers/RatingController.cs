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
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _repository;
        public RatingController(IRatingRepository repository)
        {
            _repository = repository;
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
            var model = dto.ToRatingFromCreateDto();
            var rating = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToRatingDto());
        }
    }
}