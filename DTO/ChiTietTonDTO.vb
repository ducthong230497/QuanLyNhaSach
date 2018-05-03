Public Class ChiTietTonDTO
    Dim _MaChiTietTon As String
    Dim _MaBaoCaoTon As String
    Dim _MaSach As String
    Dim _TonDau As Integer
    Dim _TonPhatSinh As Integer
    Dim _TonCuoi As Integer

    Public Sub New(MaChiTietTon As String, MaBaoCaoTon As String, MaSach As String, TonDau As Integer, TonPhatSinh As Integer, TonCuoi As Integer)
        Me.MaChiTietTon = MaChiTietTon
        Me.MaBaoCaoTon = MaBaoCaoTon
        Me.MaSach = MaSach
        Me.TonDau = TonDau
        Me.TonPhatSinh = TonPhatSinh
        Me.TonCuoi = TonCuoi
    End Sub

    Public Sub New()

    End Sub
    Public Property MaChiTietTon As String
        Get
            Return _MaChiTietTon
        End Get
        Set(value As String)
            _MaChiTietTon = value
        End Set
    End Property

    Public Property MaBaoCaoTon As String
        Get
            Return _MaBaoCaoTon
        End Get
        Set(value As String)
            _MaBaoCaoTon = value
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

    Public Property TonDau As Integer
        Get
            Return _TonDau
        End Get
        Set(value As Integer)
            _TonDau = value
        End Set
    End Property

    Public Property TonPhatSinh As Integer
        Get
            Return _TonPhatSinh
        End Get
        Set(value As Integer)
            _TonPhatSinh = value
        End Set
    End Property

    Public Property TonCuoi As Integer
        Get
            Return _TonCuoi
        End Get
        Set(value As Integer)
            _TonCuoi = value
        End Set
    End Property
End Class
