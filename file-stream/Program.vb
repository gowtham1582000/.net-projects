Imports System
Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports OfficeOpenXml
Imports OfficeOpenXml.ConditionalFormatting

Module Program
    Sub Main(args As String())
        'Dim file1 As FileStream = New FileStream("D:\file-stream-task\student-details.txt", FileMode.OpenOrCreate, FileAccess.Write)
        'Dim write As StreamWriter = New StreamWriter(file1)
        'Console.WriteLine("Enter How Many Details Do you Want To Store :")
        'Dim n As Integer = Convert.ToInt16(Console.ReadLine)
        'Dim id() As Integer = New Integer() {}
        'Dim name() As String = New String() {}
        'Dim percentage() As Double = New Double() {}
        'Dim dept() As String = New String() {}
        'Dim Year() As Integer = New Integer() {}
        'For i = 0 To n - 1
        '    Array.Resize(id, i + 1)
        '    Array.Resize(name, i + 1)
        '    Array.Resize(Year, i + 1)
        '    Array.Resize(percentage, i + 1)
        '    Array.Resize(dept, i + 1)
        '    Console.WriteLine("Enter Student ID :")
        '    id(i) = Convert.ToInt16(Console.ReadLine())
        '    Console.WriteLine("Enter Student Name :")
        '    name(i) = Convert.ToString(Console.ReadLine())
        '    Console.WriteLine("Enter Student Department :")
        '    dept(i) = Convert.ToString(Console.ReadLine())
        '    Console.WriteLine("Enter Student Year :")
        '    Year(i) = Convert.ToInt32(Console.ReadLine())
        '    Console.WriteLine("Enter Student Percentage :")
        '    percentage(i) = Convert.ToDouble(Console.ReadLine())
        '    Console.WriteLine("Enter Student College Name :")
        '    Dim college_name As String = Console.ReadLine()
        '    write.WriteLine("{0} {1} {2} {3} {4} {5}", id, name, dept, Year, percentage, college_name)
        '    Console.WriteLine()
        '    write.WriteLine()
        'Next
        'write.Close()

        'Dim file4 As FileStream = New FileStream("D:\file-stream-task\student-details2.txt", FileMode.OpenOrCreate, FileAccess.Read)
        'Dim Read1 As StreamReader = New StreamReader(file4)
        'Dim line3 As String
        'While Not Read1.EndOfStream
        '    line3 = Read1.ReadLine()
        '    Console.WriteLine(line3)
        'End While
        'Read1.Close()

        'Dim file3 As FileStream = New FileStream("D:\file-stream-task\student-details3.txt", FileMode.OpenOrCreate, FileAccess.Write)
        'Dim write1 As StreamWriter = New StreamWriter(file3)
        'Dim file2 As FileStream = New FileStream("D:\file-stream-task\student-details2.txt", FileMode.OpenOrCreate, FileAccess.Read)
        'Dim Read As StreamReader = New StreamReader(file2)
        'Dim line2 As String
        'Dim charArray As String()
        'For i = 0 To n - 1
        '    line2 = Read.ReadLine()
        '    charArray = line2.Split(" ")
        '    If CInt(charArray(i)) = id(i) Then
        '        write1.WriteLine("{0} {1} {2}", line2, name(i), percentage(i))
        '    End If
        'Next
        'write1.Close()
        'Read.Close()
        'Dim write As New ExcelWriter()
        'write.WriteDataToExcel()
        'Dim read As New ExcelReader()
        'read.ReadDataFromExcel()
        ''Dim writeread As New Compare
        ''writeread.CompareWrite()
        'Dim sort As New Yearsort()
        'sort.Sorting()
        'Dim del As New Iddelete
        'del.delete()
    End Sub
    Public Class ExcelWriter
        Protected n As Integer
        Protected studentId, studentYear As Integer
        Protected studentName, studentDepartment, studentCollege As String
        Public Sub WriteDataToExcel()
            Dim filePath As String = "D:\file-stream-task\student1.xlsx"

            Console.WriteLine("Enter the number of students:")
            n = Convert.ToInt32(Console.ReadLine())
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial

            Dim package As New ExcelPackage()

            ' Add a new worksheet to the package
            Dim worksheet = package.Workbook.Worksheets.Add("Sheet11")

            ' Prompt the user for input and store values in the worksheet
            For i As Integer = 0 To n - 1
                Console.WriteLine($"Enter details for Student {i + 1}:")

                Console.WriteLine("Enter the Student ID:")
                studentId = Convert.ToInt32(Console.ReadLine())
                worksheet.Cells(i + 1, 1).Value = studentId

                Console.WriteLine("Enter the Student Name:")
                studentName = Console.ReadLine()
                worksheet.Cells(i + 1, 2).Value = studentName

                Console.WriteLine("Enter the Student Percentage:")
                Dim studentPercentage As Double = Convert.ToDouble(Console.ReadLine())
                worksheet.Cells(i + 1, 3).Value = studentPercentage

                Console.WriteLine("Enter the Student Department:")
                studentDepartment = Console.ReadLine()
                worksheet.Cells(i + 1, 4).Value = studentDepartment

                Console.WriteLine("Enter the Student Year:")
                studentYear = Convert.ToInt32(Console.ReadLine())
                worksheet.Cells(i + 1, 5).Value = studentYear

                Console.WriteLine("Enter the Student College Name:")
                studentCollege = Console.ReadLine()
                worksheet.Cells(i + 1, 6).Value = studentCollege
            Next

            ' Save the Excel package to the specified file
            Dim file As New FileInfo(filePath)
            package.SaveAs(file)

            Console.WriteLine("Data has been written to the Excel file.")
        End Sub
    End Class
    Public Class ExcelReader
        Public Sub ReadDataFromExcel()
            Dim filePath1 As String = "D:\file-stream-task\student2.xlsx"
            Dim data As New List(Of List(Of Object))()

            Using package As New ExcelPackage(New FileInfo(filePath1))
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Dim worksheet = package.Workbook.Worksheets("Sheet2")

                ' Get the dimension of the worksheet (number of rows and columns)
                Dim rowCount As Integer = worksheet.Dimension.Rows
                Dim columnCount As Integer = worksheet.Dimension.Columns

                ' Iterate over the cells and read the values
                For i As Integer = 1 To rowCount
                    Dim row As New List(Of Object)()

                    For j As Integer = 1 To columnCount
                        Dim cellValue = worksheet.Cells(i, j).Value
                        row.Add(cellValue)
                    Next

                    data.Add(row)
                Next
            End Using

            ' Do something with the read data
            For Each row In data
                For Each cellValue In row
                    Console.Write(cellValue)
                    Console.Write(" ")
                    Console.WriteLine()
                Next
            Next
        End Sub
    End Class
    Class Compare
        Inherits ExcelWriter
        Sub CompareWrite()
            Dim filePath1 As String = "D:\file-stream-task\student1.xlsx"
            Dim filePath2 As String = "D:\file-stream-task\student2.xlsx"
            Dim outputFilePath As String = "D:\file-stream-task\student5.xlsx"

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial


            Dim package1 As New ExcelPackage(New FileInfo(filePath1))
            Dim worksheet1 = package1.Workbook.Worksheets("Sheet11")


            Dim package2 As New ExcelPackage(New FileInfo(filePath2))
            Dim worksheet2 = package2.Workbook.Worksheets("Sheet2")


            Dim outputPackage As New ExcelPackage()
            Dim outputWorksheet = outputPackage.Workbook.Worksheets.Add("Sheet1")


            Dim outputRowIndex As Integer = 1


            For i As Integer = 1 To worksheet1.Dimension.End.Row
                Dim studentId1 = worksheet1.Cells(i, 1).Value


                For j As Integer = 1 To worksheet2.Dimension.End.Row
                    Dim studentId2 = worksheet2.Cells(j, 1).Value


                    If studentId1 IsNot Nothing AndAlso studentId2 IsNot Nothing AndAlso studentId1 = studentId2 Then

                        For col As Integer = 1 To worksheet1.Dimension.End.Column
                            outputWorksheet.Cells(outputRowIndex, col).Value = worksheet1.Cells(i, col).Value
                        Next
                        outputWorksheet.Cells(outputRowIndex, 6).Value = worksheet2.Cells(j, 2).Value
                        outputWorksheet.Cells(outputRowIndex, 7).Value = worksheet2.Cells(j, 5).Value

                        outputRowIndex += 1

                        Exit For
                    End If
                Next
            Next


            outputPackage.SaveAs(New FileInfo(outputFilePath))


        End Sub
    End Class
    Class Yearsort
        Sub Sorting()
            Dim filePath As String = "D:\file-stream-task\student5.xlsx"
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial

            Using package As New ExcelPackage(New FileInfo(filePath))
                Dim worksheet = package.Workbook.Worksheets("Sheet1")
                Dim rowCount As Integer = worksheet.Dimension.End.Row
                Dim columnCount As Integer = worksheet.Dimension.End.Column

                Dim rows As New List(Of Object())()

                For i = 1 To rowCount
                    Dim rowValues(columnCount) As Object
                    For j = 1 To columnCount
                        rowValues(j - 1) = worksheet.Cells(i, j).Value
                    Next
                    rows.Add(rowValues)
                Next


                rows = rows.OrderBy(Function(row) row(5)).ToList()


                For i = 1 To rowCount
                    Dim rowValues() As Object = rows(i - 1)
                    For j = 1 To columnCount
                        worksheet.Cells(i, j).Value = rowValues(j - 1)
                    Next
                Next

                package.Save()
            End Using
            Console.WriteLine("The Excel file has been sorted by the 'Year' column.")
        End Sub
    End Class
    Class Iddelete
        Sub delete()
            Dim filePath As String = "D:\file-stream-task\student5.xlsx"
            Dim data As New List(Of List(Of Object))()
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial
            Console.WriteLine("Enter the Student ID That you want to delete The column : ")
            Dim studentIdToDelete As Integer = Convert.ToInt16(Console.ReadLine())
            Using package As New ExcelPackage(New FileInfo(filePath))
                Dim worksheet = package.Workbook.Worksheets("Sheet1")
                Dim rowCount As Integer = worksheet.Dimension.Rows
                Dim columnCount As Integer = worksheet.Dimension.Columns
                For i = 1 To rowCount
                    If studentIdToDelete = worksheet.Cells(i, 1).Value Then
                        worksheet.DeleteRow(i)
                    End If
                Next
                package.Save()
            End Using
            Console.WriteLine("The rows with the specified student ID have been deleted.")
        End Sub

    End Class
End Module
