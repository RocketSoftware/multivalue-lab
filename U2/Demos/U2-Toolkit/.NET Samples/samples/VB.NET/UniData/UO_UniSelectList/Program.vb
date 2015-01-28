Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports U2.Data.Client.UO

Namespace UO_UniSelectList
    Class Program
        Shared Sub Main(args As String())

            Try
                Dim conn_str As New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "demo"
                conn_str.ServerType = "UNIDATA"
                conn_str.AccessMode = "Native"
                ' FOR UO
                conn_str.RpcServiceType = "udcs"
                ' FOR UO
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")

                ' get RECID
                Dim us1 As UniSession = con.UniSession
                Dim sl As UniSelectList = us1.CreateUniSelectList(2)

                ' Select UniFile
                Dim fl As UniFile = us1.CreateUniFile("STUDENT")
                sl.[Select](fl)

                Dim lLastRecord As Boolean = sl.LastRecordRead

                While Not lLastRecord
                    Dim s2 As String = sl.[Next]()
                    Console.WriteLine("Record ID:" & s2)
                    lLastRecord = sl.LastRecordRead
                End While

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
