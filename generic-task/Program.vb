Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        Dim emp As List(Of EmployeeDetails) = New List(Of EmployeeDetails)
        Dim n As Integer
        Do
            Try
                Console.Write("Enter a Number Of Employee: ")
                Dim input As String = Console.ReadLine()
                checkNull(input)
                If Integer.TryParse(input, n) Then
                    If Not n <= 0 Then
                        Exit Do
                    Else
                        Throw New Exception("Invalid input: 0 or lesser than 0 is not a valid number.")
                    End If
                Else
                    Throw New Exception("Invalid input: Not a valid number.")
                End If
            Catch ex As Exception

                Console.WriteLine("Invalid Input Please Enter a positive value ")

            End Try
        Loop

        Dim emplist() As EmployeeDetails = New EmployeeDetails(n - 1) {}
        For i As Integer = 0 To n - 1
            Console.WriteLine()
            emplist(i) = New EmployeeDetails()
            Do
                Try
                    Console.Write("Enter Employee ID: ")
                    Dim input As String = Console.ReadLine()

                    checkNull(input)
                    If Not Integer.TryParse(input, emplist(i).emp_id3) Then
                        Throw New Exception("Invalid Input: Employee ID must not Contain Alphabets.")
                    End If

                    If emplist(i).emp_id3 <= 0 Then
                        Throw New Exception("Invalid Input: Employee ID must be a positive integer.")
                    End If
                    emplist(i).emp_exp3 = Integer.Parse(input)

                    Exit Do
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Loop

            Do
                Try
                    Dim pattern1 As String = "[!@#$%%^&*()-=+_~`€'\"";.,|/]"
                    Console.Write("Enter Employee Name: ")
                    Dim input As String = Console.ReadLine()
                    checkNull(input)
                    Dim match As Match = Regex.Match(input, pattern1)
                    If match.Success Then
                        Throw New Exception("Invalid Input: Employee Name cannot consist of Special Characters and Integers.")
                    Else
                        If Not Integer.TryParse(input, Nothing) Then
                            emplist(i).emp_name3 = input

                            Exit Do
                        End If
                    End If

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Loop

            Do
                Try
                    Console.Write("Enter Employee Salary: ")
                    Dim input As String = Console.ReadLine()

                    checkNull(input)

                    If Not Int64.TryParse(input, emplist(i).emp_salary3) Then
                        Throw New Exception("Invalid Input: Employee Salary must be a valid number.")
                    End If

                    If emplist(i).emp_salary3 <= 0 Then
                        Throw New Exception("Invalid Input: Employee Salary must be greater than zero.")
                    End If
                    emplist(i).emp_exp3 = Integer.Parse(input)

                    Exit Do
                Catch ex As Exception
                    Console.WriteLine("Invalid Input You Cannot Enter Special Character or Decimal digits")
                End Try
            Loop

            Do
                Try
                    Console.Write("Enter Employee Experience: ")
                    Dim input As String = Console.ReadLine()

                    checkNull(input)

                    If Not Integer.TryParse(input, emplist(i).emp_exp3) Then
                        Throw New Exception("Invalid Input: Employee Experience must be a valid number.")
                    End If

                    If emplist(i).emp_exp3 < 0 Then
                        Throw New Exception("Invalid Input: Employee Experience must be a positive integer.")
                    End If
                    emplist(i).emp_exp3 = Integer.Parse(input)
                    Exit Do
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Loop
            emp.Add(emplist(i))
        Next
        Console.WriteLine()
        Console.WriteLine("-------- Eligible Employees -------")
        Console.WriteLine()
        For Each e As EmployeeDetails In emp
            If e.emp_exp3 > 8 And e.emp_salary3 > 100000 And e.emp_salary3 < 200000 Then
                Console.WriteLine("The Salary Of {0} is {1} and Expirence is {2} So he is a Eligible Employee", e.emp_name3, e.emp_salary3, e.emp_exp3)
            End If
        Next

    End Sub

    Function checkNull(str As String)
        If String.IsNullOrWhiteSpace(str) Then
            Throw (New NullException("Input Should not be Null or Empty"))
        End If
    End Function

    Class NullException
        Inherits Exception
        Sub New(msg As String)
            MyBase.New(msg)
        End Sub
    End Class

    Public Class EmployeeDetails
        Private Emp_name1 As String
        Private Employeeid1 As Int32
        Private Emp_salary1 As Int64
        Private Emp_exp1 As Int32
        Public Property emp_id3 As Int32
            Get
                Return Employeeid1
            End Get
            Set(value As Int32)
                Employeeid1 = value
            End Set
        End Property
        Public Property emp_name3 As String
            Get
                Return Emp_name1
            End Get
            Set(value As String)
                Emp_name1 = value
            End Set
        End Property
        Public Property emp_salary3 As Int64
            Get
                Return Emp_salary1
            End Get
            Set(value As Int64)
                Emp_salary1 = value
            End Set
        End Property
        Public Property emp_exp3 As Int32
            Get
                Return Emp_exp1
            End Get
            Set(value As Int32)
                Emp_exp1 = value
            End Set
        End Property
    End Class
End Module