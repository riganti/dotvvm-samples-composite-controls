using System.Collections;
using CompositeControlsDemo.Controls.Thumbnails.Placeholder;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CompositeControlsDemo.Controls.Thumbnails.List
{
    public class ThumbnailList : HtmlGenericControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DotvvmProperty TitleProperty
            = DotvvmProperty.Register<string, ThumbnailList>(c => c.Title, "Photo list");
        
        public IEnumerable DataSource
        {
            get { return (IEnumerable)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly DotvvmProperty DataSourceProperty
            = DotvvmProperty.Register<IEnumerable, ThumbnailList>(c => c.DataSource, null);

        [ControlPropertyBindingDataContextChange(nameof(DataSource), order: 0), CollectionElementDataContextChange(order: 1)]
        public IValueBinding<string> ItemImageUrlBinding
        {
            get { return (IValueBinding<string>)GetValue(ItemImageUrlBindingProperty); }
            set { SetValue(ItemImageUrlBindingProperty, value); }
        }
        public static readonly DotvvmProperty ItemImageUrlBindingProperty
            = DotvvmProperty.Register<IValueBinding<string>, ThumbnailList>(c => c.ItemImageUrlBinding, null);


        protected override void OnInit(IDotvvmRequestContext context)
        {
            base.OnInit(context);

            var title = new HtmlGenericControl("h3");
            title.SetValueRaw(HtmlGenericControl.InnerTextProperty, GetValueRaw(TitleProperty));
            Children.Add(title);

            var repeater = new Repeater();
            repeater.SetValueRaw(ItemsControl.DataSourceProperty, GetValueRaw(DataSourceProperty));
            repeater.ItemTemplate = new DelegateTemplate(serviceProvider =>
                {
                    // You cannot do this because ThumbnailPlaceholder is a markup control
                    // var control = new ThumbnailPlaceholder();

                    // Instead, you need to do this
                    var controlBuilderFactory = serviceProvider.GetService<IControlBuilderFactory>();
                    var builder = controlBuilderFactory.GetControlBuilder("Controls/Thumbnails/Placeholder/ThumbnailPlaceholder.dotcontrol").builder.Value;
                    var control = (ThumbnailPlaceholder)builder.BuildControl(controlBuilderFactory, serviceProvider);

                    control.SetBinding(ThumbnailPlaceholder.ImageUrlProperty, GetValueBinding(ItemImageUrlBindingProperty));
                    control.Size = 200;

                    return control;
                }
            );
            Children.Add(repeater);
        }
    }
}
