Public Class ChiTietHoaDonDTO
    Dim _MaChiTietHoaDon As String
    Dim _MaHoaDon As String
    Dim _MaSach As String
    Dim _SoLuongBan As Integer
    Dim _ThanhTien As Decimal


    Public Property MaChiTietHoaDon As String
        Get
            Return _MaChiTietHoaDon
        End Get
        Set(value As String)
            _MaChiTietHoaDon = value
        End Set
    End Property

    Public Property MaHoaDon As String
        Get
            Return _MaHoaDon
        End Get
        Set(value As String)
            _MaHoaDon = value
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

    Public Property SoLuongBan As Integer
        Get
            Return _SoLuongBan
        End Get
        Set(value As Integer)
            _SoLuongBan = value
        End Set
    End Property

    Public Property ThanhTien As Decimal
        Get
            Return _ThanhTien
        End Get
        Set(value As Decimal)
            _ThanhTien = value
        End Set
    End Property
End Class
