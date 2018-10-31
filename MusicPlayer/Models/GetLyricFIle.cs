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
    class GetLyricFIle
    {
        public Lyric GetPlayingLyric(ObservableCollection<Lyric> lyricList_value, string music_title)
        {//在Lyric集合中，得到歌名一样的歌词
            Lyric lyric = new Lyric();
            foreach (var item in lyricList_value)
            {
                //DocumentProperties lyric_Properties = await item.Properties.GetDocumentPropertiesAsync();
                if (item.Title == music_title)
                {
                    lyric = item;
                }
            }
            return lyric;
        }
        public async Task GetLocalLyrics(ObservableCollection<StorageFile> lyric_list, StorageFolder lyric_folder)
        {//获取文件夹中所有.lrc文件，然后添加进Lyric集合中
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

        public async void GetLyricList(ObservableCollection<StorageFile> lyric_list,ObservableCollection<Lyric> lyricList_value)
        {//获取指定歌词文件的一些属性

            foreach (var list in lyric_list)
            {
                DocumentProperties lyric_Properties = await list.Properties.GetDocumentPropertiesAsync();
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile fileCopy = await list.CopyAsync(localFolder, list.Name, NameCollisionOption.ReplaceExisting);
                Lyric newLyric = new Lyric();
                newLyric.Title = lyric_Properties.Title;
                newLyric.LyricFile = list;
                newLyric.Lyric_Path = list.Name;
                lyricList_value.Add(newLyric);
            }
        }
    }
}
