﻿Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.ModelConfiguration.Conventions

Namespace EntityFramework_CodeFirst_MultiValue1
    <Table("STUDENT")> _
    Public Class Student
        Sub New()
        End Sub

        'Single Value
        <Key()> _
        <Column("ID")> _
        Public Property StudentID() As String
            Get
                Return m_StudentID
            End Get
            Set(value As String)
                m_StudentID = Value
            End Set
        End Property
        Private m_StudentID As String

        'Single Value
        <Column("FNAME")> _
        Public Property FirstName() As String
            Get
                Return m_FirstName
            End Get
            Set(value As String)
                m_FirstName = Value
            End Set
        End Property
        Private m_FirstName As String

        'Single Value
        <Column("LNAME")> _
        Public Property LastName() As String
            Get
                Return m_LastName
            End Get
            Set(value As String)
                m_LastName = Value
            End Set
        End Property
        Private m_LastName As String

        'Multi Value
        <Column("SEMESTER")> _
        Public Property Semester() As String
            Get
                Return m_Semester
            End Get
            Set(value As String)
                m_Semester = Value
            End Set
        End Property
        Private m_Semester As String

    End Class
    Public Class StudentContext
        Inherits DbContext
        Public Sub New()
        End Sub

        Public Property Students() As DbSet(Of Student)
            Get
                Return m_Students
            End Get
            Set(value As DbSet(Of Student))
                m_Students = Value
            End Set
        End Property
        Private m_Students As DbSet(Of Student)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)
            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        End Sub
    End Class
End Namespace
