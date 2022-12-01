using Microsoft.EntityFrameworkCore;

namespace MusifyApp.Model
{
    public class MusicContext:DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }

        public DbSet<Music> Musics { get; set; }
    }
}
