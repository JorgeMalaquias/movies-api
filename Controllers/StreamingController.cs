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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var streaming = await _repository.GetByIdAsync(id);
            if (streaming == null)
            {
                return NotFound();
            }
            return Ok(streaming);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStreamingRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = dto.ToStreamingModelFromCreateDTO();
            var rating = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToStreamingDto());
        }
    }
}