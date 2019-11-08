using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AppClassesLibrary
{
    public class UserProfile
    {
        string Name { get; set; }
        char[] ProfilePicture { get; set; }
        //.....
        UserProfile()
        {
        }
        static async Task<UserProfile> GetRandomProfile()
        {
            var res = new UserProfile();
            res.Name = String.Concat("Rand-", new Random().Next(0,100));
            
            using (var stream = new StreamReader("/AppClassLibrary;Component/Assets/Test.png"))
            {
                var buf = new char[stream.BaseStream.Length];
                await stream.ReadAsync(buf, 0, Convert.ToInt32(stream.BaseStream.Length));
                res.ProfilePicture = buf;
            }
            return res;
        }
    }
}
