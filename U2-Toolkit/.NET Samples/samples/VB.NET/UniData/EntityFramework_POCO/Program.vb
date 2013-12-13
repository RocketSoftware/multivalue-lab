Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Entity.Infrastructure

Namespace EntityFramework_POCO
    Class Program

        Shared Sub Main(args As String())
            Try
                Dim ctx As New StudentContainer()
                Dim lstudents As Object = From s In ctx.Students
                                          Select s

                Dim item As Student
                For Each item In lstudents
                    Console.WriteLine(item.ID & "=>" & item.LNAME)

                    Dim lsemesters As Object = From s2 In ctx.Semesters Where s2.ID = item.ID
                                               Select s2
                    Dim item2 As Semester
                    For Each item2 In lsemesters
                        Console.WriteLine(vbTab & vbTab & item2.CGA_MV_KEY & "=>" & item2.SEMESTER)

                        Dim lcourses As Object = From s3 In ctx.Courses Where s3.ID = item2.ID AndAlso s3.CGA_MV_KEY = item2.CGA_MV_KEY
                                                 Select s3

                        For Each item3 As Object In lcourses
                            Console.WriteLine(vbTab & vbTab & vbTab & vbTab & item3.CGA_MS_KEY & "=>" & item3.COURSE_NAME)
                        Next

                    Next
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