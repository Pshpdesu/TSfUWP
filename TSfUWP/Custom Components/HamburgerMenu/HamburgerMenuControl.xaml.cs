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
        ObservableCollection<MenuItem> MenuItems { get; set; } = new ObservableCollection<MenuItem>();
        ObservableCollection<MenuItem> BottomMenuItems { get; set; } = new ObservableCollection<MenuItem>();

        public HamburgerMenuControl(IEnumerable<MenuItem> commands) : this()
        {
            MenuItems = new ObservableCollection<MenuItem>(commands);
        }

        public HamburgerMenuControl()
        {
            this.InitializeComponent();
            SetLeft();
            this.Resources.TryGetValue("HamburgerMenuItem_LeftSide", out var test);
            var test2 = this.Resources.ToDictionary((value) => value.Key);

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
                    await Task.Run(() => SetRight());
                    break;
                case SplitViewPanePlacement.Left:
                    await Task.Run(() => SetRight());
                    break;
            }
        }

        public async void SetMenuItems(IEnumerable<MenuItem> commands)
        {
            await Task.Run(() =>
            MenuItems = new ObservableCollection<MenuItem>(commands));
            //MenuItems = new ObservableCollection<MenuItem>(commands);
        }

        private void SetRight()
        {
            this.HamburgerView.PanePlacement = SplitViewPanePlacement.Right;
            this.Resources.TryGetValue("HamburgerMenuItem_RightSide", out var template);
            this.MenuItemsList.ItemTemplate = template as DataTemplate;
            this.MenuItemsList.HorizontalAlignment = HorizontalAlignment.Right;
            this.BottomMenuItemsList.ItemTemplate = template as DataTemplate;
            this.BottomMenuItemsList.HorizontalAlignment = HorizontalAlignment.Right;
        }
        private void SetLeft()
        {
            this.HamburgerView.PanePlacement = SplitViewPanePlacement.Left;
            this.Resources.TryGetValue("HamburgerMenuItem_LeftSide", out var template);
            this.MenuItemsList.ItemTemplate = template as DataTemplate;
            this.MenuItemsList.HorizontalAlignment = HorizontalAlignment.Left;
            this.BottomMenuItemsList.ItemTemplate = template as DataTemplate;
            this.BottomMenuItemsList.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.HamburgerView.IsPaneOpen = !this.HamburgerView.IsPaneOpen;
        }
    }
}
