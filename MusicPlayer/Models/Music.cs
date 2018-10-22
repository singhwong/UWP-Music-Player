using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicPlayer.Models
{
    public class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Music_Path { get; set; }
        public BitmapImage Cover { get; set; }
        public StorageFile SongFile { get; set; }
        public int id { get; set; }
    }
}
