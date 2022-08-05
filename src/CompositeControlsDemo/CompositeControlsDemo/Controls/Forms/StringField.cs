using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Forms;

public class StringField : CompositeControl 
{

    public static DotvvmControl GetContents(
        IValueBinding<string> text,
        FormGroupCapability formGroup
    )
    {
        return formGroup.ToControls(
            new TextBox()
                .AddCssClass("form-control")
                .SetProperty(t => t.Text, text)
                .SetProperty(Validator.ValueProperty, text)
        );
    }
}