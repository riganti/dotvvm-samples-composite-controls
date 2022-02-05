using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace DotvvmControls.Composite.Controls;

public class StringField : CompositeControl 
{

    public static DotvvmControl GetContents(
        IValueBinding<string> text,
        string labelText,
        [DefaultValue(true)] ValueOrBinding<bool> enabled
    )
    {
        return FormGroup.GetContents(
            labelText, 
            new TextBox()
                .AddCssClass("form-control")
                .SetProperty(t => t.Text, text)
                .SetProperty(t => t.Enabled, enabled)
                .SetAttribute("readonly", enabled.Negate())
                .SetProperty(Validator.ValueProperty, text)
        );
    }
}