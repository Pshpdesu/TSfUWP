using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestSolutionLibrary;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.CommentComponent
{
    public sealed partial class CommentProfile : UserControl
    {
        public static readonly DependencyProperty OverlayBrushProperty =
            DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(CommentProfile), null);
        public static readonly DependencyProperty ProfileProperty =
            DependencyProperty.Register("Profile", typeof(UserProfile), typeof(CommentProfile), null);

        public UserProfile UserProfile
        {
            get { return GetValue(ProfileProperty) as UserProfile; }
            set { SetValue(ProfileProperty, value); }
        }

        public BitmapImage ProfilePic
        {
            get
            {
                if (!(UserProfile.ProfilePicture is null))
                {
                    return UserProfile.ProfilePicture;
                }
                else
                {
                    var file = Task.Run(async () =>
                        await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///CustomComponents/Assets/Test.png"))
                    );
                    var str = Task.Run(async () => await file.Result.OpenAsync(FileAccessMode.Read)).Result;
                    using (var stream = str)
                    {
                        var res = new BitmapImage();
                        res.SetSource(stream);
                        return res;
                    }
                }
            }
        }

        public Brush OverlayBrush
        {
            get { return (Brush)GetValue(OverlayBrushProperty); }
            set { SetValue(OverlayBrushProperty, value); }
        }

        public CommentProfile()
        {
            this.InitializeComponent();
            //Initializer = (async ()=> { this.viewModel.userProfile = await UserProfile.GetRandomProfile(); })();
        }

        public async Task<byte[]> GetDefaultProfilePicture()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///CustomComponents/Assets/Test.png"));
            using (var stream = await file.OpenStreamForReadAsync())
            {
                var buf = new byte[stream.Length];
                await stream.ReadAsync(buf, 0, Convert.ToInt32(stream.Length));
                return buf;
            }
        }
    }
}
