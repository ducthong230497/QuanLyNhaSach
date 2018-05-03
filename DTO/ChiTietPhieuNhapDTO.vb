Public Class ChiTietPhieuNhapDTO
    Dim _MaChiTietPhieuNhap As String
    Dim _MaPhieuNhap As String
    Dim _MaSach As String
    Dim _SoLuongNhap As Integer


    Public Property MaChiTietPhieuNhap As String
        Get
            Return _MaChiTietPhieuNhap
        End Get
        Set(value As String)
            _MaChiTietPhieuNhap = value
        End Set
    End Property

    Public Property MaPhieuNhap As String
        Get
            Return _MaPhieuNhap
        End Get
        Set(value As String)
            _MaPhieuNhap = value
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

    Public Property SoLuongNhap As Integer
        Get
            Return _SoLuongNhap
        End Get
        Set(value As Integer)
            _SoLuongNhap = value
        End Set
    End Property
End Class
