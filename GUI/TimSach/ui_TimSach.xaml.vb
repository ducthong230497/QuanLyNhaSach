Imports BUS
Imports DTO
Public Class ui_TimSach
    Dim listSach As List(Of SachDTO) = New List(Of SachDTO)
    Public Shared MaSachVuaXoa As String = String.Empty
    ''' <summary>
    ''' tìm sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnTimSach_Click(sender As Object, e As RoutedEventArgs)
        lsvMaSach.Visibility = Visibility.Hidden
        listSach = New List(Of SachDTO)
        If (checkTimKiem() = True) Then ' tìm sách trong database
            Dim SoLuongTonTu As Integer
            Dim SoLuongTonDen As Integer
            Try
                SoLuongTonTu = Integer.Parse(txbSoLuongTonTu.Text)
            Catch ex As Exception
                SoLuongTonTu = 0
                txbSoLuongTonTu.Text = "0"
            End Try
            Try
                SoLuongTonDen = Integer.Parse(txbSoLuongTonDen.Text)
            Catch ex As Exception
                SoLuongTonDen = Integer.MaxValue
                txbSoLuongTonDen.Text = ""
            End Try
            Dim DonGiaTu As Decimal
            Dim DonGiaDen As Decimal
            Try
                DonGiaTu = Decimal.Parse(txbDonGiaTu.Text)
            Catch ex As Exception
                DonGiaTu = 0
                txbDonGiaTu.Text = "0"
            End Try
            Try
                DonGiaDen = Decimal.Parse(txbDonGiaDen.Text)
            Catch ex As Exception
                DonGiaDen = Decimal.MaxValue
                txbDonGiaDen.Text = ""
            End Try
            listSach = BUS.TimSachBLL.TimSach(txbMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, SoLuongTonTu, SoLuongTonDen, DonGiaTu, DonGiaDen)
            If listSach.Count <> 0 Then ' load lên datagrid
                dtgTimSach.ItemsSource = listSach
            Else
                MessageBox.Show("Không tìm thấy", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        Else
            MessageBox.Show("Không có thông tin để tìm", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
    ''' <summary>
    ''' Kiểm tra các textbox có trống không
    ''' </summary>
    ''' <returns></returns>
    Private Function checkTimKiem() As Boolean
        If (txbMaSach.Text <> String.Empty Or txbTacGia.Text <> String.Empty Or txbTenSach.Text <> String.Empty Or txbTheLoai.Text <> String.Empty Or txbDonGiaTu.Text <> String.Empty Or txbDonGiaDen.Text <> String.Empty Or txbSoLuongTonTu.Text <> String.Empty Or txbSoLuongTonDen.Text <> String.Empty) Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' khi chọn 1 cell trong datagrid thì enable nút sửa sách và xóa sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dtgTimSach_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgTimSach.SelectionChanged
        btnSuaSach.IsEnabled = True
        btnXoaSach.IsEnabled = True
    End Sub
    ''' <summary>
    ''' mở form sửa sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSuaSach_Click(sender As Object, e As RoutedEventArgs)
        Dim suasach As SuaSach = New SuaSach() ' mở form sửa sách
        suasach.DataContext = dtgTimSach.ItemsSource
        suasach.ShowDialog()
    End Sub
    ''' <summary>
    ''' xóa sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXoaSach_Click(sender As Object, e As RoutedEventArgs)
        Dim check As Boolean
        Dim Temp As SachDTO = New SachDTO()
        Try
            Temp = dtgTimSach.SelectedItem ' lấy thông tin sách được chọn
            If Temp.MaSach = MaSachVuaXoa Then ' tránh lỗi người dùng không chọn mà bấm xóa
                Return
            End If
        Catch ex As Exception
            Return
        End Try
        check = XoaSachBLL.XoaSach(Temp.MaSach) ' xóa
        If (check = True) Then
            MaSachVuaXoa = Temp.MaSach ' cập nhập mã sách vừa xóa
            For Each item In listSach ' xóa mã sách vừa xóa khỏi list
                If (item.MaSach = Temp.MaSach) Then
                    listSach.Remove(item)
                    Exit For
                End If
            Next
            dtgTimSach.ItemsSource = Nothing ' cập nhập lại datagrid
            dtgTimSach.Items.Clear()
            dtgTimSach.ItemsSource = listSach
            btnSuaSach.IsEnabled = False
            If dtgTimSach.Items.Count = 0 Then
                btnXoaSach.IsEnabled = False
            End If
            ui_SachTamXoa.SachVuaKhoiPhuc = String.Empty
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
    ''' <summary>
    ''' hiển thị mã sách lên listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txbMaSach_TextChanged(sender As Object, e As TextChangedEventArgs)
        If txbMaSach.Text.Length = 0 Then
            lsvMaSach.Visibility = Visibility.Hidden
        Else
            Dim listMaSach As List(Of SachDTO) = TimSachBLL.TimSach(txbMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, 0, Integer.MaxValue, 0, Decimal.MaxValue)
            lsvMaSach.Items.Clear()
            If listMaSach.Count > 0 Then
                lsvMaSach.Visibility = Visibility.Visible
                For Each item In listMaSach
                    Dim i As ListViewItem = New ListViewItem()
                    i.Content = item.MaSach
                    i.Background = New SolidColorBrush(Color.FromArgb(100, 49, 188, 183))
                    lsvMaSach.Items.Add(i)
                Next
            End If
        End If
    End Sub
    ''' <summary>
    ''' gán mã sách được chọn vào textbox mã sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lsvMaSach_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim MaSach As String = String.Empty
        Try
            MaSach = lsvMaSach.SelectedItem.ToString().Substring(lsvMaSach.SelectedItem.ToString().Length - 6) ' cắt chuỗi để lấy mã sách ra
        Catch ex As Exception

        End Try
        If MaSach <> String.Empty Then
            txbMaSach.Text = MaSach
        End If
        lsvMaSach.Visibility = Visibility.Hidden
    End Sub

End Class
