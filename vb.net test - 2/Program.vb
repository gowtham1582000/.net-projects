Imports System.IO
Imports System.Text.RegularExpressions

Module Module1
    Sub Main()
        Dim pa As New hospitalbill()
        Dim pa1 As New checkpatient()
        Console.WriteLine("---------- Hospital Details --------")
        Console.WriteLine("Please Enter the Option you Want to do : ")
        Console.WriteLine("1. Want To Add Patient Details")
        Console.WriteLine("2. Want To Check a Patient Details")
        Dim option1 As Integer = Convert.ToInt16(Console.ReadLine)
        If option1 = 1 Then
            pa.getdetail()
            pa.billcreation()
            Do
                Console.WriteLine("Want To Add Some Other Patient Details : (Y/N)")
                Dim ye_no As String = Console.ReadLine()
                If ye_no = "Y" Then
                    pa.getdetail()
                    pa.billcreation()
                Else
                    Exit Do
                End If
            Loop
        Else
            pa1.patient_details()
            Do
                Console.WriteLine("Want To Check Some Other Patient Details : (Y/N)")
                Dim ye_no As String = Console.ReadLine()
                If ye_no = "Y" Then
                    pa1.patient_details()
                Else
                    Exit Do
                End If
            Loop
        End If

    End Sub


    Class patient
        Protected patient_name, patient_address, patient_illness As String
        Protected patient_ph_no As String
        Protected patient_id As Integer
        Protected n As Integer
        Sub getdetail()

            Do
                Try
                    Console.WriteLine("Enter the patient ID : ")
                    patient_id = Console.ReadLine
                    If Integer.TryParse(patient_id, n) Then
                        If Not n <= 0 Then
                            Exit Do
                        Else
                            Throw New Exception("Invalid Patient ID : 0 or lesser than 0 is not a valid number.")
                        End If
                    Else
                        Throw New Exception("Invalid Patient ID: Not a valid number.")
                    End If
                Catch ex As Exception
                    Console.WriteLine("Invalid Patient ID Please Enter a positive value ")

                End Try
            Loop

            Do
                Try
                    Dim pattern1 As String = "[!@#$%%^&*()-=+_~`€'\"";.,|/]"
                    Console.WriteLine("Enter the patient Name : ")
                    patient_name = Console.ReadLine
                    Dim match As Match = Regex.Match(patient_name, pattern1)
                    If match.Success Then
                        Throw New Exception("Invalid Patient Name: Patient Name cannot consist of Special Characters and Integers.")
                    Else
                        If patient_name = "" Then
                            Throw New Exception("Invalid Patient Name : Patient Name cannot be Empty.")
                        Else
                            Exit Do
                        End If

                    End If

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Loop
            Console.WriteLine("Enter the Patient Phone Number :")
            patient_ph_no = Console.ReadLine()
            Console.WriteLine("Enter the Patient Address :")
            patient_address = Console.ReadLine()
            Console.WriteLine("Enter the Patient Illness name :")
            patient_illness = Console.ReadLine
        End Sub
    End Class
    Class hospitalbill
        Inherits patient
        Sub billcreation()
            Dim currentDate As DateTime = DateTime.Now
            Dim rootPath As String = "D:\.NET-PROJECTS\vb.net test - 2\Hospital Bill"
            Dim yearPath As String = Path.Combine(rootPath, currentDate.Year.ToString())
            Dim monthPath As String = Path.Combine(yearPath, currentDate.ToString("MM"))
            Dim dayPath As String = Path.Combine(monthPath, currentDate.ToString("dd"))
            Directory.CreateDirectory(dayPath)
            Dim fileName As String = Path.Combine(dayPath, $"{patient_name}_{patient_id}.txt")
            Dim writer As New StreamWriter(fileName)
            writer.WriteLine("--------- Patient Details ----------")
            writer.WriteLine()
            writer.WriteLine("Patient ID: " & patient_id)
            writer.WriteLine()
            writer.WriteLine("Patient Name: " & patient_name)
            writer.WriteLine()
            writer.WriteLine()
            writer.WriteLine("Patient Ph No: " & patient_ph_no)
            writer.WriteLine()
            writer.WriteLine("Patient Address: " & patient_address)
            writer.WriteLine()
            writer.WriteLine("Patient illness Name: " & patient_illness)
            writer.WriteLine()
            writer.Close()
        End Sub
    End Class
    Class checkpatient
        Inherits patient
        Sub patient_details()
            Console.WriteLine("Enter patient ID Correctly to Check The Patient Details : ")
            Dim patient_id As String = Console.ReadLine()
            Console.WriteLine("Enter patient Name Correctly to Check The Patient Details : ")
            Dim patient_name As String = Console.ReadLine()
            Dim currentDate As DateTime = DateTime.Now
            Dim file4 As FileStream = New FileStream($"D:\.NET-PROJECTS\vb.net test - 2\Hospital Bill\{ currentDate.Year.ToString()}\{currentDate.ToString("MM")}\{currentDate.ToString("dd")}\{patient_name}_{patient_id}.txt", FileMode.OpenOrCreate, FileAccess.Read)
            Dim Read1 As StreamReader = New StreamReader(file4)
            Dim line3 As String
            While Not Read1.EndOfStream
                line3 = Read1.ReadLine()
                Console.WriteLine(line3)
            End While
            Read1.Close()
        End Sub
    End Class
End Module