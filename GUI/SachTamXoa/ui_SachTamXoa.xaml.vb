Imports DTO
Imports BUS
Public Class ui_SachTamXoa
    Dim listSachTamXoa As New List(Of SachDTO)
    Public Shared SachVuaKhoiPhuc As String = String.Empty
    ''' <summary>
    ''' xem các sách tạm xóa
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXemSachDaXoa_Click(sender As Object, e As RoutedEventArgs)
        listSachTamXoa = SachDaXoaBLL.LoadSachDaXoa()
        If listSachTamXoa.Count <> 0 Then
            btnKhoiPhucTatCa.IsEnabled = True
            dtgSachDaXoa.ItemsSource = listSachTamXoa
        End If
    End Sub
    ''' <summary>
    ''' chọn 1 cell trong datagrid thì enable nút khôi phục
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dtgSachDaXoa_SelectedCellsChanged(sender As Object, e As SelectedCellsChangedEventArgs)
        btnKhoiPhuc.IsEnabled = True
    End Sub
    ''' <summary>
    ''' khôi mục sách đang được chọn
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKhoiPhuc_Click(sender As Object, e As RoutedEventArgs)
        Dim temp As SachDTO = New SachDTO()
        Try
            temp = dtgSachDaXoa.SelectedItem ' lấy ra sách đang đc chọn
            If temp.MaSach = SachVuaKhoiPhuc Then ' tránh lỗi
                Return
            End If
        Catch ex As Exception
            Return
        End Try
        If SachDaXoaBLL.KhoiPhucSach(temp.MaSach) = True Then
            SachVuaKhoiPhuc = temp.MaSach ' cập nhập lại sách vừa khôi phục
            For Each item In listSachTamXoa
                If item.MaSach = temp.MaSach Then
                    listSachTamXoa.Remove(item) ' xóa sách khỏi list sách tạm xóa
                    Exit For
                End If
            Next
            MessageBox.Show("Khôi phục thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            ui_TimSach.MaSachVuaXoa = String.Empty
            dtgSachDaXoa.ItemsSource = Nothing ' cập nhập lai datagrid
            dtgSachDaXoa.Items.Clear()
            dtgSachDaXoa.ItemsSource = listSachTamXoa
            btnKhoiPhuc.IsEnabled = False
            If dtgSachDaXoa.Items.Count = 0 Then
                btnKhoiPhucTatCa.IsEnabled = False
            End If
        End If
    End Sub

    Private Sub btnKhoiPhucTatCa_Click(sender As Object, e As RoutedEventArgs)
        For Each item In listSachTamXoa ' duyệt từng sách trong list sách xóa để khôi phục
            SachDaXoaBLL.KhoiPhucSach(item.MaSach)
        Next
        listSachTamXoa.Clear()
        dtgSachDaXoa.ItemsSource = Nothing
        dtgSachDaXoa.Items.Clear()
        dtgSachDaXoa.ItemsSource = listSachTamXoa
        btnKhoiPhuc.IsEnabled = False
        If dtgSachDaXoa.Items.Count = 0 Then
            btnKhoiPhucTatCa.IsEnabled = False
        End If
    End Sub
End Class
