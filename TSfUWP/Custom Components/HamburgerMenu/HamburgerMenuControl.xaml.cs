using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
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
    [TemplateVisualState(Name ="LeftState", GroupName ="States")]
    [TemplateVisualState(Name ="RightState", GroupName ="States")]
    public sealed partial class HamburgerMenuControl : UserControl
    {
        ObservableCollection<MenuItem> MenuItems { get; set; }
            = new ObservableCollection<MenuItem>();
        ObservableCollection<MenuItem> BottomMenuItems { get; set; }
            = new ObservableCollection<MenuItem>();


        public HamburgerMenuControl(SplitViewPanePlacement placement = SplitViewPanePlacement.Left):this()
        {
            ChangeMenuSide(placement);
            
        }
        private HamburgerMenuControl()
        {
            this.InitializeComponent();
            MenuItemsList.ItemsSource = MenuItems;
            BottomMenuItemsList.ItemsSource = BottomMenuItems;
            //this.HamburgerView.Pane.Translation += new Vector3(0, 0, 32);
        }

        public void SetPage(Type page, object parameter)
        {
            if (parameter == null)
                parameter = new object();
            this.Page.Navigate(page, parameter);
        }

        public void SetPage(UIElement page)
        {
            this.Page.Content = page;
        }

        public void ChangeMenuSide(SplitViewPanePlacement placement)
        {
            switch (placement)
            {
                case SplitViewPanePlacement.Right:
                    SetRight();
                    break;
                case SplitViewPanePlacement.Left:
                    SetLeft();
                    break;
            }
        }

        public void SetMenuItems(IEnumerable<MenuItem> commands = null, IEnumerable<MenuItem> bottomCommands = null)
        {
            if (commands != null)
            {
                MenuItems.Clear();
                foreach (var command in commands)
                {
                    MenuItems.Add(command);
                }
            }
            if (bottomCommands != null)
            {
                BottomMenuItems.Clear();
                foreach (var command in bottomCommands)
                {
                    BottomMenuItems.Add(command);
                }
            }
        }

        public void SwitchPaneSide()
        {
            switch (HamburgerView.PanePlacement) {
                case SplitViewPanePlacement.Left:
                    this.SetRight();
                    break;
                case SplitViewPanePlacement.Right:
                    this.SetLeft();
                    break;
            }
        }
        private void SetRight()
        {
            var a = VisualStateManager.GoToState(this, "RightState", false);
        }
        private void SetLeft()
        {
            VisualStateManager.GoToState(this, "LeftState", false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.HamburgerView.IsPaneOpen = !this.HamburgerView.IsPaneOpen;
        }

        private void MenuItemsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as MenuItem;
            item.OnItemClick?.Invoke(sender, null);
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
