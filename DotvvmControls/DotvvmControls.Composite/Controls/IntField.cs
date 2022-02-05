using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace DotvvmControls.Composite.Controls;

public class IntField : CompositeControl
{

    public static DotvvmControl GetContents(
        IValueBinding<int> value,
        string labelText,
        [DefaultValue(true)] ValueOrBinding<bool> enabled,
        int? min = null,
        int? max = null
    )
    {
        return FormGroup.GetContents(
            labelText,
            new TextBox()
                .AddCssClass("form-control")
                .SetProperty(t => t.Type, TextBoxType.Number)
                .SetAttribute("min", min)
                .SetAttribute("max", max)
                .SetProperty(t => t.Text, value)
                .SetProperty(t => t.Enabled, enabled)
                .SetAttribute("readonly", enabled.Negate())
                .SetProperty(Validator.ValueProperty, value)
        );
    }
}