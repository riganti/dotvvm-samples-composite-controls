using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Thumbnails.Placeholder
{
    public class ThumbnailPlaceholder : DotvvmMarkupControl
    {

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }
        public static readonly DotvvmProperty ImageUrlProperty
            = DotvvmProperty.Register<string, ThumbnailPlaceholder>(c => c.ImageUrl, null);

        [MarkupOptions(AllowBinding = false)]
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public static readonly DotvvmProperty SizeProperty
            = DotvvmProperty.Register<int, ThumbnailPlaceholder>(c => c.Size, 150);
        
    }
}

