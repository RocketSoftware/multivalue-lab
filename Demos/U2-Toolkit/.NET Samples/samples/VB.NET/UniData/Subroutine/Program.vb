Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports U2.Data.Client
Imports System.Data

Namespace Subroutine
    Class Program
        Shared Sub Main(args As String())
            Try
                Dim conn_str As New U2ConnectionStringBuilder()
                conn_str.UserID = "user"
                conn_str.Password = "pass"
                conn_str.Server = "localhost"
                conn_str.Database = "demo"
                conn_str.ServerType = "UNIDATA"
                conn_str.Pooling = False
                Dim s As String = conn_str.ToString()
                Dim con As New U2Connection()
                con.ConnectionString = s
                con.Open()
                Console.WriteLine("Connected.........................")
                Dim command As U2Command = con.CreateCommand()
                command.CommandText = "CALL GETXMLSUB(?,?,?,?,?,?)"
                ' UniData subroutine
                command.Parameters.Clear()

                command.CommandType = CommandType.StoredProcedure
                Dim p1 As New U2Parameter()
                p1.Direction = ParameterDirection.InputOutput

                p1.Value = "LIST STUDENT"
                p1.ParameterName = "@arg1"

                Dim p2 As New U2Parameter()
                p2.Direction = ParameterDirection.InputOutput
                p2.Value = ""
                p2.ParameterName = "@arg2"


                Dim p3 As New U2Parameter()
                p3.Direction = ParameterDirection.InputOutput
                p3.Value = ""
                p3.ParameterName = "@arg3"


                Dim p4 As New U2Parameter()
                p4.Direction = ParameterDirection.InputOutput
                p4.Value = ""
                p4.ParameterName = "@arg4"

                Dim p5 As New U2Parameter()
                p5.Direction = ParameterDirection.InputOutput
                p5.Value = ""
                p5.ParameterName = "@arg5"

                Dim p6 As New U2Parameter()
                p6.Direction = ParameterDirection.InputOutput
                p6.Value = ""
                p6.ParameterName = "@arg6"


                command.Parameters.Add(p1)
                command.Parameters.Add(p2)
                command.Parameters.Add(p3)
                command.Parameters.Add(p4)
                command.Parameters.Add(p5)
                command.Parameters.Add(p6)

                command.ExecuteNonQuery()

                Dim s1 As String = command.Parameters(0).Value.ToString()
                'command
                Dim s2 As String = command.Parameters(1).Value.ToString()
                ' command option
                Dim s3 As String = command.Parameters(2).Value.ToString()
                ' xml
                Dim s4 As String = command.Parameters(3).Value.ToString()
                'xsd
                Dim s5 As String = command.Parameters(4).Value.ToString()
                ' msg #
                Dim s6 As String = command.Parameters(5).Value.ToString()
                ' msg description
                Console.WriteLine("Subroutine Output:" & s3 & Environment.NewLine)
                Console.WriteLine("Subroutine Output:" & s4 & Environment.NewLine)


                con.Close()
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