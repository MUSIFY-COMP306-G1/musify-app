using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusifyAPI.DTOs;
using MusifyAPI.Services;
using MusifyLibrary.Models;

namespace MusifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private IMusifyRepository _musifyRepository;
        private readonly IMapper _mapper;

        public MusicController(IMusifyRepository musifyRepository, IMapper mapper)
        {
            _musifyRepository = musifyRepository;
            _mapper = mapper;
        }

        //Get: api/controllers
        [HttpGet]
        [Route("/api/Song")]
        public async Task<ActionResult<Song>> GetAllMusic()
        {
            var music = await _musifyRepository.GetSongs();
            var results = _mapper.Map<IEnumerable<MusicDto>>(music);
            return Ok(results);
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetOneSong(int id)
        {
            var music = await _musifyRepository.GetSong(id);
            var results = _mapper.Map<MusicDto>(music);
            return Ok(results);
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            return null;
        }

        // PATCH: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSong(int id, string? name, string? album, string? genre, string? artist)
        {
            return null;
        }

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {

            return NoContent();
        }
    }
}