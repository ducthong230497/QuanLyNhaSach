Imports BUS
Imports DTO
Public Class ui_KhachHangTamXoa
    Dim listKhachHangDaXoa As New List(Of KhachHangDTO)
    Public Shared KHVuaKhoiPhuc As String = String.Empty
    ''' <summary>
    ''' hiển thị các khách hàng tạm xóa trên datagrid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXemKHDaXoa_Click(sender As Object, e As RoutedEventArgs)
        listKhachHangDaXoa = KhachHangDaXoaBLL.LoadKHDaXoa() ' load dữ liệu
        If listKhachHangDaXoa.Count > 0 Then
            btnKhoiPhucTatCa.IsEnabled = True
            dtgKHDaXoa.ItemsSource = listKhachHangDaXoa
        End If
    End Sub

    ''' <summary>
    ''' khôi phục 1 khách hàng đã xóa
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKhoiPhuc_Click(sender As Object, e As RoutedEventArgs)
        Dim temp As KhachHangDTO = New KhachHangDTO()
        Try
            temp = dtgKHDaXoa.SelectedItem
            If temp.MaKhachHang = KHVuaKhoiPhuc Then 'tránh lỗi người dùng ko select trong datagrid
                Return
            End If
        Catch ex As Exception
            Return
        End Try
        If KhachHangDaXoaBLL.KhoiPhucKH(temp.MaKhachHang) = True Then
            KHVuaKhoiPhuc = temp.MaKhachHang ' cập nhập lại mả vừa khôi phục
            For Each item In listKhachHangDaXoa
                If item.MaKhachHang = temp.MaKhachHang Then ' xóa mã kh khỏi list
                    listKhachHangDaXoa.Remove(item)
                    Exit For
                End If
            Next
            MessageBox.Show("Khôi phục thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            ui_TimKhachHang.MaKhachHangVuaXoa = String.Empty
            dtgKHDaXoa.ItemsSource = Nothing ' cập nhập lại datagrid
            dtgKHDaXoa.Items.Clear()
            dtgKHDaXoa.ItemsSource = listKhachHangDaXoa
            btnKhoiPhuc.IsEnabled = False
            If dtgKHDaXoa.Items.Count = 0 Then
                btnKhoiPhucTatCa.IsEnabled = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' khôi phục tất cả khách hàng đã xóa
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKhoiPhucTatCa_Click(sender As Object, e As RoutedEventArgs)
        For Each item In listKhachHangDaXoa ' duyệt từng phần tử trong list và khôi phục
            KhachHangDaXoaBLL.KhoiPhucKH(item.MaKhachHang)
        Next
        listKhachHangDaXoa.Clear() ' xóa dữ liệu trong list
        dtgKHDaXoa.ItemsSource = Nothing ' cập nhập lại datagrid
        dtgKHDaXoa.Items.Clear()
        dtgKHDaXoa.ItemsSource = listKhachHangDaXoa
        btnKhoiPhuc.IsEnabled = False
        If dtgKHDaXoa.Items.Count = 0 Then
            btnKhoiPhucTatCa.IsEnabled = False
        End If

    End Sub

    Private Sub dtgKHDaXoa_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        btnKhoiPhuc.IsEnabled = True
    End Sub
End Class
