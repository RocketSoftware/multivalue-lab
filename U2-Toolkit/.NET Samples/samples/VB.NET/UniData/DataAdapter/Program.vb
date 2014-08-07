Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports System.Data

Namespace DataAdapter
    Class Program
        Shared Sub Main(ByVal args() As String)

            Try
                Dim conn_str As U2ConnectionStringBuilder = New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "demo"
                conn_str.ServerType = "UNIDATA"
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As U2Connection = New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")
                Dim cmd As U2Command = con.CreateCommand()
                cmd.CommandText = "SELECT * FROM STUDENT_NF_SUB"
                Dim ds As DataSet = New DataSet()
                Dim da As U2DataAdapter = New U2DataAdapter(cmd)
                da.Fill(ds)
                Dim dt As DataTable = ds.Tables(0)
                Dim dr As DataRow
                For Each dr In dt.Rows
                    Console.WriteLine(dr("FNAME"))
                Next

                con.Close()

            Catch e As Exception

                Dim s As String = e.Message
                If e.InnerException IsNot Nothing Then
                    s &= e.InnerException.Message
                End If

                Console.WriteLine(s)
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try
        End Sub
    End Class
End Namespace