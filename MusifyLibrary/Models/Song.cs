using System;
using System.Collections.Generic;

namespace MusifyLibrary.Models;

public partial class Song
{
 
    public int SongId { get; set; }

    public string SongName { get; set; } = null!;

    public string Album { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Artist { get; set; } = null!;

}
