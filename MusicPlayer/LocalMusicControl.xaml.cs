using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace MusicPlayer
{
    public sealed partial class LocalMusicControl : UserControl
    {
        private SolidColorBrush deepPink = new SolidColorBrush(Colors.DeepPink);
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        public Music this_music { get { return this.DataContext as Music; } }
        public LocalMusicControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            main_storyBoard.Begin();
        }

        private void main_storyBoard_Completed(object sender, object e)
        {
            //num_textblock.Foreground = this_music.ForeColor;
            try
            {
                isPlay_textblock.Foreground = this_music.ForeColor;
        }
            catch
            {
            }           
            main_storyBoard.Begin();
        }

        //private void control_stackPanel_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    num_textblock.Foreground = deepPink;
        //    artist_textblock.Foreground = deepPink;
        //    size_textblock.Foreground = deepPink;
        //    title_textblock.Foreground = deepPink;            
        //}

        //private void control_stackPanel_PointerExited(object sender, PointerRoutedEventArgs e)
        //{
        //    num_textblock.Foreground = white;
        //    artist_textblock.Foreground = white;
        //    size_textblock.Foreground = white;
        //    title_textblock.Foreground = white;
        //}
    }
}
