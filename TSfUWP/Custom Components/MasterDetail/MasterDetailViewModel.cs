using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomComponents.MasterDetail
{
    public class MasterDetailViewModel : NotifyingClass
    {
        public MasterDetailViewModel(SplitViewPanePlacement panelPlacement=SplitViewPanePlacement.Left, UIElement master=null, 
            UIElement details=null, double masterWidth=248d)
        {
            this.panelPlacement = panelPlacement;
            this.master = master;
            this.details = details;
            this.masterWidth = masterWidth;
        }

        private SplitViewPanePlacement panelPlacement;
        public SplitViewPanePlacement PanePlacement
        {
            get => panelPlacement;
            set { panelPlacement = value; OnPropertyChanged(); }
        }

        private UIElement master;
        public UIElement Master
        {
            get => Master;
            set { Master = value; OnPropertyChanged(); }
        }

        private UIElement details;
        public UIElement Details
        {
            get => details;
            set { details = value; OnPropertyChanged(); }
        }

        private double masterWidth;
        public double MasterWidth
        {
            get => masterWidth;
            set { masterWidth = value; OnPropertyChanged(); }
        }
    }
}
