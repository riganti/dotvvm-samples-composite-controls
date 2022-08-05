using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Thumbnails.Placeholder
{
    public class ThumbnailPlaceholderComposite : CompositeControl
    {
        public static DotvvmControl GetContents(
            [DefaultValue(null)] ValueOrBinding<string> imageUrl,
            int size = 150
        )
        {
            return new HtmlGenericControl("img")
                .SetAttribute("alt", "Placeholder")
                .SetAttribute("src", imageUrl.Select(s => string.IsNullOrEmpty(s) ? $"/identicon/{size}" : s))
                .AddCssStyle("height", size + "px");
        }

    }
}
