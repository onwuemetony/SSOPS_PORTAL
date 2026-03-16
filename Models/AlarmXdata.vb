Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Alarms_copy")>
Partial Public Class AlarmXdata
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ID As Integer

    <StringLength(20)>
    Public Property Severity As String

    <StringLength(20)>
    Public Property Node As String

    <Column(TypeName:="datetime2")>
    Public Property Event_Time As Date?

    <StringLength(250)>
    Public Property Fault As String

    <StringLength(1000)>
    Public Property Description As String

    <StringLength(250)>
    Public Property Comment As String

    <StringLength(20)>
    Public Property Status As String

    Public Property UnitID As Short?

    <StringLength(20)>
    Public Property Owner As String

    Public Property Week As Byte?

    Public Property Year As Short?

    Public Property Update_date As Date?

    <StringLength(20)>
    Public Property Ticket As String

    <StringLength(1)>
    Public Property Modifies As String

    <StringLength(20)>
    Public Property Updated_By As String

    Public Overridable Property Unit As Unit
End Class

Public Class Alarmupdate

    Public Property ID As Integer

    <StringLength(20)>
    Public Property Ticket As String

    <StringLength(250)>
    Public Property Comment As String

    <StringLength(20)>
    Public Property Status As String

    Public Property UnitID As Short?

End Class
