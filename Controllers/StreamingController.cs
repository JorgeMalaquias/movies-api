using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.models;

namespace movies_api.Controllers
{
    [Route("api/streamings")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private readonly IStreamingRepository _streamingRepository;
        public StreamingController(IStreamingRepository streamingRepository)
        {
            _streamingRepository = streamingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Streaming dto)
        {
            var newStreaming = await _streamingRepository.CreateAsync(dto);
            return CreatedAtAction("Created Succesfully", newStreaming);
        }
    }
}