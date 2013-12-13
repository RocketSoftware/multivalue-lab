Imports System.Linq
Imports System.Data.Entity

Namespace EntityFramework_CodeFirst_MultiValue1
    Class Program
        Shared Sub Main(args As String())
            Try
                Console.WriteLine("start")
                Database.SetInitializer(Of CustomerContext)(Nothing)
                Dim ctx As New CustomerContext()
                'Dim q2 = ctx.Customers.ToList()

                'where p.ID = 2

                Dim q2 = From p In ctx.Customers _
                         Select New With { _
                             p.ID, _
                             p.FirstName, _
                             p.LastName, _
                             p.Price, _
                             p.BuyDate _
                         }

                For Each item As Object In q2

                    Console.WriteLine(item.ID & "=>" & item.FirstName & "=>" & item.LastName & "=>" & Convert.ToString(item.Price) & "=>" & Convert.ToString(item.BuyDate))

                Next
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

        End Sub
    End Class
End Namespace
