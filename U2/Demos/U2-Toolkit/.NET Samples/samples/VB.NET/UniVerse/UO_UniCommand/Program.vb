Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports U2.Data.Client.UO

Namespace UO_UniCommand
    Class Program
        Shared Sub Main(args As String())

            Try
                Dim conn_str As New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "HS.SALES"
                conn_str.ServerType = "UNIVERSE"
                conn_str.AccessMode = "Native"
                ' FOR UO
                conn_str.RpcServiceType = "uvcs"
                ' FOR UO
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")


                Dim us1 As UniSession = con.UniSession

                Dim cmd As UniCommand = us1.CreateUniCommand()
                cmd.Command = "LIST VOC SAMPLE 10"
                cmd.Execute()
                Dim response_str As String = cmd.Response
                Console.WriteLine("UniCommand Output" & response_str & Environment.NewLine)
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