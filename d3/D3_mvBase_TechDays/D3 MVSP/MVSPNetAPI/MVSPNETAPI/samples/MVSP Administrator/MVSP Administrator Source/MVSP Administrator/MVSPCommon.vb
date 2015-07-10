Module MVSPCommon
    Public MVSP As New rocketsoftware.MVSP.Pick
    Public MVSPFUNCTIONS As New rocketsoftware.MVSP.Functions

    Public mvsphostname As String = "localhost"
    Public mvspusername As String = My.User.Name
    Public mvsppassword As String
    Public mvspsocket As Integer = 9000
    Public mvspconfigname As String = ""
    Public connectiondir As String
    Public appdir As String = Environ("APPDATA")
    Public xmlfiledir As String = appdir & "\RocketSoftware\MVSP Administrator\"
    Public xmlconfigdir As String = xmlfiledir & "connection\"
    Public Function AccountMaint(ByVal maintFunction As String, ByVal accName As String) As Boolean
        Dim results As String = ""
        MVSP.ruleModule = "MVSP.ACCOUNT.MAINT.SUB"
        results = MVSP.MvCall(maintFunction & Chr(254) & accName)
        If MVSPFUNCTIONS.Extract(results, 1) = "0" Then
            If maintFunction = "ENABLE" Then
                MVSPMain.EnabledAccounts.Items.Add(accName)
            Else
                MVSPMain.DisabledAccounts.Items.Add(accName)
            End If

            AccountMaint = False
        Else
            AccountMaint = True
        End If
            results = Nothing
    End Function
    Public Function UserMaint(ByVal maintFunction As String, ByVal userName As String) As Boolean
        Dim results As String = ""
        MVSP.ruleModule = "MVSP.USER.MAINT.SUB"
        results = MVSP.MvCall(maintFunction & Chr(254) & userName)
        If MVSPFUNCTIONS.Extract(results, 1) = "0" Then
            If maintFunction = "ENABLE" Then
                MVSPMain.EnabledUsers.Items.Add(userName)
            Else
                MVSPMain.DisabledUsers.Items.Add(userName)
            End If

            UserMaint = False
        Else
            UserMaint = True
        End If
        results = Nothing
    End Function
End Module
