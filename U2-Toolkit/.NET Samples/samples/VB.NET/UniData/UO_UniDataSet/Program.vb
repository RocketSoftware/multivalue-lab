Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports U2.Data.Client.UO

Namespace UO_UniDataSet
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

                Dim sl As UniSelectList = us1.CreateUniSelectList(2)
                ' Select UniFile
                Dim fl As UniFile = us1.CreateUniFile("STUDENT")
                sl.[Select](fl)

                ' read records as unidataset
                Dim sArray As String() = {"291222021", "521814564", "424325656"}
                Dim uSet As UniDataSet = fl.ReadRecords(sArray)

                ' use for each statement to print the record
                For Each item As UniRecord In uSet

                    Console.WriteLine(item.ToString())
                Next

                ' use index to print the record
                Dim lCount As Integer = uSet.RowCount
                For ii As Integer = 0 To lCount - 1
                    Dim ee As UniRecord = uSet(ii)
                    Console.WriteLine(ee.ToString())
                Next

                ' print one by one record
                Dim q2 As UniRecord = uSet("291222021")
                Dim sq2 As String = q2.ToString()
                Console.WriteLine("  Record data for rec id 291222021:" & sq2)
                Dim q3 As UniRecord = uSet("521814564")
                Dim sq3 As String = q3.ToString()
                Console.WriteLine("  Record data for rec id 521814564:" & sq3)
                Dim q4 As UniRecord = uSet("424325656")
                Dim sq4 As String = q4.ToString()
                Console.WriteLine("  Record data for rec id 424325656:" & sq4)

                'create UniDataSet in the Client Side
                Dim uSet3 As UniDataSet = us1.CreateUniDataSet()
                uSet3.Insert("3", "aaa")
                uSet3.Insert("4", "bbb")
                uSet3.Insert("5", "vvv")
                uSet3.Insert(2, "8", "www")

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
