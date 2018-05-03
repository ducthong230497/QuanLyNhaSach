Public Class ThemSachDTO
    Dim _STT As Integer
    Dim _MaSach As String
    Dim _TenSach As String
    Dim _TheLoai As String
    Dim _TacGia As String
    Dim _SoLuong As Integer
    Dim _DonGia As Double

    Public Property STT As Integer
        Get
            Return _STT
        End Get
        Set(value As Integer)
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

    Public Property TheLoai As String
        Get
            Return _TheLoai
        End Get
        Set(value As String)
            _TheLoai = value
        End Set
    End Property

    Public Property TacGia As String
        Get
            Return _TacGia
        End Get
        Set(value As String)
            _TacGia = value
        End Set
    End Property

    Public Property SoLuong As Integer
        Get
            Return _SoLuong
        End Get
        Set(value As Integer)
            _SoLuong = value
        End Set
    End Property

    Public Property DonGia As Double
        Get
            Return _DonGia
        End Get
        Set(value As Double)
            _DonGia = value
        End Set
    End Property
End Class
