Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace EntityFramework_CodeFirst2
    Public Class Student
        Sub New()
        End Sub


        <Key()> _
        Public Property ID() As Integer

        Public Property FNAME() As String
        Public Property LNAME() As String
        Public Property MAJOR() As String
        Public Property MINOR() As String
    End Class

    Public Class StudentContext
        Inherits DbContext
        Public Sub New()
        End Sub

        Public Property Customers() As DbSet(Of Student)
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

            modelBuilder.Entity(Of Student)().[Property](Function(s) s.ID).IsRequired()
        End Sub

    End Class

End Namespace