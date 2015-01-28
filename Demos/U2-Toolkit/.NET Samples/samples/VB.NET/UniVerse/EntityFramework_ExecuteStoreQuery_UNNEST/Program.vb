Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace EntityFramework_ExecuteStoreQuery_UNNEST
    Class Program
        Shared Sub Main(args As String())
            Try
                Dim ctx As New CustomerContainer()
                Dim q As Object = ctx.ExecuteStoreQuery(Of CUSTOMER_MV)("SELECT * FROM UNNEST CUSTOMER ON ORDERS")
                'CUSTID is 'S'
                'FNAME is   'S'
                'PRODID is 'M'
                'DESCRIPTION is 'M'
                For Each item As Object In q

                    Console.WriteLine(item.CUSTID & "=>" & item.FNAME & "=>" & item.PRODID & "=>" & item.DESCRIPTION)
                Next
            Catch e3 As Exception

                Console.WriteLine(e3.Message)
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try

        End Sub

    End Class
End Namespace