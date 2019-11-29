using System;
using System.Collections.Generic;
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

namespace CustomComponents.MasterDetail
{
    public sealed partial class MasterDetailControl : UserControl, IMasterDetail
    {
        private MasterDetailViewModel ViewModel { get; set; } = new MasterDetailViewModel();

        public MasterDetailControl()
        {
            this.InitializeComponent();
        }


        public async Task SetMasterAsync(UIElement newMaster)
        {
            await Task.Run(() => { SetMaster(newMaster); });
        }

        public async Task SetDetailsAsync(UIElement newDetails)
        {
            await Task.Run(() => { SetDetails(newDetails)});
        }

        public void SetMaster(UIElement newMaster)
        {
            this.MasterDetailView.Pane = newMaster;
            ViewModel.Master = newMaster;
        }

        public void SetDetails(UIElement newDetails)
        {
            this.Detail.Child = newDetails;
            ViewModel.Details = newDetails;
        }
    }
}
