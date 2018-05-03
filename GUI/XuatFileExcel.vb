Imports BUS
Imports Microsoft.Office.Interop.Excel
Imports WPFFolderBrowser


Public Class XuatFileExcel
    Public Shared Sub XuatBaoCaoTonRaFileExcel(ByVal Thang As Integer, ByVal Nam As Integer)
        Dim Table
        'Khởi tạo cho file excel
        Dim xlExcel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlExcel.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets("sheet1")
        'chọn đường dẫn
        Dim dialog As WPFFolderBrowserDialog = New WPFFolderBrowserDialog()
        Dim check = dialog.ShowDialog()
        If check = True Then
            Try
                Table = ConnectionBLL.Get_BangBaoCaoTon(Thang, Nam)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0
                'ghi dữ liệu
                For Each dc In Table.Columns
                    colIndex = colIndex + 1
                    xlWorkSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In Table.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In Table.Columns
                        colIndex = colIndex + 1
                        xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                Dim FileName = "\" + "BaoCaoTon" + "_" + Date.Now.ToShortDateString() + ".xls"
                Dim finalPath = dialog.FileName + FileName
                'lưu dữ liệu
                xlWorkSheet.Columns.AutoFit()
                xlWorkBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                MessageBox.Show("Xuất thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch ex As Exception
                'giải phóng 
            Finally
                ReleaseObject(xlWorkSheet)
                xlWorkBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(xlWorkBook)
                xlExcel.Quit()
                ReleaseObject(xlExcel)
            End Try
        End If
    End Sub

    Public Shared Sub XuatBaoCaoCongNoRaFileExcel(ByVal Thang As Integer, ByVal Nam As Integer)
        Dim Table
        'Khởi tạo cho file excel
        Dim xlExcel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlExcel.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets("sheet1")
        'chọn đường dẫn
        Dim dialog As WPFFolderBrowserDialog = New WPFFolderBrowserDialog()
        Dim check = dialog.ShowDialog()
        If check = True Then
            Try
                Table = ConnectionBLL.Get_BangBaoCaoCongNo(Thang, Nam)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0
                'ghi dữ liệu
                For Each dc In Table.Columns
                    colIndex = colIndex + 1
                    xlWorkSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In Table.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In Table.Columns
                        colIndex = colIndex + 1
                        xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                Dim FileName = "\" + "BaoCaoCongNo" + "_" + Date.Now.ToShortDateString() + ".xls"
                Dim finalPath = dialog.FileName + FileName
                'lưu dữ liệu
                xlWorkSheet.Columns.AutoFit()
                xlWorkBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                MessageBox.Show("Xuất thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch ex As Exception
                'giải phóng 
            Finally
                ReleaseObject(xlWorkSheet)
                xlWorkBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(xlWorkBook)
                xlExcel.Quit()
                ReleaseObject(xlExcel)
            End Try
        End If
    End Sub

    Private Shared Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
    'problem
    Public Shared Sub asd(ByRef dtg As DataGrid)
        'Khởi tạo cho file excel
        Dim xlExcel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlExcel.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets("sheet1")

        Dim Table As System.Data.DataTable = New System.Data.DataTable()


        'chọn đường dẫn
        Dim dialog As WPFFolderBrowserDialog = New WPFFolderBrowserDialog()
        If dialog.ShowDialog() = True Then
            Try

                For i = 0 To dtg.Items.Count - 1
                    For j = 0 To dtg.Columns.Count - 1

                        dtg.CurrentCell = New DataGridCellInfo(dtg.Items(i), dtg.Columns(j))
                        'Dim cell As DataGridCell = New DataGridCell()

                        Dim content As TextBlock = DirectCast(dtg.CurrentCell.Column.GetCellContent(dtg.Items(i)), TextBlock)

                        xlWorkSheet.Cells(i + 1, j + 1) = content.Text
                    Next
                Next
                Dim FileName = "\test_" + Date.Now.ToShortDateString() + ".xls"
                Dim finalPath = dialog.FileName + FileName
                'lưu dữ liệu
                xlWorkSheet.Columns.AutoFit()
                xlWorkBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                MessageBox.Show("Xuất thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'giải phóng 
            Finally
                ReleaseObject(xlWorkSheet)
                xlWorkBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(xlWorkBook)
                xlExcel.Quit()
                ReleaseObject(xlExcel)
            End Try
        End If

    End Sub

End Class


