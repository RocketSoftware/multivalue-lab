Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Entity

Namespace EntityFramework_CodeFirst2
    Class Program
        Shared Sub Main(args As String())
            Try
                Console.WriteLine("start")
                Database.SetInitializer(Of CustomerContext)(Nothing)
                Dim ctx As New CustomerContext()

                Dim t As Object = ctx.Database.SqlQuery(Of Customer)("SELECT CUSTID,FNAME,LNAME,FULLADDR FROM CUSTOMER")
                For Each item As Customer In t
                    Console.WriteLine(item.CUSTID & "=>" & item.FNAME & "=>" & item.LNAME & "=>" & item.FULLADDR)
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