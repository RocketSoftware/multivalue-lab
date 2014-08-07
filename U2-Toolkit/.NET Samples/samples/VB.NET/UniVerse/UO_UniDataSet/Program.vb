Imports System
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

                ' get RECID

                Dim us1 As UniSession = con.UniSession

                ' open customer file
                Dim fl As UniFile = us1.CreateUniFile("CUSTOMER")

                ' read records as unidataset
                Dim sArray As String() = {"2", "12", "3", "4"}
                Dim uSet As UniDataSet = fl.ReadRecords(sArray)

                ' use for each statement to print the record
                For Each item As UniRecord In uSet

                    Console.WriteLine(item.ToString())
                Next

                ' use index to print the record
                Dim lCount As Integer = uSet.RowCount
                Dim ii As Integer = 0
                While ii < lCount
                    Dim ee As UniRecord = uSet(ii)
                    Console.WriteLine(ee.ToString())
                    System.Math.Max(System.Threading.Interlocked.Increment(ii), ii - 1)
                End While

                ' print one by one record
                Dim q2 As UniRecord = uSet("2")
                Dim sq2 As String = q2.ToString()
                Console.WriteLine("  Record data for rec id 2:" & sq2)
                Dim q3 As UniRecord = uSet("3")
                Dim sq3 As String = q3.ToString()
                Console.WriteLine("  Record data for rec id 3:" & sq3)
                Dim q4 As UniRecord = uSet("4")
                Dim sq4 As String = q4.ToString()
                Console.WriteLine("  Record data for rec id 4:" & sq4)

                ' create UniDataSet in the Client Side
                Dim uSet3 As UniDataSet = us1.CreateUniDataSet()
                uSet3.Insert("3", "aaa")
                uSet3.Insert("4", "bbb")
                uSet3.Insert("5", "vvv")
                uSet3.Insert(2, "8", "www")


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