using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.TabControls;

[DotvvmControlCapability]
public sealed record TabControlCapability
{

    public ValueOrBinding<string> HeaderText { get; set; }

    public ITemplate Template { get; set; }
}