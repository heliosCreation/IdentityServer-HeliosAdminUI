using IdentityServer.Areas.HeliosAdminUI.Dictionnary.ApiScopes;
using IdentityServer.Areas.HeliosAdminUI.Dictionnary.Clients;
using IdentityServer.Areas.HeliosAdminUI.Dictionnary.IdentityResources;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.TagHelpers
{
    [HtmlTargetElement("LabelInfo", Attributes = "[asp-for]")]
    public class LabelInfo : TagHelper
    {
        public ModelExpression AspFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);

            string labelText = AspFor.Metadata.DisplayName;

            string containerName = AspFor.Metadata.ContainerType.Name;
            var dictionary = GetDictionnaryInfo(containerName);
            string name = AspFor.Metadata.PropertyName;
            var information = dictionary.Count > 0 ? dictionary[name] : "";

            output.TagName = "div";
            output.PreContent.SetHtmlContent($@"
                            <label class=""col-form-label"">{labelText}</label>
                            <div class=""tooltip"">
                                <i class=""bi bi-info-circle ml-2 text-info cursor-pointer""></i>
                                    <span class=""tooltiptext"">{information}</span>
                            </div>");
            output.Attributes.Clear();
        }

        private Dictionary<string, string> GetDictionnaryInfo(string containerName)
        {
            var dictionary = new Dictionary<string, string>();
            containerName = containerName.ToLower();
            if (containerName.Contains("client"))
            {
                dictionary = ClientsInfo.Data;
            }
            else if(containerName.Contains("apiscope"))
            {
                dictionary = ApiScopesInfo.Data;
            }
            else if (containerName.Contains("identityresource"))
            {
                dictionary = IdentityResourcesInfo.Data;
            }

            return dictionary;
        }
    }
}
