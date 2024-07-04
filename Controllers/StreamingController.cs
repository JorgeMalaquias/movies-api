using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.Dtos.Streaming;
using movies_api.Interfaces;
using movies_api.Mappers;
using movies_api.models;

namespace movies_api.Controllers
{
    [Route("streamings")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private readonly IStreamingRepository _repository;
        public StreamingController(IStreamingRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var streaming = await _repository.GetManyAsync();
            if (streaming == null)
            {
                return NotFound();
            }
            return Ok(streaming.Select(s => s.ToStreamingDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var streaming = await _repository.GetByIdAsync(id);
            if (streaming == null)
            {
                return NotFound();
            }
            return Ok(streaming.ToStreamingDetailedDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStreamingRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.StreamingExists(dto.Name))
            {
                return Conflict("There's already a movie with this name");
            }
            var model = dto.ToStreamingModelFromCreateDTO();
            var rating = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToStreamingDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStreamingRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.StreamingExists(dto.Name))
            {
                return Conflict("There's already a movie with this name");
            }
            var model = dto.ToStreamingModelFromUpdateDTO();
            var modelFromRepository = await _repository.UpdateAsync(id, model);
            if (modelFromRepository == null)
            {
                return NotFound();
            }
            return Ok(modelFromRepository.ToStreamingDto());
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