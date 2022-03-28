using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace PhoneNumbers.Controls
{
    public class PhoneNumber3 : CompositeControl
    {

        public static DotvvmControl GetContents(
            ValueOrBinding<string> phoneNumber
        )
        {
            return new HtmlGenericControl("span")
                .AddCssClass("phone-number-clever")
                .SetProperty(l => l.InnerText, phoneNumber);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("phoneNumber");
            base.OnPreRender(context);
        }
    }
}
