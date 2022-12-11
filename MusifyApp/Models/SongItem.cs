using System;
namespace MusifyApp.Models
{
	public class SongItem
	{
        public SongItem()
        {
        }

         public int songId { get; set; }
        public string songName { get; set; }
        public string album { get; set; }
        public string genre { get; set; }
        public string artist { get; set; }
    
	}
}

