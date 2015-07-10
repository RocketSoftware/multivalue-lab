Public Class CustomerMaintenancefrm
    
    
    Private Sub connectbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectbtn.Click
        Dim rc As Boolean
        rc = MVSP.Connect(hostNametxt.Text, Val(portNotxt.Text), userNametxt.Text, userPasswordtxt.Text)
        If rc = True Then
            rc = MVSP.Logto("MVDEMO", "")
            If rc = True Then
                rc = loadcustomers()
                connectbtn.Enabled = False
                savebtn.Enabled = True
                Newbtn.Enabled = True
            End If
        Else
            MsgBox("Unable to connect")
            Exit Sub
        End If
    End Sub
    Private Function loadcustomers() As Boolean

        Dim itemid As String
        Dim item As String

        custListView.Clear()

        MVSP.ExecuteQuery("QUERY", "CUSTOMERS", "", "BY ORGANIZATIONNAME", "CUSTOMERID ORGANIZATIONNAME", "")

        While MVSP.MVResultSetNext = True
            item = MVSP.MVResultSetGetCurrentRow
            itemid = mvspfunctions.Extract(item, 1)
            Dim lvi As New ListViewItem(itemid)

            lvi.SubItems.Add(mvspfunctions.Extract(item, 2))
            custListView.Items.Add(lvi)
        End While
        custListView.Columns.Add("Itemid", 40)
        custListView.Columns.Add("Name", 150)
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            MVSP.CloseConnection()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub custListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles custListView.SelectedIndexChanged
        Dim cursorposition As Point = Me.custListView.PointToClient(Control.MousePosition)
        Dim item As ListViewItem = Me.custListView.GetItemAt(cursorposition.X, cursorposition.Y)
        Try
            currentitemid = item.Text
            Call readcustomer(currentitemid)
        Catch ex As Exception

        End Try

    End Sub
    Private Function readcustomer(ByVal customerid As String) As Boolean
        currentitem = MVSP.FileRead("CUSTOMERS", customerid)
        If MVSP.statusCode = "0" Then
            idTxt.Text = customerid
            cNametxt.Text = mvspfunctions.Extract(currentitem, 6)
            cTitletxt.Text = mvspfunctions.Extract(currentitem, 7)
            oNametxt.Text = mvspfunctions.Extract(currentitem, 1)
            addresstxt.Text = mvspfunctions.Extract(currentitem, 2)
            citytxt.Text = mvspfunctions.Extract(currentitem, 3)
            statetxt.Text = mvspfunctions.Extract(currentitem, 4)
            pctxt.Text = mvspfunctions.Extract(currentitem, 5)
            phonetxt.Text = mvspfunctions.Extract(currentitem, 8)
            faxtxt.Text = mvspfunctions.Extract(currentitem, 9)
            notestxt.Text = mvspfunctions.Extract(currentitem, 10)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Newbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Newbtn.Click
        idTxt.Text = ""
        cNametxt.Text = ""
        cTitletxt.Text = ""
        oNametxt.Text = ""
        addresstxt.Text = ""
        citytxt.Text = ""
        statetxt.Text = ""
        pctxt.Text = ""
        phonetxt.Text = ""
        faxtxt.Text = ""
        notestxt.Text = ""
        currentitem = ""
        currentitemid = ""
        idTxt.Focus()
    End Sub

    Private Sub savebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savebtn.Click
        If currentitemid = "" Then ' New Item
            If idTxt.Text <> "" Then
                Dim tmpitem As String = MVSP.FileRead("CUSTOMERS", idTxt.Text)
                If MVSP.statusCode = "0" Then
                    MsgBox("ID already in use")
                    Exit Sub
                End If
            Else
                MsgBox("ID cannot be null")
                Exit Sub
            End If
        End If
        currentitem = oNametxt.Text & AM
        currentitem = currentitem & addresstxt.Text & AM
        currentitem = currentitem & citytxt.Text & AM
        currentitem = currentitem & statetxt.Text & AM
        currentitem = currentitem & pctxt.Text & AM
        currentitem = currentitem & cNametxt.Text & AM
        currentitem = currentitem & cTitletxt.Text & AM
        currentitem = currentitem & phonetxt.Text & AM
        currentitem = currentitem & faxtxt.Text & AM
        currentitem = currentitem & notestxt.Text & AM
        MVSP.FileWrite("CUSTOMERS", idTxt.Text, currentitem)

        Call loadcustomers()

    End Sub

    Private Sub Orders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Orders.Click
        If currentitemid <> "" Then
            Dim ordersfrm As New OrderDisplay
            ordersfrm.ShowDialog()
            ordersfrm = Nothing
        End If
    End Sub
End Class
