using Microsoft.AspNetCore.Mvc;
using MusifyLibrary.Models;

namespace MusifyAPI.Services
{
    public interface IMusifyRepository
    {
        Task DeleteSong(int id);
        Task<Song> GetSong(int id);
        Task<IEnumerable<Song>> GetSongs();
        Task PatchSong(int id, string? name, string? album, string? genre, string? artist);
        Task PostSong(Song song);
        Task PutSong(int id, Song song);
    }
}