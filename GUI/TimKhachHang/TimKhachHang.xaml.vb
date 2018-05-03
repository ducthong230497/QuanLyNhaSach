Imports DTO
Imports BUS
Public Class TimKhachHang
    Dim listKhachHang As New List(Of KhachHangDTO)
    Private Sub btnTimKH_Click(sender As Object, e As RoutedEventArgs) Handles btnTimKH.Click
        listKhachHang = New List(Of KhachHangDTO)
        If (txbMaKhachHang.Text <> String.Empty Or txbTenKhachHang.Text <> String.Empty Or txbSDT.Text <> String.Empty Or txbDiaChi.Text <> String.Empty Or txbEmail.Text <> String.Empty Or txbSoNo.Text <> String.Empty) Then
            listKhachHang = BUS.TimKhachHangBLL.TimKhachHang(txbMaKhachHang.Text, txbTenKhachHang.Text, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, 0, Decimal.MaxValue)
            If (listKhachHang.Count > 0) Then
                dtgTimKH.ItemsSource = listKhachHang
            End If
        End If
    End Sub

    Private Sub btnXoaKH_Click(sender As Object, e As RoutedEventArgs)
        Dim Temp As KhachHangDTO = dtgTimKH.SelectedItem
        Dim check As Boolean = XoaKhachHangBLL.XoaKhachHang(Temp.MaKhachHang)
        If (check = True) Then
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            For Each item In listKhachHang
                If (item.MaKhachHang = Temp.MaKhachHang) Then
                    listKhachHang.Remove(item)
                    Exit For
                End If
            Next
            dtgTimKH.ItemsSource = Nothing
            dtgTimKH.Items.Clear()
            dtgTimKH.ItemsSource = listKhachHang
        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    Private Sub btnSuaKH_Click(sender As Object, e As RoutedEventArgs) Handles btnSuaKH.Click
        Dim SuaKhachHang As SuaKhachHang = New SuaKhachHang()
        SuaKhachHang.DataContext = dtgTimKH.ItemsSource
        SuaKhachHang.Show()
    End Sub

    Private Sub dtgTimKH_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgTimKH.SelectionChanged
        btnSuaKH.IsEnabled = True
        btnXoaKH.IsEnabled = True
    End Sub
End Class
