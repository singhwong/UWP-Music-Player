using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MusicPlayer.Models
{
    public class GetLocalLyric
    {
        public string Lyric_time { get; set; }
        public string Lyric_text { get; set; }


        public void GetPlayingLyric(string music_text)
        {

        }
        public async Task GetLocalLyrics(ObservableCollection<StorageFile> lyric_list, StorageFolder lyric_folder)
        {
            foreach (var lyric in await lyric_folder.GetFilesAsync())
            {
                if (lyric.FileType == ".lrc")
                {
                    lyric_list.Add(lyric);
                }
            }
            foreach (var item in await lyric_folder.GetFoldersAsync())
            {
                await GetLocalLyrics(lyric_list, item);
            }
        }
    }
}
