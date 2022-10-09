using System;
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Menus;

[DotvvmControlCapability]
public sealed record ItemsOrDataSourceCapability<TItem> where TItem : DotvvmControl
{
    public List<TItem>? Items { get; init; }
    public IValueBinding<object>? DataSource { get; init; }

    public HtmlGenericControl ToItemsOrRepeater(string wrapperTagName, Func<TItem> generateItem)
    {
        if (DataSource != null && Items?.Any() == true)
        {
            throw new DotvvmControlException("The Items in the control and the DataSource property cannot be set at the same time!");
        }

        if (DataSource != null)
        {
            return new Repeater()
                {
                    WrapperTagName = wrapperTagName,
                    ItemTemplate = new DelegateTemplate(_ => generateItem())
                }
                .SetProperty(r => r.DataSource, DataSource);
        }
        else
        {
            return new HtmlGenericControl(wrapperTagName)
                .AppendChildren(Items);
        }
    }
}