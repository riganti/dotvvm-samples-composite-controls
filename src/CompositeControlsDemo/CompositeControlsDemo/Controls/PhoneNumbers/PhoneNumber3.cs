using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace CompositeControlsDemo.Controls.PhoneNumbers
{
    public class PhoneNumber3 : CompositeControl
    {

        public static DotvvmControl GetContents(
            ValueOrBinding<string> phoneNumber,
            string emptyText = "no contact provided"
        )
        {
            return new HtmlGenericControl("span")
                .AddCssClass("phone-number-clever")
                .SetProperty(l => l.InnerText, phoneNumber)
                .SetAttribute("data-empty-text", emptyText);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("phoneNumber");
            base.OnPreRender(context);
        }
    }
}
