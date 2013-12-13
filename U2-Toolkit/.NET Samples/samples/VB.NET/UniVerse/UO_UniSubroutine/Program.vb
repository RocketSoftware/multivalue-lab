Imports System
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

                Dim RoutineName As String = "!TIMDAT"
                Dim IntTotalAtgs As Integer = 1
                Dim largs As String() = New String(IntTotalAtgs) {}
                largs(0) = "1"
                Dim tmpStr2 As UniDynArray
                Dim [sub] As UniSubroutine = us1.CreateUniSubroutine(RoutineName, IntTotalAtgs)

                Dim i As Integer = 0
                While i < IntTotalAtgs
                    [sub].SetArg(i, largs(i))
                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                End While

                [sub].[Call]()
                tmpStr2 = [sub].GetArgDynArray(0)
                Dim result As String = vbLf & "Result is :" & tmpStr2.StringValue
                Console.WriteLine("  Response from UniSubRoutineSample :" & result)


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