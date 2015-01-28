Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace EntityFramework_ExecuteStoreQuery_UNNEST
    Class Program
        Shared Sub Main(args As String())
            Try
                Dim ctx As New Student2Container()
                Dim result As Object = ctx.ExecuteStoreQuery(Of Student2_UNNEST)("SELECT * FROM STUDENT UNNEST NL_ALL CGA ;")

                For Each item As Object In result
                    ' ID is 'S'
                    ' LNAME is 'S'
                    ' SEMESTER is 'M'
                    Console.WriteLine(item.ID & "=>" & item.LNAME & "=>" & item.SEMESTER)
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