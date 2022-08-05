using System.Collections.Generic;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace CompositeControlsDemo.Controls.PhoneNumbers
{
    public class PhoneNumber1 : CompositeControl 
    {

        public static IEnumerable<DotvvmControl> GetContents(
            ValueOrBinding<string> phoneNumber,
            string emptyText = "no contact provided"
        )
        {
            yield return new HtmlGenericControl("span") { InnerText = emptyText }
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
