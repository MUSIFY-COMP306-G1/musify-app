using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [Route("/api/Music")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            await _musifyRepository.PutSong(id, song);
            return Ok();
        }

        // PATCH: api/Song/5
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> PatchSong(int id, string? name, string? album, string? genre, string? artist)
        //{
        //    return null;
        //}

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSong(int id,
            [FromBody] JsonPatchDocument<Song> patchDoc)
        {
            var music = await _musifyRepository.GetSong(id);
            patchDoc.ApplyTo(music, ModelState);

            await _musifyRepository.PatchSong(music);

            return Ok();
        }

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/api/Music")]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            await _musifyRepository.PostSong(song);
            return Ok();
            //return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            await _musifyRepository.DeleteSong(id);
            return Ok();
        }
    }
}