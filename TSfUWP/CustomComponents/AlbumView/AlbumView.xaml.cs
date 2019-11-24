using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Media3D;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.AlbumView
{
    public sealed partial class AlbumView : UserControl
    {
        public AlbumView()
        {
            this.InitializeComponent();
        }

        bool manipstarted = false;
        bool isZoomed = false;
        bool isPicSmaller = false;

        private void ScrollViewer_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {
            var typedSender = sender as ScrollViewer;
            manipstarted = true;
            var curMode = e.Mode;
            //manipstarted = e.Mode == ManipulationModes.TranslateX;
            isPicSmaller = (img.ActualHeight <= sv.ActualHeight) || (img.ActualWidth <= sv.ActualWidth);
        }

        private void ScrollViewer_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {

        }

        private void ScrollViewer_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            //if ((Math.Abs(e.Cumulative.Translation.X) < 100) || (Math.Abs(e.Cumulative.Translation.Y) < 100))
                grid.Transform3D = null;
            manipstarted = false;
        }

        private void ScrollViewer_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            bool isIntertial = e.IsInertial;
            if (isPicSmaller && manipstarted)
            { 
                var test = new CompositeTransform3D();
                test.TranslateX = e.Cumulative.Translation.X;
                test.TranslateY = e.Cumulative.Translation.Y;
                grid.Transform3D = test;
                var visibility = new Vector3((float)test.TranslateX, (float)test.TranslateY,0);
                grid.Opacity = 100-visibility.Length();
            }

            //sv.TranslationTransition = new Vector3Transition() { Components = e.Cumulative.Translation };
        }
    }
}
