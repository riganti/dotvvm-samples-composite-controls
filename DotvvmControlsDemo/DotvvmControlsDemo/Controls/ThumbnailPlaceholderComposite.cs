using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace DotvvmControlsDemo.Controls
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
                .SetAttribute("src", imageUrl.Derive(
                    (string value, string placeholderUrl) => string.IsNullOrEmpty(value) ? placeholderUrl : value, 
                    $"https://via.placeholder.com/{size}")
                )
                .AddCssStyle("height", size + "px");
        }

        
    }
}
