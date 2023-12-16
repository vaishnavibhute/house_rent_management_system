﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34209
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Partial Public Class houserentmgtsystemCacheClientSyncProvider
    Inherits Microsoft.Synchronization.Data.SqlServerCe.SqlCeClientSyncProvider
    
    Public Sub New()
        MyBase.New
        Me.ConnectionString = Global.HouseRentMgtsystem.My.MySettings.Default.ClientHOUSERENTMGTSYSTEMConnectionString
    End Sub
    
    Public Sub New(ByVal connectionString As String)
        MyBase.New
        Me.ConnectionString = connectionString
    End Sub
End Class

Partial Public Class houserentmgtsystemCacheSyncAgent
    Inherits Microsoft.Synchronization.SyncAgent
    
    Private _tenantTb1SyncTable As TenantTb1SyncTable
    
    Partial Private Sub OnInitialized()
    End Sub
    
    Public Sub New()
        MyBase.New
        Me.InitializeSyncProviders
        Me.InitializeSyncTables
        Me.OnInitialized
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Property TenantTb1() As TenantTb1SyncTable
        Get
            Return Me._tenantTb1SyncTable
        End Get
        Set
            Me.Configuration.SyncTables.Remove(Me._tenantTb1SyncTable)
            Me._tenantTb1SyncTable = value
            Me.Configuration.SyncTables.Add(Me._tenantTb1SyncTable)
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeSyncProviders()
        'Create SyncProviders.
        Me.RemoteProvider = New houserentmgtsystemCacheServerSyncProvider()
        Me.LocalProvider = New houserentmgtsystemCacheClientSyncProvider()
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeSyncTables()
        'Create SyncTables.
        Me._tenantTb1SyncTable = New TenantTb1SyncTable()
        Me._tenantTb1SyncTable.SyncGroup = New Microsoft.Synchronization.Data.SyncGroup("TenantTb1SyncTableSyncGroup")
        Me.Configuration.SyncTables.Add(Me._tenantTb1SyncTable)
    End Sub
    
    Partial Public Class TenantTb1SyncTable
        Inherits Microsoft.Synchronization.Data.SyncTable
        
        Partial Private Sub OnInitialized()
        End Sub
        
        Public Sub New()
            MyBase.New
            Me.InitializeTableOptions
            Me.OnInitialized
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitializeTableOptions()
            Me.TableName = "TenantTb1"
            Me.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable
        End Sub
    End Class
End Class


Partial Public Class TenantTb1SyncAdapter
    Inherits Microsoft.Synchronization.Data.Server.SyncAdapter
    
    Partial Private Sub OnInitialized()
    End Sub
    
    Public Sub New()
        MyBase.New
        Me.InitializeCommands
        Me.InitializeAdapterProperties
        Me.OnInitialized
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeCommands()
        'TenantTb1SyncTableInsertCommand command.
        Me.InsertCommand = New System.Data.SqlClient.SqlCommand()
        Me.InsertCommand.CommandText = " SET IDENTITY_INSERT dbo.TenantTb1 ON ;WITH CHANGE_TRACKING_CONTEXT (@sync_client"& _ 
            "_id_binary) INSERT INTO dbo.TenantTb1 ([TenId], [TenName], [TenPhone], [TenGen])"& _ 
            " VALUES (@TenId, @TenName, @TenPhone, @TenGen) SET @sync_row_count = @@rowcount;"& _ 
            " IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.TenantTb1')) > @sync_last_"& _ 
            "received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking "& _ 
            "information for table ''%s''. To recover from this error, the client must reinit"& _ 
            "ialize its local database and try again',16,3,N'dbo.TenantTb1')  SET IDENTITY_IN"& _ 
            "SERT dbo.TenantTb1 OFF "
        Me.InsertCommand.CommandType = System.Data.CommandType.Text
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenId", System.Data.SqlDbType.Int))
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenName", System.Data.SqlDbType.VarChar))
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenPhone", System.Data.SqlDbType.VarChar))
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenGen", System.Data.SqlDbType.VarChar))
        Dim insertcommand_sync_row_countParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int)
        insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output
        Me.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter)
        Me.InsertCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        'TenantTb1SyncTableDeleteCommand command.
        Me.DeleteCommand = New System.Data.SqlClient.SqlCommand()
        Me.DeleteCommand.CommandText = ";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) DELETE dbo.TenantTb1 FROM "& _ 
            "dbo.TenantTb1 JOIN CHANGETABLE(VERSION dbo.TenantTb1, ([TenId]), (@TenId)) CT  O"& _ 
            "N CT.[TenId] = dbo.TenantTb1.[TenId] WHERE (@sync_force_write = 1 OR CT.SYS_CHAN"& _ 
            "GE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT"& _ 
            ".SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_bina"& _ 
            "ry)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(obje"& _ 
            "ct_id(N'dbo.TenantTb1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Ch"& _ 
            "ange Tracking has cleaned up tracking information for table ''%s''. To recover f"& _ 
            "rom this error, the client must reinitialize its local database and try again',1"& _ 
            "6,3,N'dbo.TenantTb1') "
        Me.DeleteCommand.CommandType = System.Data.CommandType.Text
        Me.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
        Me.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenId", System.Data.SqlDbType.Int))
        Me.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit))
        Me.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Dim deletecommand_sync_row_countParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int)
        deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output
        Me.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter)
        'TenantTb1SyncTableUpdateCommand command.
        Me.UpdateCommand = New System.Data.SqlClient.SqlCommand()
        Me.UpdateCommand.CommandText = ";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) UPDATE dbo.TenantTb1 SET ["& _ 
            "TenName] = @TenName, [TenPhone] = @TenPhone, [TenGen] = @TenGen FROM dbo.TenantT"& _ 
            "b1  JOIN CHANGETABLE(VERSION dbo.TenantTb1, ([TenId]), (@TenId)) CT  ON CT.[TenI"& _ 
            "d] = dbo.TenantTb1.[TenId] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION"& _ 
            " IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANG"& _ 
            "E_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @"& _ 
            "sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'db"& _ 
            "o.TenantTb1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Track"& _ 
            "ing has cleaned up tracking information for table ''%s''. To recover from this e"& _ 
            "rror, the client must reinitialize its local database and try again',16,3,N'dbo."& _ 
            "TenantTb1') "
        Me.UpdateCommand.CommandType = System.Data.CommandType.Text
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenName", System.Data.SqlDbType.VarChar))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenPhone", System.Data.SqlDbType.VarChar))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenGen", System.Data.SqlDbType.VarChar))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenId", System.Data.SqlDbType.Int))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Me.UpdateCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
        Dim updatecommand_sync_row_countParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int)
        updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output
        Me.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter)
        'TenantTb1SyncTableSelectConflictDeletedRowsCommand command.
        Me.SelectConflictDeletedRowsCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectConflictDeletedRowsCommand.CommandText = "SELECT CT.[TenId], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM CHANGETABLE("& _ 
            "CHANGES dbo.TenantTb1, @sync_last_received_anchor) CT WHERE (CT.[TenId] = @TenId"& _ 
            " AND CT.SYS_CHANGE_OPERATION = 'D')"
        Me.SelectConflictDeletedRowsCommand.CommandType = System.Data.CommandType.Text
        Me.SelectConflictDeletedRowsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectConflictDeletedRowsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenId", System.Data.SqlDbType.Int))
        'TenantTb1SyncTableSelectConflictUpdatedRowsCommand command.
        Me.SelectConflictUpdatedRowsCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectConflictUpdatedRowsCommand.CommandText = "SELECT dbo.TenantTb1.[TenId], [TenName], [TenPhone], [TenGen], CT.SYS_CHANGE_CONT"& _ 
            "EXT, CT.SYS_CHANGE_VERSION FROM dbo.TenantTb1 JOIN CHANGETABLE(VERSION dbo.Tenan"& _ 
            "tTb1, ([TenId]), (@TenId)) CT  ON CT.[TenId] = dbo.TenantTb1.[TenId]"
        Me.SelectConflictUpdatedRowsCommand.CommandType = System.Data.CommandType.Text
        Me.SelectConflictUpdatedRowsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TenId", System.Data.SqlDbType.Int))
        'TenantTb1SyncTableSelectIncrementalInsertsCommand command.
        Me.SelectIncrementalInsertsCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectIncrementalInsertsCommand.CommandText = "IF @sync_initialized = 0 SELECT dbo.TenantTb1.[TenId], [TenName], [TenPhone], [Te"& _ 
            "nGen] FROM dbo.TenantTb1 LEFT OUTER JOIN CHANGETABLE(CHANGES dbo.TenantTb1, @syn"& _ 
            "c_last_received_anchor) CT ON CT.[TenId] = dbo.TenantTb1.[TenId] WHERE (CT.SYS_C"& _ 
            "HANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary) ELSE  "& _ 
            "BEGIN SELECT dbo.TenantTb1.[TenId], [TenName], [TenPhone], [TenGen] FROM dbo.Ten"& _ 
            "antTb1 JOIN CHANGETABLE(CHANGES dbo.TenantTb1, @sync_last_received_anchor) CT ON"& _ 
            " CT.[TenId] = dbo.TenantTb1.[TenId] WHERE (CT.SYS_CHANGE_OPERATION = 'I' AND CT."& _ 
            "SYS_CHANGE_CREATION_VERSION  <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CON"& _ 
            "TEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRA"& _ 
            "CKING_MIN_VALID_VERSION(object_id(N'dbo.TenantTb1')) > @sync_last_received_ancho"& _ 
            "r RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information fo"& _ 
            "r table ''%s''. To recover from this error, the client must reinitialize its loc"& _ 
            "al database and try again',16,3,N'dbo.TenantTb1')  END "
        Me.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text
        Me.SelectIncrementalInsertsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit))
        Me.SelectIncrementalInsertsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectIncrementalInsertsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
        Me.SelectIncrementalInsertsCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt))
        'TenantTb1SyncTableSelectIncrementalDeletesCommand command.
        Me.SelectIncrementalDeletesCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectIncrementalDeletesCommand.CommandText = "IF @sync_initialized > 0  BEGIN SELECT CT.[TenId] FROM CHANGETABLE(CHANGES dbo.Te"& _ 
            "nantTb1, @sync_last_received_anchor) CT WHERE (CT.SYS_CHANGE_OPERATION = 'D' AND"& _ 
            " CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT I"& _ 
            "S NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_"& _ 
            "MIN_VALID_VERSION(object_id(N'dbo.TenantTb1')) > @sync_last_received_anchor RAIS"& _ 
            "ERROR (N'SQL Server Change Tracking has cleaned up tracking information for tabl"& _ 
            "e ''%s''. To recover from this error, the client must reinitialize its local dat"& _ 
            "abase and try again',16,3,N'dbo.TenantTb1')  END "
        Me.SelectIncrementalDeletesCommand.CommandType = System.Data.CommandType.Text
        Me.SelectIncrementalDeletesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit))
        Me.SelectIncrementalDeletesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectIncrementalDeletesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectIncrementalDeletesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
        'TenantTb1SyncTableSelectIncrementalUpdatesCommand command.
        Me.SelectIncrementalUpdatesCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectIncrementalUpdatesCommand.CommandText = "IF @sync_initialized > 0  BEGIN SELECT dbo.TenantTb1.[TenId], [TenName], [TenPhon"& _ 
            "e], [TenGen] FROM dbo.TenantTb1 JOIN CHANGETABLE(CHANGES dbo.TenantTb1, @sync_la"& _ 
            "st_received_anchor) CT ON CT.[TenId] = dbo.TenantTb1.[TenId] WHERE (CT.SYS_CHANG"& _ 
            "E_OPERATION = 'U' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT"& _ 
            ".SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary))"& _ 
            "; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.TenantTb1')) > @sync_last"& _ 
            "_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking"& _ 
            " information for table ''%s''. To recover from this error, the client must reini"& _ 
            "tialize its local database and try again',16,3,N'dbo.TenantTb1')  END "
        Me.SelectIncrementalUpdatesCommand.CommandType = System.Data.CommandType.Text
        Me.SelectIncrementalUpdatesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit))
        Me.SelectIncrementalUpdatesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectIncrementalUpdatesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt))
        Me.SelectIncrementalUpdatesCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary))
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeAdapterProperties()
        Me.TableName = "TenantTb1"
    End Sub
End Class

Partial Public Class houserentmgtsystemCacheServerSyncProvider
    Inherits Microsoft.Synchronization.Data.Server.DbServerSyncProvider
    
    Private _tenantTb1SyncAdapter As TenantTb1SyncAdapter
    
    Partial Private Sub OnInitialized()
    End Sub
    
    Public Sub New()
        MyBase.New
        Dim connectionString As String = Global.HouseRentMgtsystem.My.MySettings.Default.houserentmgtsystemConnectionString
        Me.InitializeConnection(connectionString)
        Me.InitializeSyncAdapters
        Me.InitializeNewAnchorCommand
        Me.OnInitialized
    End Sub
    
    Public Sub New(ByVal connectionString As String)
        MyBase.New
        Me.InitializeConnection(connectionString)
        Me.InitializeSyncAdapters
        Me.InitializeNewAnchorCommand
        Me.OnInitialized
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Property TenantTb1SyncAdapter() As TenantTb1SyncAdapter
        Get
            Return Me._tenantTb1SyncAdapter
        End Get
        Set
            Me._tenantTb1SyncAdapter = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeConnection(ByVal connectionString As String)
        Me.Connection = New System.Data.SqlClient.SqlConnection(connectionString)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeSyncAdapters()
        'Create SyncAdapters.
        Me._tenantTb1SyncAdapter = New TenantTb1SyncAdapter()
        Me.SyncAdapters.Add(Me._tenantTb1SyncAdapter)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitializeNewAnchorCommand()
        'selectNewAnchorCmd command.
        Me.SelectNewAnchorCommand = New System.Data.SqlClient.SqlCommand()
        Me.SelectNewAnchorCommand.CommandText = "Select @sync_new_received_anchor = CHANGE_TRACKING_CURRENT_VERSION()"
        Me.SelectNewAnchorCommand.CommandType = System.Data.CommandType.Text
        Dim selectnewanchorcommand_sync_new_received_anchorParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt)
        selectnewanchorcommand_sync_new_received_anchorParameter.Direction = System.Data.ParameterDirection.Output
        Me.SelectNewAnchorCommand.Parameters.Add(selectnewanchorcommand_sync_new_received_anchorParameter)
    End Sub
End Class