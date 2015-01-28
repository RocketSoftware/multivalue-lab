Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Namespace EntityFramework_CodeFirst

    Class Program
        Shared Sub Main(args As String())

            Try
                Console.WriteLine("start")
                Database.SetInitializer(Of CustomerContext)(Nothing)
                Dim ctx As New CustomerContext()
                Dim t = ctx.Customers.ToList()
                Dim item As Customer
                For Each item In t
                    Console.WriteLine(item.CUSTID & item.FNAME)
                    Dim q2 = From o In ctx.Orders Where o.CUSTID = item.CUSTID
                             Select o

                    For Each item2 As Order In q2
                        Console.WriteLine(vbTab & item2.PRODID & "=>" & item2.SER_NUM)

                    Next
                Next
            Catch e As Exception
                If e.InnerException IsNot Nothing Then
                    Console.WriteLine(e.InnerException.Message)
                Else
                    Console.WriteLine(e.Message)

                End If
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try

        End Sub
    End Class
End Namespace