﻿#pragma checksum "C:\Users\wang\source\repos\UWP-Music-Player\MusicPlayer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3034D5EE1310E2E4EA66BBA01917510E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicPlayer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::MusicPlayer.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj5;

            public MainPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5: // MainPage.xaml line 69
                        this.obj5 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MusicPlayer.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MusicPlayer.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_use_music(obj.use_music, phase);
                    }
                }
            }
            private void Update_use_music(global::System.Collections.ObjectModel.ObservableCollection<global::MusicPlayer.Models.Music> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 69
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj5, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // MainPage.xaml line 26
                {
                    this.main_grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 56
                {
                    this.main_progressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 4: // MainPage.xaml line 64
                {
                    this.name_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 69
                {
                    this.main_listview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.main_listview).ItemClick += this.main_listview_ItemClick;
                }
                break;
            case 6: // MainPage.xaml line 84
                {
                    this.ellipse_scrollViewer = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 7: // MainPage.xaml line 145
                {
                    this.main_progressbar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 8: // MainPage.xaml line 147
                {
                    this.main_progressbar2 = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 9: // MainPage.xaml line 92
                {
                    this.musicDetails_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 10: // MainPage.xaml line 97
                {
                    this.main_ellipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 11: // MainPage.xaml line 119
                {
                    this.songTile_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // MainPage.xaml line 125
                {
                    this.artist_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // MainPage.xaml line 130
                {
                    this.album_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // MainPage.xaml line 135
                {
                    this.lyric_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // MainPage.xaml line 105
                {
                    this.story_board = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 17: // MainPage.xaml line 151
                {
                    this.main_AppBar = (global::Windows.UI.Xaml.Controls.AppBar)(target);
                }
                break;
            case 18: // MainPage.xaml line 169
                {
                    this.main_mediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                    ((global::Windows.UI.Xaml.Controls.MediaElement)this.main_mediaElement).CurrentStateChanged += this.main_mediaElement_CurrentStateChanged;
                }
                break;
            case 19: // MainPage.xaml line 250
                {
                    this.stop_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.stop_button).PointerEntered += this.stop_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.stop_button).PointerExited += this.stop_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.stop_button).Click += this.stop_button_Click;
                }
                break;
            case 20: // MainPage.xaml line 263
                {
                    this.model_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.model_button).PointerEntered += this.model_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.model_button).PointerExited += this.model_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.model_button).Click += this.model_button_Click;
                }
                break;
            case 21: // MainPage.xaml line 293
                {
                    this.add_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.add_button).PointerEntered += this.add_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.add_button).PointerExited += this.add_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.add_button).Click += this.add_button_Click;
                }
                break;
            case 22: // MainPage.xaml line 306
                {
                    this.volume = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.volume).PointerEntered += this.volume_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.volume).PointerExited += this.volume_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.volume).Click += this.volume_Click;
                }
                break;
            case 23: // MainPage.xaml line 347
                {
                    this.display_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.display_button).PointerEntered += this.display_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.display_button).PointerExited += this.display_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.display_button).Click += this.display_button_Click;
                }
                break;
            case 24: // MainPage.xaml line 360
                {
                    this.setting_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_Button).PointerEntered += this.setting_Button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_Button).PointerExited += this.setting_Button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_Button).Click += this.setting_Button_Click_1;
                }
                break;
            case 25: // MainPage.xaml line 374
                {
                    this.menu_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 26: // MainPage.xaml line 375
                {
                    this.background_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.background_menu).Click += this.background_menu_Click;
                }
                break;
            case 27: // MainPage.xaml line 405
                {
                    this.feedback_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.feedback_menu).Click += this.feedback_menu_Click;
                }
                break;
            case 28: // MainPage.xaml line 410
                {
                    this.about_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.about_menu).Click += this.about_menu_Click;
                }
                break;
            case 29: // MainPage.xaml line 396
                {
                    this.Yes_item = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Yes_item).Click += this.Yes_item_Click;
                }
                break;
            case 30: // MainPage.xaml line 400
                {
                    this.No_item = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.No_item).Click += this.No_item_Click;
                }
                break;
            case 31: // MainPage.xaml line 320
                {
                    this.volume_flyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 32: // MainPage.xaml line 321
                {
                    this.volume_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 33: // MainPage.xaml line 325
                {
                    this.volumeIcon_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.volumeIcon_textblock).Tapped += this.volumeIcon_textblock_Tapped;
                }
                break;
            case 34: // MainPage.xaml line 331
                {
                    this.volume_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.volume_slider).ValueChanged += this.volume_slider_ValueChanged;
                }
                break;
            case 35: // MainPage.xaml line 338
                {
                    this.volume_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 36: // MainPage.xaml line 277
                {
                    this.model_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 37: // MainPage.xaml line 278
                {
                    this.item_1 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_1).Click += this.item_1_Click;
                }
                break;
            case 38: // MainPage.xaml line 282
                {
                    this.item_2 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_2).Click += this.item_2_Click;
                }
                break;
            case 39: // MainPage.xaml line 286
                {
                    this.item_3 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_3).Click += this.item_3_Click;
                }
                break;
            case 40: // MainPage.xaml line 240
                {
                    this.main_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.main_slider).ValueChanged += this.main_slider_ValueChanged;
                }
                break;
            case 41: // MainPage.xaml line 230
                {
                    this.bottomTitle_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 42: // MainPage.xaml line 234
                {
                    this.playTime_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 43: // MainPage.xaml line 177
                {
                    this.bottom_image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 44: // MainPage.xaml line 182
                {
                    this.back_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.back_button).PointerEntered += this.back_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.back_button).PointerExited += this.back_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.back_button).Click += this.back_button_Click;
                }
                break;
            case 45: // MainPage.xaml line 195
                {
                    this.play_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.play_button).PointerEntered += this.play_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.play_button).PointerExited += this.play_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.play_button).Click += this.play_button_Click;
                }
                break;
            case 46: // MainPage.xaml line 208
                {
                    this.forward_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.forward_button).PointerEntered += this.forward_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.forward_button).PointerExited += this.forward_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.forward_button).Click += this.forward_button_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

