Imports BUS
Public Class ui_SuaSach
    ''' <summary>
    ''' sửa thông tin sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim check As Boolean = SuaSachBLL.SuaSach(tblMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, txbDonGia.Text)
        If (check = True) Then
            MessageBox.Show("Sửa sách thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Sửa sách không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If

    End Sub
End Class
