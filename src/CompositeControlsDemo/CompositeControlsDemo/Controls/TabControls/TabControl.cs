using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CompositeControlsDemo.Controls.Menus;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
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
            return new HtmlGenericControl("div", html)
                .AppendChildren(
                    itemsOrDataSource.ToItemsOrRepeater("ul",
                            () => new TabItem().SetCapability(tabControl),
                            (tabItem, itemIndex) =>
                            {
                                // TODO: problem, we are joining bindings with different contexts
                                var targetId = this.GetDotvvmUniqueId(
                                    prefix: ValueOrBinding<string>.FromBoxedValue("#"), 
                                    suffix: GetTabIndexIdFragment(itemIndex, itemsOrDataSource.DataSource));

                                return new HtmlGenericControl("li")
                                    .AddCssClass("nav-item")
                                    .AppendChildren(
                                        new HtmlGenericControl("button")
                                            .AddCssClass("nav-link")
                                            .AddAttribute("data-bs-toggle", "tag")
                                            .AddAttribute("data-bs-target", targetId)
                                            .SetProperty(a => a.InnerText, tabItem.GetCapability<TabControlCapability>().HeaderText)
                                    );
                            })
                        .AddCssClasses("nav", "nav-tabs"),

                    itemsOrDataSource.ToItemsOrRepeater("div",
                        () => new TabItem().SetCapability(tabControl),
                        (tabItem, itemIndex) =>
                        {
                            var id = this.GetDotvvmUniqueId(
                                suffix: GetTabIndexIdFragment(itemIndex, itemsOrDataSource.DataSource)
                            );
                            return tabItem
                                .SetProperty(i => i.ID, id);
                        }
                    )
                );
        }

        private ValueOrBinding<string> GetTabIndexIdFragment(int? itemIndex, IValueBinding? dataSourceBinding)
        {
            if (itemIndex != null)
            {
                return ValueOrBinding<string>.FromBoxedValue("_tab" + itemIndex);
            }

            var dataContext = dataSourceBinding!.GetProperty<CollectionElementDataContextBindingProperty>().DataContext;
            var indexBinding = bindingService.Cache.CreateCachedBinding("_index", new object[] { dataContext }, 
                () => new ValueBindingExpression<string>(bindingService, new object?[] 
                    {
                        dataContext,
                        new ParsedExpressionBindingProperty(
                            ExpressionUtils.Replace((int id) => "tab_" + id, CreateIndexBindingExpression(dataContext))
                        )
                    }));
            return ValueOrBinding<string>.FromBoxedValue(indexBinding);
        }

        private static ParameterExpression CreateIndexBindingExpression(DataContextStack dataContext) =>
            Expression.Parameter(typeof(int), "_index")
                .AddParameterAnnotation(new BindingParameterAnnotation(dataContext, new CurrentCollectionIndexExtensionParameter()));
    }
}
