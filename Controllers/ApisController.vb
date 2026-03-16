Imports System.Text
Imports System.Net
Imports System.Net.Http
Imports System.Web
Imports System.Web.Http
Imports System.Web.Http.Controllers

'Imports System.Web.Mvc
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports Microsoft.Ajax.Utilities
Imports System.Globalization
Imports System.Data.Entity.Infrastructure


Namespace Controllers
    Public Class Plldpapiuser(Of T)
        Public Property UserName As String
        Public Property pwd As String
        Public Property JSON_list As List(Of T)
    End Class
    Public Class Plldp_JSON
        Public Property Sample_Time As DateTime
        Public Property MBC_Prefix As String
        Public Property Plldp_record As List(Of Plldp_record)
    End Class
    Public Class Plldp_record
        Public Property MBC_Name As String
        Public Property Pload_Avg As String
        Public Property Pload_Max As String
        Public Property Pload_Max_Bladeid As String

    End Class



    Public Class ApisController
        Inherits Controller

        Public Function Pload_apiUpdate() As String

            Dim JSONdata As String = TryCast(TempData("JSONdata"), String)

            ' Try

            If Not JSONdata Is Nothing Then
                    Dim db As New ssportaldbEntities1
                    Dim pload As New Pload
                    Dim rootData As Plldp_JSON = JsonConvert.DeserializeObject(Of Plldp_JSON)(JSONdata)

                    Dim mbc_Prefix As String = rootData.MBC_Prefix
                'Dim sample_Time As String = DateTime.ParseExact(rootData.Sample_Time, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                Dim sample_Time As DateTime = rootData.Sample_Time
                'Dim sample_Time As String = rootData.Sample_Time

                ' For Each item In rootData
                For Each inner_item In rootData.Plldp_record
                        pload.MBC_Prefix = mbc_Prefix
                        pload.Sample_Time = sample_Time
                        pload.MBC_Name = inner_item.MBC_Name
                        pload.Pload_Avg = Decimal.Parse(inner_item.Pload_Avg)
                        pload.Pload_Max = Decimal.Parse(inner_item.Pload_Max)
                        pload.Pload_Max_Bladeid = Integer.Parse(inner_item.Pload_Max_Bladeid)
                        db.Ploads.Add(pload)
                        db.SaveChanges()
                    Next


                End If
                Return "DB update succeeded"
            ' Catch ex As Exception
            '  Return "Error processing JSON: " & ex.Message

            '  End Try

            Return "Error processing JSON"
        End Function
    End Class

End Namespace