using System;
using AutoMapper;
using MusifyAPI.DTOs;
using MusifyLibrary.Models;

namespace MusifyAPI.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Song, MusicDto>();
		}
	}
}

