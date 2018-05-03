Imports System.Data
Imports BUS
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Win32

Public Class ImportFileExcel
    Public Shared Sub ImportExcel(ByRef dtg As DataGrid)
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        If ofd.ShowDialog() = True Then
            Try
                Dim path As String = ofd.FileName
                Dim con As OleDb.OleDbConnection
                Dim dataset As DataSet
                Dim adt As OleDb.OleDbDataAdapter
                con = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + ";Extended Properties=Excel 12.0")
                adt = New OleDb.OleDbDataAdapter("select * from [Sheet1$]", con)
                dataset = New DataSet()
                adt.Fill(dataset)
                dtg.ItemsSource = dataset.Tables(0).DefaultView()
                con.Dispose()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class
