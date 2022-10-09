using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Menus;

public class MenuItem : CompositeControl
{
    public static DotvvmControl GetContents(
        MenuItemCapability props)
    {
        return new HtmlGenericControl("li")
            .AddCssClass("nav-item")
            .AppendChildren(
                new HtmlGenericControl("a")
                    .AddCssClass("nav-link")
                    .SetProperty(HtmlGenericControl.CssClassesGroupDescriptor.GetDotvvmProperty("active"), props.IsActive)
                    .SetAttribute("href", props.Url)
                    .SetProperty(HtmlGenericControl.InnerTextProperty, props.Text)
            );
    }
}