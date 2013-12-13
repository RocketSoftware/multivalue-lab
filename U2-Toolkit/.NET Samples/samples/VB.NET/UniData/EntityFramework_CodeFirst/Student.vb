Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Namespace EntityFramework_CodeFirst
    <Table("STUDENT_NF_SUB", Schema:="ppp")> _
    Public Class Student
        Sub New()
            Semesters = New HashSet(Of Semester)()
        End Sub

        <Key()> _
        Public Property ID() As String

        Public Property FNAME() As String

        Public Overridable Property Semesters() As ICollection(Of Semester)


    End Class

    <Table("STUDENT_CGA_MV_SUB", Schema:="ppp")> _
    Public Class Semester
        Sub New()
            Courses = New HashSet(Of Course)()
        End Sub


        Public Property ID() As String

        <Key()> _
        Public Property CGA_MV_KEY() As Integer

        Public Property SEMESTER() As String

        Public Overridable Property Student() As Student
        Public Overridable Property Courses() As ICollection(Of Course)

    End Class


    <Table("STUDENT_CGA_MS_SUB", Schema:="ppp")> _
    Public Class Course

        Sub New()
        End Sub


        Public Property ID() As String


        Public Property CGA_MV_KEY() As Integer

        <Key()> _
        Public Property CGA_MS_KEY() As Integer

        Public Property COURSE_NAME() As String

        Public Property TEACHER() As String

        Public Overridable Property Semester() As Semester


    End Class

    Public Class StudentContext
        Inherits DbContext

        Public Sub New()
        End Sub

        Public Property Students() As DbSet(Of Student)
        Public Property Semesters() As DbSet(Of Semester)
        Public Property Courses() As DbSet(Of Course)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

            modelBuilder.Conventions.Remove(Of IncludeMetadataConvention)()
            ' this will take care of 
            'SELECT Extent1.Id, Extent1.ModelHash FROM dbo.EdmMetadata AS Extent1 ORDER BY Extent1.Id DESC SAMPLE 1 


            modelBuilder.Entity(Of Student)().[Property](Function(s) s.ID).IsRequired()
        End Sub


    End Class
End Namespace