using CustomComponents.HamburgerMenu;
using CustomComponents.MasterDetail;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs ea)
        {
            base.OnNavigatedTo(ea);
            var hamburgerMenu = new HamburgerMenuControl();
            panel.Child = hamburgerMenu;
            //hamburgerMenu.HorizontalAlignment = HorizontalAlignment.Stretch;
            //hamburgerMenu.VerticalAlignment = VerticalAlignment.Stretch;
            List<MenuItem> commands = new List<MenuItem>()
            {
                new MenuItem(){
                    Icon =Symbol.Home,
                    ItemText = "Home",
                    OnItemClick = new MenuItem.onItemClick((e, v)=>{
                        hamburgerMenu.SetPage(new MasterDetailControl());
                    })
                },
                new MenuItem()
                {
                    Icon = Symbol.AlignLeft,
                    ItemText = "Test1",
                    OnItemClick = new MenuItem.onItemClick((e,v) =>
                    {
                        hamburgerMenu.SetPage(new TextBlock(){Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                                                                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                                                                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi 
                                                                            ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
                                                                            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                                                                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
                                                                            deserunt mollit anim id est laborum.",
                                                                            TextAlignment=TextAlignment.Center,
                                                                            HorizontalAlignment = HorizontalAlignment.Stretch,
                        });
                    })
                },
                new MenuItem()
                {
                    Icon = Symbol.AlignLeft,
                    ItemText = "Test2",
                    OnItemClick = new MenuItem.onItemClick((e,v)=>
                    {
                        hamburgerMenu.SetPage(new TextBlock(){Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                                                                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                                                                            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi 
                                                                            ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
                                                                            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                                                                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
                                                                            deserunt mollit anim id est laborum.",
                                                                            TextAlignment=TextAlignment.Right,
                                                                            HorizontalAlignment = HorizontalAlignment.Stretch
                        });
                    }),
                },
                new MenuItem()
                {
                    Icon = Symbol.DockLeft,
                    ItemText="Change Pane Alignment to Left",
                    OnItemClick = new MenuItem.onItemClick((e, v) =>
                    {
                        hamburgerMenu.ChangeMenuSide(SplitViewPanePlacement.Left);
                    })
                },
                new MenuItem()
                {
                    Icon = Symbol.DockRight,
                    ItemText="Change Pane Alignment to Right",
                    OnItemClick = new MenuItem.onItemClick((e, v) =>
                    {
                        hamburgerMenu.ChangeMenuSide(SplitViewPanePlacement.Right);
                    })
                }
            };
            List<MenuItem> bottomCommands = new List<MenuItem>() {
                new MenuItem()
                {
                    Icon = Symbol.SwitchApps,
                    ItemText = "Switch side",
                    OnItemClick = new MenuItem.onItemClick((e, v) =>
                    {
                        hamburgerMenu.SwitchPaneSide();
                    })
                }
            };
            hamburgerMenu.SetMenuItems(commands,bottomCommands);
        }
    }
}
