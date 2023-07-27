Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Program
    Sub Main(args As String())
        Dim emp_id As Int16
        Dim emp_name As String
        Dim salary As Double
        'Console.WriteLine("Enter employee ID : ")
        'emp_id = Convert.ToInt16(Console.ReadLine)
        'Console.WriteLine("Enter employee name : ")
        'emp_name = Console.ReadLine
        'Console.WriteLine("Enter employee Salary : ")
        'salary = Convert.ToInt64(Console.ReadLine)

        Dim con As New SqlConnection
        Dim insert As String = "delete from EmployeeADO  where salary = (select max(salary) from EmployeeADO)"
        con.ConnectionString = "Data Source=CHN-NAND-CW03;Initial Catalog=SRFDatabase;Integrated Security=true"
        Dim cmd As New SqlCommand
        Try
            con.Open()

            Dim adapter As New SqlDataAdapter
            Dim ds As New DataSet

            cmd.Connection = con
            cmd.CommandText = "select * from EmployeeADO"
            cmd.ExecuteNonQuery()
            adapter = New SqlDataAdapter(cmd)
            adapter.Fill(ds)
            Dim sqlcmd As SqlCommandBuilder = New SqlCommandBuilder(adapter)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim result = From dt In ds.Tables(0).AsEnumerable
                             Where dt.Field(Of Double)("salary") > 70000
                             Select New With {.emp_id = dt.Field(Of Integer)("emp_id"),
                                 .emp_name = dt.Field(Of String)("emp_name"),
                                 .emp_sal = dt.Field(Of Double)("salary")
                                 }
                For Each i In result
                    Console.WriteLine($"ID : {i.emp_id}, Name : {i.emp_name}, Salary : {i.emp_sal}")
                Next
            End If
            'Console.WriteLine("Enter Employee Id")
            'Dim id As Integer = Convert.ToInt16(Console.ReadLine())
            'Console.WriteLine("Enter the Employee name")
            'Dim name1 As String = Console.ReadLine()
            'Console.WriteLine("Enter Employee Salary")
            'Dim salary1 = Convert.ToDouble(Console.ReadLine())
            'Dim dr As DataRow = ds.Tables(0).Rows(0)
            'dr(0) = id
            'dr(1) = name1
            'dr(2) = salary1
            'ds.Tables(0).Rows.Add(dr)
            'adapter.Update(ds, ds.Tables(0).ToString)
            'For i = 0 To ds.Tables(0).Rows.Count - 1
            '    Console.WriteLine("ID: " & ds.Tables(0).Rows(i).ItemArray(0))
            '    Console.WriteLine("Name: " & ds.Tables(0).Rows(i).ItemArray(1))
            '    Console.WriteLine("Salary: " & ds.Tables(0).Rows(i).ItemArray(2))
            'Next
            'cmd = New SqlCommand(select1, con)
            'Dim reader As SqlDataReader = cmd.ExecuteReader()
            'While reader.Read()
            '    Console.WriteLine("ID : {0}, Name : {1}, Salary : {2}",
            '        reader("emp_id"), reader("emp_name"), reader("salary"))
            'End While
            con.Close()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try


    End Sub
End Module
