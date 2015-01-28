Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Objects

Namespace EntityFramework
    Class Program
        Shared Sub Main(args As String())
            Try
                'first
                Dim ctx As New CustomerContainer()
                Try
                    
                    Dim customers As ObjectSet(Of CUSTOMER) = ctx.CUSTOMERS

                    Dim customersQuery = _
                        From customer In customers _
                        Select customer

                    Console.WriteLine("Customer Names:")
                    For Each cust In customersQuery
                        Console.WriteLine(cust.FNAME)
                    Next

                Catch e As Exception

                    Console.WriteLine(e.Message)
                    If (e.InnerException IsNot Nothing) Then
                        Console.WriteLine(e.InnerException.Message)
                    End If
                End Try


                ' second ( multi-value)
                Dim ctx2 As New CustomerContainer()

                Try
                    
                    For Each customer As CUSTOMER_MV In ctx2.ExecuteStoreQuery(Of CUSTOMER_MV)("SELECT * FROM UNNEST CUSTOMER ON ORDERS")
                        Console.WriteLine(customer.FNAME)
                    Next


                    
                Catch e2 As Exception

                    Console.WriteLine(e2.Message)


                    If (e2.InnerException IsNot Nothing) Then
                        Console.WriteLine(e2.InnerException.Message)
                    End If

                End Try
            Catch e3 As Exception

                Console.WriteLine(e3.Message)

                If (e3.InnerException IsNot Nothing) Then
                    Console.WriteLine(e3.InnerException.Message)
                End If
            Finally
                Console.WriteLine("Enter to exit:")
                Dim line As String = Console.ReadLine()
            End Try

        End Sub

    End Class
End Namespace