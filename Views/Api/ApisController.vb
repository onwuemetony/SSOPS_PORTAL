'Imports System.Text
'Imports System.Net
'Imports System.Net.Http
'Imports System.Web
'Imports System.Web.Http
'Imports System.Web.Http.Controllers

''Imports System.Web.Mvc
'Imports Newtonsoft.Json
'Imports Newtonsoft.Json.Linq
'Imports System.Collections.Generic


'Namespace Controllers
'    Public Class Plldpapiuser(Of T)
'        Public Property UserName As String
'        Public Property pwd As String
'        Public Property JSON_list As List(Of T)
'    End Class
'    Public Class Plldp_JSON
'        Public Property Sample_Time As String
'        Public Property MBC_Prefix As String
'        Public Property Plldp_record As List(Of Plldp_record)
'    End Class
'    Public Class Plldp_record
'        Public Property MBC_Name As String
'        Public Property Pload_Avg As String
'        Public Property Pload_Max As String
'        Public Property Pload_Max_Bladeid As String

'    End Class



'    Public Class ApisController
'        Inherits ApiController

'        <HttpPost>
'        <AllowAnonymous>
'        <Authorize>
'        Public Function Pload() As System.Web.Http.IHttpActionResult
'            Try
'                Dim jsonString As String = Request.Content.ReadAsStringAsync().Result

'                ' Deserialize dynamically based on expected type (example with Person)
'                ' You’d need to know the type at runtime or have multiple endpoints
'                Dim rootData As Plldpapiuser(Of Plldp_JSON) = JsonConvert.DeserializeObject(Of Plldpapiuser(Of Plldp_JSON))(jsonString) ' voodoo to assign JSON to user

'                Dim username As String = rootData.UserName
'                Dim pwd As String = rootData.pwd

'                If pwd = "$oiPPE0983jkdg@" And username = "plldpapiuser" Then '$oiPPE0983jkdg@
'                    FormsAuthentication.SetAuthCookie(username, False)

'                    Dim responseMessage As New System.Text.StringBuilder()
'                    For Each item In rootData.JSON_list
'                        responseMessage.AppendLine($"Processed: {item.MBC_Prefix}")
'                    Next

'                    Return Ok("Authentication successful. Items processed:" & vbCrLf & responseMessage.ToString())
'                Else
'                    Return BadRequest("Invalid username or password")


'                End If
'            Catch ex As Exception
'                Return BadRequest("Error processing JSON: " & ex.Message)

'            End Try

'            Return BadRequest("Error processing JSON")
'        End Function
'    End Class

'End Namespace