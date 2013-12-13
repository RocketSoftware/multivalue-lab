Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client

Namespace Connection
    Class Program
        Shared Sub Main(ByVal args() As String)
            Try
                Dim conn_str As U2ConnectionStringBuilder = New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "HS.SALES"
                conn_str.ServerType = "UNIVERSE"
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As U2Connection = New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")
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