Imports System.Configuration
Imports System.Data.Entity
Imports System.Data.Entity.Core.EntityClient

Module DbContextFactory
    Public Function GetSsPortalDbContext() As String
        ' Get the connection string from Azure / web.config
        'Dim connStr As String = ConfigurationManager.ConnectionStrings("ssportaldbEntities1")?.ConnectionString
        Dim connStr As String = System.Environment.GetEnvironmentVariable("ssportaldbEntities1")
        'connStr = ""

        Debug.WriteLine(connStr)


        If String.IsNullOrEmpty(connStr) Then
            Dim localMap As New ExeConfigurationFileMap With {
                .ExeConfigFilename = "Web.config.local" ' your local file
                }
            Dim config = ConfigurationManager.OpenMappedExeConfiguration(localMap, ConfigurationUserLevel.None)
            connStr = config.ConnectionStrings.ConnectionStrings("ssportaldbEntities1")?.ConnectionString
        End If
        ' Build the full EF connection string (metadata + provider)
        Dim efBuilder As New EntityConnectionStringBuilder()
        efBuilder.Provider = "System.Data.SqlClient"
        efBuilder.ProviderConnectionString = connStr
        efBuilder.Metadata = "res://*/Models.dbModel.csdl|res://*/Models.dbModel.ssdl|res://*/Models.dbModel.msl;"
        connStr = efBuilder.ToString()
        ' Pass the connection string to your DbContext constructor
        Return connStr
    End Function
End Module