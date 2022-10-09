using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Controls.Menus
{
    [ControlMarkupOptions(AllowContent = false, DefaultContentProperty = "Items")]
    public class Menu : CompositeControl
    {
        public static DotvvmControl GetContents(
            ItemsOrDataSourceCapability<MenuItem> itemsOrDataSource,

            [DotvvmControlCapability("Item")]
            [ControlPropertyBindingDataContextChange("DataSource", order: 0)]
            [CollectionElementDataContextChange(order: 1)]
            MenuItemCapability itemProps)
        {
            return itemsOrDataSource
                .ToItemsOrRepeater(
                    wrapperTagName: "ul",
                    generateItem: () => new MenuItem().SetCapability(itemProps))
                .AddCssClasses("nav", "nav-pills", "mb-4");
        }
    }
}
