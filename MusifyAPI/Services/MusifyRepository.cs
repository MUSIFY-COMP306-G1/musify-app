using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusifyLibrary;
using MusifyLibrary.Models;

namespace MusifyAPI.Services
{
    public class MusifyRepository : IMusifyRepository
    {
        private MusifyContext _context;

        public MusifyRepository(MusifyContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }


        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            return song;
        }

        // PUT: api/Song/5
        public async Task PutSong(int id, Song song)
        {
            _context.Entry(song).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();
        }

        // POST: api/Song
        [HttpPost]
        public async Task PostSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Song/5
        public async Task DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

        }

        // PATCH: 
        public async Task PatchSong(int id, String? name, String? album, String? genre, String? artist)
        {
            // TO DO //
            var song = await _context.Songs.FindAsync(id);

            _context.Entry(name).State = EntityState.Modified;
            _context.Entry(album).State = EntityState.Modified;
            _context.Entry(genre).State = EntityState.Modified;
            _context.Entry(artist).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();

        }


        private bool SongExists(int id)
        {
            return (_context.Songs?.Any(e => e.SongId == id)).GetValueOrDefault();
        }
    }
}

