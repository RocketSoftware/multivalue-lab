Imports System.Linq
Imports System.Data.Entity


Namespace EntityFramework_CodeFirst_MultiValue2
    Class Program
        Shared Sub Main(args As String())
            If True Then
                If True Then
                    Try
                        Console.WriteLine("start")
                        Database.SetInitializer(Of CustomerContext)(Nothing)
                        Dim ctx As New CustomerContext()


                        'Dim q2 = ctx.Customers.ToList()

                        'Where p.ID = 2
                        Dim q2 = From p In ctx.Customers _
                                 Select p

                        Dim i As Integer = 0
                        For Each item As Customer In q2
                            Console.WriteLine(Convert.ToString(item.ID) & "=>" & Convert.ToString(item.FirstName) & "=>" & Convert.ToString(item.LastName))
                            i += 1

                            Dim custID = item.ID
                            Dim q3 = From p In ctx.Orders Where p.ID = custID _
                                     Select New With { _
                                         p.BuyDate, _
                                         p.Price _
                                     }

                            For Each item2 As Object In q3
                                Console.WriteLine(vbTab & vbTab & vbTab & Convert.ToString(item2.BuyDate) & "=>" & item2.Price)

                            Next
                        Next
                        Console.WriteLine("# of Rows:" & i)
                    Catch e As Exception

                        If e.InnerException IsNot Nothing Then
                            Console.WriteLine(e.InnerException.Message)
                        Else
                            Console.WriteLine(e.Message)

                        End If
                    Finally
                        Console.WriteLine("Enter to exit:")
                        Dim line As String = Console.ReadLine()
                    End Try

                End If
            End If
        End Sub
    End Class
End Namespace