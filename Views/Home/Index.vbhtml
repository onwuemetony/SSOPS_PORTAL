<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    @*<title>@ViewBag.Title - My ASP.NET Application</title>*@
    <title>Switch Support Portal</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
@code
    Layout = ""
End Code
@Html.Partial("_Home")

@Section Scripts
    @Scripts.Render("~/bundles/knockout")
    @*@Scripts.Render("~/bundles/app")*@
End Section
