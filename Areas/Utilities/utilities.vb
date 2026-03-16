

Imports System.Data.SqlClient
Imports System.Linq

Namespace Areas.utilities


    Public Class AlarmXusersrchsinglewk ' AlarmX app user search by single week
        Public Property Wk As Integer
        Public Property Yr As Integer
        Public Property User As String

    End Class
    Public Class Return_units
        Public Property rwliststr As String
        Public Property rwliststrsum As String
        Public Sub Return_units()
            Dim db As New PortalappModel
            rwliststr = ""
            rwliststrsum = ""
            Dim rwlist = (From U In db.Units Select U.Name).ToList
            For Each rw In rwlist
                rw = rw.Replace(vbCrLf, "")
                rwliststr &= "[" & rw & "],"
                rwliststrsum &= "([" & rw & "]) +"
            Next
            rwliststr = rwliststr.Remove(rwliststr.Length - 1)
            rwliststrsum = rwliststrsum.Remove(rwliststrsum.Length - 1)

        End Sub
    End Class

    Public Class AlarmXreport
        Public Fromdate As Date
        Public Nodeid As Integer

        Public FromWeek As Integer
        Public ToWeek As Integer

        Public Yr As Short?

        Public category As Int16

        Public categoryid As Int16

        Public criteria As Int16
        ' <StringLength(20)>
        'Public Property Ticket As String

        Public Function Loadtable1() As List(Of String)
            Dim db As New PortalappModel
            Dim srchquerystr As String = ""
            Dim subsrchquerystr As String = ""
            Dim subqrystr As String = " Where A.Week >=" & FromWeek & " And A.Week <= " & ToWeek & " And A.Year =" & Yr
            Dim fieldstr As String = ""
            Dim srchlist As List(Of String) = New List(Of String)
            Dim con As SqlConnection = db.Database.Connection
            Dim sqlcommand As SqlCommand
            Dim bool As Boolean = False
            Dim edate As String = Fromdate.AddDays(-28).ToString("yyyy-MM-dd HH:mm:ss")

            If criteria = 2 Then
                subqrystr &= " And A.Event_Time < '" & edate & "'"
            End If

            If criteria = 3 Then
                subqrystr &= " And A.Event_Time >= '" & edate & "'"
            End If

            ' category = 1 == summaries, category = 2 === nodes
            If category = 1 Then
                Select Case categoryid

                    Case = 1 ' Alarm status
                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & ") VERT " _
                                           & "PIVOT (COUNT(Status) For Status In (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 2 ' Alarm severity
                        srchquerystr = "Select *,(Critical + Major ) As Total " _
                                           & "FROM (Select A.Week,  A.Severity As Severity " _
                                            & "From dbo.Alarms AS A " & subqrystr & ") VERT " _
                                           & "PIVOT (COUNT(Severity) For Severity In (Critical,Major)) pt Order by Week"


                    Case = 3 ' Owner Units
                        Dim return_units As New Return_units
                        return_units.Return_units()
                        srchquerystr = "Select *,(" & return_units.rwliststrsum & ") As Total " _
                                           & "FROM (Select A.Week, U.Name As UNIT, A.Status As Status FROM Alarms As A " _
                                           & "Join Units As U On A.UnitID= U.ID" & subqrystr & ")  UNITS_VERT " _
                                           & "PIVOT (COUNT(Status) For UNIT In (" & return_units.rwliststr & ")) pt Order by Week"

                    Case = 4 ' Units Resolution
                        Dim return_units As New Return_units
                        return_units.Return_units()
                        srchquerystr = "Select *,(" & return_units.rwliststrsum & ") As Total " _
                                           & "FROM (Select A.Week, U.Name As UNIT, A.Status As Status FROM Alarms As A " _
                                           & "Join Units As U On A.UnitID= U.ID " & subqrystr & " And Status='Resolved')  UNITS_VERT " _
                                           & "PIVOT (COUNT(Status) For UNIT IN (" & return_units.rwliststr & ")) pt Order by Week"

                    Case = 5 ' Exemptions
                        srchquerystr = "SELECT * " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A" & subqrystr & " And Status ='Exemption')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 6 ' MBC

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A" & subqrystr & " And Node Like '%MBC%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 7 ' TSC

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%TSC%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 8 ' MGW

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%MGW%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"
                    Case = 9 ' HBC

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%HBC%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 10 ' CUDB

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%CUDB%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"

                    Case = 11 ' HSS

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%HSS%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"
                    Case = 12 ' STP

                        srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A " & subqrystr & " And Node Like '%STP%')  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"
                End Select
            End If

            If category = 2 Then
                srchquerystr = "SELECT *,(Resolved + Active + Exemption) AS Total " _
                                           & "FROM (Select  A.Week,  A.Status As Status " _
                                           & "From dbo.Alarms AS A Join Nodes AS N on A.Node = N.Name " & subqrystr & " And N.ID = " & categoryid & ")  VERT " _
                                           & "PIVOT (COUNT(Status) For Status IN (Resolved, Active, Exemption)) pt Order by Week"
            End If

            sqlcommand = New SqlCommand(srchquerystr, con)
            con.Open()

            Dim sqlreader As SqlDataReader = sqlcommand.ExecuteReader()
            With sqlreader
                srchlist.Add("")

                For i = 0 To (.FieldCount - 2)
                    fieldstr &= .GetName(i) & ","
                Next
                srchlist.Item(0) = fieldstr & .GetName(.FieldCount - 1)


                If .HasRows Then
                    While .Read()
                        fieldstr = ""
                        For i = 0 To (.FieldCount - 2)
                            fieldstr &= .Item(i) & ","
                        Next
                        srchlist.Add(fieldstr & .Item(.FieldCount - 1))
                    End While
                End If

            End With
            sqlreader.Close()
            con.Close()


            Return srchlist

            'Return srchlist
        End Function


        Public Function Loadtable2() As IEnumerable
            Dim db As New PortalappModel
            Dim srchquerystr As String = ""
            Dim srchquery As IEnumerable = Nothing
            'Dim srchquery1 As IEnumerable
            Dim sdate As Date = Fromdate.AddDays(-1825)
            Dim edate As Date = Fromdate.AddDays(1825)
            Dim sdatestr, edatestr As String

            Select Case criteria
                Case 2
                    sdate = Fromdate.AddDays(-1825)
                    edate = Fromdate.AddDays(-28)
                Case 3
                    sdate = Fromdate.AddDays(-28)
                    edate = Fromdate.AddDays(1825)
            End Select

            sdatestr = sdate.ToString("yyyy-mm-dd hh:mm:ss")
            edatestr = edate.ToString("yyyy-mm-dd hh:mm:ss")

            With db

                ' category = 1 == summaries, category = 2 === nodes
                If category = 1 Then

                    Select Case categoryid

                        Case = 1, 2, 3 ' 1 - Alarm status, 2- Alarm severity, 3 - Owner Units

                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 4 ' Units Resolution
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Status = "Resolved" And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner


                        Case = 5 ' Exemptions
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Status = "Exemption" And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 6 ' MBC
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("MBC") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 7 ' TSC
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("TSC") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner


                        Case = 8 ' MGW

                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("MGW") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 9 ' HBC

                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("HBC") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 10 ' CUDB

                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("CUDB") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 11 ' HSS
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("HSS") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                        Case = 12 ' STP
                            srchquery = From A In .Alarms  ' build basic query
                                        Join N In .Nodes On A.Node Equals N.Name
                                        Join U In .Units On A.UnitID Equals U.ID
                                        Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And A.Node.Contains("STP") And A.Event_Time > sdate And A.Event_Time <= edate
                                        Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner

                    End Select
                End If

                If category = 2 Then
                    srchquery = From A In .Alarms  ' retrieve individual nodes
                                Join N In .Nodes On A.Node Equals N.Name
                                Join U In .Units On A.UnitID Equals U.ID
                                Where A.Week >= FromWeek And A.Week <= ToWeek And A.Year = Yr And N.ID = categoryid And A.Event_Time > sdate And A.Event_Time <= edate
                                Select A.Week, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, A.UnitID, U.Name, A.Owner
                End If





            End With

            Return srchquery

        End Function

    End Class

End Namespace