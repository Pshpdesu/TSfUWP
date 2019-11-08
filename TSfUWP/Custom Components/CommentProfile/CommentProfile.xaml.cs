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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.CommentProfile
{
    public sealed partial class CommentProfile : UserControl
    {
        public DependencyProperty OverlayBrushProperty =
            DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(CommentProfile), null);

        CommentProfileViewModel viewModel { get; set; }

        public Brush OverlayBrush
        {
            get { return (Brush)GetValue(OverlayBrushProperty); }
            set { SetValue(OverlayBrushProperty, value); }
        }

        public CommentProfile()
        {
            this.InitializeComponent();
            viewModel.userProfile = UserProfile.GetRandomProfile();
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
