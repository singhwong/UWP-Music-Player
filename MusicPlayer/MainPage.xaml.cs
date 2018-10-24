using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MusicPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> use_music;
        private ObservableCollection<StorageFile> allMusic;
        //private bool IsComplete_bool = false;
        public MainPage()
        {
            this.InitializeComponent();
            ExtendAcrylicIntoTitleBar();
            use_music = new ObservableCollection<Music>();
            allMusic = new ObservableCollection<StorageFile>();
        }
        private bool RandomPlay_bool = false;
        private bool ListPlay_bool = false;
        private bool SingleCycle_bool = false;
        private bool IsBackButtonClick = false;
        private bool IsMusicPlaying = false;
        private bool IsHiddenButtonClick = false;
        private string source_path;
        private string image_source_path;
        private SolidColorBrush skyblue = new SolidColorBrush(Colors.SkyBlue);
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);

        private ApplicationDataContainer local_volume = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_backGround = ApplicationData.Current.LocalSettings;
        private string backGround_path;
        private double volume_value;

        private ImageBrush imageBrush = new ImageBrush();
        private ImageBrush imageBrush_ellipse = new ImageBrush();
        private BitmapImage Album_Cover = new BitmapImage();
        private bool IsVolumeOpen = true;
        private double volume_num;
        string mm_str;
        string ss_str;
        string allmm_str;
        string allss_str;
        private int allsong_count;
        StorageFolder localFolder;
        StorageFile fileCopy;
        private int num = 0;
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        private SolidColorBrush transParent = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush lightBlue = new SolidColorBrush(Colors.LightBlue);
        private SolidColorBrush hotPink = new SolidColorBrush(Colors.HotPink);
        private SolidColorBrush aliceBlue = new SolidColorBrush(Colors.AliceBlue);
        private SolidColorBrush darkRed = new SolidColorBrush(Colors.DarkRed);
        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            if (source_path != null)
            {
                stop_button.Foreground = black;
                if (IsMusicPlaying==false)
                {
                    main_mediaElement.Play();
                    play_button.Foreground = skyblue;
                    main_slider.Maximum = main_mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                    play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    play_button.Content = "\uE769";
                    IsMusicPlaying = true;
                }
                else
                {
                    main_mediaElement.Pause();
                    play_button.Foreground = darkRed;
                    //status_textblock.Text = "暂停中";
                    play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    play_button.Content = "\uE768";
                    IsMusicPlaying = false;
                }              
            }
        }

        //private void pause_button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (source_path != null)
        //    {
        //        main_mediaElement.Pause();
        //        pause_button.Foreground = skyblue;
        //        play_button.Foreground = black;
        //        status_textblock.Text = "暂停中";
        //    }
        //}

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE768";
            IsMusicPlaying = false;
            play_button.Foreground = black;
            stop_button.Foreground = darkRed;
            main_mediaElement.Stop();
            //status_textblock.Text = "";
        }

        private void main_slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

            int allSeconds = (int)main_slider.Maximum;
            int currentSeconds = (int)main_slider.Value;
            int mm = currentSeconds / 60;
            int ss = currentSeconds % 60;
            int all_mm = allSeconds / 60;
            int all_ss = allSeconds % 60;
            if (mm > 9)
            {
                mm_str = mm.ToString();
            }
            else
            {
                mm_str = "0" + mm.ToString();
            }
            if (ss > 9)
            {
                ss_str = ss.ToString();
            }
            else
            {
                ss_str = "0" + ss.ToString();
            }
            if (all_mm > 9)
            {
                allmm_str = all_mm.ToString();
            }
            else
            {
                allmm_str = "0" + all_mm.ToString();
            }
            if (all_ss > 9)
            {
                allss_str = all_ss.ToString();
            }
            else
            {
                allss_str = "0" + all_ss.ToString();
            }
            playTime_textblock.Text = mm_str + ":" + ss_str + "/" + allmm_str + ":" + allss_str;

            if (main_slider.Value == main_slider.Maximum)
            {
                play_button.Foreground = black;
                play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                play_button.Content = "\uE768";
                if (SingleCycle_bool)
                {
                    Single_Cycle();
                }
                else if (ListPlay_bool)
                {
                    List_Source();
                }
                else if (RandomPlay_bool)
                {
                    Random_Source();
                }
                else
                {
                    IsMusicPlaying = false;
                }
            }
        }
        private void Random_Source()
        {           
            Random rm = new Random();
            int index = rm.Next(0, allsong_count);
            var auto_value = use_music[index];

            source_path = auto_value.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            //BitmapImage album_cover = new BitmapImage();
            Album_Cover = auto_value.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = auto_value.Title + " - " + auto_value.Artist;
            bottomTitle_textblock.Text = songTile_textblock.Text;
            main_storyBoard.Begin();
        }
        private void List_Source()
        {
            Music list_music = SetMusicById.GetIDByPathSource(use_music,source_path);
            int index = list_music.id;          
            var list_value = new Music();
            if (IsBackButtonClick)
            {
                num = index - 1;
                IsBackButtonClick = false;
            }
            else
            {
                num = index + 1;
            }
            if (num==use_music.Count)
            {
                num = 0;
            }
            else if (num==-1)
            {
                num = use_music.Count - 1;
            }
            list_value = use_music[num];
            source_path = list_value.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            //BitmapImage album_cover = new BitmapImage();
            Album_Cover = list_value.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = list_value.Title + " - " + list_value.Artist;
            bottomTitle_textblock.Text = songTile_textblock.Text;
            main_storyBoard.Begin();

        }
        private void Single_Cycle()
        {
            main_storyBoard.Begin();
        }
        private async void add_button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker file = new FileOpenPicker();
            file.FileTypeFilter.Add(".mp3");
            StorageFile media_file = await file.PickSingleFileAsync();
            if (media_file != null)
            {
                using (var stream = await media_file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    #region 获取音乐文件专辑封面
                    StorageItemThumbnail current_Thumb = await media_file.GetThumbnailAsync(
                    ThumbnailMode.MusicView,
                    300,
                    ThumbnailOptions.UseCurrentScale);

                    Album_Cover.SetSource(current_Thumb);
                    bottom_image.Source = Album_Cover;
                    imageBrush_ellipse.ImageSource = Album_Cover;
                    #endregion                   
                    main_ellipse.Fill = imageBrush_ellipse;
                }
            }
            localFolder = ApplicationData.Current.LocalFolder;
            try
            {

                MusicProperties song_Properties = await media_file.Properties.GetMusicPropertiesAsync();
                songTile_textblock.Text = song_Properties.Title + " - " + song_Properties.Artist;
                bottomTitle_textblock.Text = songTile_textblock.Text;
                fileCopy = await media_file.CopyAsync(localFolder, media_file.Name, NameCollisionOption.ReplaceExisting);
                source_path =media_file.Name;//获取选定音乐文件路径
                main_mediaElement.Source = new Uri("ms-appdata:///local/" + source_path);
                play_button.Foreground = black;
                play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                play_button.Content = "\uE768";
                IsMusicPlaying = false;
            }
            catch
            {
            }
        }

        private void display_button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            bool isInFullScreenMode = view.IsFullScreenMode;
            if (isInFullScreenMode)
            {

                view.ExitFullScreenMode();
                display_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                display_button.Content = "\uE740";
            }
            else
            {
                view.TryEnterFullScreenMode();
                display_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                display_button.Content = "\uE73F";
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            back_button.IsEnabled = false;
            forward_button.IsEnabled = false;
            main_progressRing.IsActive = true;
            GetLocalMusic();//获取本地音乐文件ListView
            main_progressRing.IsActive = false;
            forward_button.IsEnabled = false;
            back_button.IsEnabled = false;

            BackIcon_textblock.Visibility = Visibility.Collapsed;
            ForwardIcon_textblock.Visibility = Visibility.Collapsed;
            main_progressRing.Visibility = Visibility.Collapsed;
            setting_button.Visibility = Visibility.Collapsed;
            playTime_textblock.Text = "00:00/00:00";
            try
            {
                backGround_path = local_backGround.Values["backGround_image"].ToString();
                imageBrush.ImageSource = new BitmapImage(new Uri(backGround_path));
            }
            catch
            {
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/girl.jpg", UriKind.Absolute));
            }
            main_grid.Background = imageBrush;
            main_grid.Background.Opacity = 0.7;
            try
            {
                volume_value = (double)local_volume.Values["Volume"];
                volume_slider.Value = volume_value;
                volume_textblock.Text = volume_value.ToString();
                main_mediaElement.Volume = volume_value / 100;
            }
            catch
            {
                volume_slider.Value = 30;
                volume_textblock.Text = "30";
                main_mediaElement.Volume = 0.3;
            }
            story_board.Begin();


        }

        private void volume_Click(object sender, RoutedEventArgs e)
        {
            volume.Flyout.Hide();
        }

        private void volume_slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            volume_num = volume_slider.Value;
            volume_textblock.Text = volume_num.ToString();
            main_mediaElement.Volume = volume_num / 100;
            local_volume.Values["Volume"] = volume_num;
        }
        //private void SetAcrylic()
        //{
        //    #region 设置亚克力背景
        //    if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
        //    {
        //        AcrylicBrush myBrush = new AcrylicBrush();
        //        myBrush.BackgroundSource = AcrylicBackgroundSource.HostBackdrop;
        //        myBrush.TintColor = Colors.AliceBlue;
        //        myBrush.FallbackColor = Colors.AliceBlue;
        //        myBrush.TintOpacity = 0.3;
        //    }
        //    else
        //    {
        //        SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(100, 20, 24, 37));
        //    }
        //    #endregion
        //}

        private void background_menu_Click(object sender, RoutedEventArgs e)
        {
            GetBackgroundImage();
        }

        private void Yes_item_Click(object sender, RoutedEventArgs e)
        {
            story_board.Begin();
        }

        private void No_item_Click(object sender, RoutedEventArgs e)
        {
            story_board.Stop();
        }

        private async void GetBackgroundImage()
        {
            FileOpenPicker file = new FileOpenPicker();
            file.FileTypeFilter.Add(".jpg");
            StorageFile image_file = await file.PickSingleFileAsync();
            if (image_file != null)
            {
                BitmapImage image = new BitmapImage();
                using (var stream = await image_file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    image.SetSource(stream);
                }//这段代码作用尚不明确，有可能是为了及时释放资源
            }
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile fileCopy = await image_file.CopyAsync(localFolder, image_file.Name, NameCollisionOption.ReplaceExisting);
                image_source_path = "ms-appdata:///local/" + image_file.Name;

                imageBrush.ImageSource = new BitmapImage(new Uri(image_source_path));
                main_grid.Background = imageBrush;
                local_backGround.Values["backGround_image"] = image_source_path;
            }
            catch
            {
            }
        }

        #region 将亚克力扩展到标题栏
        private void ExtendAcrylicIntoTitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }
        #endregion
        private void volumeIcon_textblock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsVolumeOpen)
            {
                volumeIcon_textblock.FontFamily = new FontFamily("Segoe MDL2 Assets");
                volumeIcon_textblock.Text = "\uE74F";
                main_mediaElement.Volume = 0;
                IsVolumeOpen = false;
            }
            else
            {
                volumeIcon_textblock.FontFamily = new FontFamily("Segoe MDL2 Assets");
                volumeIcon_textblock.Text = "\uE994";
                main_mediaElement.Volume = volume_num / 100;
                IsVolumeOpen = true;
            }
        }
        private async Task GetAllSongs(ObservableCollection<StorageFile> list, StorageFolder folder)
        {
            foreach (var song in await folder.GetFilesAsync())
            {
                if (song.FileType == ".mp3" || song.FileType == ".wav")
                {
                    list.Add(song);
                }
            }
            foreach (var item in await folder.GetFoldersAsync())
            {
                await GetAllSongs(list, item);
            }
        }

        private async Task ListView_Songs(ObservableCollection<StorageFile> files)
        {

            foreach (var song in files)
            {
                MusicProperties song_Properties = await song.Properties.GetMusicPropertiesAsync();
                StorageItemThumbnail current_Thumb = await song.GetThumbnailAsync(
                    ThumbnailMode.MusicView,
                    200,
                    ThumbnailOptions.UseCurrentScale);
                BitmapImage album_cover = new BitmapImage();
                album_cover.SetSource(current_Thumb);
                Music music = new Music();
                music.Title = song_Properties.Title;
                music.Artist = song_Properties.Artist;
                music.Cover = album_cover;
                localFolder = ApplicationData.Current.LocalFolder;
                fileCopy = await song.CopyAsync(localFolder, song.Name, NameCollisionOption.ReplaceExisting);
                music.Music_Path = song.Name;
                music.id = num;
                music.SongFile = song;
                use_music.Add(music);
                num++;
            }
            allsong_count = use_music.Count;
        }
        private async void GetLocalMusic()
        {
            StorageFolder folder = KnownFolders.MusicLibrary;
            await GetAllSongs(allMusic, folder);
            await ListView_Songs(allMusic);
        }

        private void main_listview_ItemClick(object sender, ItemClickEventArgs e)
        {           
            var value = (Music)e.ClickedItem;
            source_path =  value.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            //BitmapImage album_cover = new BitmapImage();
            Album_Cover = value.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = value.Title + " - " + value.Artist;
            bottomTitle_textblock.Text = songTile_textblock.Text;
            play_button.Foreground = black;
            main_storyBoard2.Begin();
            IsMusicPlaying = true;
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
        }     

        private void setting_button_Click(object sender, RoutedEventArgs e)
        {
            main_AppBar.Visibility = Visibility.Visible;
            setting_button.Visibility = Visibility.Collapsed;
            BackIcon_textblock.Visibility = Visibility.Collapsed;
            ForwardIcon_textblock.Visibility = Visibility.Collapsed;
            IsHiddenButtonClick = false;
        }

        private void hidden_menu_Click(object sender, RoutedEventArgs e)
        {
            IsHiddenButtonClick = true;
            main_AppBar.Visibility = Visibility.Collapsed;
            setting_button.Visibility = Visibility.Visible;
            if (ListPlay_bool||RandomPlay_bool)
            {
                BackIcon_textblock.Visibility = Visibility.Visible;
                ForwardIcon_textblock.Visibility = Visibility.Visible;
            }           
        }

        private void main_storyBoard_Completed(object sender, object e)
        {
            forward_button.Foreground = black;
            back_button.Foreground = black;
            StoryBoardBegin();
            main_storyBoard2.Stop();

        }

        private void main_storyBoard2_Completed(object sender, object e)
        {
            StoryBoardBegin();
            main_storyBoard.Stop();
        }
        private void StoryBoardBegin()
        {
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
            play_button.Foreground = skyblue;          
            main_mediaElement.Play();
            main_slider.Maximum = main_mediaElement.NaturalDuration.TimeSpan.TotalSeconds;            
        }


        private void forward_button_Click(object sender, RoutedEventArgs e)
        {
            forward_button.Foreground = skyblue;
            play_button.Foreground = black;
            stop_button.Foreground = black;
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE768";
            IsBackButtonClick = false;
            if (ListPlay_bool)
            {
                List_Source();
            }
            else if (RandomPlay_bool)
            {
                Random_Source();
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            back_button.Foreground = skyblue;
            play_button.Foreground = black;
            stop_button.Foreground = black;
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE768";
            IsBackButtonClick = true;
            if (ListPlay_bool)
            {
                List_Source();
            }
            else if (RandomPlay_bool)
            {
                Random_Source();
            }

        }

        private void setting_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            setting_button.Opacity = 1;
        }

        private void setting_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            setting_button.Opacity = 0.1;
        }


        private void item_1_Click(object sender, RoutedEventArgs e)
        {
            SingleCycle_bool = true;
            ListPlay_bool = false;
            RandomPlay_bool = false;
            model_button.Content = "单曲循环";
            back_button.IsEnabled = false;
            forward_button.IsEnabled = false;
            BackIcon_textblock.Visibility = Visibility.Collapsed;
            ForwardIcon_textblock.Visibility = Visibility.Collapsed;
        }

        private void item_2_Click(object sender, RoutedEventArgs e)
        {
            ListPlay_bool = true;
            SingleCycle_bool = false;
            RandomPlay_bool = false;
            model_button.Content = "顺序播放";
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
            if (IsHiddenButtonClick)
            {
                BackIcon_textblock.Visibility = Visibility.Visible;
                ForwardIcon_textblock.Visibility = Visibility.Visible;
            }
        }

        private void item_3_Click(object sender, RoutedEventArgs e)
        {
            RandomPlay_bool = true;
            SingleCycle_bool = false;
            ListPlay_bool = false;       
            model_button.Content = "随机播放";
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
            if (IsHiddenButtonClick)
            {
                BackIcon_textblock.Visibility = Visibility.Visible;
                ForwardIcon_textblock.Visibility = Visibility.Visible;
            }
        }

        private void item_4_Click(object sender, RoutedEventArgs e)
        {
            SingleCycle_bool = false;
            ListPlay_bool = false;
            RandomPlay_bool = false;
            model_button.Content = "播放模式";
            back_button.IsEnabled = false;
            forward_button.IsEnabled = false;
            BackIcon_textblock.Visibility = Visibility.Collapsed;
            ForwardIcon_textblock.Visibility = Visibility.Collapsed;
        }

        private void BackIcon_textblock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
            IsBackButtonClick = true;
            if (ListPlay_bool)
            {
                List_Source();
            }
            else if (RandomPlay_bool)
            {
                Random_Source();
            }
        }

        private void ForwardIcon_textblock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
            IsBackButtonClick = false;
            if (ListPlay_bool)
            {
                List_Source();
            }
            else if (RandomPlay_bool)
            {
                Random_Source();
            }
        }

        private async void about_menu_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog content = new ContentDialog
            {
                Title = "用户知悉",
                Content = "纯免费软件,无广告,\n个人用户可以随时下载和安装使用,\n严禁用于商业用途。" +
                "\n(自动获取的本地音乐文件，为PC音乐文件夹中的音乐文件。)",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
            };
            ContentDialogResult result = await content.ShowAsync();
        }

        private void model_button_Click(object sender, RoutedEventArgs e)
        {
            model_flyout.Hide();
        }

        private void setting_Button_Click_1(object sender, RoutedEventArgs e)
        {
            menu_flyout.Hide();
        }

        private void model_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            model_button.Opacity = 1;
        }

        private void model_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            model_button.Opacity = 0.3;
        }

        private void main_listview_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            main_listview.Background = white;
        }

        private void main_listview_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            main_listview.Background = transParent;
        }

        private void BackIcon_textblock_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            BackIcon_textblock.Foreground = hotPink;
        }

        private void BackIcon_textblock_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            BackIcon_textblock.Foreground = aliceBlue;
        }

        private void ForwardIcon_textblock_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ForwardIcon_textblock.Foreground = hotPink;
        }

        private void ForwardIcon_textblock_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ForwardIcon_textblock.Foreground = aliceBlue;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ellipse_scrollViewer.Height = this.Height;
        }
    }
}

