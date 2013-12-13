Imports U2.Data.Client
Imports System.Data

Namespace DataAdapter_MultiValue
    Class Program
        Shared Sub Main(args As String())

            FillDataSetWithUNNEST()
            Console.WriteLine("Enter to exit:")
            Dim line As String = Console.ReadLine()
        End Sub


        Private Shared Sub FillDataSetWithUNNEST()
            Try
                Dim conn_str As New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "HS.SALES"
                conn_str.ServerType = "UNIVERSE"
                conn_str.FirstNormalForm = False
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")
                Dim cmd As U2Command = con.CreateCommand()
                cmd.CommandText = "SELECT FNAME, PRICE FROM UNNEST CUSTOMER ON ORDERS"
                ' FNAME = SingleValue, PRICE = multivalue
                Dim ds As New DataSet()
                Dim da As New U2DataAdapter(cmd)
                da.Fill(ds)
                Dim dt As DataTable = ds.Tables(0)
                For Each dr As DataRow In dt.Rows
                    Console.WriteLine(Convert.ToString(dr("FNAME")) & "==" & Convert.ToString(dr("PRICE")))
                Next


                con.Close()
            Catch e As Exception

                Console.WriteLine(e.Message)
            End Try
        End Sub
    End Class
End Namespace