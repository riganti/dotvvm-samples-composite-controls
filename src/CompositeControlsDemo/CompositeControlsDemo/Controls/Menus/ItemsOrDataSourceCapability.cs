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

    public HtmlGenericControl ToItemsOrRepeater(string wrapperTagName, Func<TItem> generateItem, 
        Func<TItem, int?, DotvvmControl>? transformItem = null)
    {
        transformItem ??= (i, _) => i;

        if (DataSource != null && Items?.Any() == true)
        {
            throw new DotvvmControlException("The Items in the control and the DataSource property cannot be set at the same time!");
        }

        if (DataSource != null)
        {
            return new Repeater()
                {
                    WrapperTagName = wrapperTagName,
                    ItemTemplate = new DelegateTemplate(_ => transformItem(generateItem(), null))
                }
                .SetProperty(r => r.DataSource, DataSource);
        }
        else
        {
            return new HtmlGenericControl(wrapperTagName)
                .AppendChildren(Items!.Select((item, index) => transformItem(item, index)));
        }
    }

}