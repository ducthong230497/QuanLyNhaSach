Imports DTO
Imports BUS
Public Class ui_TimKhachHang
    Dim listKhachHang As New List(Of KhachHangDTO)
    Public Shared MaKhachHangVuaXoa As String = String.Empty
    ''' <summary>
    ''' tìm KH
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnTimKH_Click(sender As Object, e As RoutedEventArgs)
        lsvMaKH.Visibility = Visibility.Hidden ' ẩn listview hiện mã kh đi
        listKhachHang = New List(Of KhachHangDTO)
        If (txbMaKhachHang.Text <> String.Empty Or txbTenKhachHang.Text <> String.Empty Or txbSDT.Text <> String.Empty Or txbDiaChi.Text <> String.Empty Or txbEmail.Text <> String.Empty Or txbSoNoTu.Text <> String.Empty Or txbSoNoDen.Text <> String.Empty) Then
            Dim SoTienNoTu As Decimal
            Dim SoTienNoDen As Decimal
            Try
                SoTienNoTu = Decimal.Parse(txbSoNoTu.Text)
            Catch ex As Exception
                SoTienNoTu = 0
                txbSoNoTu.Text = "0"
            End Try
            Try
                SoTienNoDen = Decimal.Parse(txbSoNoDen.Text)
            Catch ex As Exception
                SoTienNoDen = Decimal.MaxValue
                txbSoNoDen.Text = ""
            End Try
            listKhachHang = BUS.TimKhachHangBLL.TimKhachHang(txbMaKhachHang.Text, txbTenKhachHang.Text, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, SoTienNoTu, SoTienNoDen)
            If (listKhachHang.Count > 0) Then
                dtgTimKH.ItemsSource = listKhachHang ' load dữ liệu lên datagrid
            Else
                MessageBox.Show("Không tìm thấy", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        Else
            MessageBox.Show("Không có thông tin để tìm", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
    ''' <summary>
    ''' chọn 1 khách hàng trong datagrid để xóa
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXoaKH_Click(sender As Object, e As RoutedEventArgs)
        Dim Temp As KhachHangDTO = New KhachHangDTO()
        Try
            Temp = dtgTimKH.SelectedItem
            If (Temp.MaKhachHang = MaKhachHangVuaXoa) Then
                Return
            End If
        Catch ex As Exception

        End Try
        Dim check As Boolean = XoaKhachHangBLL.XoaKhachHang(Temp.MaKhachHang) 'xóa sách được chọn
        If (check = True) Then
            For Each item In listKhachHang
                If (item.MaKhachHang = Temp.MaKhachHang) Then ' xóa khỏi list
                    listKhachHang.Remove(item)
                    Exit For
                End If
            Next
            dtgTimKH.ItemsSource = Nothing ' cập nhập lại datagrid
            dtgTimKH.Items.Clear()
            dtgTimKH.ItemsSource = listKhachHang
            btnSuaKH.IsEnabled = False
            If dtgTimKH.Items.Count = 0 Then
                btnXoaKH.IsEnabled = False
            End If
            ui_KhachHangTamXoa.KHVuaKhoiPhuc = String.Empty
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    ''' <summary>
    ''' sửa khách hàng được chọn
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSuaKH_Click(sender As Object, e As RoutedEventArgs)
        Dim SuaKhachHang As SuaKhachHang = New SuaKhachHang() ' mở form sừa KH
        SuaKhachHang.DataContext = dtgTimKH.ItemsSource
        SuaKhachHang.ShowDialog()
    End Sub
    ''' <summary>
    ''' khi chọn 1 cell trong datagrid thì enable nút sửa khách hàng
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dtgTimKH_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgTimKH.SelectionChanged
        btnSuaKH.IsEnabled = True
        btnXoaKH.IsEnabled = True
    End Sub

    Private Sub lsvMaKH_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim MaKH As String = String.Empty
        Try
            MaKH = lsvMaKH.SelectedItem.ToString().Substring(lsvMaKH.SelectedItem.ToString().Length - 6) ' cắt chuỗi để lấy mã KH ra
        Catch ex As Exception

        End Try
        If MaKH <> String.Empty Then
            txbMaKhachHang.Text = MaKH
        End If
        lsvMaKH.Visibility = Visibility.Hidden
    End Sub

    Private Sub txbMaKhachHang_TextChanged(sender As Object, e As TextChangedEventArgs)
        If txbMaKhachHang.Text.Length = 0 Then
            lsvMaKH.Visibility = Visibility.Hidden
        Else
            Dim listKH As New List(Of KhachHangDTO)
            listKH = TimKhachHangBLL.TimKhachHang(txbMaKhachHang.Text, txbTenKhachHang.Text, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, 0, Decimal.MaxValue)
            If listKH.Count > 0 Then
                lsvMaKH.Visibility = Visibility.Visible
                lsvMaKH.Items.Clear()
                For Each item In listKH
                    Dim i As ListViewItem = New ListViewItem()
                    i.Content = item.MaKhachHang
                    i.Background = New SolidColorBrush(Color.FromArgb(100, 49, 188, 183))
                    lsvMaKH.Items.Add(i)
                Next
            End If
        End If
    End Sub
End Class
