using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Panels
{
    public class Panel : CompositeControl
    {
        public static DotvvmControl GetContents(
            TextOrContentCapability body,

            [DotvvmControlCapability("Header")]
            TextOrContentCapability header
        )
        {
            return new HtmlGenericControl("div")
                .AddCssClass("card")
                .AppendChildren(
                    new HtmlGenericControl("div")
                        .AddCssClass("card-header")
                        .AppendChildren(header.ToControls()),
                    new HtmlGenericControl("div")
                        .AddCssClass("card-body")
                        .AppendChildren(body.ToControls())
                );
        }
    }
}
