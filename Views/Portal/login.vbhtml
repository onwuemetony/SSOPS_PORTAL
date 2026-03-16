<!DOCTYPE html>
<html lang="en">
@code
    Layout = ""
End Code

<head>
    <meta charset="utf-8" />
    @*<title>@ViewBag.Title - My ASP.NET Application</title>*@
    <title>SSOPS Portal</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="/Content/jquery-ui.css" rel="stylesheet" />
    <link href="/Content/Site.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/datatables.css" rel="stylesheet" />

    <script src="/Scripts/modernizr-2.8.3.js"></script>

    @*@Styles.Render("~/Content/css")
        @Scripts.Render("~/bundles/modernizr")@*@
</head>
<body style="background-color:lightgrey">

    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card border-primary " style="min-width: 380px;">
            <div class="card-header bg-primary text-white fw-semibold " style="text-align:center;background-color:maroon "><span class="glyphicon glyphicon-user "></span> User Sign-In</div>
                <div class="card-body" style="color: blue; background-image: url(../../images/login.png); height: 200px;">
                    <div class="container mt-4">
                    @using (Html.BeginForm("../Portal/Login", "Portal", FormMethod.Post, New With {.id = User}))
                            @<div class="row  mb-3 align-items-center g-0">
                             <label for="password" class="col-sm-4 col-form-label">User name:</label>
                             <div class="col-sm-6">
                                <input type="text" class="form-control" name="UserName" />
                            </div>
                            </div>
                            @<div class="row mb-3 align-items-center g-0">
                               <label for="password" class="col-sm-4 col-form-label">Password:</label>
                        <div class="col-sm-6">
                            <input type="password" class="form-control" name="pwd" />
                            
                        </div>
                        </div>

                            @<div class="row">
                                <div class="col-sm-8 offset-sm-2">
                                <button type="submit" id="submiter" class="btn-primary" style="width:100%">Sign-In</button>
                                <br /><br /><label style="color:red">@ViewBag.error</label>
                            </div>
                        </div>
                        End Using
                        </div>
                        </div>
              
            </div>

        </div>


</body>

</html>
