Imports U2.Data.Client
Imports System.Data

Namespace DataAdapter_TOXML
    Class Program
        Shared Sub Main(args As String())
            Try
                Dim conn_str As New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "HS.SALES"
                conn_str.ServerType = "UNIVERSE"
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")
                Dim cmd As U2Command = con.CreateCommand()
                cmd.CommandText = "LIST CUSTOMER"
                Dim ds As New DataSet()
                Dim da As New U2DataAdapter(cmd)
                da.FillWithTOXML(ds)


                Console.WriteLine(ds.GetXml())




                con.Close()
            Catch e As Exception

                Console.WriteLine(e.Message)
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try
        End Sub
    End Class
End Namespace