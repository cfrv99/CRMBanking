#pragma checksum "C:\Users\Murad\Desktop\HackatHon\CRMApp\Views\Company\MonthlySalary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "013150cc8f008ec711bd26bdb8506423afc6c8a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_MonthlySalary), @"mvc.1.0.view", @"/Views/Company/MonthlySalary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/MonthlySalary.cshtml", typeof(AspNetCore.Views_Company_MonthlySalary))]
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
#line 1 "C:\Users\Murad\Desktop\HackatHon\CRMApp\Views\_ViewImports.cshtml"
using CRMApp;

#line default
#line hidden
#line 2 "C:\Users\Murad\Desktop\HackatHon\CRMApp\Views\_ViewImports.cshtml"
using CRMApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"013150cc8f008ec711bd26bdb8506423afc6c8a1", @"/Views/Company/MonthlySalary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"288d72217f40d247f7ebea6b640f1c9a876b99a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_MonthlySalary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Murad\Desktop\HackatHon\CRMApp\Views\Company\MonthlySalary.cshtml"
  
    ViewData["Title"] = "MonthlySalary";

#line default
#line hidden
            BeginContext(51, 517, true);
            WriteLiteral(@"
    <div class=""page-section"">
        <!-- grid row -->
        <div class=""row"">
            <!-- grid column -->
            <div class=""col-lg-12"">
                <!-- .card -->
                <section class=""card card-fluid"">
                    <!-- .card-body -->
                    <div class=""card-body"">
                        <canvas id=""canvas-line"" class=""chartjs""></canvas>
                    </div>
                    <!-- /.card-body -->
                    <!-- .card-footer -->
");
            EndContext();
            BeginContext(1421, 220, true);
            WriteLiteral("                    <!-- /.card-footer -->\r\n                </section>\r\n                <!-- /.card -->\r\n            </div>\r\n\r\n            <!-- /grid column -->\r\n        </div>\r\n        <!-- /grid row -->\r\n    </div>\r\n\r\n");
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
