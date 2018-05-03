Imports BUS
Imports DTO
Public Class ThemKhachHang
    Dim STT = 0
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        InitNewID()
    End Sub

    Private Sub InitNewID()
        Dim intMaSach = BUS.ThemKhachHangBLL.getMaKH().ToString()
        Dim stringMaSach = "KH0000"
        lblMaKH.Content = stringMaSach.Remove(stringMaSach.Length - intMaSach.ToString().Length, intMaSach.ToString().Length).Insert(stringMaSach.Length - intMaSach.ToString().Length, intMaSach.ToString())
    End Sub

    Dim listKhachHang As New List(Of dtgKhachHang)
    Dim MaKhachHangVuaThem As String = String.Empty
    Private Sub btnThem_Click(sender As Object, e As RoutedEventArgs) Handles btnThem.Click
        If (txbTenKhachHang.Text = String.Empty) Then
            MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
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
        Dim KhachHang As New KhachHangDTO()
        Dim KhachHangdtg As New dtgKhachHang()
        Dim ThemThanhCong As Boolean
        KhachHang = ThemKhachHangBLL.ThemKhachHang(lblMaKH.Content, txbTenKhachHang.Text, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, ThemThanhCong)
        KhachHangdtg.MaKH = KhachHang.MaKhachHang
        KhachHangdtg.TenKH = KhachHang.HoTenKhachHang
        KhachHangdtg.DiaChi = KhachHang.DiaChi
        KhachHangdtg.DienThoai = KhachHang.DienThoai
        KhachHangdtg.Email = KhachHang.Email
        If (ThemThanhCong = True) Then
            MaKhachHangVuaThem = KhachHangdtg.MaKH
            STT = STT + 1
            KhachHangdtg.STT = STT
            listKhachHang.Add(KhachHangdtg)
            dtgThemKhachHang.ItemsSource = Nothing
            dtgThemKhachHang.Items.Clear()
            dtgThemKhachHang.ItemsSource = listKhachHang
            InitNewID()
            txbDiaChi.Clear()
            txbTenKhachHang.Clear()
            txbSDT.Clear()
            txbEmail.Clear()
            MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            MessageBox.Show("Thêm khách hàng không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If

    End Sub

    Private Sub btnXoa_Click(sender As Object, e As RoutedEventArgs) Handles btnXoa.Click
        If (MaKhachHangVuaThem <> String.Empty) Then
            Dim check As Boolean = XoaKhachHangBLL.XoaKhachHang(MaKhachHangVuaThem)
            If (check = True) Then
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                For Each item In listKhachHang
                    If (item.MaKH = MaKhachHangVuaThem) Then
                        listKhachHang.Remove(item)
                        Exit For
                    End If
                Next
                dtgThemKhachHang.ItemsSource = Nothing
                dtgThemKhachHang.Items.Clear()
                dtgThemKhachHang.ItemsSource = listKhachHang
            Else
                MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        End If
    End Sub
End Class
Public Class dtgKhachHang
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
