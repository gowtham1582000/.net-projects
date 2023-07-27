Imports System
'Imports System.Reflection.Metadata.Ecma335

Module Program
    Sub Main(args As String())
        Console.WriteLine("Enter Your Number")
        Dim phone As Long
        Dim oddplus As Integer
        Dim evenplus As Integer
        Dim even As String = ""
        Dim odd As String = ""
        Dim phone1 As String
        phone = Convert.ToInt64(Console.ReadLine())
        phone1 = phone.ToString
        Dim length As Integer = phone.ToString.Length
        For i As Integer = 1 To length
            If Not i Mod 2 = 0 Then

                odd += phone1(i - 1)
                oddplus = CInt(odd)
            Else

                even += phone1(i - 1)
                evenplus = CInt(even)
            End If
        Next
        Console.WriteLine("Odd Index Numbers")
        Console.WriteLine(oddplus)
        Console.WriteLine("Even Index Numbers")
        Console.WriteLine(evenplus)
        Console.WriteLine("Sum Of Odd Numbers : " & GetSingle(oddplus))
        Console.WriteLine("Sum Of Even Number : " & GetSingle(evenplus))
        Console.WriteLine("Sum Of Even And Odd : " & GetSingle(oddplus) + GetSingle(evenplus))
        Console.ReadKey()
    End Sub
    Function GetSingle(ByVal num As Integer) As Integer
        If num < 10 Then
            Return num
        End If
        Dim sum As Integer = 0
        While num > 0
            sum += num Mod 10
            num \= 10
        End While
        Return GetSingle(sum)
    End Function
End Module
