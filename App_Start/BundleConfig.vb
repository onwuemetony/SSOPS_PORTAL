Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862

    Public Sub RegisterBundles(bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-3.7.1.js",
            "~/Scripts/jquery-ui.js"
            ))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.unobtrusive*",
            "~/Scripts/jquery.validate*"))

        bundles.Add(New ScriptBundle("~/bundles/knockout").Include(
            "~/Scripts/knockout-{version}.js",
            "~/Scripts/knockout.validation.js"))

        bundles.Add(New ScriptBundle("~/bundles/app").Include(
            "~/Scripts/sammy-{version}.js",
            "~/Scripts/app/common.js",
            "~/Scripts/app/app.datamodel.js",
            "~/Scripts/app/app.viewmodel.js",
            "~/Scripts/app/home.viewmodel.js",
            "~/Scripts/app/_run.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))

        bundles.Add(New Bundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.bundle.min.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include("~/Content/datatables.css",
             "~/Content/jquery-ui.css",
            "~/Content/jquery.datetimepicker.css",
            "~/Content/Site.css", "~/Content/bootstrap.css"))
        ' "~/Content/buttons.dataTables.min.css",//"~/Content/datatables.css","~/Content/dataTables.bootstrap.css", "~/Content/buttons.bootstrap.css", "~/Scripts/bootstrap.bundle.js", 

    End Sub
End Module
