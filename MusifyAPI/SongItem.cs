using System;
namespace MusifyAPI
{
	public class SongItem
	{
        public int songId { get; set; }
        public string songName { get; set; }
        public string album { get; set; }
        public string genre { get; set; }
        public string artist { get; set; }
        public SongItem()
		{
		}

        public override string ToString()
        {
            return $"{songId,-10} {songName,-50} {album,-10} \n";
        }
    }
}

