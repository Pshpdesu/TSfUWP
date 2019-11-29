using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.HamburgerMenu
{
    public sealed partial class HamburgerMenuControl : UserControl
    {
        IObservable<MenuItem> MenuItems { get; set; }
        public HamburgerMenuControl(IObservable<MenuItem> commands):this()
        {
            MenuItems = commands;
        }

        public HamburgerMenuControl()
        {
            this.InitializeComponent();

        }

        public async Task SetPage(UIElement page)
        {
            await Task.Run(() => { this.Page.Child = page; });
        }
        public async Task ChangeMenuSide(SplitViewPanePlacement placement)
        {
            switch (placement)
            {
                case SplitViewPanePlacement.Right:
                    await Task.Run(()=>SetRight());
                    break;
                case SplitViewPanePlacement.Left:
                    await Task.Run(()=>SetRight());
                    break;
            }
        }
        private void SetRight()
        {
            this.HamburgerView.PanePlacement = SplitViewPanePlacement.Right;
            this.MenuItemsList.ItemTemplate = this.Resources["HamburgerMenuItem_LeftSide"] as DataTemplate;
            this.MenuItemsList.HorizontalAlignment = HorizontalAlignment.Right;
        }
        private void SetLeft()
        {
            this.HamburgerView.PanePlacement = SplitViewPanePlacement.Left;
            this.MenuItemsList.ItemTemplate = this.Resources["HamburgerMenuItem_RightSide"] as DataTemplate;
            this.MenuItemsList.HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
}
