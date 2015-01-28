Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace EntityFramework_CodeFirst2
    Public Class Customer
        Sub New()
        End Sub


        <Key()> _
        Public Property CUSTID() As Integer

        Public Property FNAME() As String
        Public Property LNAME() As String
        Public Property FULLADDR() As String
    End Class

    Public Class CustomerContext
        Inherits DbContext
        Public Sub New()
        End Sub

        Public Property Customers() As DbSet(Of Customer)
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

            modelBuilder.Entity(Of Customer)().[Property](Function(s) s.FNAME).IsRequired()
        End Sub

    End Class
End Namespace