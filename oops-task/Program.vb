Module Program
    Sub Main(args As String())
        'Dim train As traindetails = New traindetails()
        'train.Gettraindetails()
        'train.PrintTrainDetails()
        'Dim Lib1 As Bookdetails = New Bookdetails()
        'Lib1.Bookdetails()
        'Lib1.ShowBookDetails()
        Dim bank As Bankdetails = New Bankdetails()
        bank.GetDetails()
        bank.PrintDetails()
    End Sub
    Public Class Trainbooking
        Protected train_no, psg_no As Int64
        Protected train_fare As Double
        Protected train_name As String
        Protected name() As String
        Protected age() As Integer
        Sub Gettraindetails()
            Console.WriteLine("Enter The Train Number : ")
            train_no = Convert.ToInt64(Console.ReadLine())
            Console.WriteLine("Enter The Train Name : ")
            train_name = Convert.ToString(Console.ReadLine())
            Console.WriteLine("Enter The Train Fare : ")
            train_fare = Convert.ToInt64(Console.ReadLine())
            Console.WriteLine("Enter How Many Passangers : ")
            psg_no = Convert.ToInt32(Console.ReadLine())
            For i As Integer = 0 To psg_no - 1
                Array.Resize(name, i + 1)
                Array.Resize(age, i + 1)
                Console.WriteLine("Enter The Passanger Name {0} : ", i + 1)
                name(i) = Convert.ToString(Console.ReadLine())
                Console.WriteLine("Enter The {0} Age : ", name(i))
                age(i) = Convert.ToInt16(Console.ReadLine())
            Next
        End Sub
    End Class
    Class traindetails
        Inherits Trainbooking
        Sub PrintTrainDetails()
            Dim age1 As Double
            Dim count As Double
            Console.WriteLine()
            Console.WriteLine("------------- Passenger Details -------------")
            Console.WriteLine("Train Number : " & train_no)
            Console.WriteLine("Train Name : " + train_name)
            Console.WriteLine("Passenger Name | Age | Train Fare Details ")
            For i As Integer = 0 To psg_no - 1

                If age(i) > 60 Then
                    age1 = train_fare * 0.75
                    Console.WriteLine("Name : {0} | Age : {1} | Fare : {2}", name(i), age(i), age1)
                ElseIf age(i) <= 5 Then
                    age1 = train_fare / 2
                    Console.WriteLine("Name : {0} | Age : {1} | Fare : {2}", name(i), age(i), age1)
                Else
                    Console.WriteLine("Name : {0} | Age : {1} | Fare : {2}", name(i), age(i), train_fare)
                    count += train_fare
                End If
                count += age1
            Next
            Console.WriteLine("The Total Of the Passenger Tickets : " & count)
        End Sub
    End Class
    Class Library

        Protected User_name As String
        Protected Book_name(), book_author() As String
        Protected book_count, Book_Code() As Double
        Protected Fine_amount As Integer = 25
        Protected db As Date = New Date()
        Protected bcount As Integer


        Sub Bookdetails()
            Console.WriteLine("--------Library Book Details------------")
            Console.WriteLine("Enter The User Name : ")
            User_name = Convert.ToString(Console.ReadLine())
            Console.WriteLine("Enter The Number Of Book You want to Check Out : ")
            bcount = Convert.ToInt16(Console.ReadLine())
            For i As Integer = 0 To bcount - 1
                Array.Resize(Book_Code, i + 1)
                Array.Resize(Book_name, i + 1)
                Array.Resize(book_author, i + 1)
                Console.WriteLine("Enter The Book Name {0} : ", i + 1)
                Book_name(i) = Convert.ToString(Console.ReadLine())
                Console.WriteLine("Enter The Book Author Name {0} : ", i + 1)
                book_author(i) = Convert.ToString(Console.ReadLine())
                Console.WriteLine("Enter The Book Author Code {0} : ", i + 1)
                Book_Code(i) = Convert.ToInt64(Console.ReadLine())
            Next
            Console.WriteLine("Enter The Purchase Date Of The Book")
            db = Date.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo)
        End Sub
    End Class
    Class Bookdetails
        Inherits Library
        Protected db1 As Date = New Date()
        Dim su_date1, due_date, fine As Integer
        Sub ShowBookDetails()
            Console.WriteLine("Enter The Submission Date Of the Books :")
            db1 = Date.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo)
            su_date1 = (db1 - db).Days
            due_date = su_date1 - 10
            fine = due_date * 25
            Console.WriteLine("----------The Books You Returned----------")
            For i As Integer = 0 To bcount - 1
                Console.WriteLine("The {0} Book You Returned At {1}/{2}/{3}", Book_name(i), db1.Day, db1.Month, db1.Year)
            Next
            If due_date = 0 Then
                Console.WriteLine("There is No Due For To Pay!!!")
            Else
                Console.WriteLine("The Due You Need To Pay For {0} Days is {1}", (db1 - db).Days, fine)

            End If
        End Sub
    End Class
    Class Bank
        Protected Account_name, Account_Type As String
        Protected Account_number, Balance As Long
        Sub GetDetails()
            Console.WriteLine("Enter The Acount Number : ")
            Account_number = Convert.ToInt64(Console.ReadLine())
            Console.WriteLine("Enter The Acount Name : ")
            Account_name = Convert.ToString(Console.ReadLine())
            Console.WriteLine("Enter The Acount Type (Savings Or Current) : ")
            Account_Type = Convert.ToString(Console.ReadLine())
            Console.WriteLine("Enter How Much Amount Deposited : ")
            Balance = Convert.ToUInt64(Console.ReadLine())
        End Sub
    End Class
    Class Bankdetails
        Inherits Bank
        Dim acc_name, transaction As String
        Dim transfer, with_draw As Int64
        Dim deposit, credit, acc_no As Long
        Sub PrintDetails()
            Console.WriteLine("-----------Bank Details---------------")
            Transaction1()
            Dim y_n As String
            Console.WriteLine("Want To Do Some Other Option(Y/N) : ")
            y_n = Console.ReadLine()
            If y_n = "N" Then
                Console.WriteLine("Thanks For Using Our Bank")
                Console.ReadKey()
            Else
                While y_n = "Y"
                    Transaction1()
                    Console.WriteLine("Want To Do Some Other Option(Y/N) : ")
                    y_n = Console.ReadLine
                End While
            End If
        End Sub
        Sub Accountdetails()
            Console.WriteLine("--------- Your Account Details --------")
            Console.WriteLine("Account Name : {0}", Account_name)
            Console.WriteLine("Account Number : {0}", +Account_number)
            Console.WriteLine("Account Type : {0}", Account_Type)
            Console.WriteLine("Account Balance : {0}", +Balance)
        End Sub
        Sub Transaction1()
            Console.WriteLine("Want To Do Some Transaction? : ")
            Console.WriteLine("A. Deposit")
            Console.WriteLine("B. Credit")
            Console.WriteLine("C. With Draw")
            Console.WriteLine("E. Balance")
            Console.WriteLine("F. Last Transaction")
            transaction = Convert.ToString(Console.ReadLine())
            Select Case transaction
                Case "A"
                    Console.WriteLine("Enter The Amount You Want To Deposit : ")
                    deposit = Convert.ToInt64(Console.ReadLine())
                    Console.WriteLine("Amount has been Deposited")
                    Balance += deposit
                    Accountdetails()
                Case "B"
                    Console.WriteLine("Enter The Amount You Want To Transfer : ")
                    credit = Convert.ToInt64(Console.ReadLine())
                    If Balance > credit Then
                        Console.WriteLine("Enter The Account Number You Want Transfer : ")
                        transfer = Convert.ToInt64(Console.ReadLine())
                        Console.WriteLine("Amount has been Transfered")
                        Balance -= credit
                        Accountdetails()
                    Else
                        Console.WriteLine("Insufficent Balance in Your Account To Transfer Money")
                    End If
                Case "C"
                    Console.WriteLine("Enter The Amount You Want To WithDraw : ")
                    with_draw = Convert.ToInt64(Console.ReadLine())
                    If Balance > with_draw Then
                        Balance -= with_draw
                        Console.WriteLine("Amount Has Been WithDrawed")
                        Accountdetails()
                    End If
                Case "E"
                    Console.WriteLine("The Balance Of Your Account is {0}", Balance)
                Case "F"
                    Accountdetails()
            End Select
        End Sub
    End Class
End Module
