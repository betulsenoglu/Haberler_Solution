#pragma checksum "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\Shared\Error_NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eced577e34e8f1b1ec4d015dc74157984951bf9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error_NotFound), @"mvc.1.0.view", @"/Views/Shared/Error_NotFound.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error_NotFound.cshtml", typeof(AspNetCore.Views_Shared_Error_NotFound))]
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
#line 1 "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\_ViewImports.cshtml"
using Haberler.WebUI.MVC;

#line default
#line hidden
#line 2 "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\_ViewImports.cshtml"
using Haberler.WebUI.MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eced577e34e8f1b1ec4d015dc74157984951bf9b", @"/Views/Shared/Error_NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"894c7df8ac847219b45ce507cc4818a705a1a706", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\Shared\Error_NotFound.cshtml"
  
    ViewData["Title"] = "HATA";

#line default
#line hidden
            BeginContext(55, 151, true);
            WriteLiteral("\r\n<h1 class=\"text-danger\">HATA.</h1>\r\n<h2 class=\"text-danger\">Bir Hata Oluştu.</h2>\r\n\r\n<p>\r\n    <strong>Aradığınız Sayfa Bulunamadı... </strong> <code>");
            EndContext();
            BeginContext(207, 5, false);
#line 10 "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\Shared\Error_NotFound.cshtml"
                                                      Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(212, 19, true);
            WriteLiteral("</code>\r\n</p>\r\n\r\n\r\n");
            EndContext();
            BeginContext(232, 80, false);
#line 14 "C:\Users\Betul\Desktop\Demiroren_Case\Haberler_Solution\Haberler.WebUI.MVC\Views\Shared\Error_NotFound.cshtml"
Write(Html.ActionLink("GERİ DÖN", "Index", "Home", new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(312, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
