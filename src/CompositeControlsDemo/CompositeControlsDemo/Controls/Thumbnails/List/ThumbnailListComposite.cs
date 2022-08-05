using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CompositeControlsDemo.Controls.Thumbnails.Placeholder;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Thumbnails.List
{
    public class ThumbnailListComposite : CompositeControl
    {
        public static IEnumerable<DotvvmControl> GetContents(
            [DefaultValue("Photo list")] ValueOrBinding<string> title,

            IValueBinding<IEnumerable> dataSource,

            [ControlPropertyBindingDataContextChange("DataSource", order: 0), CollectionElementDataContextChange(order: 1)] 
            IValueBinding<string> itemImageUrlBinding)
        {
            yield return new HtmlGenericControl("h3")
                .SetProperty(HtmlGenericControl.InnerTextProperty, title);

            yield return new Repeater() 
                {
                    ItemTemplate = new DelegateTemplate(_ => 
                        new ThumbnailPlaceholderComposite()
                            .SetProperty("ImageUrl", itemImageUrlBinding)
                            .SetProperty("Size", new ValueOrBinding<int>(200)))
                }
                .SetProperty(ItemsControl.DataSourceProperty, dataSource);
        }
    }
}