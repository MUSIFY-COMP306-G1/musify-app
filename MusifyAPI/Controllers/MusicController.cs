using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusifyAPI.Services;
using MusifyLibrary.Models;

namespace MusifyAPI.Controllers
{
    [Route("api/[controller]")]
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
		public async Task<ActionResult<Song>> GetAllMusic()
		{
			var music = await _musifyRepository.GetSongs();
			var results = _mapper.Map<IEnumerable<Song>>(music);
			return Ok(results);
		}
	}
}

