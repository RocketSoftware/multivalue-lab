Public Class OrderDisplay

    Private Sub OrderDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim item As String
        Dim withclause As String

        withclause = "WITH CUSTOMERID = """ & currentitemid & """"

        MVSP.ExecuteQuery("LIST", "ORDERS", withclause, "", "ORDERID SHIPCITY SHIPDATE", "")

        orderListView.Clear()
        orderListView.Columns.Add("Order ID", 60)
        orderListView.Columns.Add("Ship City", 150)
        orderListView.Columns.Add("Ship Date", 100)
        While MVSP.MVResultSetNext = True
            item = MVSP.MVResultSetGetCurrentRow
            Dim lvi As New ListViewItem(mvspfunctions.Extract(item, 1))
            lvi.SubItems.Add(mvspfunctions.Extract(item, 2))
            lvi.SubItems.Add(mvspfunctions.Extract(item, 3))
            orderListView.Items.Add(lvi)
        End While
        
    End Sub
End Class