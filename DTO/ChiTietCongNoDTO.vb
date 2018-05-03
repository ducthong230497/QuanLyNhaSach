Public Class ChiTietCongNoDTO
    Dim _MaChiTietCongNo As String
    Dim _MaBaoCaoCongNo As String
    Dim _MaKH As String
    Dim _NoDau As Decimal
    Dim _NoPhatSinh As Decimal
    Dim _NoCuoi As Decimal

    Public Sub New(MaChiTietCongNo As String, MaBaoCaoCongNo As String, MaKH As String, NoDau As Decimal, NoPhatSinh As Decimal, NoCuoi As Decimal)
        Me.MaChiTietCongNo = MaChiTietCongNo
        Me.MaBaoCaoCongNo = MaBaoCaoCongNo
        Me.MaKH = MaKH
        Me.NoDau = NoDau
        Me.NoPhatSinh = NoPhatSinh
        Me.NoCuoi = NoCuoi
    End Sub

    Public Sub New()

    End Sub

    Public Property MaChiTietCongNo As String
        Get
            Return _MaChiTietCongNo
        End Get
        Set(value As String)
            _MaChiTietCongNo = value
        End Set
    End Property

    Public Property MaBaoCaoCongNo As String
        Get
            Return _MaBaoCaoCongNo
        End Get
        Set(value As String)
            _MaBaoCaoCongNo = value
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

    Public Property NoDau As Decimal
        Get
            Return _NoDau
        End Get
        Set(value As Decimal)
            _NoDau = value
        End Set
    End Property

    Public Property NoPhatSinh As Decimal
        Get
            Return _NoPhatSinh
        End Get
        Set(value As Decimal)
            _NoPhatSinh = value
        End Set
    End Property

    Public Property NoCuoi As Decimal
        Get
            Return _NoCuoi
        End Get
        Set(value As Decimal)
            _NoCuoi = value
        End Set
    End Property
End Class
