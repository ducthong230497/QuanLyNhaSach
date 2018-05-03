Imports BUS
Imports DTO
Public Class ThemSach
    Dim SoLuongSachHienTai As Integer = 0
    Dim STT = 0
    Private Sub Window_Initialized(sender As Object, e As EventArgs)
        InitNewID()
    End Sub

    Private Sub InitNewID()
        Dim intMaSach = BUS.ThemSachBLL.getMaSach().ToString()
        Dim stringMaSach = "MS0000"
        tblMaSach.Text = stringMaSach.Remove(stringMaSach.Length - intMaSach.ToString().Length, intMaSach.ToString().Length).Insert(stringMaSach.Length - intMaSach.ToString().Length, intMaSach.ToString())
    End Sub

    Dim listSachThem As New List(Of ThemSachDTO)
    Dim MaSachVuaThem As String = String.Empty
    Private Sub btnThem_Click(sender As Object, e As RoutedEventArgs) Handles btnThem.Click
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

        ThemSach = BUS.ThemSachBLL.ThemSach(tblMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, DonGia, ThemThanhCong)
        If ThemThanhCong = True Then
            MaSachVuaThem = ThemSach.MaSach
            STT = STT + 1
            ThemSach.STT = STT
            listSachThem.Add(ThemSach)
            dtgThemSach.ItemsSource = Nothing
            dtgThemSach.Items.Clear()
            dtgThemSach.ItemsSource = listSachThem
            'tblMaSach.Text = "MS" + BUS.ThemSachBLL.getMaSach().ToString()
            InitNewID()
            txbTenSach.Clear()
            txbTheLoai.Clear()
            txbTacGia.Clear()
            txbDonGia.Clear()
            MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Thêm sách không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As RoutedEventArgs) Handles btnXoa.Click
        If (MaSachVuaThem <> String.Empty) Then
            Dim check As Boolean = XoaSachBLL.XoaSach(MaSachVuaThem)
            If (check = True) Then
                STT = STT - 1
                For Each item In listSachThem
                    If (item.MaSach = MaSachVuaThem) Then
                        listSachThem.Remove(item)
                        Exit For
                    End If
                Next
                InitNewID()
                dtgThemSach.ItemsSource = Nothing
                dtgThemSach.Items.Clear()
                dtgThemSach.ItemsSource = listSachThem
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Else
                MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        End If
    End Sub
End Class
