<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerMaintenancefrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerMaintenancefrm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.userNametxt = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.userPasswordtxt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.hostNametxt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.idTxt = New System.Windows.Forms.TextBox
        Me.connectbtn = New System.Windows.Forms.Button
        Me.custListView = New System.Windows.Forms.ListView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cNametxt = New System.Windows.Forms.TextBox
        Me.cTitletxt = New System.Windows.Forms.TextBox
        Me.oNametxt = New System.Windows.Forms.TextBox
        Me.addresstxt = New System.Windows.Forms.TextBox
        Me.citytxt = New System.Windows.Forms.TextBox
        Me.statetxt = New System.Windows.Forms.TextBox
        Me.pctxt = New System.Windows.Forms.TextBox
        Me.phonetxt = New System.Windows.Forms.TextBox
        Me.faxtxt = New System.Windows.Forms.TextBox
        Me.notestxt = New System.Windows.Forms.TextBox
        Me.Newbtn = New System.Windows.Forms.Button
        Me.savebtn = New System.Windows.Forms.Button
        Me.portNotxt = New System.Windows.Forms.TextBox
        Me.Orders = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'userNametxt
        '
        Me.userNametxt.Location = New System.Drawing.Point(65, 6)
        Me.userNametxt.Name = "userNametxt"
        Me.userNametxt.Size = New System.Drawing.Size(94, 20)
        Me.userNametxt.TabIndex = 1
        Me.userNametxt.Text = "DM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'userPasswordtxt
        '
        Me.userPasswordtxt.Location = New System.Drawing.Point(65, 32)
        Me.userPasswordtxt.Name = "userPasswordtxt"
        Me.userPasswordtxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.userPasswordtxt.Size = New System.Drawing.Size(94, 20)
        Me.userPasswordtxt.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(211, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hostname"
        '
        'hostNametxt
        '
        Me.hostNametxt.Location = New System.Drawing.Point(281, 6)
        Me.hostNametxt.Name = "hostNametxt"
        Me.hostNametxt.Size = New System.Drawing.Size(94, 20)
        Me.hostNametxt.TabIndex = 5
        Me.hostNametxt.Text = "localhost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(211, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Port"
        '
        'idTxt
        '
        Me.idTxt.Location = New System.Drawing.Point(367, 84)
        Me.idTxt.Name = "idTxt"
        Me.idTxt.Size = New System.Drawing.Size(31, 20)
        Me.idTxt.TabIndex = 9
        '
        'connectbtn
        '
        Me.connectbtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.connectbtn.Location = New System.Drawing.Point(402, 16)
        Me.connectbtn.Name = "connectbtn"
        Me.connectbtn.Size = New System.Drawing.Size(94, 31)
        Me.connectbtn.TabIndex = 8
        Me.connectbtn.Text = "Connect"
        Me.connectbtn.UseVisualStyleBackColor = False
        '
        'custListView
        '
        Me.custListView.FullRowSelect = True
        Me.custListView.Location = New System.Drawing.Point(10, 84)
        Me.custListView.Name = "custListView"
        Me.custListView.Size = New System.Drawing.Size(226, 364)
        Me.custListView.TabIndex = 27
        Me.custListView.UseCompatibleStateImageBehavior = False
        Me.custListView.View = System.Windows.Forms.View.Details
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(256, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Customer ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(256, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Contact Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(256, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Contact Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(256, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Organization Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(256, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Address"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(256, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "City"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(256, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "State"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(364, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Postal Code"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(256, 266)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Phone Number"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(256, 292)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Fax Number"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(256, 315)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Note"
        '
        'cNametxt
        '
        Me.cNametxt.Location = New System.Drawing.Point(367, 107)
        Me.cNametxt.Name = "cNametxt"
        Me.cNametxt.Size = New System.Drawing.Size(141, 20)
        Me.cNametxt.TabIndex = 11
        '
        'cTitletxt
        '
        Me.cTitletxt.Location = New System.Drawing.Point(367, 132)
        Me.cTitletxt.Name = "cTitletxt"
        Me.cTitletxt.Size = New System.Drawing.Size(141, 20)
        Me.cTitletxt.TabIndex = 13
        '
        'oNametxt
        '
        Me.oNametxt.Location = New System.Drawing.Point(367, 159)
        Me.oNametxt.Name = "oNametxt"
        Me.oNametxt.Size = New System.Drawing.Size(141, 20)
        Me.oNametxt.TabIndex = 15
        '
        'addresstxt
        '
        Me.addresstxt.Location = New System.Drawing.Point(367, 185)
        Me.addresstxt.Name = "addresstxt"
        Me.addresstxt.Size = New System.Drawing.Size(141, 20)
        Me.addresstxt.TabIndex = 17
        '
        'citytxt
        '
        Me.citytxt.Location = New System.Drawing.Point(367, 211)
        Me.citytxt.Name = "citytxt"
        Me.citytxt.Size = New System.Drawing.Size(141, 20)
        Me.citytxt.TabIndex = 19
        '
        'statetxt
        '
        Me.statetxt.Location = New System.Drawing.Point(292, 233)
        Me.statetxt.Name = "statetxt"
        Me.statetxt.Size = New System.Drawing.Size(66, 20)
        Me.statetxt.TabIndex = 21
        '
        'pctxt
        '
        Me.pctxt.Location = New System.Drawing.Point(442, 233)
        Me.pctxt.Name = "pctxt"
        Me.pctxt.Size = New System.Drawing.Size(66, 20)
        Me.pctxt.TabIndex = 22
        '
        'phonetxt
        '
        Me.phonetxt.Location = New System.Drawing.Point(367, 263)
        Me.phonetxt.Name = "phonetxt"
        Me.phonetxt.Size = New System.Drawing.Size(141, 20)
        Me.phonetxt.TabIndex = 23
        '
        'faxtxt
        '
        Me.faxtxt.Location = New System.Drawing.Point(367, 289)
        Me.faxtxt.Name = "faxtxt"
        Me.faxtxt.Size = New System.Drawing.Size(141, 20)
        Me.faxtxt.TabIndex = 24
        '
        'notestxt
        '
        Me.notestxt.Location = New System.Drawing.Point(367, 315)
        Me.notestxt.Multiline = True
        Me.notestxt.Name = "notestxt"
        Me.notestxt.Size = New System.Drawing.Size(141, 55)
        Me.notestxt.TabIndex = 25
        '
        'Newbtn
        '
        Me.Newbtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Newbtn.Enabled = False
        Me.Newbtn.Location = New System.Drawing.Point(259, 387)
        Me.Newbtn.Name = "Newbtn"
        Me.Newbtn.Size = New System.Drawing.Size(73, 31)
        Me.Newbtn.TabIndex = 28
        Me.Newbtn.Text = "New"
        Me.Newbtn.UseVisualStyleBackColor = False
        '
        'savebtn
        '
        Me.savebtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.savebtn.Enabled = False
        Me.savebtn.Location = New System.Drawing.Point(350, 387)
        Me.savebtn.Name = "savebtn"
        Me.savebtn.Size = New System.Drawing.Size(73, 31)
        Me.savebtn.TabIndex = 26
        Me.savebtn.Text = "Save"
        Me.savebtn.UseVisualStyleBackColor = False
        '
        'portNotxt
        '
        Me.portNotxt.Location = New System.Drawing.Point(281, 32)
        Me.portNotxt.Name = "portNotxt"
        Me.portNotxt.Size = New System.Drawing.Size(94, 20)
        Me.portNotxt.TabIndex = 7
        Me.portNotxt.Text = "9000"
        '
        'Orders
        '
        Me.Orders.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Orders.Location = New System.Drawing.Point(435, 387)
        Me.Orders.Name = "Orders"
        Me.Orders.Size = New System.Drawing.Size(73, 31)
        Me.Orders.TabIndex = 29
        Me.Orders.Text = "Orders"
        Me.Orders.UseVisualStyleBackColor = False
        '
        'CustomerMaintenancefrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(511, 460)
        Me.Controls.Add(Me.Orders)
        Me.Controls.Add(Me.portNotxt)
        Me.Controls.Add(Me.savebtn)
        Me.Controls.Add(Me.Newbtn)
        Me.Controls.Add(Me.notestxt)
        Me.Controls.Add(Me.faxtxt)
        Me.Controls.Add(Me.phonetxt)
        Me.Controls.Add(Me.pctxt)
        Me.Controls.Add(Me.statetxt)
        Me.Controls.Add(Me.citytxt)
        Me.Controls.Add(Me.addresstxt)
        Me.Controls.Add(Me.oNametxt)
        Me.Controls.Add(Me.cTitletxt)
        Me.Controls.Add(Me.cNametxt)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.custListView)
        Me.Controls.Add(Me.connectbtn)
        Me.Controls.Add(Me.idTxt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.hostNametxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.userPasswordtxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.userNametxt)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CustomerMaintenancefrm"
        Me.Text = "Customer Maintenance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents userNametxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents userPasswordtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents hostNametxt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents idTxt As System.Windows.Forms.TextBox
    Friend WithEvents connectbtn As System.Windows.Forms.Button
    Friend WithEvents custListView As System.Windows.Forms.ListView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cNametxt As System.Windows.Forms.TextBox
    Friend WithEvents cTitletxt As System.Windows.Forms.TextBox
    Friend WithEvents oNametxt As System.Windows.Forms.TextBox
    Friend WithEvents addresstxt As System.Windows.Forms.TextBox
    Friend WithEvents citytxt As System.Windows.Forms.TextBox
    Friend WithEvents statetxt As System.Windows.Forms.TextBox
    Friend WithEvents pctxt As System.Windows.Forms.TextBox
    Friend WithEvents phonetxt As System.Windows.Forms.TextBox
    Friend WithEvents faxtxt As System.Windows.Forms.TextBox
    Friend WithEvents notestxt As System.Windows.Forms.TextBox
    Friend WithEvents Newbtn As System.Windows.Forms.Button
    Friend WithEvents savebtn As System.Windows.Forms.Button
    Friend WithEvents portNotxt As System.Windows.Forms.TextBox
    Friend WithEvents Orders As System.Windows.Forms.Button

End Class
