using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class SetMusicById
    {
        public static Music GetIDByPathSource(ObservableCollection<Music> music,string path)
        {
            Music music_value = new Music();
            foreach (var item in music)
            {
                if (item.Music_Path==path)
                {
                    music_value = item;
                }
            }
            return music_value;
        }
    }
}
