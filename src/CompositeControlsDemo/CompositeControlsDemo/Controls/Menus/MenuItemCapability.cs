using System.ComponentModel;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Menus;

[DotvvmControlCapability]
public sealed record MenuItemCapability
{
    public ValueOrBinding<string> Text { get; set; }

    public ValueOrBinding<string> Url { get; set; }
    
    [DefaultValue(true)]
    public ValueOrBinding<bool> IsActive { get; set; }
}