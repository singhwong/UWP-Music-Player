using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace MusicPlayer.Models
{
    public class Lyric
    {
            public string Title { get; set; }
            public string Lyric_Path { get; set; }
            public StorageFile LyricFile { get; set; }
            public string album_title { get; set; }


       
    }
}
