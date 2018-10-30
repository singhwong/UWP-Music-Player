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
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
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
        private Music main_music = new Music();
        private Music local_music;

        private bool RandomPlay_bool = false;
        private bool ListPlay_bool = false;
        private bool SingleCycle_bool = false;
        private bool IsBackButtonClick = false;
        private bool IsMusicPlaying = false;
        private bool IsMusicListAutoShow = true;
        private string source_path;
        private string image_source_path;
        private SolidColorBrush skyblue = new SolidColorBrush(Colors.SkyBlue);
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);

        private ApplicationDataContainer local_volume = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_backGround = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_musicPath = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_allTime = ApplicationData.Current.LocalSettings;
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
        private int num = 1;
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        private SolidColorBrush transParent = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush hotPink = new SolidColorBrush(Colors.HotPink);
        private SolidColorBrush lightPink = new SolidColorBrush(Colors.LightPink);
        private AcrylicBrush myBrush = new AcrylicBrush();
        string local_allTimeStr;
        private SystemMediaTransportControls systemMedia_TransportControls = SystemMediaTransportControls.GetForCurrentView();
        public MainPage()
        {
            this.InitializeComponent();
            ExtendAcrylicIntoTitleBar();
            use_music = new ObservableCollection<Music>();
            allMusic = new ObservableCollection<StorageFile>();
            //this.PreviewKeyDown
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            if (source_path != null)
            {
                stop_button.Foreground = white;
                if (IsMusicPlaying == false)
                {
                    main_mediaElement.AutoPlay = true;
                    main_mediaElement.Play();
                    play_button.Foreground = skyblue;

                    play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    play_button.Content = "\uE769";
                    IsMusicPlaying = true;
                }
                else
                {
                    main_mediaElement.Pause();
                    play_button.Foreground = white;
                    play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    play_button.Content = "\uE768";
                    IsMusicPlaying = false;
                }
            }
        }

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE768";
            IsMusicPlaying = false;
            play_button.Foreground = white;
            stop_button.Foreground = skyblue;
            main_mediaElement.Stop();
            //status_textblock.Text = "";
        }

        private void main_slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

            SetAllTimeMethod();

            if (main_slider.Value == main_slider.Maximum)
            {
                
                
                //play_button.Foreground = black;
                //play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                //play_button.Content = "\uE768";
                if (SingleCycle_bool)
                {
                    Single_Cycle();
                }
                else if (ListPlay_bool)
                {
                    try
                    {
                        local_music.ForeColor = transParent;
                    }
                    catch
                    {                       
                    }
                    main_music.ForeColor = transParent;
                    List_Source();
                }
                else if (RandomPlay_bool)
                {
                    try
                    {
                        local_music.ForeColor = transParent;
                    }
                    catch
                    {                      
                    }
                    main_music.ForeColor = transParent;
                    Random_Source();
                }
                else
                {
                    IsMusicPlaying = false;
                }
                local_musicPath.Values["music_path"] = source_path;

            }
        }
        private void SetAllTimeMethod()
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
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
        }
        private void Random_Source()
        {
            Random rm = new Random();
            int index = rm.Next(0, allsong_count);
            main_music = use_music[index];

            source_path = main_music.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            //BitmapImage album_cover = new BitmapImage();
            Album_Cover = main_music.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = "演唱者:   " + main_music.Artist;
            album_textblock.Text = "专辑:   " + main_music.album_title;
            bottomTitle_textblock.Text = songTile_textblock.Text;
            //main_storyBoard.Begin();

            main_music.ForeColor = skyblue;

            //play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            //play_button.Content = "\uE769";
            //play_button.Foreground = skyblue;

        }
        private void List_Source()
        {
            var list_music = SetMusicById.GetIDByPathSource(use_music, source_path);
            int index = list_music.id;
            if (IsBackButtonClick)
            {
                num = index - 1;
                IsBackButtonClick = false;
            }
            else
            {
                num = index + 1;
            }
            if (num == use_music.Count + 1)
            {
                num = 1;
            }
            else if (num == 0)
            {
                num = use_music.Count;
            }
            main_music = use_music[num - 1];
            source_path = main_music.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            Album_Cover = main_music.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = "演唱者:   " + main_music.Artist;
            album_textblock.Text = "专辑:   " + main_music.album_title;
            bottomTitle_textblock.Text = songTile_textblock.Text;

            main_music.ForeColor = skyblue;

            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
            play_button.Foreground = skyblue;


        }
        private void Single_Cycle()
        {
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);
            //try
            //{
            //    local_music.ForeColor = skyblue;
            //}
            //catch
            //{
            //    main_music.ForeColor = skyblue;
            //}
            
        }
        private async void add_button_Click(object sender, RoutedEventArgs e)
        {
            main_mediaElement.AutoPlay = false;
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
                    BitmapImage add_AlbumCover = new BitmapImage();//重新实例化，不然会出现专辑封面显示错乱bug
                    add_AlbumCover.SetSource(current_Thumb);
                    bottom_image.Source = add_AlbumCover;
                    imageBrush_ellipse.ImageSource = add_AlbumCover;
                    #endregion                   
                    main_ellipse.Fill = imageBrush_ellipse;
                }
                try
                {
                    local_music.ForeColor = transParent;
                }
                catch
                {
                }
                main_music.ForeColor = transParent;
            }
            localFolder = ApplicationData.Current.LocalFolder;
            try
            {

                MusicProperties song_Properties = await media_file.Properties.GetMusicPropertiesAsync();
                fileCopy = await media_file.CopyAsync(localFolder, media_file.Name, NameCollisionOption.ReplaceExisting);
                source_path = media_file.Name;
                songTile_textblock.Text = song_Properties.Title;
                artist_textblock.Text = "演唱者:   " + song_Properties.Artist;
                album_textblock.Text = "专辑:   " + song_Properties.Album;
                bottomTitle_textblock.Text = songTile_textblock.Text;
                main_mediaElement.Source = new Uri("ms-appdata:///local/" + source_path);
                play_button.Foreground = white;
                play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                play_button.Content = "\uE768";
                IsMusicPlaying = false;
            }
            catch
            {
            }
           
            //local_musicPath.Values["music_path"] = source_path;
            //local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
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
        //初始化Load
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            systemMedia_TransportControls.IsPlayEnabled = true;
            systemMedia_TransportControls.IsPauseEnabled = true;
            systemMedia_TransportControls.IsPreviousEnabled = true;
            systemMedia_TransportControls.IsNextEnabled = true;
            systemMedia_TransportControls.ButtonPressed += SystemControls_ButtonPressed;
            play_button.IsEnabled = false;
            add_button.IsEnabled = false;

            if (Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported())
            {
                this.feedback_menu.Visibility = Visibility.Visible;
            }//确定设备是否显示反馈按钮

            SetAcrylic();
            ListPlay_bool = true;
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
            main_progressRing.IsActive = true;
            GetLocalMusic();//获取本地音乐文件ListView
            main_progressRing.IsActive = false;
            main_progressRing.Visibility = Visibility.Collapsed;
            playTime_textblock.Text = "00:00/00:00";
            try
            {
                backGround_path = local_backGround.Values["backGround_image"].ToString();
                imageBrush.ImageSource = new BitmapImage(new Uri(backGround_path));
            }
            catch
            {
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/rain.jpg", UriKind.Absolute));
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

        private void SetAcrylic()
        {
            #region 设置亚克力背景
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
            {

                myBrush.BackgroundSource = AcrylicBackgroundSource.HostBackdrop;
                myBrush.TintColor = Colors.WhiteSmoke;
                myBrush.FallbackColor = Colors.WhiteSmoke;
                myBrush.TintOpacity = 0.3;
                main_AppBar.Background = myBrush;
            }
            else
            {
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(100, 20, 24, 37));
                main_AppBar.Background = myBrush;
            }
            #endregion
        }

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
                music.ForeColor = transParent;
                music.str = song_Properties.Genre.ToString();//当前对象字符串
                music.album_title = song_Properties.Album;
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
            main_mediaElement.AutoPlay = false;
            GetHistoryMusic();
            play_button.IsEnabled = true;
            add_button.IsEnabled = true;
            main_listview.IsItemClickEnabled = true;

        }

        private void main_listview_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                main_mediaElement.AutoPlay = true;
                local_music.ForeColor = transParent;
            }
            catch
            {
            }
            main_music.ForeColor = transParent;
            main_music = (Music)e.ClickedItem;
            source_path = main_music.Music_Path;
            main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + source_path);

            //BitmapImage album_cover = new BitmapImage();
            Album_Cover = main_music.Cover;
            imageBrush_ellipse.ImageSource = Album_Cover;
            main_ellipse.Fill = imageBrush_ellipse;
            bottom_image.Source = Album_Cover;

            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = "演唱者:   " + main_music.Artist;
            album_textblock.Text = "专辑:   " + main_music.album_title;
            bottomTitle_textblock.Text = songTile_textblock.Text;
            play_button.Foreground = white;
            IsMusicPlaying = true;
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";

            main_music.ForeColor = skyblue;

            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";
            play_button.Foreground = skyblue;

            local_musicPath.Values["music_path"] = source_path;
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
        }

        private void forward_button_Click(object sender, RoutedEventArgs e)
        {
            IsBackButtonClick = false;
            SwitchMusic();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            IsBackButtonClick = true;
            SwitchMusic();

        }

        private void SwitchMusic()
        {
            try
            {
                local_music.ForeColor = transParent;
                main_mediaElement.AutoPlay = true;
            }
            catch
            {
            }
            main_music.ForeColor = transParent;
            stop_button.Foreground = white;
            play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            play_button.Content = "\uE769";

            if (ListPlay_bool)
            {
                List_Source();
            }
            else if (RandomPlay_bool)
            {
                Random_Source();
            }
            local_musicPath.Values["music_path"] = source_path;
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;

        }
        private void item_1_Click(object sender, RoutedEventArgs e)
        {
            SingleCycle_bool = true;
            ListPlay_bool = false;
            RandomPlay_bool = false;
            model_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            model_button.Content = "\uE8ED";
            back_button.IsEnabled = false;
            forward_button.IsEnabled = false;
        }

        private void item_2_Click(object sender, RoutedEventArgs e)
        {
            ListPlay_bool = true;
            SingleCycle_bool = false;
            RandomPlay_bool = false;
            model_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            model_button.Content = "\uE777";
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
        }

        private void item_3_Click(object sender, RoutedEventArgs e)
        {
            RandomPlay_bool = true;
            SingleCycle_bool = false;
            ListPlay_bool = false;
            model_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
            model_button.Content = "\uE8B1";
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
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

        private void main_listview_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (IsMusicListAutoShow)
            {
                main_listview.Background = myBrush;
            }        
        }

        private void main_listview_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (IsMusicListAutoShow)
            {
                main_listview.Background = transParent;
            }          
        }
        private async void SystemControls_ButtonPressed(SystemMediaTransportControls sender,
    SystemMediaTransportControlsButtonPressedEventArgs args)
        {

            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        main_mediaElement.AutoPlay = true;
                        main_mediaElement.Play();
                        play_button.Foreground = skyblue;
                        play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                        play_button.Content = "\uE769";
                        stop_button.Foreground = white;
                        IsMusicPlaying = true;
                    });
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        main_mediaElement.Pause();
                        play_button.Foreground = white;
                        play_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                        play_button.Content = "\uE768";
                        IsMusicPlaying = false;
                    });
                    break;
                case SystemMediaTransportControlsButton.Previous:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        IsBackButtonClick = true;
                        SwitchMusic();
                    });
                    break;
                case SystemMediaTransportControlsButton.Next:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        IsBackButtonClick = false;
                        SwitchMusic();
                    });
                    break;
                default:
                    break;
            }
        }

        private void main_mediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            switch (main_mediaElement.CurrentState)
            {
                case MediaElementState.Playing:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                    main_slider.Maximum = main_mediaElement.NaturalDuration.TimeSpan.TotalSeconds;//有了此段代码，可以删除storyBoard控件了
                    break;
                case MediaElementState.Paused:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                case MediaElementState.Stopped:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                default:
                    break;
            }
        }

        private void GetHistoryMusic()
        {
            try
            {
                source_path = local_musicPath.Values["music_path"].ToString();
                local_allTimeStr = local_allTime.Values["allTime"].ToString();
                local_music = SetMusicById.GetIDByPathSource(use_music, source_path);
                main_mediaElement.Source = new Uri(this.BaseUri, "ms-appdata:///local/" + local_music.Music_Path);

                Album_Cover = local_music.Cover;
                imageBrush_ellipse.ImageSource = Album_Cover;
                main_ellipse.Fill = imageBrush_ellipse;
                bottom_image.Source = Album_Cover;

                songTile_textblock.Text = local_music.Title;
                artist_textblock.Text = "演唱者:   " + local_music.Artist;
                album_textblock.Text = "专辑:   " + local_music.album_title;
                bottomTitle_textblock.Text = songTile_textblock.Text;

                playTime_textblock.Text = "00:00" + "/" + local_allTimeStr;
                local_music.ForeColor = skyblue;
            }
            catch
            {
            }
        }
        private void back_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            back_button.Background = hotPink;
        }

        private void back_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            back_button.Background = lightPink;
        }

        private void play_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            play_button.Background = hotPink;
        }

        private void play_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            play_button.Background = lightPink;
        }

        private void forward_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            forward_button.Background = hotPink;
        }

        private void forward_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            forward_button.Background = lightPink;
        }

        private void stop_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            stop_button.Background = hotPink;
        }

        private void stop_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            stop_button.Background = lightPink;
        }

        private void model_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            model_button.Background = hotPink;
        }

        private void model_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            model_button.Background = lightPink;
        }

        private void add_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            add_button.Background = hotPink;
        }

        private void add_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            add_button.Background = lightPink;
        }

        private void volume_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            volume.Background = hotPink;
        }

        private void volume_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            volume.Background = lightPink;
        }

        private void display_button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            display_button.Background = hotPink;
        }

        private void display_button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            display_button.Background = lightPink;
        }

        private void setting_Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            setting_Button.Background = hotPink;
        }

        private void setting_Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            setting_Button.Background = lightPink;
        }

        private void txt_Nombre_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                ApplicationView view = ApplicationView.GetForCurrentView();
                bool isInFullScreenMode = view.IsFullScreenMode;
                if (isInFullScreenMode)
                {

                    view.ExitFullScreenMode();
                    display_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                    display_button.Content = "\uE740";
                }
                //else
                //{
                //    view.TryEnterFullScreenMode();
                //    display_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
                //    display_button.Content = "\uE73F";
                //}
            }
        }

        private void Auto_item_Click(object sender, RoutedEventArgs e)
        {
            IsMusicListAutoShow = true;
        }

        private void true_item_Click(object sender, RoutedEventArgs e)
        {
            IsMusicListAutoShow = false;
            main_listview.Background = myBrush;
        }

        private void false_item_Click(object sender, RoutedEventArgs e)
        {
            IsMusicListAutoShow = false;
            main_listview.Background = transParent;
        }

        private async void feedback_menu_Click(object sender, RoutedEventArgs e)
        {
            var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
            await launcher.LaunchAsync();
        }
        //private void MainPage_KeyDown(object sender, KeyRoutedEventArgs e)
        //{
        //    if (e.Key == VirtualKey.Escape)
        //    {
        //        ApplicationView view = ApplicationView.GetForCurrentView();
        //        bool isInFullScreenMode = view.IsFullScreenMode;
        //        if (isInFullScreenMode)
        //        {

        //            view.ExitFullScreenMode();
        //            display_button.FontFamily = new FontFamily("Segoe MDL2 Assets");
        //            display_button.Content = "\uE740";
        //        }              
        //    }
        //}
    }
}

