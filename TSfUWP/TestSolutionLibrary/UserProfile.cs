using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace TestSolutionLibrary
{
    public class UserProfile
    {
        public string Name { get; set; }
        public BitmapImage ProfilePicture { get; set; }
        //.....
        public UserProfile()
        {
        }
        public static UserProfile GetRandomProfile()
        {
            var res = new UserProfile();
            res.Name = String.Concat("Rand-", new Random().Next(0, 100));
            return res;
        }
        public static async Task<UserProfile> GetRandomProfileAsync()
        {
            var res = new UserProfile();
            res.Name = String.Concat("Rand-", new Random().Next(0, 100));
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///TestSolutionLibrary/Assets/Test.png"));
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                res.ProfilePicture.SetSource(stream);
            }
            return res;
        }
    }
}
