Public Class KhachHangDTO
    Sub New(ByVal MaKH As String, ByVal TenKH As String, ByVal DiaChi As String, ByVal SDT As String, ByVal Email As String, ByVal TienNo As Single)
        _MaKhachHang = MaKH
        _HoTenKhachHang = TenKH
        _DiaChi = DiaChi
        _DienThoai = SDT
        _Email = Email
        _SoTienNo = TienNo
    End Sub

    Public Sub New()
    End Sub

    Dim _MaKhachHang As String
    Dim _HoTenKhachHang As String
    Dim _DiaChi As String
    Dim _DienThoai As String
    Dim _Email As String
    Dim _SoTienNo As Double

    Public Property MaKhachHang As String
        Get
            Return _MaKhachHang
        End Get
        Set(value As String)
            _MaKhachHang = value
        End Set
    End Property

    Public Property HoTenKhachHang As String
        Get
            Return _HoTenKhachHang
        End Get
        Set(value As String)
            _HoTenKhachHang = value
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

    Public Property SoTienNo As Double
        Get
            Return _SoTienNo
        End Get
        Set(value As Double)
            _SoTienNo = value
        End Set
    End Property
End Class
