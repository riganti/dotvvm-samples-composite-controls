using System.Collections.Generic;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace CompositeControlsDemo.Controls.PhoneNumbers
{
    public class PhoneNumber2 : CompositeControl
    {

        public static IEnumerable<DotvvmControl> GetContents(
            ValueOrBinding<string> phoneNumber,
            string emptyText = "no contact provided"
        )
        {
            yield return new HtmlLiteral() { WrapperTagName = "span" }
                .SetProperty(l => l.Html, phoneNumber.Select(n => n == null ? emptyText : "<i class='phone-number-icon'></i>"));

            yield return new Literal()
                .SetProperty(l => l.Text, phoneNumber);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("phoneNumber");
            base.OnPreRender(context);
        }
    }
}
