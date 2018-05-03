Imports BUS
Imports DTO
Public Class ui_ThemSach
    Dim SoLuongSachHienTai As Integer = 0
    Dim STT = 0
    ''' <summary>
    ''' hàm sinh mã sách từ mã sách mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaSach() As String
        Dim temp = ThemSachBLL.getMaSach()
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaSach As String = "0000"
            MaSach += temp
            MaSach = MaSach.Substring(MaSach.Length - 4)
            Return "MS" + MaSach
        Else
            Return "MS0000"
        End If
    End Function

    Dim listSachThem As New List(Of ThemSachDTO)
    Dim MaSachVuaThem As String = String.Empty
    Private Sub btnThem_Click(sender As Object, e As RoutedEventArgs)
        If (txbTenSach.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập tên sách", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbTacGia.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập tác giả", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbTheLoai.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập thế loại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbDonGia.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập đơn giá", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        Dim DonGia As Integer
        Dim ThemSach As DTO.ThemSachDTO = New ThemSachDTO()
        Dim ThemThanhCong As Boolean
        Try
            DonGia = Single.Parse(txbDonGia.Text)
        Catch ex As Exception
            MessageBox.Show("Đơn giá không hợp lệ. Xin kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
            Return
        End Try

        ThemSach = BUS.ThemSachBLL.ThemSach(tblMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, DonGia, ThemThanhCong) ' thêm sách
        If ThemThanhCong = True Then
            MaSachVuaThem = ThemSach.MaSach
            STT = STT + 1
            ThemSach.STT = STT
            listSachThem.Add(ThemSach) ' cập nhập lại datagrid
            dtgThemSach.ItemsSource = Nothing
            dtgThemSach.Items.Clear()
            dtgThemSach.ItemsSource = listSachThem
            ' tạo báo cáo tồn cho sách vừa thêm
            tblMaSach.Text = Get_MaSach()
            txbTenSach.Clear()
            txbTheLoai.Clear()
            txbTacGia.Clear()
            txbDonGia.Clear()
            Dim ChiTietTon As ChiTietTonDTO = New ChiTietTonDTO()
            ChiTietTon.MaChiTietTon = ui_BaoCaoTon.Get_MaChiTietTon()
            ChiTietTon.MaBaoCaoTon = BaoCaoTonBLL.Get_MaBaoCaoTon()
            ChiTietTon.MaSach = ThemSach.MaSach
            ChiTietTon.TonDau = 0
            ChiTietTon.TonPhatSinh = 0
            ChiTietTon.TonCuoi = 0
            If ChiTietTonBLL.ThemChiTietTon(ChiTietTon) = True Then
                MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)

            Else
                MessageBox.Show("Thêm sách không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As RoutedEventArgs)
        If listSachThem.Count > 0 Then ' kiểm tra trong list sách có phần tử không
            If SachDaXoaBLL.TimMaSachDaXoa(listSachThem.Item(listSachThem.Count - 1).MaSach) = True Then ' tránh lỗi xóa bên tra cứu xong quay lại xóa, vì xóa rồi
                listSachThem.Remove(listSachThem.Item(listSachThem.Count - 1)) 'cập nhập lại datagrid
                tblMaSach.Text = Get_MaSach()
                dtgThemSach.ItemsSource = Nothing
                dtgThemSach.Items.Clear()
                dtgThemSach.ItemsSource = listSachThem
                MessageBox.Show("Mã sách không có trong hệ thống", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                Return
            End If
            If XoaSachBLL.XoaSach(listSachThem.Item(listSachThem.Count - 1).MaSach) = True Then
                listSachThem.Remove(listSachThem.Item(listSachThem.Count - 1)) ' cập nhập lại datagrid
                tblMaSach.Text = Get_MaSach()
                dtgThemSach.ItemsSource = Nothing
                dtgThemSach.Items.Clear()
                dtgThemSach.ItemsSource = listSachThem
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If

        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
End Class
