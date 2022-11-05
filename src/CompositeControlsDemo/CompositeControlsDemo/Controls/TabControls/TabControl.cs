using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CompositeControlsDemo.Controls.Menus;
using CompositeControlsDemo.Utils;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Utils;

namespace CompositeControlsDemo.Controls.TabControls
{
    [ControlMarkupOptions(AllowContent = false, DefaultContentProperty = "Items")]
    public class TabControl : CompositeControl
    {
        private readonly BindingCompilationService bindingService;

        public TabControl(BindingCompilationService bindingService)
        {
            this.bindingService = bindingService;
        }

        public HtmlGenericControl GetContents(
            HtmlCapability html,

            [DotvvmControlCapability("Item")]
            [ControlPropertyBindingDataContextChange("DataSource", order: 0)]
            [CollectionElementDataContextChange(order: 1)]
            TabControlCapability tabControl,

            ItemsOrDataSourceCapability<TabItem> itemsOrDataSource)
        {
            // build control ID generator
            var controlId = this.CreateClientId() ?? this.GetDotvvmUniqueId();
            
            Func<int?, ValueOrBinding<string>> controlIdGenerator;
            if (itemsOrDataSource.DataSource != null)
            {
                var childDataContext = itemsOrDataSource.DataSource.GetProperty<CollectionElementDataContextBindingProperty>().DataContext;
                controlId = IdUtils.ConcatStringBindings(bindingService,
                    IdUtils.TransferToChildContext(bindingService, controlId, childDataContext), 
                    IdUtils.GetTabIndexIdFragment(bindingService, childDataContext)
                );
                controlIdGenerator = _ => controlId;
            }
            else
            {
                controlIdGenerator = itemIndex => IdUtils.ConcatStringBindings(bindingService, controlId, new ValueOrBinding<string>("_tab" + itemIndex));
            }

            return new HtmlGenericControl("div", html)
                .AppendChildren(
                    itemsOrDataSource.ToItemsOrRepeater("ul",
                            () => new TabItem().SetCapability(tabControl),
                            (tabItem, itemIndex) => 
                                new HtmlGenericControl("li")
                                    .AddCssClass("nav-item")
                                    .AddAttribute("role", "presentation")
                                    .AppendChildren(
                                        new HtmlGenericControl("button")
                                            .AddCssClass("nav-link")
                                            .AddAttribute("data-bs-toggle", "tab")
                                            .AddAttribute("data-bs-target", IdUtils.ConcatStringBindings(bindingService, new ValueOrBinding<string>("#"), controlIdGenerator(itemIndex)))
                                            .AddAttribute("role", "tab")
                                            .SetProperty(a => a.InnerText, tabItem.GetCapability<TabControlCapability>().HeaderText)
                                    ))
                        .AddAttribute("role", "tablist")
                        .AddCssClasses("nav", "nav-tabs"),

                    itemsOrDataSource.ToItemsOrRepeater("div",
                        () => new TabItem().SetCapability(tabControl),
                        (tabItem, itemIndex) =>
                        {
                            return tabItem
                                .SetProperty(i => i.ID, controlIdGenerator(itemIndex))
                                .SetProperty(i => i.ClientIDMode, ClientIDMode.Static);
                        })
                        .AddCssClass("tab-content")
                );
        }
    }
}
