Imports System.IO
Public Class MVSPMain
    
    Dim xmlfunctions As New MVSPAdminConfig
    Dim disableddrag As Boolean = False
    Dim enableddrag As Boolean = False
    Dim dragfail As Boolean = True

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmabout As New MVSPAdminisratorAbout
        frmabout.ShowDialog()
        frmabout = Nothing
    End Sub

    Private Sub DisconnectMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectMenu.Click
        MVSP.CloseConnection()
        DisconnectMenu.Enabled = False
    End Sub
    Private Sub getconfigdetails()

        Dim item As String

        Select Case MVSP.Platform
            Case "D3"
                item = MVSP.FileReadu("MVSP.CONTROL", "CONFIG")
                TCPIPSocket.Value = Val(MVSPFUNCTIONS.extract(item, 1))
                If UCase(MVSPFUNCTIONS.extract(item, 2)) = "Y" Then
                    DiagLogYes.Checked = True
                Else
                    DiagLogNo.Checked = True
                End If
                CommGroup.Enabled = True
                item = MVSP.FileRead("MD", "ACCOUNT-COLDSTART")
                If MVSP.StatusCode = 202 Then
                    AutobootNo.Checked = True
                Else
                    AutobootYes.Checked = True
                End If
                fullAccountPath.Enabled = False
                NewUserName.Enabled = False
                NewUserPass.Enabled = False
                NewUserbtn.Enabled = False
            Case "MVBASE"
                item = MVSP.FileReadu("MVSP.CONTROL", "CONFIG")
                If UCase(MVSPFUNCTIONS.extract(item, 2)) = "Y" Then
                    DiagLogYes.Checked = True
                Else
                    DiagLogNo.Checked = False
                End If
                CommGroup.Enabled = False
                fullAccountPath.Enabled = False
            Case "UNIVERSE"
                item = MVSP.FileReadu("MVSP.CONTROL", "CONFIG")
                If UCase(MVSPFUNCTIONS.Extract(item, 2)) = "Y" Then
                    DiagLogYes.Checked = True
                Else
                    DiagLogNo.Checked = False
                End If
                CommGroup.Enabled = False
                fullAccountPath.Enabled = False
            Case Else

        End Select

    End Sub

    Private Sub MVSPMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MVSP.CloseConnection()
    End Sub


    Private Sub MVSPMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Windows.Forms.Cursor.Current = Cursors.AppStarting
        getconnectionlist()
        ConnectProgressBar.Visible = False
        System.Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub
    Private Sub getconnectionlist()
        Try
            Dim x As String
            Dim max As Integer = Len(xmlconfigdir) + 1
            Dim lpc As Integer = 0
            Dim dirs As String() = Directory.GetFiles(xmlconfigdir, "*.cfg")
            Dim dir As String
            For Each dir In dirs
                x = Mid(dir, max, 99)
                x = Mid(x, 1, Len(x) - 4)
                ConnectionList.Items.Add(x, x, 4)
                lpc = lpc + 1
            Next


        Catch ex As Exception
            Directory.CreateDirectory(appdir & "\TigerLogic")
            Directory.CreateDirectory(appdir & "\TigerLogic\MVSP Administrator")
            Directory.CreateDirectory(appdir & "\TigerLogic\MVSP Administrator\connection")
        End Try
    End Sub

    Private Sub ConnectionList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConnectionList.DoubleClick
        Dim cursorposition As Point = Me.ConnectionList.PointToClient(Control.MousePosition)
        Dim item As ListViewItem = Me.ConnectionList.GetItemAt(cursorposition.X, cursorposition.Y)

        xmlfunctions.load(item.Text & ".cfg")
        mvsphostname = xmlfunctions.getconfigxml("hostname")
        mvspusername = xmlfunctions.getconfigxml("username")
        mvspsocket = Val(xmlfunctions.getconfigxml("socket"))
        mvspconfigname = item.Text

        showlogin()
    End Sub

    Private Sub ConnectionList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectionList.SelectedIndexChanged

    End Sub
    Private Function showlogin() As Boolean
        Dim loginfrm As New MVSPLogin
        loginfrm.hostname = mvsphostname
        loginfrm.socket = mvspsocket
        loginfrm.username = mvspusername
        loginfrm.password = mvsppassword
        loginfrm.configname = mvspconfigname
        Dim rc As Boolean
        If loginfrm.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            loginfrm = Nothing
            Exit Function
        End If

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        ConnectProgressBar.Visible = True
        ConnectProgressBar.Value = 10

        rc = MVSP.connect(loginfrm.hostname, loginfrm.socket, loginfrm.username, loginfrm.password)

        ConnectProgressBar.Value = 50
        'System.Threading.Thread.Sleep(500)
        If rc = False Then
            MsgBox(MVSP.StatusMessage, MsgBoxStyle.Critical, "Connection Error")
            System.Windows.Forms.Cursor.Current = Cursors.Arrow
            ConnectProgressBar.Visible = False
            Return False
        Else
            mvsphostname = loginfrm.hostname
            mvspsocket = loginfrm.socket
            mvspusername = loginfrm.username
            mvsppassword = loginfrm.password
            mvspconfigname = loginfrm.configname
            Status.Text = "Connected"
            If mvspconfigname <> "" Then
                xmlfunctions.load(mvspconfigname & ".cfg")
                xmlfunctions.setconfigxml("hostname", mvsphostname)
                xmlfunctions.setconfigxml("username", mvspusername)
                xmlfunctions.setconfigxml("socket", mvspsocket)
                xmlfunctions.saveconfig(mvspconfigname & ".cfg")
            End If
            loginfrm = Nothing
            DisconnectMenu.Enabled = True
            ConnectProgressBar.Value = 50
            ServerNameTxt.Text = mvsphostname
            ServerPibTxt.Text = MVSP.connectedPib
            ServerPlatformTxt.Text = MVSP.platform
            ServerVersionTxt.Text = MVSP.serverVersion
            ServerSoftwareSerialNotxt.Text = MVSP.softwareSerialNo

            Call getconfigdetails()
            ConnectProgressBar.Value = 60
            Call getallaccounts()
            ConnectProgressBar.Value = 70
            Call getallusers()
            ConnectProgressBar.Value = 80
            Call getconnections()
            ConnectProgressBar.Value = 100
            'Call getallaccounts()
            System.Windows.Forms.Cursor.Current = Cursors.Arrow
            System.Threading.Thread.Sleep(100)
            ConnectProgressBar.Visible = False
            TabControl1.SelectTab(1)
        End If
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rc As Boolean
        rc = showlogin()
    End Sub
    Private Function getallaccounts() As String
        Dim tmp As String = ""
        Dim item As String = ""
        Dim item1 As String = ""
        Dim rc As Boolean
        Dim cnt As Integer = 0
        Dim maxcnt As Integer = 0
        Dim dsortedlist(1000) As String
        Dim esortedlist(1000) As String
        Dim emaxcnt As Integer = 0
        rc = MVSP.FileSelect("MVSP.SYSTEM")
        getallaccounts = ""
        Do
            tmp = MVSP.FileReadNext
            If MVSP.eol = False Then
                If UCase(tmp) <> "MVSP" Then
                    item = MVSP.FileRead("MVSP.SYSTEM", tmp)
                    item1 = MVSP.FileRead("MVSP.CONTROL,ACCOUNTS", tmp)
                    If MVSP.statusCode = 202 Then
                        If MVSP.platform = "UNIVERSE" Then
                            dsortedlist(maxcnt) = tmp
                            maxcnt = maxcnt + 1
                        Else

                            If UCase(Mid(MVSPFUNCTIONS.Extract(item, 1), 1, 1)) = "D" Then
                                dsortedlist(maxcnt) = tmp
                                maxcnt = maxcnt + 1
                            End If
                        End If
                    Else
                        esortedlist(emaxcnt) = tmp
                        emaxcnt = emaxcnt + 1
                    End If
                Else
                    'esortedlist(emaxcnt) = tmp
                    'emaxcnt = emaxcnt + 1
                End If
            End If
        Loop Until MVSP.eol = True
        maxcnt = maxcnt - 1
        Dim newlist(maxcnt) As String
        For cnt = 0 To (maxcnt)
            newlist(cnt) = dsortedlist(cnt)
        Next
        Array.Sort(newlist)
        emaxcnt = emaxcnt - 1
        Dim enewlist(emaxcnt) As String
        cnt = 0
        For cnt = 0 To emaxcnt
            enewlist(cnt) = esortedlist(cnt)
        Next
        DisabledAccounts.Items.Clear()
        EnabledAccounts.Items.Clear()
        cnt = 0
        'If MVSP.Platform = "D3" Then
        Do
            DisabledAccounts.Items.Add(newlist(cnt))
            cnt = cnt + 1
        Loop Until cnt > maxcnt
        cnt = 0
        If emaxcnt >= 0 Then
            Do
                EnabledAccounts.Items.Add(enewlist(cnt))
                cnt = cnt + 1
            Loop Until cnt > emaxcnt
        End If
        'End If
    End Function

    Private Sub DisabledAccounts_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DisabledAccounts.DragDrop
        Dim accName As String
        Dim results As String
        accName = e.Data.GetData(DataFormats.Text)
        MVSP.ruleModule = "MVSP.ACCOUNT.MAINT.SUB"
        results = MVSP.MvCall("DISABLE" & Chr(254) & accName)
        If MVSPFUNCTIONS.Extract(results, 1) = "0" Then
            DisabledAccounts.Items.Add(accName)
            dragfail = False
        Else
            dragfail = True
        End If
    End Sub

    Private Sub DisabledAccounts_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DisabledAccounts.DragEnter
        If e.KeyState <> 9 Then
            If disableddrag = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub DisabledAccounts_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DisabledAccounts.MouseDown
        Dim DragDropResult As System.Windows.Forms.DragDropEffects
        If e.Button = Windows.Forms.MouseButtons.Left Then
            disableddrag = True
            enableddrag = False
            DragDropResult = DisabledAccounts.DoDragDrop(DisabledAccounts.Items(DisabledAccounts.SelectedIndex), DragDropEffects.Move)
            If DragDropResult = DragDropEffects.Move And dragfail = False Then
                DisabledAccounts.Items.RemoveAt(DisabledAccounts.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub EnabledAccounts_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles EnabledAccounts.DragDrop
        Dim accName As String

        accName = e.Data.GetData(DataFormats.Text)
        
        dragfail = AccountMaint("ENABLE", accName)
        
        accName = Nothing
    End Sub

    Private Sub EnabledAccounts_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles EnabledAccounts.DragEnter
        If e.KeyState <> 9 Then
            If enableddrag = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Move
            End If            
        End If
    End Sub

    Private Sub EnabledAccounts_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles EnabledAccounts.MouseDown
        Dim DragDropResult As System.Windows.Forms.DragDropEffects
        If e.Button = Windows.Forms.MouseButtons.Left Then
            enableddrag = True
            disableddrag = False
            DragDropResult = DisabledAccounts.DoDragDrop(EnabledAccounts.Items(EnabledAccounts.SelectedIndex), DragDropEffects.Move)
            If DragDropResult = DragDropEffects.Move And dragfail = False Then
                EnabledAccounts.Items.RemoveAt(EnabledAccounts.SelectedIndex)
            End If
        End If
    End Sub

    
    Private Sub updateConfigbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateConfigbtn.Click

        Dim configrec As String = ""
        Dim tmp As String = ""

        MVSP.ruleModule = "MVSP.SERVER.MAINT.SUB"
        configrec = "UPDATE" & Chr(254) & TCPIPSocket.Value & Chr(254)
        If AutobootNo.Checked = True Then
            configrec = configrec & "N"
        Else
            configrec = configrec & "Y"
        End If
        tmp = MVSP.MvCall(configrec)
        If MVSPFUNCTIONS.Extract(tmp, 1, 1) <> "0" Then
            MsgBox("Update failed", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub enableAccountbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enableAccountbtn.Click
        Dim accname As String = ""
        accname = DisabledAccounts.SelectedItem
        If accname = "" Then Exit Sub
        dragfail = AccountMaint("ENABLE", accname)
        If dragfail = False Then
            DisabledAccounts.Items.RemoveAt(DisabledAccounts.SelectedIndex)
        End If
        accname = Nothing
    End Sub

    Private Sub disableAccountbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disableAccountbtn.Click
        Dim accname As String = ""
        accname = EnabledAccounts.SelectedItem
        If accname = "" Then Exit Sub
        dragfail = AccountMaint("DISABLE", accname)
        If dragfail = False Then
            EnabledAccounts.Items.RemoveAt(EnabledAccounts.SelectedIndex)
        End If
        accname = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectionsRefreshbtn.Click
        Call getconnections()
    End Sub
    Private Sub getconnections()
        Dim tmpString As String = ""
        Dim tmp1 As String = ""
        ConnectionListView.Items.Clear()
        ConnectionListView.Columns.Add("Pib", 40, HorizontalAlignment.Right)
        ConnectionListView.Columns.Add("Logon Date/Time", 100, HorizontalAlignment.Left)
        ConnectionListView.Columns.Add("MV User", 100, HorizontalAlignment.Left)
        ConnectionListView.Columns.Add("Client User", 120, HorizontalAlignment.Left)
        ConnectionListView.Columns.Add("Client Host", 150, HorizontalAlignment.Left)
        ConnectionListView.Columns.Add("Client App", 140, HorizontalAlignment.Left)
        ConnectionListView.Columns.Add("Client Env", 100, HorizontalAlignment.Left)

        MVSP.ExecuteQuery("QUERY", "MVSP.LINES", "", "BY PIB", "PIB LDATETIME MVUSER CUSER CHOST CAPP CENV", "")
        While MVSP.MVResultSetNext = True
            tmpString = MVSP.MVResultSetGetCurrentRow
            tmp1 = MVSPFUNCTIONS.Extract(tmpString, 2)
            tmp1 = MVSPFUNCTIONS.Swap(tmp1, Chr(253), " ")
            Dim item1 As New ListViewItem(MVSPFUNCTIONS.Extract(tmpString, 1), 0)
            item1.SubItems.Add(tmp1)
            item1.SubItems.Add(MVSPFUNCTIONS.Extract(tmpString, 3))
            item1.SubItems.Add(MVSPFUNCTIONS.Extract(tmpString, 4))
            item1.SubItems.Add(MVSPFUNCTIONS.Extract(tmpString, 5))
            item1.SubItems.Add(MVSPFUNCTIONS.Extract(tmpString, 6))
            item1.SubItems.Add(MVSPFUNCTIONS.Extract(tmpString, 7))
            ConnectionListView.Items.Add(item1)
        End While


    End Sub


    Private Function getallusers() As String
        Dim tmp As String = ""
        Dim item As String = ""
        Dim item1 As String = ""
        Dim rc As Boolean
        Dim cnt As Integer = 0
        Dim maxcnt As Integer = 0
        Dim dsortedlist(1000) As String
        Dim esortedlist(1000) As String
        Dim emaxcnt As Integer = 0
        rc = MVSP.FileSelect("MVSP.USERS")
        getallusers = ""
        Do
            tmp = MVSP.FileReadNext
            If MVSP.eol = False Then
                If UCase(tmp) <> "MVSP" And tmp.Contains("$") = False Then
                    item = MVSP.FileRead("MVSP.USERS", tmp)
                    If UCase(MVSPFUNCTIONS.Extract(item, 10)) = "Y" Then
                        esortedlist(emaxcnt) = tmp
                        emaxcnt = emaxcnt + 1
                    Else
                        dsortedlist(maxcnt) = tmp
                        maxcnt = maxcnt + 1
                    End If
                End If
            End If
        Loop Until MVSP.eol = True
        maxcnt = maxcnt - 1
        Dim newlist(maxcnt) As String
        For cnt = 0 To (maxcnt)
            newlist(cnt) = dsortedlist(cnt)
        Next
        Array.Sort(newlist)
        emaxcnt = emaxcnt - 1
        Dim enewlist(emaxcnt) As String
        cnt = 0
        For cnt = 0 To emaxcnt
            enewlist(cnt) = esortedlist(cnt)
        Next
        DisabledUsers.Items.Clear()
        EnabledUsers.Items.Clear()
        cnt = 0
        Try
            Do
                DisabledUsers.Items.Add(newlist(cnt))
                cnt = cnt + 1
            Loop Until cnt > maxcnt
        Catch ex As Exception
        End Try
        Try
            cnt = 0
            If emaxcnt >= 0 Then
                Do
                    EnabledUsers.Items.Add(enewlist(cnt))
                    cnt = cnt + 1
                Loop Until cnt > emaxcnt
            End If
        Catch ex As Exception
        End Try


    End Function
    Private Sub DisabledUsers_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DisabledUsers.DragDrop
        Dim username As String
        Dim results As String
        username = e.Data.GetData(DataFormats.Text)
        MVSP.ruleModule = "MVSP.User.MAINT.SUB"
        results = MVSP.MvCall("DISABLE" & Chr(254) & username)
        If MVSPFUNCTIONS.Extract(results, 1) = "0" Then
            DisabledUsers.Items.Add(username)
            dragfail = False
        Else
            dragfail = True
        End If
    End Sub

    Private Sub DisabledUsers_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DisabledUsers.DragEnter
        If e.KeyState <> 9 Then
            If disableddrag = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub DisabledUsers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DisabledUsers.MouseDown
        Dim DragDropResult As System.Windows.Forms.DragDropEffects
        If e.Button = Windows.Forms.MouseButtons.Left Then
            disableddrag = True
            enableddrag = False
            DragDropResult = DisabledUsers.DoDragDrop(DisabledUsers.Items(DisabledUsers.SelectedIndex), DragDropEffects.Move)
            If DragDropResult = DragDropEffects.Move And dragfail = False Then
                DisabledUsers.Items.RemoveAt(DisabledUsers.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub EnabledUsers_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles EnabledUsers.DragDrop
        Dim username As String

        username = e.Data.GetData(DataFormats.Text)
        
        dragfail = UserMaint("ENABLE", username)
        
        username = Nothing
    End Sub

    Private Sub EnabledUsers_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles EnabledUsers.DragEnter
        If e.KeyState <> 9 Then
            If enableddrag = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub EnabledUsers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles EnabledUsers.MouseDown
        Dim DragDropResult As System.Windows.Forms.DragDropEffects
        If e.Button = Windows.Forms.MouseButtons.Left Then
            enableddrag = True
            disableddrag = False
            DragDropResult = DisabledUsers.DoDragDrop(EnabledUsers.Items(EnabledUsers.SelectedIndex), DragDropEffects.Move)
            If DragDropResult = DragDropEffects.Move And dragfail = False Then
                EnabledUsers.Items.RemoveAt(EnabledUsers.SelectedIndex)
            End If
        End If
    End Sub
    Private Sub enableUserbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableUserbtn.Click
        Dim username As String = ""
        username = DisabledUsers.SelectedItem
        If username = "" Then Exit Sub
        dragfail = UserMaint("ENABLE", username)
        If dragfail = False Then
            DisabledUsers.Items.RemoveAt(DisabledUsers.SelectedIndex)
        End If
        username = Nothing
    End Sub

    Private Sub disableUserbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableUserbtn.Click
        Dim username As String = ""
        username = EnabledUsers.SelectedItem
        If username = "" Then Exit Sub
        dragfail = UserMaint("DISABLE", username)
        If dragfail = False Then
            EnabledUsers.Items.RemoveAt(EnabledUsers.SelectedIndex)
        End If
        username = Nothing
    End Sub

    Private Sub NewUserbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewUserbtn.Click
        If NewUserName.Text = "" Then
            MsgBox("Name cannot be null")
            Exit Sub
        End If
        Dim item As String
        Dim rc As String
        Dim params As String = "CREATE"
        item = MVSP.FileRead("MVSP.USERS", NewUserName.Text)
        If MVSP.statusCode = 202 Then
            MVSP.ruleModule = "MVSP.USER.MAINT.SUB"
            params = params & Chr(254) & NewUserName.Text & Chr(254) & NewUserPass.Text
            rc = MVSP.MvCall(params)
            If MVSPFUNCTIONS.Extract(rc, 1, 1) <> "0" Then
                MsgBox("Error creating user code=" & MVSPFUNCTIONS.Extract(rc, 1))
                Exit Sub
            End If
            Call getallusers()
        Else
            MsgBox("User already exists")
        End If
    End Sub
End Class
