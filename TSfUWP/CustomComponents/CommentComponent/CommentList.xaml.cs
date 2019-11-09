using CustomComponents.CommentComponent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.CommentComponent
{
    public sealed partial class CommentList : UserControl
    {
        DependencyProperty commentListProp = 
            DependencyProperty.Register("Comments", typeof(IEnumerable<Comment>), typeof(CommentList), null);

        public ObservableCollection<Comment> ListOfMessages
        {
            get
            {
                return GetValue(commentListProp) as ObservableCollection<Comment>;
            }
            set
            {
                SetValue(commentListProp, 
                    value is IObservable<Comment> 
                    ? value 
                    : new ObservableCollection<Comment>(value));
            }
        }
        public CommentList()
        {
            this.InitializeComponent();
            ListOfMessages = new ObservableCollection<Comment>();
        }
    }
}
