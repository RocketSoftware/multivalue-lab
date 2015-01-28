Imports System.Linq
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Namespace EntityFramework_CodeFirst_MultiValue2
    Class Program
        Shared Sub Main(args As String())

            Try
                Console.WriteLine("start")
                Database.SetInitializer(Of StudentContext)(Nothing)
                Dim ctx As New StudentContext()

                'Dim q2 As Object = ctx.Students.ToList()


                Dim q2 As Object = From p In ctx.Students _
                                   Select p

                Dim i As Integer = 0

                For Each item As Student In q2

                    Console.WriteLine(item.StudentID & "=>" & item.FirstName & "=>" & item.LastName)
                    i += 1

                    Dim stuID = item.StudentID
                    Dim q3 = From p In ctx.Semesters Where p.StudentID = stuID _
                             Select New With { _
                                 p.StudentID, _
                                 p.StudentSemester _
                             }

                    Dim item2 As Object
                    For Each item2 In q3
                        Console.WriteLine(vbTab & vbTab & vbTab & item2.StudentID & "=>" & item2.StudentSemester)

                    Next
                Next
                Console.WriteLine("# of Rows:" & i)
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