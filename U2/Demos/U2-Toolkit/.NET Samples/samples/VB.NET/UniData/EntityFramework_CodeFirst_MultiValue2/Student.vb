Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

Namespace EntityFramework_CodeFirst_MultiValue2

    Public Class Student
        Private Sub New()
        End Sub

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

        Public Overridable Property Semesters() As Semester
            Get
                Return m_Semesters
            End Get
            Set(value As Semester)
                m_Semesters = Value
            End Set
        End Property
        Private m_Semesters As Semester


    End Class
    Public Class Semester
        Private Sub New()
        End Sub

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

        'Multi Value
        <Column("SEMESTER")> _
        Public Property StudentSemester() As String
            Get
                Return m_StudentSemester
            End Get
            Set(value As String)
                m_StudentSemester = Value
            End Set
        End Property
        Private m_StudentSemester As String

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
        Public Property Semesters() As DbSet(Of Semester)
            Get
                Return m_Semesters
            End Get
            Set(value As DbSet(Of Semester))
                m_Semesters = Value
            End Set
        End Property
        Private m_Semesters As DbSet(Of Semester)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)
            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
            modelBuilder.Entity(Of Student)().HasRequired(Function(c) c.Semesters).WithRequiredPrincipal()
            modelBuilder.Entity(Of Student)().ToTable("STUDENT")
            modelBuilder.Entity(Of Semester)().ToTable("STUDENT")
        End Sub
    End Class
End Namespace