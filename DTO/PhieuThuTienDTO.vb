Public Class PhieuThuTienDTO
    Dim _MaPhieuThu As String
    Dim _MaKhachHang As String
    Dim _NgayThu As Date
    Dim _SoTienThu As Decimal

    Public Property MaPhieuThu As String
        Get
            Return _MaPhieuThu
        End Get
        Set(value As String)
            _MaPhieuThu = value
        End Set
    End Property

    Public Property MaKhachHang As String
        Get
            Return _MaKhachHang
        End Get
        Set(value As String)
            _MaKhachHang = value
        End Set
    End Property

    Public Property NgayThu As Date
        Get
            Return _NgayThu
        End Get
        Set(value As Date)
            _NgayThu = value
        End Set
    End Property

    Public Property SoTienThu As Decimal
        Get
            Return _SoTienThu
        End Get
        Set(value As Decimal)
            _SoTienThu = value
        End Set
    End Property
End Class
