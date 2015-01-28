Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Objects

Namespace EntityFramework_Subroutine
    Class Program
        Shared Sub Main(args As String())

            Try
                'first Sample
                Dim ctx As New CustomerContainer()
                Try

                    Dim outputParameter1 As Object = New ObjectParameter("RESULT", GetType(String))
                    outputParameter1.Value = ""

                    Dim outputParameter2 As Object = New ObjectParameter("arg_xsd", GetType(String))
                    outputParameter2.Value = ""

                    Dim outputParameter3 As Object = New ObjectParameter("arg_errnum", GetType(String))
                    outputParameter3.Value = ""

                    Dim outputParameter4 As Object = New ObjectParameter("arg_errmsg", GetType(String))
                    outputParameter4.Value = ""

                    ctx.GetXmlSubroutine("LIST CUSTOMER", "", outputParameter1, outputParameter2, outputParameter3, outputParameter4)

                    Dim sXmlData As String = CType(outputParameter1.Value, String)
                    Dim sXsdData As String = CType(outputParameter2.Value, String)
                    Dim sErrNum As String = CType(outputParameter3.Value, String)
                    Dim sErrMsg As String = CType(outputParameter4.Value, String)


                    Console.WriteLine(sXmlData)
                Catch e As Exception
                    Console.WriteLine(e.Message)
                End Try




                'Second Sample

                ' make sure you have subroutine GETCUSTOMER compiled and catalog

                'STEPS

                ' 1 . Create a BP directory
                ' 2.  ED BP GETCUSTOMER
                ' 3.  Cut and paste the following subroutine
                ' 4.  BASIC BP GETCUSTOMER
                ' 5.  CATALOG BP GETCUSTOMER

                ' SUBROUTINE GETCUSTOMER
                '$INCLUDE UNIVERSE.INCLUDE ODBC.H
                'SELSTMT = "SELECT *  FROM CUSTOMER"
                'ST = SQLExecDirect(@HSTMT, SELSTMT)
                'RETURN


                Dim ctx2 As New CustomerContainer()
                Try

                    Dim q As ObjectResult(Of CUSTOMER) = ctx2.GetCustomer()
                    Dim lCustList As List(Of CUSTOMER) = q.ToList()

                    For Each item As CUSTOMER In lCustList
                        Console.WriteLine(item.FNAME)
                    Next
                Catch e As Exception
                    Console.WriteLine(e.Message)

                End Try
            Catch e2 As Exception
                Console.WriteLine(e2.Message)
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try

        End Sub

    End Class
End Namespace