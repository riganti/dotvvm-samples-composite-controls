using System;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using Jdenticon;

namespace CompositeControlsDemo.Presenter;

public class IdenticonPresenter : IDotvvmPresenter
{
    public async Task ProcessRequest(IDotvvmRequestContext context)
    {
        context.HttpContext.Response.ContentType = "image/png";

        await Identicon
            .FromValue(Guid.NewGuid(), Convert.ToInt32(context.Parameters["size"]))
            .SaveAsPngAsync(context.HttpContext.Response.Body);
    }
}