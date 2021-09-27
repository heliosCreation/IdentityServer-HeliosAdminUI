using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.TagHelpers
{
    [HtmlTargetElement("FieldInfo", Attributes ="[asp-for],[field-information]")]
    public class LabelInfo : TagHelper
    {
        public ModelExpression AspFor { get; set; }
        public string FieldInformation { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            string labelText = AspFor.Metadata.DisplayName;
            output.TagName = "div";
            output.PreContent.SetHtmlContent($@"
                            <label class=""col-form-label"">{labelText}</label>
                            <div class=""tooltip"">
                                <i class=""bi bi-info-circle ml-2 text-info cursor-pointer""></i>
                                    <span class=""tooltiptext"">{FieldInformation}</span>
                            </div>");
            output.Attributes.Clear();
        }
    }
}
