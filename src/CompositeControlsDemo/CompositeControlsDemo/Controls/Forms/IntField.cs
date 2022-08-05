using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Forms;

public class IntField : CompositeControl
{

    public static DotvvmControl GetContents(
        IValueBinding<int> value,
        FormGroupCapability formGroup,
        int? min = null,
        int? max = null
    )
    {
        return formGroup.ToControls(
            new TextBox()
                .AddCssClass("form-control")
                .SetProperty(t => t.Type, TextBoxType.Number)
                .SetAttribute("min", min)
                .SetAttribute("max", max)
                .SetProperty(t => t.Text, value)
                .SetProperty(Validator.ValueProperty, value)
        );
    }
}