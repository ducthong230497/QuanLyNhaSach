Imports BUS
Imports DTO
Public Class ui_NhapSach
    Dim listSach As New List(Of SachDTO)
    Dim listNhapSach As New List(Of NhapSachDTO)
    Dim STT As Integer = 0
    Dim nhapThanhCong As Boolean = False
    Dim NgayNhap As Date

    ''' <summary>
    ''' nhập sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnNhap_Click(sender As Object, e As RoutedEventArgs)
        Dim sln As Integer ' số lượng nhập
        If (txbMaSach.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập mã sách", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If

        If (txbSoLuongNhap.Text = String.Empty) Then
            MessageBox.Show("Đề nghị chọn mã sách", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        Else
            Try
                sln = Integer.Parse(txbSoLuongNhap.Text)
            Catch ex As Exception
                MessageBox.Show("Số lượng nhập không hợp lệ. Xin kiểm tra lại!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error)
                Return
            End Try
        End If

        Try
            NgayNhap = Date.Parse(txbNgayNhap.Text)
        Catch ex As Exception
            MessageBox.Show("Ngày nhập không hợp lệ!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try
        Dim checkFound As Boolean ' kiểm tra sách có trong hệ thống hay không
        Dim Sach As SachDTO = New DTO.SachDTO
        Dim nhapsachDTO As NhapSachDTO = New NhapSachDTO ' dùng để binding dữ liệu cho datagrid

        Try

            Sach = BUS.NhapSachBLL.TimSach(txbMaSach.Text, checkFound)
            If checkFound = True Then
                If (Sach.SoLuong >= ThamSoDTO.SoLuongTonToiDaTruocKhiNhap) Then
                    MessageBox.Show("Số lượng tồn lớn hơn " + ThamSoDTO.SoLuongTonToiDaTruocKhiNhap.ToString() + ". Xin kiểm tra lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
                ElseIf sln < ThamSoDTO.SoLuongNhapToiThieu Then
                    MessageBox.Show("Số lượng nhập nhỏ hơn " + ThamSoDTO.SoLuongNhapToiThieu.ToString() + ". Xin kiểm tra lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
                Else
                    listSach.Add(Sach) ' đưa sách nhập vào list nhập sách
                    STT = STT + 1
                    nhapsachDTO.STT = STT
                    nhapsachDTO.MaSach = Sach.MaSach
                    nhapsachDTO.TenSach = Sach.TenSach
                    nhapsachDTO.TacGia = Sach.TacGia
                    nhapsachDTO.SoLuongTonCu = Sach.SoLuong
                    nhapsachDTO.SoLuongNhap = sln
                    nhapsachDTO.SoLuongTonMoi = nhapsachDTO.SoLuongTonCu + nhapsachDTO.SoLuongNhap
                    If (BUS.NhapSachBLL.NhapSach(nhapsachDTO, nhapsachDTO.SoLuongTonCu) = True) Then
                        listNhapSach.Add(nhapsachDTO)
                        'dtgNhapSach.Items.Add(nhapsachDTO)
                        dtgNhapSach.ItemsSource = Nothing 'cập nhập lại datagrid
                        dtgNhapSach.Items.Clear()
                        dtgNhapSach.ItemsSource = listNhapSach

                        Dim MaBaoCaoTon As String = BaoCaoTonBLL.Get_MaBaoCaoTon()
                        Dim TonDau As Integer = ChiTietTonBLL.Get_TonDau(Sach.MaSach, MaBaoCaoTon) ' lấy tồn đầu
                        Dim TonPhatSinh As Integer = ChiTietTonBLL.Get_TonPhatSinh(Sach.MaSach, MaBaoCaoTon)
                        If ChiTietTonBLL.SuaTonPhatSinh(Sach.MaSach, MaBaoCaoTon, sln + TonPhatSinh, TonDau) = True Then ' sửa tồn phát sinh
                            MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
                            nhapThanhCong = True
                        Else
                            MessageBox.Show("Nhập không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub
    ''' <summary>
    ''' tạo phiếu nhập và chi tiết phiếu nhập
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnHoanThanh_Click(sender As Object, e As RoutedEventArgs)
        If (nhapThanhCong = True) Then
            Dim PhieuNhap As PhieuNhapDTO = New PhieuNhapDTO()
            PhieuNhap.MaPhieuNhap = GetMaPN() ' sinh mã phiếu nhập
            PhieuNhap.NgayNhap = NgayNhap
            If NhapSachBLL.ThemPhieuNhap(PhieuNhap) = True Then
                Dim i = 0
                While i < listNhapSach.Count ' duyệt list thê, chi tiết phiếu nhập
                    Dim CTPN As ChiTietPhieuNhapDTO = New ChiTietPhieuNhapDTO()
                    CTPN.MaChiTietPhieuNhap = GetMaCTPN()
                    CTPN.MaPhieuNhap = PhieuNhap.MaPhieuNhap
                    CTPN.MaSach = listNhapSach.Item(i).MaSach
                    CTPN.SoLuongNhap = listNhapSach.Item(i).SoLuongNhap
                    NhapSachBLL.ThemChiTietPhieuNhap(CTPN)
                    i = i + 1
                End While
            End If
            listNhapSach.Clear()
            dtgNhapSach.ItemsSource = Nothing
            dtgNhapSach.Items.Clear()
            nhapThanhCong = False
            STT = 0
            MessageBox.Show("Hoàn thành", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    ''' <summary>
    ''' hàm sinh mã phiếu nhập từ mã phiếu nhập mới nhất
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaPN() As String
        Dim temp = NhapSachBLL.GetMaPN()
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaPN As String = "0000"
            MaPN += temp
            MaPN = MaPN.Substring(MaPN.Length - 4)
            Return "PN" + MaPN
        Else
            Return "PN0000"
        End If
    End Function
    ''' <summary>
    ''' hàm sinh mã chi tiết phiếu nhập từ mã chi tiết phiếu nhập mới nhất
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaCTPN() As String
        Dim temp = NhapSachBLL.GetMaCTPN()
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaCTPN As String = "0000"
            MaCTPN += temp
            MaCTPN = MaCTPN.Substring(MaCTPN.Length - 4)
            Return "CTPN" + MaCTPN
        Else
            Return "CTPN0000"
        End If
    End Function
    ''' <summary>
    ''' nhập từ file excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnNhapExcel_Click(sender As Object, e As RoutedEventArgs)
        ImportFileExcel.ImportExcel(dtgNhapSach)
    End Sub
    ''' <summary>
    ''' load mã sách vào listview cho người dùng xem
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txbMaSach_TextChanged(sender As Object, e As TextChangedEventArgs)
        If txbMaSach.Text.Length = 0 Then
            lsvMaSach.Visibility = Visibility.Hidden
        Else
            Dim listMaSach As List(Of SachDTO) = TimSachBLL.TimSach(txbMaSach.Text, "", "", "", 0, Integer.MaxValue, 0, Decimal.MaxValue)
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
    ''' gán mã sách mà người dùng chọn vào textbox mả sách
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
