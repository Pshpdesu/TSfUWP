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
            for (int i = 0; i < 5; i++)
            {
                res.AddLast(new Comment()
                {
                    UserProfile = UserProfile.GetRandomProfile(),
                    CommentBody = DateTime.Now.ToString()+": Comment"
                });
            }
            return new ObservableCollection<Comment>(res);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var test = UserProfile.GetRandomProfile();
        }
    }
}
