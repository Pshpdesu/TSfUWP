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
using Windows.UI.Xaml.Media.Animation;
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
            var brush = new SolidColorBrush();
            brush.Color = new Windows.UI.Color() { A = 180 };

            grid.Background = brush;
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
            //typedSender.
            isPicSmaller = typedSender.ZoomFactor <= 1;
            //isPicSmaller = (img.Height <= sv.ActualHeight) || (img.Width<= sv.ActualWidth);

        }

        private void ScrollViewer_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {

        }

        private void ScrollViewer_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            //if ((Math.Abs(e.Cumulative.Translation.X) < 100) || (Math.Abs(e.Cumulative.Translation.Y) < 100))
            img.Transform3D = null;
            (this.Parent as UIElement).Transform3D = null;
            manipstarted = false;
            img.Opacity = 1.0;
        }

        private void ScrollViewer_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var sv = sender as ScrollViewer;
            bool isIntertial = e.IsInertial;
            if (isPicSmaller && manipstarted)
            {
                var test = new CompositeTransform3D();
                test.TranslateX = e.Cumulative.Translation.X;
                test.TranslateY = e.Cumulative.Translation.Y;
                test.CenterX = img.ActualWidth / 2;
                test.CenterY = img.ActualHeight / 2;
                test.RotationZ = e.Cumulative.Translation.X / 50.0;
                //test.RotationZ = e.Cumulative.Translation.Y;

                img.Transform3D = test;
                var visibility = new Vector3((float)test.TranslateX, (float)test.TranslateY, 0);
                var normalizedLength = visibility.Length() / 500.0;
                img.Opacity = 1.0 - (Math.Pow(normalizedLength, 2) - normalizedLength);
            }
            else
            {

                var newManip = e;

            }
            if (true)
            {
                var totalTransition = new Vector3((float)e.Cumulative.Translation.X, (float)e.Cumulative.Translation.Y, 0);
                if (totalTransition.Length() > 0)
                {
                    var parent = this.Parent as Grid;
                    parent.Transform3D = img.Transform3D;
                }

            }

            //sv.TranslationTransition = new Vector3Transition() { Components = e.Cumulative.Translation };
        }
    }
}
