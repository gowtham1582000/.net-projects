Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Xml

Module Program
    Sub Main(args As String())
        Console.WriteLine("------------- Enter the Two String ---------")
        Dim str1 As String
        Dim str2 As String
        Do
            Try
                Dim pattern1 As String = "[!@#$%%^&*()-=+_~`€'\"";.,|/]"
                Console.WriteLine("Enter the First String :")
                str1 = Console.ReadLine
                Dim match As Match = Regex.Match(str1, pattern1)
                If match.Success Then
                    Throw New Exception("Invalid Input String 1: Input String 1 cannot consist of Special Characters and Integers.")
                Else
                    If str1 = "" Then
                        Throw New Exception("Invalid Input String 1: Input String 1 cannot be Empty.")
                    Else
                        Exit Do
                    End If

                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Loop
        Do
            Try
                Dim pattern1 As String = "[!@#$%%^&*()-=+_~`€'\"";.,|/]"
                Console.WriteLine("Enter the Second String :")
                str2 = Console.ReadLine
                Dim match1 As Match = Regex.Match(str2, pattern1)
                If match1.Success Then
                    Throw New Exception("Invalid Input String 2: Input String 2 cannot consist of Special Characters and Integers.")
                Else
                    If str2 = "" Then
                        Throw New Exception("Invalid Input String 2: Input String 2 cannot be Empty.")
                    Else
                        Exit Do
                    End If
                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Loop
        Dim result() As Char = New Char(Len(str1)) {}
        Dim char1() As Char = str1.ToLower().ToCharArray
        Dim char2() As Char = str2.ToLower().ToCharArray
        Dim count As Integer = 0
        Dim count1 As Integer = 0
        For Each i As Char In char1
            If char2.Contains(i) Then
                result(count) = i
                count += 1
            End If
        Next
        Dim str3 As String = New String(result)
        Console.WriteLine("The Common Letters From The Strings: {0}", str3)
        Console.WriteLine("The Total Count Of the Both Strings : {0}", count)
    End Sub
End Module
