Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports U2.Data.Client.UO

Namespace UO_UniSubroutine
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
                Dim us1 As UniSession = con.UniSession

                Dim RoutineName As String = "*GETXMLSUB"
                Dim IntTotalAtgs As Integer = 6
                Dim largs As String() = New String(IntTotalAtgs - 1) {}
                largs(0) = "LIST STUDENT ALL"
                largs(1) = "arg2"
                largs(2) = "arg3"
                largs(3) = "arg4"
                largs(4) = "arg5"
                largs(5) = "arg6"
                Dim tmpStr2 As UniDynArray
                Dim [sub] As UniSubroutine = us1.CreateUniSubroutine(RoutineName, IntTotalAtgs)

                For i As Integer = 0 To IntTotalAtgs - 1
                    [sub].SetArg(i, largs(i))
                Next

                [sub].[Call]()
                tmpStr2 = [sub].GetArgDynArray(2)
                Dim result As String = vbLf & "Result is :" & tmpStr2.StringValue
                Console.WriteLine("  Response from UniSubRoutineSample :" & result)

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
