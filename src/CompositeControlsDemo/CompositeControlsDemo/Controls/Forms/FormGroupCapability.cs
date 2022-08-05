using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Forms;

[DotvvmControlCapability]
public sealed class FormGroupCapability
{

    public string LabelText { get; set; }

    public string HelpText { get; set; }

    public ValueOrBinding<bool>? Enabled { get; set; }



    public DotvvmControl ToControls(
        params DotvvmControl[] content
    )
    {
        var formGroup = new HtmlGenericControl("div")
            .AddCssClass("mb-3")
            .SetProperty(FormControls.EnabledProperty, Enabled);

        formGroup.AppendChildren(
            new HtmlGenericControl("label")
                .AddCssClass("form-label")
                .SetProperty(l => l.InnerText, LabelText)
        );

        formGroup.AppendChildren(content);

        if (!string.IsNullOrEmpty(HelpText))
        {
            formGroup.AppendChildren(
                new HtmlGenericControl("div")
                    .AddCssClass("form-text")
                    .SetProperty(l => l.InnerText, HelpText)
            );
        }

        return formGroup;
    }

}