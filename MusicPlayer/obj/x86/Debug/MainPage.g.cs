﻿#pragma checksum "C:\Users\singhwong\Source\Repos\UWP-Music-Player\MusicPlayer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6BB24E64A0C801AB4EE28AF85596CFEF"
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
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj21_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::MusicPlayer.Models.Music dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj21;
            private global::Windows.UI.Xaml.Controls.Image obj22;
            private global::Windows.UI.Xaml.Controls.TextBlock obj23;
            private global::Windows.UI.Xaml.Controls.TextBlock obj24;

            public MainPage_obj21_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 21: // MainPage.xaml line 141
                        this.obj21 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 22: // MainPage.xaml line 142
                        this.obj22 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 23: // MainPage.xaml line 147
                        this.obj23 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 24: // MainPage.xaml line 155
                        this.obj24 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj21.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::MusicPlayer.Models.Music) item, 1 << phase);
            }

            public void Recycle()
            {
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
                    this.dataRoot = (global::MusicPlayer.Models.Music)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MusicPlayer.Models.Music obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Cover(obj.Cover, phase);
                        this.Update_Title(obj.Title, phase);
                        this.Update_Artist(obj.Artist, phase);
                    }
                }
            }
            private void Update_Cover(global::Windows.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 142
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj22, obj, null);
                }
            }
            private void Update_Title(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 147
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj23, obj, null);
                }
            }
            private void Update_Artist(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 155
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj24, obj, null);
                }
            }
        }

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
            private global::Windows.UI.Xaml.Controls.ListView obj7;

            public MainPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // MainPage.xaml line 130
                        this.obj7 = (global::Windows.UI.Xaml.Controls.ListView)target;
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
                    // MainPage.xaml line 130
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj7, obj, null);
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
            case 2: // MainPage.xaml line 14
                {
                    this.main_storyBoard = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                    ((global::Windows.UI.Xaml.Media.Animation.Storyboard)this.main_storyBoard).Completed += this.main_storyBoard_Completed;
                }
                break;
            case 3: // MainPage.xaml line 24
                {
                    this.main_storyBoard2 = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                    ((global::Windows.UI.Xaml.Media.Animation.Storyboard)this.main_storyBoard2).Completed += this.main_storyBoard2_Completed;
                }
                break;
            case 4: // MainPage.xaml line 34
                {
                    this.main_grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // MainPage.xaml line 87
                {
                    this.main_progressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 6: // MainPage.xaml line 95
                {
                    this.main_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7: // MainPage.xaml line 130
                {
                    this.main_listview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.main_listview).ItemClick += this.main_listview_ItemClick;
                }
                break;
            case 8: // MainPage.xaml line 164
                {
                    this.status_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // MainPage.xaml line 171
                {
                    this.ellipse_Grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 10: // MainPage.xaml line 224
                {
                    this.main_mediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 11: // MainPage.xaml line 226
                {
                    this.songTile_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // MainPage.xaml line 254
                {
                    this.setting_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_button).PointerEntered += this.setting_button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_button).PointerExited += this.setting_button_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.Button)this.setting_button).Click += this.setting_button_Click;
                }
                break;
            case 13: // MainPage.xaml line 267
                {
                    this.main_progressbar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 14: // MainPage.xaml line 271
                {
                    this.main_progressbar2 = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 15: // MainPage.xaml line 240
                {
                    this.main_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.main_slider).ValueChanged += this.main_slider_ValueChanged;
                }
                break;
            case 16: // MainPage.xaml line 247
                {
                    this.playTime_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // MainPage.xaml line 184
                {
                    this.BackIcon_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.BackIcon_textblock).Tapped += this.BackIcon_textblock_Tapped;
                }
                break;
            case 18: // MainPage.xaml line 191
                {
                    this.main_ellipse = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                }
                break;
            case 19: // MainPage.xaml line 213
                {
                    this.ForwardIcon_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.ForwardIcon_textblock).Tapped += this.ForwardIcon_textblock_Tapped;
                }
                break;
            case 20: // MainPage.xaml line 200
                {
                    this.story_board = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 25: // MainPage.xaml line 98
                {
                    this.Title_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // MainPage.xaml line 103
                {
                    this.model_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 27: // MainPage.xaml line 113
                {
                    this.model_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 28: // MainPage.xaml line 114
                {
                    this.item_1 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_1).Click += this.item_1_Click;
                }
                break;
            case 29: // MainPage.xaml line 117
                {
                    this.item_2 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_2).Click += this.item_2_Click;
                }
                break;
            case 30: // MainPage.xaml line 120
                {
                    this.item_3 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_3).Click += this.item_3_Click;
                }
                break;
            case 31: // MainPage.xaml line 123
                {
                    this.item_4 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.item_4).Click += this.item_4_Click;
                }
                break;
            case 32: // MainPage.xaml line 285
                {
                    this.main_commanBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 33: // MainPage.xaml line 289
                {
                    this.back_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.back_button).Click += this.back_button_Click;
                }
                break;
            case 34: // MainPage.xaml line 293
                {
                    this.play_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.play_button).Click += this.play_button_Click;
                }
                break;
            case 35: // MainPage.xaml line 297
                {
                    this.forward_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.forward_button).Click += this.forward_button_Click;
                }
                break;
            case 36: // MainPage.xaml line 305
                {
                    this.stop_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.stop_button).Click += this.stop_button_Click;
                }
                break;
            case 37: // MainPage.xaml line 309
                {
                    this.add_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.add_button).Click += this.add_button_Click;
                }
                break;
            case 38: // MainPage.xaml line 313
                {
                    this.volume = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.volume).Click += this.volume_Click;
                }
                break;
            case 39: // MainPage.xaml line 348
                {
                    this.display_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.display_button).Click += this.display_button_Click;
                }
                break;
            case 40: // MainPage.xaml line 352
                {
                    this.settign = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.settign).Click += this.settign_Click;
                }
                break;
            case 41: // MainPage.xaml line 357
                {
                    this.menu_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 42: // MainPage.xaml line 358
                {
                    this.background_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.background_menu).Click += this.background_menu_Click;
                }
                break;
            case 43: // MainPage.xaml line 373
                {
                    this.hidden_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.hidden_menu).Click += this.hidden_menu_Click;
                }
                break;
            case 44: // MainPage.xaml line 377
                {
                    this.about_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.about_menu).Click += this.about_menu_Click;
                }
                break;
            case 45: // MainPage.xaml line 364
                {
                    this.Yes_item = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Yes_item).Click += this.Yes_item_Click;
                }
                break;
            case 46: // MainPage.xaml line 368
                {
                    this.No_item = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.No_item).Click += this.No_item_Click;
                }
                break;
            case 47: // MainPage.xaml line 318
                {
                    this.volume_flyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 48: // MainPage.xaml line 319
                {
                    this.volume_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 49: // MainPage.xaml line 323
                {
                    this.volumeIcon_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.volumeIcon_textblock).Tapped += this.volumeIcon_textblock_Tapped;
                }
                break;
            case 50: // MainPage.xaml line 329
                {
                    this.volume_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.volume_slider).ValueChanged += this.volume_slider_ValueChanged;
                }
                break;
            case 51: // MainPage.xaml line 336
                {
                    this.volume_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 21: // MainPage.xaml line 141
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element21 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    MainPage_obj21_Bindings bindings = new MainPage_obj21_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element21.DataContext);
                    element21.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element21, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element21, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

