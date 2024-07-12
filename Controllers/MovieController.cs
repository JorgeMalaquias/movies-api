using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using movies_api.Dtos.Movie;
using movies_api.Helpers;
using movies_api.Interfaces;
using movies_api.Mappers;
using movies_api.models;

namespace movies_api.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        private readonly IGenreRepository _genreRepository;
        private readonly IStreamingRepository _streamingRepository;
        public MovieController(IMovieRepository repository, IGenreRepository genreRepository, IStreamingRepository streamingRepository)
        {
            _repository = repository;
            _genreRepository = genreRepository;
            _streamingRepository = streamingRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToMovieDetailedDto());
        }
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] MovieQuery query)
        {
            var movies = await _repository.GetManyAsync(query);
            return Ok(movies.Select(m => m.ToMovieDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.MovieExists(dto.Title))
            {
                return Conflict("There's already a movie with this name");
            }
            var model = dto.ToMovieModelFromCreateDTO();
            var movie = await _repository.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToMovieDetailedDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _repository.MovieExists(dto.Title))
            {
                return Conflict("There's already a movie with this name");
            }
            var model = dto.ToMovieModelFromUpdateDTO();
            var modelFromRepository = await _repository.UpdateAsync(id, model);
            if (modelFromRepository == null)
            {
                return NotFound();
            }
            return Ok(modelFromRepository.ToMovieDetailedDto());
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

        [HttpPatch("add_genre/{genreId:int}/{movieId:int}")]
        public async Task<IActionResult> ConnectToGenre([FromRoute] int genreId, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genre = await _genreRepository.GetByIdAsync(genreId);
            if (genre == null)
            {
                return NotFound("Genre not found");
            }
            var movie = await _repository.ConnectGenreAsync(movieId, genre);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie.ToMovieDetailedDto());
        }
        [HttpPatch("add_streaming/{streamingId:int}/{movieId:int}")]
        public async Task<IActionResult> ConnectToStreaming([FromRoute] int streamingId, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var streaming = await _streamingRepository.GetByIdAsync(streamingId);
            if (streaming == null)
            {
                return NotFound("Streaming not found");
            }
            var movie = await _repository.ConnectStreamingAsync(movieId, streaming);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie.ToMovieDetailedDto());
        }
    }
}