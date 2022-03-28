using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using System.Collections.Generic;

namespace PhoneNumbers.Controls
{
    public class PhoneNumber1 : CompositeControl 
    {

        public static IEnumerable<DotvvmControl> GetContents(
            ValueOrBinding<string> phoneNumber
        )
        {
            yield return new HtmlLiteral() { Html = "&nbsp;", WrapperTagName = "span" }
                .SetProperty(l => l.IncludeInPage, phoneNumber.Select(n => n == null));

            yield return new HtmlGenericControl("span")
                .AddCssClass("phone-number")
                .SetProperty(l => l.InnerText, phoneNumber)
                .SetProperty(l => l.IncludeInPage, phoneNumber.Select(n => n != null));
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("phoneNumber");
            base.OnPreRender(context);
        }

    }
}
