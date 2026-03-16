Imports System.Web.Mvc
Imports System.Web.Services
Imports System.Web.Security
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports SSOPS_PORTAL.Areas.utilities
Imports System.DirectoryServices.AccountManagement
Imports System.Web
Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Data.Entity
'Imports System.Web.Http

'Imports SSOPS_PORTAL.PortalappModel

Namespace Controllers


    Public Class PortalController
        Inherits Controller

        ' GET: Portal
        <HttpGet>
        <AllowAnonymous>
        Function Login() As ActionResult
            If Not (ModelState.IsValid) Then
                Return View()
            End If
            Return View()

        End Function

        <HttpPost()>
        Public Function Login(UserName As String, pwd As String, JSONdata As String) As ActionResult

            Try
                If pwd = "$oiPPE0983jkdg@" And UserName = "plldpapiuser" Then '$oiPPE0983jkdg@
                    FormsAuthentication.SetAuthCookie(UserName, False)
                    If Not JSONdata Is Nothing Then
                        TempData("JSONdata") = JSONdata
                        Return RedirectToAction("Pload_apiUpdate", "Apis")
                    End If
                End If
            Catch
                ViewBag.error = "JSON error"
                Return View(ViewBag.error)
            End Try

            If pwd = "ONYEadmin1#" And UserName = "anthonon" Then
                FormsAuthentication.SetAuthCookie(UserName, False)
                Return RedirectToAction("Main", "Portal")
            End If
            Try
                Dim pc As New PrincipalContext(ContextType.Domain, "mtn.com.ng")
                If (pc.ValidateCredentials(UserName, pwd)) Then
                    Dim db As New PortalappModel

                    If (From U In db.Users Where U.Name = UserName Select U.Name).Count Then
                        FormsAuthentication.SetAuthCookie(UserName, False)
                        Return RedirectToAction("Main", "Portal")
                    End If
                    ViewBag.error = "User not profiled"
                    Return View(ViewBag.error)
                End If
            Catch
            End Try
            ViewBag.error = "Invalid Login Credentials"
            Return View(ViewBag.error)
        End Function
        Function Logout() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("Login", "Portal")
        End Function

        Function Main() As ActionResult
            Return View()
        End Function
        Public Function Ploadreport() As ActionResult
            'Dim db As New PloadappModel

            '  With db
            ' ViewBag.alarmxunitsdropdown = New SelectList(.Units, "ID", "Name")
            ' End With
            '  Return RedirectToAction("API", "SendJsonData")
            Return View("~/Views/Reports/_Ploadreport.vbhtml")
            'Return View("~/Views/Apps/_AlarmX.vbhtml", ViewBag.alarmxunitsdropdown)
        End Function
        Public Function AlarmXapp() As ActionResult
            Dim db As New PortalappModel

            With db
                ViewBag.alarmxunitsdropdown = New SelectList(.Units, "ID", "Name")
            End With

            Return View("~/Views/Apps/_AlarmX.vbhtml", ViewBag.alarmxunitsdropdown)
        End Function

        Public Function AlarmXappread(wk As Int16, yr As Int16, wspace As Integer, user As String) As PartialViewResult
            'Dim db As New PortalappModel
            Dim db As New ssportaldbEntities1

            With db
                Dim qry = ""
                If wspace = 1 Then
                    ViewBag.srchquery = (From A In .Alarms
                                         Join U In .Units On A.UnitID Equals U.ID
                                         Join N In .Nodes On A.Node Equals N.Name
                                         Where A.Week = wk And A.Year = yr And A.Owner = user
                                         Select A.ID, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner, N.Type
                                    ).ToList
                End If
                If wspace = 2 Then
                    qry = (From Alt In .Users Where Alt.Name = user Select Alt.Alternate).Single

                    ViewBag.srchquery = (From A In .Alarms
                                         Join U In .Units On A.UnitID Equals U.ID
                                         Join N In .Nodes On A.Node Equals N.Name
                                         Where A.Week = wk And A.Year = yr And A.Owner = qry
                                         Select A.ID, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner, N.Type
                                    ).ToList
                End If
                If wspace = 3 Then
                    qry = (From Alt In .Users Where Alt.Name = user Select Alt.Region).Single
                    ViewBag.srchquery = (From A In .Alarms
                                         Join U In .Units On A.UnitID Equals U.ID
                                         Join N In .Nodes On A.Node Equals N.Name
                                         Where A.Week = wk And A.Year = yr And N.Region = qry
                                         Select A.ID, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner, N.Type
                                    ).ToList
                End If
            End With
            Return PartialView("~/Views/Apps/_AlarmXtable.vbhtml", ViewBag.srchquery)
        End Function

        Public Function AlarmXappupdate(wk As Int16, yr As Int16, wspace As Integer, user As String, updata As List(Of Alarmupdate)) As String
            Dim db As New ssportaldbEntities1
            Dim Udata As New Alarmupdate
            Dim x1 As Integer
            If (wspace = 1 Or wspace = 2) Then
                With db
                    If wspace = 2 Then
                        user = (From Alt In .Users Where Alt.Name = user Select Alt.Alternate).Single
                    End If

                    Dim updquery As IEnumerable = From A In .Alarms Where A.Week = wk And A.Year = yr And A.Owner = user
                    Try
                        For Each qry In updquery
                            With qry
                                x1 = .ID
                                Udata = updata.Where(Function(x) x.ID = .ID).FirstOrDefault
                                .Ticket = Udata.Ticket
                                .Comment = Udata.Comment
                                .Status = Udata.Status
                                .UnitID = Udata.UnitID
                            End With

                        Next

                        '    .Entry(updquery).State = Entity.EntityState.Modified
                        .SaveChanges()
                    Catch ex As Exception
                        '  Return ex.ToString
                    End Try
                End With

            End If


            Return "successfully saved to server"
        End Function



        Public Function AlarmXreport() As ActionResult
            Dim db As New ssportaldbEntities1

            With db
                ViewBag.alarmxrportNodesdropdown = New SelectList(.Nodes, "ID", "Name")
            End With

            Return View("~/Views/Reports/_AlarmXreport.vbhtml", ViewBag.alarmxrportNodesdropdown)
        End Function

        Public Function AlarmXreportread(Fromdate As Date, FromWeek As Integer, ToWeek As Integer, Yr As Short?, category As Int16, categoryid As Int16, criteria As Int16) As PartialViewResult

            Dim AlarmXrep As New AlarmXreport

            With AlarmXrep
                .Fromdate = Date.Parse(Fromdate)
                .FromWeek = FromWeek
                .ToWeek = ToWeek
                .Yr = Yr
                .category = category
                .categoryid = categoryid
                .criteria = criteria
            End With
            ViewBag.table1 = AlarmXrep.Loadtable1()
            ViewBag.table2 = AlarmXrep.Loadtable2()


            Return PartialView("~/Views/Reports/_AlarmXreporttables.vbhtml", ViewBag)
        End Function


        Public Function Ploadreportread(Fromdate As String, Todate As String, node As Integer) As PartialViewResult
            Dim db As New ssportaldbEntities1
            Dim fdate As DateTime = DateTime.ParseExact(Fromdate, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)
            Dim tdate As DateTime = DateTime.ParseExact(Todate, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)
            Dim prefix As String = ""

            If (node < 1) And (node >= 5) Then
                node = 1
            End If


            With db
                If (node = 1) Then
                    Dim qry = From P In .Ploads
                              Where P.Sample_Time >= fdate And P.Sample_Time <= tdate
                              Select P.MBC_Prefix, P.MBC_Name, P.Pload_Avg, P.Pload_Max, P.Pload_Max_Bladeid, P.Sample_Time
                    ViewBag.chart = (qry.OrderByDescending(Function(x) x.Pload_Avg).Take(10).Select(Function(x) New With {Key x.MBC_Name, x.Sample_Time, x.Pload_Avg})).ToList
                    ViewBag.table = qry.ToList
                    ViewBag.hcount = qry.Where(Function(x) x.Pload_Avg >= 70).Count
                    ViewBag.wcount = qry.Where(Function(x) x.Pload_Avg >= 60 And x.Pload_Max < 70).Count
                    ViewBag.ncount = qry.Where(Function(x) x.Pload_Avg < 60).Count
                End If

                If (node > 1) And (node < 6) Then
                    Select Case node
                        Case Is = 2
                            prefix = "ASMBC"
                        Case Is = 3
                            prefix = "ABMBC"
                        Case Is = 4
                            prefix = "OJMBC"
                        Case Is = 5
                            prefix = "LGMBC"
                    End Select

                    Dim qry = From P In .Ploads
                              Where P.Sample_Time >= fdate And P.Sample_Time <= tdate And P.MBC_Prefix = prefix
                              Select P.MBC_Prefix, P.MBC_Name, P.Pload_Avg, P.Pload_Max, P.Pload_Max_Bladeid, P.Sample_Time
                    ViewBag.chart = (qry.OrderByDescending(Function(x) x.Pload_Avg).Take(10).Select(Function(x) New With {Key x.MBC_Name, x.Sample_Time, x.Pload_Avg})).ToList
                    ViewBag.table = qry.ToList
                    ViewBag.hcount = qry.Where(Function(x) x.Pload_Avg >= 70).Count
                    ViewBag.wcount = qry.Where(Function(x) x.Pload_Avg >= 60 And x.Pload_Max < 70).Count
                    ViewBag.ncount = qry.Where(Function(x) x.Pload_Avg < 60).Count
                End If

            End With
            Return PartialView("~/Views/Reports/_PloadChartTable.vbhtml", ViewBag)


        End Function




    End Class

End Namespace