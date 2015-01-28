Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace EntityFramework_CodeFirst

    <Table("CUSTOMER", Schema:="HS_SALES")> _
    Public Class Customer
        Sub New()
            Orders = New HashSet(Of Order)()
        End Sub

        <Key()> _
        Public Property CUSTID() As Integer

        Public Property FNAME() As String

        Public Overridable Property Orders() As ICollection(Of Order)
    End Class

    <Table("CUSTOMER_ORDERS", Schema:="HS_SALES")> _
    Public Class Order
        Sub New()
        End Sub


        <Key()> _
        <Column("@ASSOC_ROW")> _
        Public Property ASSOC_ROW() As Decimal

        Public Property CUSTID() As Integer
        Public Property PRODID() As String
        Public Property SER_NUM() As String

        Public Overridable Property Customer() As Customer

    End Class
    Public Class CustomerContext
        Inherits DbContext

        Public Sub New()
        End Sub

        Public Property Customers() As DbSet(Of Customer)
        Public Property Orders() As DbSet(Of Order)
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

            modelBuilder.Entity(Of Customer)().[Property](Function(s) s.FNAME).IsRequired()
        End Sub


    End Class

End Namespace