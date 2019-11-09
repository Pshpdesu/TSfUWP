using TestSolutionLibrary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomComponents.CommentComponent
{
    public sealed partial class CommentItem : UserControl
    {

        DependencyProperty MessageProp = 
            DependencyProperty.Register("Message", typeof(Comment), typeof(CommentItem), null);

        public Comment Message
        {
            get
            {
                return (Comment)GetValue(MessageProp);
            }
            set
            {
                SetValue(MessageProp, value);
            }
        }

        public CommentItem()
        {
            this.InitializeComponent();
            Message = new Comment();
        }
    }
}
