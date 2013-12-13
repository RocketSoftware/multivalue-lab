Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace EntityFramework_POCO
    Class Program
        Shared Sub Main(args As String())

            Try
                Dim ctx As New CustomerContainer()

                Dim q As Object = From c In ctx.CUSTOMERS Order By c.CUSTID
                                    Select c

                For Each item As Object In q

                    Console.WriteLine(item.CUSTID & "=>" & item.FNAME)
                Next
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