<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MVSPMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MVSPMain))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel
        Me.ConnectProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.ConnectionList = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.updateConfigbtn = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ServerSoftwareSerialNotxt = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ServerVersionTxt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ServerPibTxt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ServerPlatformTxt = New System.Windows.Forms.TextBox
        Me.ServerNameTxt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DiagLogNo = New System.Windows.Forms.RadioButton
        Me.DiagLogYes = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.CommGroup = New System.Windows.Forms.GroupBox
        Me.AutobootNo = New System.Windows.Forms.RadioButton
        Me.AutobootYes = New System.Windows.Forms.RadioButton
        Me.TCPIPSocket = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.disableAccountbtn = New System.Windows.Forms.Button
        Me.enableAccountbtn = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.fullAccountPath = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.EnabledAccounts = New System.Windows.Forms.ListBox
        Me.DisabledAccounts = New System.Windows.Forms.ListBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.NewUserbtn = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.NewUserPass = New System.Windows.Forms.TextBox
        Me.DisableUserbtn = New System.Windows.Forms.Button
        Me.EnableUserbtn = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.NewUserName = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.EnabledUsers = New System.Windows.Forms.ListBox
        Me.DisabledUsers = New System.Windows.Forms.ListBox
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.ConnectionListView = New System.Windows.Forms.ListView
        Me.connectionsRefreshbtn = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisconnectMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.CommGroup.SuspendLayout()
        CType(Me.TCPIPSocket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status, Me.ConnectProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(792, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(71, 17)
        Me.Status.Text = "Disconnected"
        '
        'ConnectProgressBar
        '
        Me.ConnectProgressBar.Name = "ConnectProgressBar"
        Me.ConnectProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(792, 527)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(792, 551)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(792, 527)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.ConnectionList)
        Me.TabPage3.ImageKey = "connect_toNetwork.ico"
        Me.TabPage3.Location = New System.Drawing.Point(4, 42)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(784, 481)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Servers"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(18, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "New Connection"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConnectionList
        '
        Me.ConnectionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ConnectionList.LargeImageList = Me.ImageList1
        Me.ConnectionList.Location = New System.Drawing.Point(18, 50)
        Me.ConnectionList.Name = "ConnectionList"
        Me.ConnectionList.Size = New System.Drawing.Size(751, 420)
        Me.ConnectionList.TabIndex = 0
        Me.ConnectionList.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.SystemColors.Control
        Me.ImageList1.Images.SetKeyName(0, "document.bmp")
        Me.ImageList1.Images.SetKeyName(1, "userAccounts.bmp")
        Me.ImageList1.Images.SetKeyName(2, "PropertiesHH.bmp")
        Me.ImageList1.Images.SetKeyName(3, "Disconnect.png")
        Me.ImageList1.Images.SetKeyName(4, "connect_toNetwork.ico")
        Me.ImageList1.Images.SetKeyName(5, "user.bmp")
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.updateConfigbtn)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.CommGroup)
        Me.TabPage1.ImageIndex = 2
        Me.TabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabPage1.Location = New System.Drawing.Point(4, 42)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(784, 481)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Config"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'updateConfigbtn
        '
        Me.updateConfigbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.updateConfigbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.updateConfigbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.updateConfigbtn.Location = New System.Drawing.Point(677, 444)
        Me.updateConfigbtn.Name = "updateConfigbtn"
        Me.updateConfigbtn.Size = New System.Drawing.Size(98, 29)
        Me.updateConfigbtn.TabIndex = 3
        Me.updateConfigbtn.Text = "Update Config"
        Me.updateConfigbtn.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ServerSoftwareSerialNotxt)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ServerVersionTxt)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.ServerPibTxt)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ServerPlatformTxt)
        Me.GroupBox3.Controls.Add(Me.ServerNameTxt)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(513, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(262, 178)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Server Information"
        '
        'ServerSoftwareSerialNotxt
        '
        Me.ServerSoftwareSerialNotxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ServerSoftwareSerialNotxt.Location = New System.Drawing.Point(111, 148)
        Me.ServerSoftwareSerialNotxt.Name = "ServerSoftwareSerialNotxt"
        Me.ServerSoftwareSerialNotxt.ReadOnly = True
        Me.ServerSoftwareSerialNotxt.Size = New System.Drawing.Size(133, 21)
        Me.ServerSoftwareSerialNotxt.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Software Serial No"
        '
        'ServerVersionTxt
        '
        Me.ServerVersionTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ServerVersionTxt.Location = New System.Drawing.Point(111, 114)
        Me.ServerVersionTxt.Name = "ServerVersionTxt"
        Me.ServerVersionTxt.ReadOnly = True
        Me.ServerVersionTxt.Size = New System.Drawing.Size(133, 21)
        Me.ServerVersionTxt.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Server Version"
        '
        'ServerPibTxt
        '
        Me.ServerPibTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ServerPibTxt.Location = New System.Drawing.Point(111, 80)
        Me.ServerPibTxt.Name = "ServerPibTxt"
        Me.ServerPibTxt.ReadOnly = True
        Me.ServerPibTxt.Size = New System.Drawing.Size(133, 21)
        Me.ServerPibTxt.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Connected Pib"
        '
        'ServerPlatformTxt
        '
        Me.ServerPlatformTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ServerPlatformTxt.Location = New System.Drawing.Point(111, 46)
        Me.ServerPlatformTxt.Name = "ServerPlatformTxt"
        Me.ServerPlatformTxt.ReadOnly = True
        Me.ServerPlatformTxt.Size = New System.Drawing.Size(133, 21)
        Me.ServerPlatformTxt.TabIndex = 8
        '
        'ServerNameTxt
        '
        Me.ServerNameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ServerNameTxt.Location = New System.Drawing.Point(111, 12)
        Me.ServerNameTxt.Name = "ServerNameTxt"
        Me.ServerNameTxt.ReadOnly = True
        Me.ServerNameTxt.Size = New System.Drawing.Size(133, 21)
        Me.ServerNameTxt.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Platform"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Server Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DiagLogNo)
        Me.GroupBox2.Controls.Add(Me.DiagLogYes)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 44)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Diagnostics"
        '
        'DiagLogNo
        '
        Me.DiagLogNo.AutoSize = True
        Me.DiagLogNo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DiagLogNo.Location = New System.Drawing.Point(154, 16)
        Me.DiagLogNo.Name = "DiagLogNo"
        Me.DiagLogNo.Size = New System.Drawing.Size(44, 18)
        Me.DiagLogNo.TabIndex = 7
        Me.DiagLogNo.TabStop = True
        Me.DiagLogNo.Text = "No"
        Me.DiagLogNo.UseVisualStyleBackColor = True
        '
        'DiagLogYes
        '
        Me.DiagLogYes.AutoSize = True
        Me.DiagLogYes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DiagLogYes.Location = New System.Drawing.Point(111, 16)
        Me.DiagLogYes.Name = "DiagLogYes"
        Me.DiagLogYes.Size = New System.Drawing.Size(46, 18)
        Me.DiagLogYes.TabIndex = 6
        Me.DiagLogYes.TabStop = True
        Me.DiagLogYes.Text = "Yes"
        Me.DiagLogYes.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Enable Logging"
        '
        'CommGroup
        '
        Me.CommGroup.Controls.Add(Me.AutobootNo)
        Me.CommGroup.Controls.Add(Me.AutobootYes)
        Me.CommGroup.Controls.Add(Me.TCPIPSocket)
        Me.CommGroup.Controls.Add(Me.Label2)
        Me.CommGroup.Controls.Add(Me.Label1)
        Me.CommGroup.Location = New System.Drawing.Point(6, 6)
        Me.CommGroup.Name = "CommGroup"
        Me.CommGroup.Size = New System.Drawing.Size(218, 70)
        Me.CommGroup.TabIndex = 0
        Me.CommGroup.TabStop = False
        Me.CommGroup.Text = "Communications"
        '
        'AutobootNo
        '
        Me.AutobootNo.AutoSize = True
        Me.AutobootNo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AutobootNo.Location = New System.Drawing.Point(154, 43)
        Me.AutobootNo.Name = "AutobootNo"
        Me.AutobootNo.Size = New System.Drawing.Size(44, 18)
        Me.AutobootNo.TabIndex = 4
        Me.AutobootNo.TabStop = True
        Me.AutobootNo.Text = "No"
        Me.AutobootNo.UseVisualStyleBackColor = True
        '
        'AutobootYes
        '
        Me.AutobootYes.AutoSize = True
        Me.AutobootYes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AutobootYes.Location = New System.Drawing.Point(112, 43)
        Me.AutobootYes.Name = "AutobootYes"
        Me.AutobootYes.Size = New System.Drawing.Size(46, 18)
        Me.AutobootYes.TabIndex = 3
        Me.AutobootYes.TabStop = True
        Me.AutobootYes.Text = "Yes"
        Me.AutobootYes.UseVisualStyleBackColor = True
        '
        'TCPIPSocket
        '
        Me.TCPIPSocket.Location = New System.Drawing.Point(111, 12)
        Me.TCPIPSocket.Maximum = New Decimal(New Integer() {32267, 0, 0, 0})
        Me.TCPIPSocket.Minimum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.TCPIPSocket.Name = "TCPIPSocket"
        Me.TCPIPSocket.Size = New System.Drawing.Size(86, 21)
        Me.TCPIPSocket.TabIndex = 2
        Me.TCPIPSocket.Value = New Decimal(New Integer() {9000, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Auto boot Server"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TCP/IP Socket"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.disableAccountbtn)
        Me.TabPage2.Controls.Add(Me.enableAccountbtn)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.fullAccountPath)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.EnabledAccounts)
        Me.TabPage2.Controls.Add(Me.DisabledAccounts)
        Me.TabPage2.ImageIndex = 0
        Me.TabPage2.Location = New System.Drawing.Point(4, 42)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(784, 481)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Account"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'disableAccountbtn
        '
        Me.disableAccountbtn.BackColor = System.Drawing.Color.IndianRed
        Me.disableAccountbtn.Location = New System.Drawing.Point(323, 174)
        Me.disableAccountbtn.Name = "disableAccountbtn"
        Me.disableAccountbtn.Size = New System.Drawing.Size(116, 32)
        Me.disableAccountbtn.TabIndex = 7
        Me.disableAccountbtn.Text = "<<< Disable"
        Me.disableAccountbtn.UseVisualStyleBackColor = False
        '
        'enableAccountbtn
        '
        Me.enableAccountbtn.BackColor = System.Drawing.Color.IndianRed
        Me.enableAccountbtn.Location = New System.Drawing.Point(323, 114)
        Me.enableAccountbtn.Name = "enableAccountbtn"
        Me.enableAccountbtn.Size = New System.Drawing.Size(116, 32)
        Me.enableAccountbtn.TabIndex = 6
        Me.enableAccountbtn.Text = "Enable >>>"
        Me.enableAccountbtn.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 358)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Full path to account"
        '
        'fullAccountPath
        '
        Me.fullAccountPath.Location = New System.Drawing.Point(27, 374)
        Me.fullAccountPath.Name = "fullAccountPath"
        Me.fullAccountPath.Size = New System.Drawing.Size(424, 21)
        Me.fullAccountPath.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(492, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Enabled Accounts"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Disabled Accounts"
        '
        'EnabledAccounts
        '
        Me.EnabledAccounts.AllowDrop = True
        Me.EnabledAccounts.FormattingEnabled = True
        Me.EnabledAccounts.Location = New System.Drawing.Point(495, 53)
        Me.EnabledAccounts.Name = "EnabledAccounts"
        Me.EnabledAccounts.Size = New System.Drawing.Size(252, 277)
        Me.EnabledAccounts.Sorted = True
        Me.EnabledAccounts.TabIndex = 1
        '
        'DisabledAccounts
        '
        Me.DisabledAccounts.AllowDrop = True
        Me.DisabledAccounts.FormattingEnabled = True
        Me.DisabledAccounts.Location = New System.Drawing.Point(27, 53)
        Me.DisabledAccounts.Name = "DisabledAccounts"
        Me.DisabledAccounts.Size = New System.Drawing.Size(252, 277)
        Me.DisabledAccounts.Sorted = True
        Me.DisabledAccounts.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabPage4.Controls.Add(Me.NewUserbtn)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.NewUserPass)
        Me.TabPage4.Controls.Add(Me.DisableUserbtn)
        Me.TabPage4.Controls.Add(Me.EnableUserbtn)
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.NewUserName)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.EnabledUsers)
        Me.TabPage4.Controls.Add(Me.DisabledUsers)
        Me.TabPage4.ImageKey = "userAccounts.bmp"
        Me.TabPage4.Location = New System.Drawing.Point(4, 42)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(784, 481)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "User"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'NewUserbtn
        '
        Me.NewUserbtn.BackColor = System.Drawing.Color.IndianRed
        Me.NewUserbtn.Location = New System.Drawing.Point(190, 408)
        Me.NewUserbtn.Name = "NewUserbtn"
        Me.NewUserbtn.Size = New System.Drawing.Size(136, 32)
        Me.NewUserbtn.TabIndex = 18
        Me.NewUserbtn.Text = "Create && Enable >>>"
        Me.NewUserbtn.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 418)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Password"
        '
        'NewUserPass
        '
        Me.NewUserPass.Location = New System.Drawing.Point(34, 434)
        Me.NewUserPass.Name = "NewUserPass"
        Me.NewUserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(46)
        Me.NewUserPass.Size = New System.Drawing.Size(137, 21)
        Me.NewUserPass.TabIndex = 16
        '
        'DisableUserbtn
        '
        Me.DisableUserbtn.BackColor = System.Drawing.Color.IndianRed
        Me.DisableUserbtn.Location = New System.Drawing.Point(330, 192)
        Me.DisableUserbtn.Name = "DisableUserbtn"
        Me.DisableUserbtn.Size = New System.Drawing.Size(116, 32)
        Me.DisableUserbtn.TabIndex = 15
        Me.DisableUserbtn.Text = "<<< Disable"
        Me.DisableUserbtn.UseVisualStyleBackColor = False
        '
        'EnableUserbtn
        '
        Me.EnableUserbtn.BackColor = System.Drawing.Color.IndianRed
        Me.EnableUserbtn.Location = New System.Drawing.Point(330, 132)
        Me.EnableUserbtn.Name = "EnableUserbtn"
        Me.EnableUserbtn.Size = New System.Drawing.Size(116, 32)
        Me.EnableUserbtn.TabIndex = 14
        Me.EnableUserbtn.Text = "Enable >>>"
        Me.EnableUserbtn.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 376)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Username"
        '
        'NewUserName
        '
        Me.NewUserName.Location = New System.Drawing.Point(34, 392)
        Me.NewUserName.Name = "NewUserName"
        Me.NewUserName.Size = New System.Drawing.Size(137, 21)
        Me.NewUserName.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(499, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Enabled Users"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Disabled Users"
        '
        'EnabledUsers
        '
        Me.EnabledUsers.AllowDrop = True
        Me.EnabledUsers.FormattingEnabled = True
        Me.EnabledUsers.Location = New System.Drawing.Point(502, 71)
        Me.EnabledUsers.Name = "EnabledUsers"
        Me.EnabledUsers.Size = New System.Drawing.Size(252, 277)
        Me.EnabledUsers.Sorted = True
        Me.EnabledUsers.TabIndex = 9
        '
        'DisabledUsers
        '
        Me.DisabledUsers.AllowDrop = True
        Me.DisabledUsers.FormattingEnabled = True
        Me.DisabledUsers.Location = New System.Drawing.Point(34, 71)
        Me.DisabledUsers.Name = "DisabledUsers"
        Me.DisabledUsers.Size = New System.Drawing.Size(252, 277)
        Me.DisabledUsers.Sorted = True
        Me.DisabledUsers.TabIndex = 8
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.ConnectionListView)
        Me.TabPage5.Controls.Add(Me.connectionsRefreshbtn)
        Me.TabPage5.Location = New System.Drawing.Point(4, 42)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(784, 481)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Connections"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'ConnectionListView
        '
        Me.ConnectionListView.BackColor = System.Drawing.Color.Linen
        Me.ConnectionListView.Location = New System.Drawing.Point(13, 16)
        Me.ConnectionListView.MultiSelect = False
        Me.ConnectionListView.Name = "ConnectionListView"
        Me.ConnectionListView.Size = New System.Drawing.Size(755, 423)
        Me.ConnectionListView.TabIndex = 2
        Me.ConnectionListView.UseCompatibleStateImageBehavior = False
        Me.ConnectionListView.View = System.Windows.Forms.View.Details
        '
        'connectionsRefreshbtn
        '
        Me.connectionsRefreshbtn.Location = New System.Drawing.Point(13, 445)
        Me.connectionsRefreshbtn.Name = "connectionsRefreshbtn"
        Me.connectionsRefreshbtn.Size = New System.Drawing.Size(75, 23)
        Me.connectionsRefreshbtn.TabIndex = 1
        Me.connectionsRefreshbtn.Text = "Refresh"
        Me.connectionsRefreshbtn.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisconnectMenu, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem2})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'DisconnectMenu
        '
        Me.DisconnectMenu.Enabled = False
        Me.DisconnectMenu.Name = "DisconnectMenu"
        Me.DisconnectMenu.Size = New System.Drawing.Size(126, 22)
        Me.DisconnectMenu.Text = "&Disconnect"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(126, 22)
        Me.ExitToolStripMenuItem2.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'MVSPMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "MVSPMain"
        Me.Text = "MVSP Administrator"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.CommGroup.ResumeLayout(False)
        Me.CommGroup.PerformLayout()
        CType(Me.TCPIPSocket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommGroup As System.Windows.Forms.GroupBox
    Friend WithEvents AutobootYes As System.Windows.Forms.RadioButton
    Friend WithEvents TCPIPSocket As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AutobootNo As System.Windows.Forms.RadioButton
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DiagLogNo As System.Windows.Forms.RadioButton
    Friend WithEvents DiagLogYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DisconnectMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ConnectionList As System.Windows.Forms.ListView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ServerPlatformTxt As System.Windows.Forms.TextBox
    Friend WithEvents ServerNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ServerVersionTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ServerPibTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ConnectProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EnabledAccounts As System.Windows.Forms.ListBox
    Friend WithEvents DisabledAccounts As System.Windows.Forms.ListBox
    Friend WithEvents ServerSoftwareSerialNotxt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents updateConfigbtn As System.Windows.Forms.Button
    Friend WithEvents disableAccountbtn As System.Windows.Forms.Button
    Friend WithEvents enableAccountbtn As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents fullAccountPath As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents connectionsRefreshbtn As System.Windows.Forms.Button
    Friend WithEvents DisableUserbtn As System.Windows.Forms.Button
    Friend WithEvents EnableUserbtn As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NewUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents EnabledUsers As System.Windows.Forms.ListBox
    Friend WithEvents DisabledUsers As System.Windows.Forms.ListBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NewUserPass As System.Windows.Forms.TextBox
    Friend WithEvents NewUserbtn As System.Windows.Forms.Button
    Friend WithEvents ConnectionListView As System.Windows.Forms.ListView

End Class
