#pragma checksum "G:\samis\Views\Admin\Projects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "340424f1cf3796a4051f2a34c15e7bc442e72585"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Projects), @"mvc.1.0.view", @"/Views/Admin/Projects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Projects.cshtml", typeof(AspNetCore.Views_Admin_Projects))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "G:\samis\Views\_ViewImports.cshtml"
using samis;

#line default
#line hidden
#line 2 "G:\samis\Views\_ViewImports.cshtml"
using samis.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"340424f1cf3796a4051f2a34c15e7bc442e72585", @"/Views/Admin/Projects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6608b16612bc14be2bbd5ef2f8151a4a65aebd3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Projects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BudgetManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration: none; color: inherit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "G:\samis\Views\Admin\Projects.cshtml"
  
    ViewData["Title"] = "Projects";
    var projects = ViewBag.Projects;

#line default
#line hidden
            BeginContext(84, 333, true);
            WriteLiteral(@"
    <div class=""flex-container"">
        <div style=""flex-grow: 1"">
            <h4>
                <b>
                    PROJECTS
                </b>
            </h4>
        </div>
        <div style=""flex-grow: 1"">
            <h6 style=""text-align: right"">ADMINISTRATOR</h6>
        </div>
    </div>

<div>
");
            EndContext();
#line 21 "G:\samis\Views\Admin\Projects.cshtml"
     foreach (Project project in projects)
    {

#line default
#line hidden
            BeginContext(468, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(476, 2737, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "340424f1cf3796a4051f2a34c15e7bc442e725854878", async() => {
                BeginContext(630, 538, true);
                WriteLiteral(@"
            <div asp-controller=""Projects"" asp-action=""Details"" asp-route-id=""1"" style=""text-decoration: none; color: inherit"">
                <div class=""card"" style=""margin-top: 16px"">
                    <div class=""card-container"">
                        <b>ORGANIZED BY:</b> VINCENT MARY SCHOOL OF SCIENCE AND TECHNOLOGY
                        <div class=""flex-container"" style=""margin-top: 16px"">
                            <div style=""flex-grow: 1"">
                                <span class=""ongoing-dot""></span> <b>");
                EndContext();
                BeginContext(1169, 43, false);
#line 30 "G:\samis\Views\Admin\Projects.cshtml"
                                                                Write(project.activityInformation.referenceNumber);

#line default
#line hidden
                EndContext();
                BeginContext(1212, 5, true);
                WriteLiteral("</b> ");
                EndContext();
                BeginContext(1218, 40, false);
#line 30 "G:\samis\Views\Admin\Projects.cshtml"
                                                                                                                 Write(project.activityInformation.activityName);

#line default
#line hidden
                EndContext();
                BeginContext(1258, 169, true);
                WriteLiteral("\r\n                            </div>\r\n                            <div style=\"flex-grow: 3\">\r\n                                <h6 style=\"text-align: right\">PROPOSED ON: ");
                EndContext();
                BeginContext(1428, 61, false);
#line 33 "G:\samis\Views\Admin\Projects.cshtml"
                                                                      Write(project.activityInformation.timestamp.ToString("dd MMM yyyy"));

#line default
#line hidden
                EndContext();
                BeginContext(1489, 75, true);
                WriteLiteral("</h6>\r\n                            </div>\r\n                        </div>\r\n");
                EndContext();
#line 36 "G:\samis\Views\Admin\Projects.cshtml"
                          
                            var totalProposedDouble = 0.0;
                            var totalApprovedDouble = 0.0;
                            foreach (var budget in project.budgets)
                            {
                                if (budget.budgetStatusId == 1 && budget.budgetDescriptionId == 1)
                                {
                                    totalProposedDouble += budget.amount;
                                }
                                else if (budget.budgetStatusId == 2 && budget.budgetDescriptionId == 1)
                                {
                                    totalApprovedDouble += budget.amount;
                                }
                            }

                            var totalApprovedString = "";
                            if (totalApprovedDouble < 1)
                            {
                                totalApprovedString = "Pending";
                            }
                            else
                            {
                                totalApprovedString = "฿" + totalProposedDouble.ToString("N");
                            }
                        

#line default
#line hidden
                BeginContext(2804, 151, true);
                WriteLiteral("                        <div class=\"flex-container\" style=\"margin-top: 16px\">\r\n                            <div style=\"flex-grow: 1\">Proposed Budget: ฿");
                EndContext();
                BeginContext(2956, 33, false);
#line 62 "G:\samis\Views\Admin\Projects.cshtml"
                                                                   Write(totalProposedDouble.ToString("N"));

#line default
#line hidden
                EndContext();
                BeginContext(2989, 80, true);
                WriteLiteral("</div>\r\n                            <div style=\"flex-grow: 20\">Approved Budget: ");
                EndContext();
                BeginContext(3070, 19, false);
#line 63 "G:\samis\Views\Admin\Projects.cshtml"
                                                                   Write(totalApprovedString);

#line default
#line hidden
                EndContext();
                BeginContext(3089, 120, true);
                WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 23 "G:\samis\Views\Admin\Projects.cshtml"
                                                               WriteLiteral(project.activityInformation.activityId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3213, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 69 "G:\samis\Views\Admin\Projects.cshtml"
    }

#line default
#line hidden
            BeginContext(3222, 381, true);
            WriteLiteral(@"</div>


<div class=""flex-container"" style=""margin-top: 30px"">
    <div style=""flex-grow: 1""><a class=""ongoing-dot""></a> &nbsp; ONGOING PROJECT</div>
    <div style=""flex-grow: 1""><a class=""complete-dot""></a> &nbsp; COMPLETED PROJECT</div>
    <div style=""flex-grow: 1""><a class=""rejected-dot""></a> &nbsp; REJECTED PROJECT</div>
    <div style=""flex-grow: 20""></div>
</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
