using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutionLibrary;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CustomComponents.CommentProfile
{
    public class CommentProfileViewModel
    {
        public UserProfile userProfile { get; set; }

        public BitmapImage profilePic
        {
            get
            {
                if (userProfile.ProfilePicture.DecodePixelWidth > 0)
                {
                    return userProfile.ProfilePicture;
                }
                else
                {
                    var file =
                        StorageFile
                        .GetFileFromApplicationUriAsync(new Uri("ms-appx:///CustomComponents/Assets/Test.png"))
                        .GetResults();
                    using (var stream = file.OpenAsync(FileAccessMode.Read).GetResults())
                    {
                        var res = new BitmapImage();
                        res.SetSource(stream);
                        return res;
                    }
                }
            }
        }
    }
}
