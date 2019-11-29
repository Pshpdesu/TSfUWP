using CustomComponents.AlbumView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestSolutionLibrary;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TSfUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Comment> comments { get; set; } = new ObservableCollection<Comment>();
        public Comment comment { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            comments = GenerateComments();
            comment = GenerateComments().First();
        }

        private ObservableCollection<Comment> GenerateComments()
        {
            var res = new LinkedList<Comment>();
            for (int i = 0; i < 100; i++)
            {
                res.AddLast(new Comment()
                {
                    UserProfile = UserProfile.GetRandomProfile(),
                    CommentBody = DateTime.Now.ToString() + ": Comment"
                });
            }
            return new ObservableCollection<Comment>(res);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private async void Button_ClickAsync2(object sender, RoutedEventArgs e)
        {
            var msgdlg = new Flyout();
            msgdlg.Content = new AlbumView();
            msgdlg.ShowMode = FlyoutShowMode.Standard;
            msgdlg.ShouldConstrainToRootBounds = true;
            //msgdlg.Placement = FlyoutPlacementMode.;
            msgdlg.ShowAt(this);
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var test = UserProfile.GetRandomProfile();
            //var flyout = new Popup()
            //{
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    ShouldConstrainToRootBounds = true,
            //    //Width = Window.Current.CoreWindow.Bounds.Width,
            //    //Height = Window.Current.CoreWindow.Bounds.Height,
            //    //IsLightDismissEnabled = true,
            //    Child = new AlbumView(),
            //    IsOpen = false,
            //};
            //Window.Current.Content
            var pop = new Popup();
            //pop.Height = Window.Current.Bounds.Height;
            //pop.Width= Window.Current.Bounds.Width;
            pop.VerticalAlignment = VerticalAlignment.Stretch;
            pop.HorizontalAlignment = HorizontalAlignment.Stretch;
            pop.Child = new AlbumView();
            //flyout.IsOpen = true;
            //await pop.ShowAsync();
            pop.IsLightDismissEnabled = true;
            pop.IsOpen = true;
        }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    //private async Task<Control> testControlCreation()
    //{
    //}
}
}
