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
                Database.SetInitializer(Of StudentContext)(Nothing)
                Dim ctx As New StudentContext()

                Dim t As Object = ctx.Database.SqlQuery(Of Student)("SELECT ID,FNAME,LNAME,MAJOR,MINOR FROM STUDENT_NF_SUB")
                For Each item As Student In t
                    Console.WriteLine(item.ID & "=>" & item.FNAME & "=>" & item.LNAME & "=>" & item.MAJOR & "=>" & item.MINOR)
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