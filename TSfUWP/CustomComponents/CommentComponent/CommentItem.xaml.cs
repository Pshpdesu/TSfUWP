using TestSolutionLibrary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

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

        void SetUpComposition()
        {
            var compositor = ElementCompositionPreview.GetElementVisual(this.).Compositor;
            var spriteVisual = compositor.CreateSpriteVisual();
            spriteVisual.Size = this.grid.RenderSize.ToVector2();

            var dropShadow = compositor.CreateDropShadow();
            dropShadow.Mask = this.txtBlock.GetAlphaMask();
            dropShadow.Offset = new Vector3(10, 10, 0);
            spriteVisual.Shadow = dropShadow;

            ElementCompositionPreview.SetElementChildVisual(this.grid, spriteVisual);
        }
    }
}
