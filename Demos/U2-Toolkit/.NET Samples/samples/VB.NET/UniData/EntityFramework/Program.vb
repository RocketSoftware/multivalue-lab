Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace EntityFramework
    Class Program
        Shared Sub Main(args As String())

            Dim ctx As New StudentContainer()
            Try
                'LINQ Query
                Dim q = From c In ctx.Students

                Dim StudentList As List(Of Student) = q.ToList()

                For Each item As Student In StudentList

                    Console.WriteLine(item.FNAME)
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
