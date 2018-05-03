Imports System.Data
Imports BUS
Imports DTO

Public Class ui_BanSach
    Dim NgayLapHoaDon As String
    Dim BanThanhCong As Boolean = False
    Dim GiaSachVuaBan As Decimal
    Public Shared HoanThanh As Boolean = False
    ''' <summary>
    ''' Lấy tên và nợ của khách hàng vào textbox
    ''' </summary>
    Private Sub getTen_No()
        Try
            Dim Ten_No As New List(Of String)
            Dim MaKH As String = txbMaKH.Text

            Ten_No = BanSachBLL.getTen_No(MaKH)
            txbTenKH.Text = Ten_No.Item(0)
            txbTienNo.Text = Ten_No.Item(1)
        Catch ex As Exception

        End Try
    End Sub


    Dim ListBanSach As New List(Of BanSach) 'Danh sách các sách bán
    Dim STT = 1
    Dim SoLuongTonSauKhiBan As Integer
    ''' <summary>
    ''' Thêm sách cần bán vào danh sách bán
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXacNhan_Click(sender As Object, e As RoutedEventArgs) Handles btnXacNhan.Click
        Dim SoLuongBan As Integer
        lsvMaKH.Visibility = Visibility.Hidden
        lsvMaSach.Visibility = Visibility.Hidden
        If (txbNgayLapHoaDon.Text = String.Empty) Then
            NgayLapHoaDon = DateTime.Now.ToShortDateString()
        Else
            Try
                NgayLapHoaDon = DateTime.Parse(txbNgayLapHoaDon.Text).ToShortDateString
            Catch ex As Exception
                MessageBox.Show("Ngày nhập không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                Return
            End Try
        End If
        If (txbMaKH.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập mã khách hàng", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        Else
            If BanSachBLL.CheckTonTaiKH(txbMaKH.Text) = False Then
                MessageBox.Show("Mã khách hàng này không có trong hệ thống", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                Return
            End If
        End If
        If (txbMaSach.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập mã sách", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbSoLuongBan.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập số lượng bán", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        Else
            Try
                SoLuongBan = Integer.Parse(txbSoLuongBan.Text)
                If SoLuongBan < 0 Then
                    MessageBox.Show("Số lượng bán phải > 0", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                    Return
                End If
            Catch ex As Exception
                MessageBox.Show("Số lượng bán không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End If

        Dim MaSach = txbMaSach.Text
        Dim BanSach As BanSach = New BanSach()
        Dim checkFound As Boolean = False
        Dim Sach As SachDTO = NhapSachBLL.TimSach(MaSach, checkFound) 'Tìm lấy thông tin sách cần bán

        If checkFound = True Then 'checkFound = true, tìm thấy sách
            If STT = 1 Then
                SoLuongTonSauKhiBan = Sach.SoLuong
            End If
            BanSach.STT = STT
            BanSach.TenSach = Sach.TenSach
            BanSach.MaSach = Sach.MaSach
            BanSach.SoLuongBan = txbSoLuongBan.Text
            SoLuongTonSauKhiBan = SoLuongTonSauKhiBan - SoLuongBan
            BanSach.SoLuongTonSauKhiBan = SoLuongTonSauKhiBan
            BanSach.DonGia = Sach.DonGia
            BanSach.ThanhTien = Sach.DonGia * SoLuongBan
            STT = STT + 1
            If (BanSach.SoLuongTonSauKhiBan < ThamSoDTO.SoLuongTonToiThieuSauKhiBan) Then
                MessageBox.Show("Số lượng sách còn lại nhỏ hơn 20. Không thể bán!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                STT = 1
                Return
            End If
            If (Integer.Parse(txbTienNo.Text) > ThamSoDTO.SoTienNoToiDa) Then
                MessageBox.Show("Khách hàng nợ quá nhiều. Không thể bán!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                STT = 1
                Return
            End If
            'tính tổng tiền
            Dim TongTien As String = lblTongTien.Content
            TongTien = TongTien.Remove(TongTien.Length - 2, 2)
            lblTongTien.Content = (Double.Parse(TongTien) + BanSach.DonGia * BanSach.SoLuongBan).ToString() + " đ"
            GiaSachVuaBan = BanSach.DonGia * BanSach.SoLuongBan 'lưu giá sách vừa bán để trừ lại khi bỏ đi

            ListBanSach.Add(BanSach)
            dtgBanSach.ItemsSource = Nothing
            dtgBanSach.Items.Clear()
            dtgBanSach.ItemsSource = ListBanSach
            '   MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            '    BanThanhCong = True
            'Else
            '   MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            'End If
        Else
            MessageBox.Show("Mã sách này không có trong hệ thống", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If

    End Sub

    ''' <summary>
    ''' bỏ 1 sách vừa bán đi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXoaSachVuaBan_Click(sender As Object, e As RoutedEventArgs)
        If ListBanSach.Count > 0 Then
            ListBanSach.RemoveAt(ListBanSach.Count - 1) 'bỏ sách khỏi list sách bán
            dtgBanSach.ItemsSource = Nothing
            dtgBanSach.Items.Clear()
            dtgBanSach.ItemsSource = ListBanSach
            Dim TongTien As String = lblTongTien.Content
            TongTien = TongTien.Remove(TongTien.Length - 2, 2)
            lblTongTien.Content = (Double.Parse(TongTien) - GiaSachVuaBan).ToString() + " đ" 'cập nhập lại tổng  tiền
            STT = STT - 1
        End If
    End Sub

    Dim check As Boolean
    ''' <summary>
    ''' tạo hóa đơn và chi tiết hóa đơn
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnHoanThanh_Click(sender As Object, e As RoutedEventArgs) Handles btnHoanThanh.Click
        'If BanThanhCong = True Then
        If ListBanSach.Count > 0 Then
            Try
                Dim HoaDon As HoaDonDTO = New HoaDonDTO() 'tạo hóa đơn bán sách
                HoaDon.MaHoaDon = GetMaHD()
                HoaDon.MaKhachHang = txbMaKH.Text
                HoaDon.NgayLapHoaDon = NgayLapHoaDon
                Dim TongTien As String = lblTongTien.Content
                TongTien = TongTien.Remove(TongTien.Length - 2, 2)
                HoaDon.TongTien = TongTien
                If BanSachBLL.ThemHD(HoaDon) = True Then 'nếu tạo thành công
                    Try
                        Dim i = 0
                        Dim Thang = Date.Now.Month 'lấy tháng hiện tại
                        Dim Nam = Date.Now.Year
                        While i < ListBanSach.Count 'duyệt hết list sách bán để tạo từng chi tiết hóa đơn
                            check = BanSachBLL.BanSach(ListBanSach.Item(i).MaSach, ListBanSach.Item(i).SoLuongTonSauKhiBan) ' trừ số lượng sách trong cơ sở dữ liệu
                            Dim CTHD As ChiTietHoaDonDTO = New ChiTietHoaDonDTO()
                            CTHD.MaChiTietHoaDon = GetMaCTHD()
                            CTHD.MaHoaDon = HoaDon.MaHoaDon
                            CTHD.MaSach = ListBanSach.Item(i).MaSach
                            CTHD.SoLuongBan = ListBanSach.Item(i).SoLuongBan
                            CTHD.ThanhTien = ListBanSach.Item(i).ThanhTien
                            BanSachBLL.ThemCTHD(CTHD)
                            ' thay đổi thông tin của bảng chi tiết tồn
                            Dim MaBaoCaoTon As String = BaoCaoTonBLL.Get_MaBaoCaoTon()
                            Dim TonDau As Integer = ChiTietTonBLL.Get_TonDau(CTHD.MaSach, MaBaoCaoTon)
                            Dim TonPhatSinh As Integer = ChiTietTonBLL.Get_TonPhatSinh(CTHD.MaSach, MaBaoCaoTon)
                            ChiTietTonBLL.SuaTonPhatSinh(CTHD.MaSach, MaBaoCaoTon, TonPhatSinh - CTHD.SoLuongBan, TonDau) 'sửa tồn phát sinh
                            i = i + 1
                        End While
                        ThuTienBLL.Update_TienNo(Decimal.Parse(TongTien) + Decimal.Parse(txbTienNo.Text), HoaDon.MaKhachHang) 'cập nhập tiền nợ của khách hàng sau khi thu tiền
                        Dim MaBaoCaoCongNo As String = BaoCaoCongNoBLL.Get_MaBaoCaoCongNo()
                        Dim NoDau As Decimal = ChiTietCongNoBLL.Get_NoDau(HoaDon.MaKhachHang, MaBaoCaoCongNo)
                        Dim NoPhatSinh As Decimal = ChiTietCongNoBLL.Get_NoPhatSinh(HoaDon.MaKhachHang, MaBaoCaoCongNo)
                        ChiTietCongNoBLL.SuaNoPhatSinh(HoaDon.MaKhachHang, MaBaoCaoCongNo, NoPhatSinh + Decimal.Parse(TongTien), NoDau) 'sửa nợ phát sinh
                        ListBanSach.Clear() 'sau khi hoàn thành xóa hết dữ liệu trong list sách bán
                        lblTongTien.Content = "0 đ"
                        STT = 1
                        'HoanThanh = True
                        dtgBanSach.ItemsSource = Nothing
                        dtgBanSach.Items.Clear()
                        dtgBanSach.ItemsSource = ListBanSach
                        txbMaKH.Text = String.Empty
                        txbMaKH.Text = HoaDon.MaKhachHang
                        lsvMaKH.Visibility = Visibility.Hidden
                        txbTienNo.Text = (NoPhatSinh + Decimal.Parse(TongTien)).ToString()
                        MessageBox.Show("Hoàn thành", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        'End If
    End Sub
    ''' <summary>
    ''' hàm sinh mã hóa đơn từ mã hóa đơn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaHD() As String
        Dim temp = BanSachBLL.GetMaHD() ' lấy mã hóa đơn mới nhất
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaHD As String = "0000"
            MaHD += temp
            MaHD = MaHD.Substring(MaHD.Length - 4)
            Return "HD" + MaHD
        Else
            Return "HD0000"
        End If
    End Function
    ''' <summary>
    ''' hàm sinh mã chi tiết hóa đơn từ mã chi tiết hóa đơn lớn nhất
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaCTHD() As String
        Dim temp = BanSachBLL.GetMaCTHD() ' lấy mã chi tiết hóa đơn mới nhất
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaCTHD As String = "0000"
            MaCTHD += temp
            MaCTHD = MaCTHD.Substring(MaCTHD.Length - 4)
            Return "CTHD" + MaCTHD
        Else
            Return "CTHD0000"
        End If
    End Function

    ''' <summary>
    ''' load các mã sách vào listview khi gõ vào textbox mã sách
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txbMaSach_TextChanged(sender As Object, e As TextChangedEventArgs)
        If txbMaSach.Text.Length = 0 Then
            lsvMaSach.Visibility = Visibility.Hidden
        Else
            Dim listMaSach As List(Of SachDTO) = TimSachBLL.TimSach(txbMaSach.Text, "", "", "", 0, Integer.MaxValue, 0, Decimal.MaxValue) ' tìm các mã sách
            lsvMaSach.Items.Clear()
            If listMaSach.Count > 0 Then ' bỏ mã sách tìm thấy vào listview
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
    ''' gán mã sách mà người dùng chọn qua textbox khi chọn
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
    ''' <summary>
    ''' gán mã KH mà người dùng chọn qua textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lsvMaKH_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim MaKH As String = String.Empty
        Try
            MaKH = lsvMaKH.SelectedItem.ToString().Substring(lsvMaKH.SelectedItem.ToString().Length - 6) ' cắt chuỗi để lấy mã KH ra
        Catch ex As Exception

        End Try
        If MaKH <> String.Empty Then
            txbMaKH.Text = MaKH
        End If
        lsvMaKH.Visibility = Visibility.Hidden
    End Sub

    ''' <summary>
    ''' load các mã KH vào listview khi gõ vào textbox mã kh
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txbMaKH_TextChanged(sender As Object, e As TextChangedEventArgs)
        getTen_No() ' Lấy tên và nợ của khách hàng vào textbox
        If txbMaKH.Text.Length = 0 Then
            lsvMaKH.Visibility = Visibility.Hidden 'textbox ko có text thì ẩn listview đi
        Else
            Dim listKH As New List(Of KhachHangDTO)
            listKH = TimKhachHangBLL.TimKhachHang(txbMaKH.Text, "", "", "", "", 0, Decimal.MaxValue) ' tìm tất cả mã kh
            If listKH.Count > 0 Then ' bỏ mã khách hàng vào listview
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

''' <summary>
''' class dùng để binding qua datagrid
''' </summary>
Public Class BanSach
    Dim _STT As String
    Dim _MaSach As String
    Dim _TenSach As String
    Dim _SoLuongBan As Integer
    Dim _SoLuongTonSauKhiBan As Integer
    Dim _DonGia As Double
    Dim _ThanhTien As Double

    Public Property STT As String
        Get
            Return _STT
        End Get
        Set(value As String)
            _STT = value
        End Set
    End Property

    Public Property MaSach As String
        Get
            Return _MaSach
        End Get
        Set(value As String)
            _MaSach = value
        End Set
    End Property

    Public Property TenSach As String
        Get
            Return _TenSach
        End Get
        Set(value As String)
            _TenSach = value
        End Set
    End Property

    Public Property SoLuongBan As Integer
        Get
            Return _SoLuongBan
        End Get
        Set(value As Integer)
            _SoLuongBan = value
        End Set
    End Property

    Public Property SoLuongTonSauKhiBan As Integer
        Get
            Return _SoLuongTonSauKhiBan
        End Get
        Set(value As Integer)
            _SoLuongTonSauKhiBan = value
        End Set
    End Property

    Public Property DonGia As Single
        Get
            Return _DonGia
        End Get
        Set(value As Single)
            _DonGia = value
        End Set
    End Property

    Public Property ThanhTien As Double
        Get
            Return _ThanhTien
        End Get
        Set(value As Double)
            _ThanhTien = value
        End Set
    End Property
End Class