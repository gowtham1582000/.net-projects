Module Program
    Sub Main(args As String())
        Dim count As Integer = 1
        Console.WriteLine("Enter how many numbers want to print")
        Dim num As Integer = Convert.ToInt16(Console.ReadLine())
        Console.WriteLine("Enter the multiper number you want to multiply in the odd positions")
        Dim m As Integer = Convert.ToInt16(Console.ReadLine())
        Dim series() As Integer = New Integer(num) {}
        If num = 1 Then
            Console.Write(m)
        Else
            For i As Integer = 1 To num
                If Not i Mod 2 = 0 Then
                    series(i - 1) = m * count
                    count += 1
                Else
                    series(i - 1) = Fibonnaci(i)
                End If
            Next
        End If
        For i As Integer = 0 To series.Length - 2
            Console.Write(series(i) & " ")
        Next
        'Dim name1 As String = Nothing

        'name1 = "gowtham"

        'Console.WriteLine(name1)
    End Sub
    Function Fibonnaci(ByVal f As Integer)
        Dim a As Integer = 0, b = 1, c
        If f = 2 Then
            Return a
        End If
        Dim i As Integer = 3
        While (i <= (f / 2))
            c = (a + b)
            a = b
            b = c
            i += 1
        End While
        Return b
    End Function
End Module
