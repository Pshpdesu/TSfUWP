using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CustomComponents.HamburgerMenu
{
    public class MenuItem
    {
        public string ItemText { get; set; }
        public IconElement Icon { get; set; }
        public delegate Task onClick();
    }
}
