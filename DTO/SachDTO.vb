Public Class SachDTO
    Sub New()

    End Sub
    Sub New(ByVal MaSach As String, ByVal TenSach As String, ByVal TheLoai As String, ByVal TacGia As String, ByVal SoLuong As Int16, ByVal DonGia As Single)
        Me._MaSach = MaSach
        Me._TenSach = TenSach
        Me._TheLoai = TheLoai
        Me._TacGia = TacGia
        Me._SoLuong = SoLuong
        Me._DonGia = DonGia
    End Sub


    Dim _MaSach As String
    Dim _TenSach As String
    Dim _TheLoai As String
    Dim _TacGia As String
    Dim _SoLuong As Integer
    Dim _DonGia As Double

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

    Public Property SoLuong As Short
        Get
            Return _SoLuong
        End Get
        Set(value As Short)
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
