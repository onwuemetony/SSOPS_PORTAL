Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Partial Public Class PortalappModel
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=PortalappModel")
    End Sub

    Public Overridable Property Alarms As DbSet(Of Alarm)
    Public Overridable Property Alarms_copy As DbSet(Of AlarmXdata)

    Public Overridable Property Nodes As DbSet(Of Node)

    Public Overridable Property sysdiagrams As DbSet(Of sysdiagram)
    Public Overridable Property Units As DbSet(Of Unit)
    Public Overridable Property Users As DbSet(Of User)
    Public Overridable Property Ploads As DbSet(Of Pload)




    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.Id)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.MBC_Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.MBC_Prefix) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.Sample_Time)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.Pload_Avg)

        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.Pload_Max)


        modelBuilder.Entity(Of Pload)() _
            .Property(Function(e) e.Pload_Max_Bladeid)


        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Severity) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Node) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Fault) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Description) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Comment) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Status) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Owner) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Ticket) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Modifies) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of Alarm)() _
            .Property(Function(e) e.Updated_By) _
            .IsUnicode(False)
        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Severity) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Node) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Fault) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Description) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Comment) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Status) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Owner) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Ticket) _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Modifies) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of AlarmXdata)() _
            .Property(Function(e) e.Updated_By) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Node)() _
            .Property(Function(e) e.Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Node)() _
            .Property(Function(e) e.Owner) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Node)() _
            .Property(Function(e) e.Region) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Node)() _
            .Property(Function(e) e.Location) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Node)() _
            .Property(Function(e) e.Type) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Unit)() _
            .Property(Function(e) e.Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Unit)() _
            .Property(Function(e) e.Description) _
            .IsUnicode(False)


        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Region) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Role) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Alternate) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Full_Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Unit) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Sub_Unit) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Unit_Supervised) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Sub_Unit_Supervised) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Location) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Last_Logon) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Authentication) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.Code) _
            .IsUnicode(False)


    End Sub
End Class
