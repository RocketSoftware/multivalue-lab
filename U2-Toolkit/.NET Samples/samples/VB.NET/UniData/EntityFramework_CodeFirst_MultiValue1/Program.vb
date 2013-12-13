Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Namespace EntityFramework_CodeFirst_MultiValue1
    Class Program
        Shared Sub Main(args As String())
            Try
                Console.WriteLine("start")
                Database.SetInitializer(Of StudentContext)(Nothing)
                Dim ctx As New StudentContext()
                'Dim q2 As Object = ctx.Students.ToList()

                'where p.StudentID = "521814564"
                Dim q2 As Object = From p In ctx.Students _
                                   Select New With { _
                                       p.StudentID, _
                                       p.FirstName, _
                                       p.LastName, _
                                       p.Semester _
                                   }


                For Each item As Object In q2

                    Console.WriteLine(item.StudentID & "=>" & item.FirstName & "=>" & item.LastName & "=>" & item.Semester)

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
