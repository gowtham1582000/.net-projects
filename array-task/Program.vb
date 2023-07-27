Imports System
Imports System.Security.Cryptography

Module Program
    Sub Main(args As String())

        'SortingArray()
        'Cyclic()
        'Uniquevalues()


    End Sub
    Function Uniquevalues()
        Console.WriteLine("Array That Consist Of Duplicate Values")
        Dim inputarray() As String = {"Ram", "Shanker", "Ram", "parthipan", "Shanker"}
        For i As Integer = 0 To inputarray.Length - 1
            Console.WriteLine(inputarray(i))
        Next
        Console.WriteLine("Unique and Repeated Values in the array : ")
        For i As Integer = 0 To inputarray.Length - 1
            Dim isRepeated As Boolean = False
            For j As Integer = i + 1 To inputarray.Length - 1
                If inputarray(i) = inputarray(j) Then
                    isRepeated = True
                    Exit For

                End If
            Next
            If Not isRepeated Then
                Console.WriteLine(inputarray(i))
            End If
        Next
    End Function
    Function SortingArray()
        Dim temp As Integer
        Dim name() As Integer = {6, 7, 8, 9, 2, 5, 1, 3}
        Console.WriteLine("Unsorted Array : ")
        For i As Integer = 0 To name.Length - 1
            Console.WriteLine(name(i))
        Next
        For i As Integer = 0 To name.Length - 1
            For j As Integer = 0 To name.Length - i - 2
                If name(j) > name(j + 1) Then
                    temp = name(j)
                    name(j) = name(j + 1)
                    name(j + 1) = temp
                End If
            Next
        Next
        Console.WriteLine("Sorted Array : ")
        For i As Integer = 0 To name.Length - 1
            Console.WriteLine(name(i))

        Next
    End Function
    Function Cyclic()
        Dim inputarray() As Integer = {6, 7, 8, 9, 2, 5, 1, 3}
        Console.WriteLine("Enter The Number of Rotaion you Want : ")
        Dim rotation As Integer = Convert.ToInt32(Console.ReadLine())
        For i As Integer = 1 To rotation
            Dim islastelement As Integer = inputarray(inputarray.Length - 1)
            For j As Integer = inputarray.Length - 1 To 1 Step -1
                inputarray(j) = inputarray(j - 1)
            Next
            inputarray(0) = islastelement
        Next
        For Each num As Integer In inputarray
            Console.Write(num & " ")
        Next
    End Function

End Module
