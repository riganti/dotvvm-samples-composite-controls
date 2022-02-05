using System;
using System.Collections;
using DotVVM.Framework.Controls;

namespace DotvvmControls.Composite.Controls;

public class FormGroup : CompositeControl
{

    public static DotvvmControl GetContents(
        string labelText,
        params DotvvmControl[] content
    )
    {
        return new HtmlGenericControl("div")
            .AddCssClass("mb-3")
            .AppendChildren(
                new HtmlGenericControl("label")
                    .AddCssClass("form-label")
                    .SetProperty(l => l.InnerText, labelText)
            )
            .AppendChildren(content);
    }

}