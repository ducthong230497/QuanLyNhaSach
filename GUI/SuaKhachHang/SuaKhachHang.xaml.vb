﻿Imports BUS
Public Class SuaKhachHang
    ''' <summary>
    ''' sửa thông tin khách hàng
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim check As Boolean = SuaKhachHangBLL.SuaKhachHang(tblMaKH.Text, txbTenKH.Text, txbDienThoai.Text, txbDiaChi.Text, txbEmail.Text, txbTienNo.Text)
        If (check = True) Then
            MessageBox.Show("Sửa khách hàng thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Close()
        Else
            MessageBox.Show("Sửa khách hàng không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
End Class
