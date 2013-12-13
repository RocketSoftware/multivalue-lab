Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Objects

Namespace EntityFramework_Subroutine
    Class Program
        Shared Sub Main(args As String())
            'first
            Dim ctx As New StudentContainer()
            Try

                Dim outputParameter1 As Object = New ObjectParameter("RESULT", GetType(String))
                outputParameter1.Value = ""

                Dim outputParameter2 As Object = New ObjectParameter("arg_xsd", GetType(String))
                outputParameter2.Value = ""

                Dim outputParameter3 As Object = New ObjectParameter("arg_errnum", GetType(String))
                outputParameter3.Value = ""

                Dim outputParameter4 As Object = New ObjectParameter("arg_errmsg", GetType(String))
                outputParameter4.Value = ""

                ctx.GetXmlSubroutine("LIST STUDENT ALL", "", outputParameter1, outputParameter2, outputParameter3, outputParameter4)

                Dim sXmlData As String = CType(outputParameter1.Value, String)
                Dim sXsdData As String = CType(outputParameter2.Value, String)
                Dim sErrNum As String = CType(outputParameter3.Value, String)
                Dim sErrMsg As String = CType(outputParameter4.Value, String)


                Console.WriteLine(sXmlData)
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