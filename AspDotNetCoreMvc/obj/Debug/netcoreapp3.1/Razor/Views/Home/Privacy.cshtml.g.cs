#pragma checksum "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "159defb04a1e46918e916ec6fe3029fb2564c47f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#nullable restore
#line 1 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\_ViewImports.cshtml"
using AspDotNetCoreMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\_ViewImports.cshtml"
using AspDotNetCoreMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"159defb04a1e46918e916ec6fe3029fb2564c47f", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c860dec16892b3749ce8d5959342a14ce12944c0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\nAccessToken:\r\n<p>");
#nullable restore
#line 7 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
Write(ViewData["accessToken"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\nIdToken:\r\n<p>");
#nullable restore
#line 9 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
Write(ViewData["idToken"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\nRefreshToken:\r\n<p>");
#nullable restore
#line 11 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
Write(ViewData["refreshToken"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<dl>\r\n");
#nullable restore
#line 14 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 16 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 17 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 18 "E:\identity\IdentityServer4-Demo\AspDotNetCoreMvc\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n");
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
