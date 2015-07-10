<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderDisplay))
        Me.orderListView = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'orderListView
        '
        Me.orderListView.Location = New System.Drawing.Point(21, 12)
        Me.orderListView.Name = "orderListView"
        Me.orderListView.Size = New System.Drawing.Size(448, 236)
        Me.orderListView.TabIndex = 0
        Me.orderListView.UseCompatibleStateImageBehavior = False
        Me.orderListView.View = System.Windows.Forms.View.Details
        '
        'OrderDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(486, 257)
        Me.Controls.Add(Me.orderListView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OrderDisplay"
        Me.Text = "OrderDisplay"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents orderListView As System.Windows.Forms.ListView
End Class
