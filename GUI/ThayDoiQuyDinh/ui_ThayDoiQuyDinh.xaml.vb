Imports BUS
Imports DTO
Public Class ui_ThayDoiQuyDinh
    ''' <summary>
    ''' thay đổi quy định
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCapNhap_Click(sender As Object, e As RoutedEventArgs)
        Try
            ThamSoDTO.SoLuongNhapToiThieu = Integer.Parse(txbSoLuongNhapToiThieu.Text)
        Catch ex As Exception
            MessageBox.Show("Định dạng không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try

        Try
            ThamSoDTO.SoLuongTonToiDaTruocKhiNhap = Integer.Parse(txbSoLuongTonTruocKhiNhap.Text)
        Catch ex As Exception
            MessageBox.Show("Định dạng không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try

        Try
            ThamSoDTO.SoLuongTonToiThieuSauKhiBan = Integer.Parse(txbLuongTonToiThieuSauKhiBan.Text)
        Catch ex As Exception
            MessageBox.Show("Định dạng không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try

        Try
            ThamSoDTO.SoTienNoToiDa = Integer.Parse(txbTienNoToiDa.Text)
        Catch ex As Exception
            MessageBox.Show("Định dạng không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try

        ThamSoDTO.SuDungQuyDinh4 = cxbQuyDInh4.IsChecked
        If (ThayDoiQuyDinhBLL.ThayDoiQuyDinh() = True) Then
            MessageBox.Show("Cập nhập thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Cập nhập không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
End Class
