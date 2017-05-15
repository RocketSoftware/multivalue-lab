VERSION 5.00
Begin VB.Form frmadoodbcx 
   Caption         =   "[adoodbcx] SQL via ADO/ ODBC  (Q00677)"
   ClientHeight    =   3915
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8490
   LinkTopic       =   "Form1"
   MinButton       =   0   'False
   ScaleHeight     =   3915
   ScaleWidth      =   8490
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdDelete 
      Caption         =   "SQL Delete"
      Enabled         =   0   'False
      Height          =   495
      Left            =   4920
      TabIndex        =   18
      Top             =   3360
      Width           =   1095
   End
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "SQL Update"
      Enabled         =   0   'False
      Height          =   495
      Left            =   3720
      TabIndex        =   17
      Top             =   3360
      Width           =   1095
   End
   Begin VB.CommandButton cmdInSert 
      Caption         =   "SQL Insert"
      Enabled         =   0   'False
      Height          =   495
      Left            =   2520
      TabIndex        =   16
      Top             =   3360
      Width           =   1095
   End
   Begin VB.CommandButton cmdSelect 
      Caption         =   "SQL Select"
      Enabled         =   0   'False
      Height          =   495
      Left            =   1320
      TabIndex        =   14
      Top             =   3360
      Width           =   1095
   End
   Begin VB.TextBox txtSQL 
      Height          =   975
      Left            =   840
      MultiLine       =   -1  'True
      TabIndex        =   13
      Top             =   1800
      Width           =   7575
   End
   Begin VB.ListBox lstTables 
      Height          =   1230
      Left            =   3960
      TabIndex        =   11
      Top             =   480
      Width           =   4455
   End
   Begin VB.Frame FrLogin 
      Caption         =   "Login"
      Height          =   1695
      Left            =   120
      TabIndex        =   4
      Top             =   0
      Width           =   3735
      Begin VB.ComboBox cboDSNList 
         Height          =   315
         ItemData        =   "adoodbcx.frx":0000
         Left            =   1800
         List            =   "adoodbcx.frx":0002
         Sorted          =   -1  'True
         Style           =   2  'Dropdown List
         TabIndex        =   15
         Top             =   240
         Width           =   1800
      End
      Begin VB.TextBox txtPWD 
         Height          =   375
         IMEMode         =   3  'DISABLE
         Left            =   1800
         PasswordChar    =   "*"
         TabIndex        =   9
         Top             =   1200
         Width           =   1815
      End
      Begin VB.TextBox txtUID 
         Height          =   375
         Left            =   1800
         TabIndex        =   7
         Top             =   720
         Width           =   1815
      End
      Begin VB.Label Label5 
         BackColor       =   &H80000018&
         Caption         =   "Password"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000001&
         Height          =   375
         Left            =   120
         TabIndex        =   8
         Top             =   1200
         Width           =   1575
      End
      Begin VB.Label Label4 
         BackColor       =   &H80000018&
         Caption         =   "User Name"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000001&
         Height          =   375
         Left            =   120
         TabIndex        =   6
         Top             =   720
         Width           =   1575
      End
      Begin VB.Label Label1 
         BackColor       =   &H80000018&
         Caption         =   "ODBC DSN"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000001&
         Height          =   375
         Left            =   120
         TabIndex        =   5
         Top             =   240
         Width           =   1575
      End
   End
   Begin VB.CommandButton cmdDisConnect 
      Caption         =   "DisConnect"
      Enabled         =   0   'False
      Height          =   495
      Left            =   6120
      TabIndex        =   3
      Top             =   3360
      Width           =   1095
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "Connect"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   3360
      Width           =   1095
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   495
      Left            =   7320
      TabIndex        =   1
      Top             =   3360
      Width           =   1095
   End
   Begin VB.Label lblSQL 
      BackColor       =   &H80000018&
      Caption         =   "SQL"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000001&
      Height          =   375
      Left            =   120
      TabIndex        =   12
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label lblRecordList 
      BackColor       =   &H80000018&
      Caption         =   "Record List:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000001&
      Height          =   255
      Left            =   3960
      TabIndex        =   10
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label msgs 
      BackColor       =   &H80000018&
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   2880
      Width           =   8295
   End
End
Attribute VB_Name = "frmadoodbcx"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'   Pogram project  : adoodbcx.zip
'   Pogram function : Demo to run SQL SELECT, INSERT, UPDATE AND DELETE statements.
'           via UniOLEDB ADO / ODBC Server connection.
'   Comparable ver. : UniData 6.x & UniVerse 10.x.
'   Date : 4/2/2007 (version 1.2)
'
'   ver 1.1: support native select SQL command
'       UV sample: {NATIVE 'SELECT * FROM CUSTOMER;'}
'   ver 1.2: After the session is disconnected, destroy the session object
'
Private Declare Function SQLDataSources Lib "ODBC32.DLL" (ByVal henv&, ByVal fDirection%, ByVal szDSN$, ByVal cbDSNMax%, pcbDSN%, ByVal szDescription$, ByVal cbDescriptionMax%, pcbDescription%) As Integer
Private Declare Function SQLAllocEnv% Lib "ODBC32.DLL" (env&)
Const SQL_SUCCESS As Long = 0
Const SQL_FETCH_NEXT As Long = 1
'
Dim cnnUnidata As New ADODB.Connection
Dim rstTables As ADODB.Recordset
Dim cmdADO As ADODB.Command
Dim rstADO As New ADODB.Recordset
Dim errloop As ADODB.Error
Dim btnOpt As Integer
Dim glVersion As String

Private Sub cmdConnect_Click()
Dim strConnect As String
On Error GoTo Error_Connect
    '
    ' ADO / ODBC
    cnnUnidata.Provider = "MSDASQL.1"
    'cnnUnidata.Provider = "MSDASQL"
    '
    strConnect = "DSN=" & cboDSNList.Text & "; " & _
                "Persist Security Info=True;" & _
                "USER ID=" & txtUID.Text & "; " & _
                "PASSWORD=" & txtPWD.Text & "; "
    '
    ' adUseServer
    '
    cnnUnidata.CursorLocation = adUseServer
    cnnUnidata.ConnectionString = strConnect
    cnnUnidata.ConnectionTimeout = 10
    cnnUnidata.Open
    '
    cmdConnect.Enabled = False
    cmdSelect.Enabled = True
    cmdInSert.Enabled = True
    cmdUpdate.Enabled = True
    cmdDelete.Enabled = True
    cmdDisConnect.Enabled = True
    msgs.Caption = "ODBC server has been connected !"
    Exit Sub
    '
Error_Connect:
    MsgBox "Error: " & Err.Number & " - " & Err.Description & vbCrLf & _
        "Source: " & Err.Source & vbCrLf & vbCrLf
End Sub

Private Sub cmdDelete_Click()
Dim tmp As String
Dim i As Integer
Dim Recordsaffected As Long
    '
On Error GoTo Error_Update
    tmp = txtSQL
    If Len(tmp) < 7 Then
        msgs.Caption = "Please check the SQL syntax"
        Exit Sub
    Else
        tmp = UCase(Mid(tmp, 1, 6))
        If StrComp(tmp, "DELETE", vbTextCompare) = 0 Then
        Else
            msgs.Caption = "Please check the SQL syntax"
            Exit Sub
        End If
    End If
    '
    msgs.Caption = ""
    msgs.Refresh
    '
    Set cmdADO = New ADODB.Command
    cmdADO.ActiveConnection = cnnUnidata
    '
    cmdADO.CommandType = adCmdText
    cmdADO.CommandText = txtSQL
    cmdADO.Execute Recordsaffected
    '
    msgs.Caption = Str(Recordsaffected) & " records have been deleted successfully!"
    '
    btnOpt = 1
    Set cmdADO = Nothing
    '
    Exit Sub
    '
Error_Update:
    If cnnUnidata.Errors.Count > 0 Then
        'Set errloop = cnnUnidata.Errors
        For Each errloop In cnnUnidata.Errors
            MsgBox "Error number: " & errloop.Number & vbCr & _
            errloop.Description
        Next errloop
    End If
    msgs.Caption = "SQL DELETE error !"
    '
End Sub

Private Sub cmdDisConnect_Click()
    '
On Error GoTo Error_DisConnect
    msgs.Caption = ""
    lstTables.Clear
    cnnUnidata.Close
    Set cnnUnidata = Nothing
    '
    cmdConnect.Enabled = True
    cmdDisConnect.Enabled = False
    cmdSelect.Enabled = False
    cmdInSert.Enabled = False
    cmdUpdate.Enabled = False
    cmdDelete.Enabled = False
    Exit Sub
    '
Error_DisConnect:
    MsgBox "Error: " & Err.Number & " - " & Err.Description & vbCrLf & _
        "Source: " & Err.Source & vbCrLf & vbCrLf & _
        "Unable to disconnect! Aborting."
    '
End Sub

Private Sub cmdExit_Click()
    On Error Resume Next
    cnnUnidata.Close
    Set cnnUnidata = Nothing
    '
    End
End Sub

Private Sub cmdInSert_Click()
Dim starttime As Variant
Dim tmp As String
Dim i As Integer
Dim Recordsaffected As Long
    '
On Error GoTo Error_Insert
    tmp = txtSQL
    If Len(tmp) < 7 Then
        msgs.Caption = "Please check the SQL syntax"
        Exit Sub
    Else
        tmp = UCase(Mid(tmp, 1, 6))
        If StrComp(tmp, "INSERT", vbTextCompare) = 0 Then
        Else
            msgs.Caption = "Please check the SQL syntax"
            Exit Sub
        End If
    End If
    '
    msgs.Caption = ""
    msgs.Refresh
    '
    Set cmdADO = New ADODB.Command
    cmdADO.ActiveConnection = cnnUnidata
    '
    cmdADO.CommandType = adCmdText
    cmdADO.CommandText = txtSQL
    cmdADO.Execute Recordsaffected
    '
    msgs.Caption = Str(Recordsaffected) & " records have inserted successfully!"
    '
    btnOpt = 1
    Set cmdADO = Nothing
    '
    msgs.Caption = Str(Recordsaffected) & " records have inserted successfully!"
    Exit Sub
    '
Error_Insert:
    If cnnUnidata.Errors.Count > 0 Then
        'Set errloop = cnnUnidata.Errors
        For Each errloop In cnnUnidata.Errors
            MsgBox "Error number: " & errloop.Number & vbCr & _
            errloop.Description
        Next errloop
    End If
    msgs.Caption = "SQL INSERT error !"
    '
End Sub

Private Sub cmdSelect_Click()
Dim starttime As Variant
Dim tmp As String
Dim i As Integer
    '
On Error GoTo Error_Select
    tmp = txtSQL
    If Len(tmp) < 7 Then
        msgs.Caption = "Please check the SQL syntax"
        Exit Sub
    Else
        tmp = UCase(Mid(tmp, 1, 6))
        If StrComp(tmp, "SELECT", vbTextCompare) = 0 Then
        Else
            i = InStr(1, txtSQL, "native", vbTextCompare)
            If i > 0 Then
            Else
                msgs.Caption = "Please check the SQL syntax"
                Exit Sub
            End If
        End If
    End If
    '
    msgs.Caption = ""
    msgs.Refresh
    starttime = Now
    '
    Set cmdADO = New ADODB.Command
    cmdADO.ActiveConnection = cnnUnidata
    '
    cmdADO.CommandType = adCmdText
    cmdADO.CommandText = txtSQL
    Set rstADO = cmdADO.Execute()
    '
    lstTables.Clear
    Do While Not rstADO.EOF
        'tmp = rstADO!ID & " " & rstADO!LNAME
        tmp = rstADO.Fields.Item(0)
        For i = 1 To rstADO.Fields.Count - 1
            tmp = tmp & " " & rstADO.Fields.Item(i)
        Next i
        lstTables.AddItem tmp
        rstADO.MoveNext
    Loop
    '
    btnOpt = 1
    Set rstADO = Nothing
    Set cmdADO = Nothing
    '
    tmp = DateDiff("s", starttime, Now)
    msgs.Caption = "SQL SELECT statement has been executed for " & tmp & " secs successfully! "
    Exit Sub
    '
Error_Select:
    If cnnUnidata.Errors.Count > 0 Then
        'Set errloop = cnnUnidata.Errors
        For Each errloop In cnnUnidata.Errors
            MsgBox "Error number: " & errloop.Number & vbCr & _
            errloop.Description
        Next errloop
    End If
    msgs.Caption = "SQL SELECT error !"
    '
End Sub

Private Sub cmdUpdate_Click()
Dim tmp As String
Dim i As Integer
Dim Recordsaffected As Long
    '
On Error GoTo Error_Update
    tmp = txtSQL
    If Len(tmp) < 7 Then
        msgs.Caption = "Please check the SQL syntax"
        Exit Sub
    Else
        tmp = UCase(Mid(tmp, 1, 6))
        If StrComp(tmp, "UPDATE", vbTextCompare) = 0 Then
        Else
            msgs.Caption = "Please check the SQL syntax"
            Exit Sub
        End If
    End If
    '
    msgs.Caption = ""
    msgs.Refresh
    '
    Set cmdADO = New ADODB.Command
    cmdADO.ActiveConnection = cnnUnidata
    '
    cmdADO.CommandType = adCmdText
    cmdADO.CommandText = txtSQL
    cmdADO.Execute Recordsaffected
    '
    msgs.Caption = Str(Recordsaffected) & " records have been updated successfully!"
    '
    btnOpt = 1
    Set cmdADO = Nothing
    '
    Exit Sub
    '
Error_Update:
    If cnnUnidata.Errors.Count > 0 Then
        'Set errloop = cnnUnidata.Errors
        For Each errloop In cnnUnidata.Errors
            MsgBox "Error number: " & errloop.Number & vbCr & _
            errloop.Description
        Next errloop
    End If
    msgs.Caption = "SQL UPDATE error !"
    '
End Sub

Private Sub Form_Load()
    glVersion = "1.2"
    GetDSNsAndDrivers
    frmadoodbcx.Caption = frmadoodbcx.Caption & " (ver " & glVersion & ")"
End Sub

Private Sub lstTables_Click()
Dim tmp, tmp1 As String
    '
    tmp = lstTables.List(lstTables.ListIndex)
    frmshowdata!txtRecord = tmp
    frmshowdata.Show 1
    '
End Sub

Sub GetDSNsAndDrivers()
    Dim i As Integer
    Dim sDSNItem As String * 1024
    Dim sDRVItem As String * 1024
    Dim sDSN As String
    Dim sDRV As String
    Dim iDSNLen As Integer
    Dim iDRVLen As Integer
    Dim lHenv As Long         'handle to the environment

    On Error Resume Next
    cboDSNList.AddItem "(None)"

    'get the DSNs
    If SQLAllocEnv(lHenv) <> -1 Then
        Do Until i <> SQL_SUCCESS
            sDSNItem = Space$(1024)
            sDRVItem = Space$(1024)
            i = SQLDataSources(lHenv, SQL_FETCH_NEXT, sDSNItem, 1024, iDSNLen, sDRVItem, 1024, iDRVLen)
            sDSN = Left$(sDSNItem, iDSNLen)
            'sDRV = Left$(sDRVItem, iDRVLen)
                
            If sDSN <> Space(iDSNLen) Then
                cboDSNList.AddItem sDSN
                'cboDrivers.AddItem sDRV
            End If
        Loop
    End If
    'remove the dupes
    'If cboDSNList.ListCount > 0 Then
    '    With cboDrivers
    '        If .ListCount > 1 Then
    '            i = 0
    '            While i < .ListCount
    '                If .List(i) = .List(i + 1) Then
    '                    .RemoveItem (i)
    '                Else
    '                    i = i + 1
    '                End If
    '            Wend
    '        End If
    '    End With
    'End If
    cboDSNList.ListIndex = 0
End Sub

