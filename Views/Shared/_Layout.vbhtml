<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    @*<title>@ViewBag.Title - My ASP.NET Application</title>*@
    <title>SSOPS Portal</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body style="display: flex; background-color: white; min-height: 100vh;min-width:100vw; ">
    <div class="navbar navbar-dark bg-dark fixed-top " style="padding-top:0px; padding-bottom: 0px;min-height: 50px; height: 50px">
        <div class="navbar-brand">
            <img src="~/images/GoldCrestlogo.png" style="height: 35px">

            @************************* TOP MENU BAR *********************@
            @*=============================================================*@

            <div class="btn-group ">
                <button type="button" class="btn btn-primary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">Applications <span class="caret"></span></button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <li><a class="dropdown-item" id="AlarmXApptopmenuLink" href="javascript:void(0);" onclick="loadmainTab('AlarmXapptab');">AlarmX</a></li>
                    @*<li>@Html.ActionLink("SSR", "Index", "AppCommon")</li>*@
                </ul>
            </div>
            <div class="btn-group">
                <button type="button" class="btn btn-primary dropdown-toggle " data-bs-toggle="dropdown">Documents <b><span class="caret"></span></b></button>
                <div class="dropdown-menu">
                    <ul>
                        <li><a class="dropdown-item" id="AuditsDoctopmenuLink" href="javascript:void(0);" onclick="loadmainTab('Auditsdoctab');">Audits</a></li>
                        <li>@Html.ActionLink("Job descriptions", "Index", "AppCommon")</li>
                    </ul>
                </div>
            </div>
            <div class="btn-group">
                <button type="button" class="btn btn-primary dropdown-toggle " data-bs-toggle="dropdown">Reports <b><span class="caret"></span></b></button>
                <div class="dropdown-menu">
                    <ul>
                        <li><a class="dropdown-item" id="AlarmXAppreporttopmenuLink" href="javascript:void(0);" onclick="loadmainTab('AlarmXreporttab');">AlarmX</a></li>

                    </ul>
                    <ul>
                        <li><a class="dropdown-item" id="PloadApptopmenuLink" href="javascript:void(0);" onclick="loadmainTab('Ploadreporttab');">Pload</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="navbar-text navbar-right">
            <span class="glyphicon glyphicon-user" style="padding-right:10px;color:white"><label id="Userid">@User.Identity.Name</label></span>  <span class="glyphicon glyphicon-log-out" style="padding-right:50px;color:white">
                <a style="color:white"
                   href="~/Portal/Logout">Logout</a>
            </span>

        </div>
    </div>

    @************************* END TOP MENU BAR *********************@


    <div>
        @RenderBody()
        @RenderSection("SPAViews", required:=False)
    </div>

    <div class="navbar fixed-bottom bg-dark" style="padding-top:0px; padding-bottom: 0px;min-height: 25px; height: 25px">
        <div class="container-fluid justify-content-center"><p style=" color:white;"> Developed by Anthony Onwueme - build 20260322</p></div>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")

    <script src="~/Scripts/Utilities.js"></script>
    <script src="~/Scripts/AlarmXapp.js"></script>
    <script src="~/Scripts/Pload.js"></script>
    <script src="~/Scripts/jquery.datetimepicker.full.js"></script>
    <script src="~/Scripts/datatables.js"></script>

    <script src="~/Scripts/jszip.js"></script>
    <script src="~/Scripts/buttons.html5.min.js"></script>
    <script src="~/Scripts/chart.js"></script>
    <script src="~/Scripts/chartjs-plugin-datalabels.js"></script>

    @RenderSection("scripts", required:=False)

</body>
</html>
@*@Html.ActionLink("Applications", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"}) <script src="~/Scripts/datatables.bootstrap.js"></script> <script src="~/Scripts/dataTables.buttons.js"></script><script src="~/Scripts/datatables.bootstrap.js"></script>*@