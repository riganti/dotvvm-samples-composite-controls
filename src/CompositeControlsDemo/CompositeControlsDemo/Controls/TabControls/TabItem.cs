using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.TabControls;

[ControlMarkupOptions(AllowContent = false, DefaultContentProperty = "Template")]
public class TabItem : CompositeControl
{
    public DotvvmControl GetContents(
        HtmlCapability html,
        TabControlCapability tabControl
    )
    {
        return new HtmlGenericControl("div", html)
            .AddCssClass("tab-body")
            .AppendChildren(new TemplateHost(tabControl.Template));
    }

}