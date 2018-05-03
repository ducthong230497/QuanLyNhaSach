Imports BUS
Imports DTO
Imports Geocoding
Imports Geocoding.Google

Public Class ui_ThemKhachHang
    Dim STT = 0
    ''' <summary>
    ''' hàm sinh mã khách hàng từ mã khách hàng mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaKH() As String
        Dim temp = ThemKhachHangBLL.getMaKH()
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaKH As String = "0000"
            MaKH += temp
            MaKH = MaKH.Substring(MaKH.Length - 4)
            Return "KH" + MaKH
        Else
            Return "KH0000"
        End If
    End Function

    Dim listKhachHang As New List(Of dtgThemKhachHang)
    Dim MaKhachHangVuaThem As String = String.Empty
    ''' <summary>
    ''' thêm khách hàng
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnThem_Click(sender As Object, e As RoutedEventArgs)
        If (txbTenKhachHang.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        Else
            txbTenKhachHang.Text = txbTenKhachHang.Text.Trim()
            While txbTenKhachHang.Text.Contains("  ")
                txbTenKhachHang.Text = txbTenKhachHang.Text.Replace("  ", " ")
            End While
        End If
        If (txbDiaChi.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbSDT.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If (txbEmail.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập Email", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If FormatChecking.CheckValid.IsValidEmail(txbEmail.Text) = False Then
            MessageBox.Show("Email không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        If FormatChecking.CheckValid.IsValidPhoneNumber(txbSDT.Text, FormatChecking.CountryCode.Vietnam) = False Then
            MessageBox.Show("Số điện thoại không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If
        Dim KhachHang As New KhachHangDTO()
        Dim KhachHangdtg As New dtgThemKhachHang()
        Dim ThemThanhCong As Boolean ' kiểm tra thêm thành công
        KhachHang = ThemKhachHangBLL.ThemKhachHang(lblMaKH.Content, txbTenKhachHang.Text, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, ThemThanhCong) ' thêm khách hàng
        KhachHangdtg.MaKH = KhachHang.MaKhachHang
        KhachHangdtg.TenKH = KhachHang.HoTenKhachHang
        KhachHangdtg.DiaChi = KhachHang.DiaChi
        KhachHangdtg.DienThoai = KhachHang.DienThoai
        KhachHangdtg.Email = KhachHang.Email
        If (ThemThanhCong = True) Then
            MaKhachHangVuaThem = KhachHangdtg.MaKH
            STT = STT + 1
            KhachHangdtg.STT = STT
            listKhachHang.Add(KhachHangdtg) ' thêm vào list, để xóa
            dtgThemKhachHang.ItemsSource = Nothing ' cập nhập lại datagrid
            dtgThemKhachHang.Items.Clear()
            dtgThemKhachHang.ItemsSource = listKhachHang
            lblMaKH.Content = Get_MaKH()

            txbDiaChi.Clear()
            txbTenKhachHang.Clear()
            txbSDT.Clear()
            txbEmail.Clear()

            Dim ChiTietCongNo As ChiTietCongNoDTO = New ChiTietCongNoDTO() ' tạo công nợ cho khách hàng vừa thêm
            ChiTietCongNo.MaChiTietCongNo = ui_BaoCaoCongNo.Get_MaChiTietCongNo()
            ChiTietCongNo.MaBaoCaoCongNo = BaoCaoCongNoBLL.Get_MaBaoCaoCongNo()
            ChiTietCongNo.MaKH = KhachHang.MaKhachHang
            ChiTietCongNo.NoDau = 0
            ChiTietCongNo.NoPhatSinh = 0
            ChiTietCongNo.NoCuoi = 0
            If ChiTietCongNoBLL.ThemChiTietCongNo(ChiTietCongNo) = True Then
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Else
                MessageBox.Show("Thêm khách hàng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        End If
    End Sub
    ''' <summary>
    ''' xóa khách hàng vừa thêm (thêm mã khách hàng vào bảng khách hàng đã xóa)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXoa_Click(sender As Object, e As RoutedEventArgs)
        If listKhachHang.Count > 0 Then ' kiểm tra trong list khách hàng có phần tử không
            If KhachHangDaXoaBLL.TimMaKHDaXoa(listKhachHang.Item(listKhachHang.Count - 1).MaKH) = True Then ' tránh lỗi xóa bên tra cứu xong quay lại xóa, vì xóa rồi
                listKhachHang.Remove(listKhachHang.Item(listKhachHang.Count - 1)) 'cập nhập lại datagrid
                lblMaKH.Content = Get_MaKH()
                dtgThemKhachHang.ItemsSource = Nothing
                dtgThemKhachHang.Items.Clear()
                dtgThemKhachHang.ItemsSource = listKhachHang
                MessageBox.Show("Mã khách hàng không có trong hệ thống", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                Return
            End If
            If XoaKhachHangBLL.XoaKhachHang(listKhachHang.Item(listKhachHang.Count - 1).MaKH) = True Then
                listKhachHang.Remove(listKhachHang.Item(listKhachHang.Count - 1)) ' cập nhập lại datagrid
                lblMaKH.Content = Get_MaKH()
                dtgThemKhachHang.ItemsSource = Nothing
                dtgThemKhachHang.Items.Clear()
                dtgThemKhachHang.ItemsSource = listKhachHang
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If

        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
    ''' <summary>
    ''' tự động hoàn thành địa chỉ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnHoanThanhDiaChi_Click(sender As Object, e As RoutedEventArgs)
        If txbDiaChi.Text <> String.Empty Then
            Try
                Dim geocoder As IGeocoder = New GoogleGeocoder("AIzaSyDACOr7cCwQXdN3RizokCbPzeqFcBH297Y")
                Dim Addresses As IEnumerable(Of Address) = geocoder.Geocode(txbDiaChi.Text)
                txbDiaChi.Text = Addresses.First().FormattedAddress
            Catch ex As Exception
                MessageBox.Show("Kết nối mạng không ổn định!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End If
    End Sub
End Class
''' <summary>
''' class để binding lên datagrid
''' </summary>
Public Class dtgThemKhachHang
    Dim _STT As Integer
    Dim _MaKH As String
    Dim _TenKH As String
    Dim _DiaChi As String
    Dim _DienThoai As String
    Dim _Email As String

    Public Property STT As Integer
        Get
            Return _STT
        End Get
        Set(value As Integer)
            _STT = value
        End Set
    End Property

    Public Property MaKH As String
        Get
            Return _MaKH
        End Get
        Set(value As String)
            _MaKH = value
        End Set
    End Property

    Public Property TenKH As String
        Get
            Return _TenKH
        End Get
        Set(value As String)
            _TenKH = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return _DiaChi
        End Get
        Set(value As String)
            _DiaChi = value
        End Set
    End Property

    Public Property DienThoai As String
        Get
            Return _DienThoai
        End Get
        Set(value As String)
            _DienThoai = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property
End Class
