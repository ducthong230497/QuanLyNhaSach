Public Class NhapSachDTO
	Dim _STT As String

	Public Property STT As Integer
		Get
			Return _STT
		End Get
		Set(value As Integer)
			_STT = value
		End Set
	End Property

    Dim _MaSach As String

    Public Property MaSach As String
        Get
            Return _MaSach
        End Get
        Set(value As String)
            _MaSach = value
        End Set
    End Property

    Dim _TenSach As String

    Public Property TenSach As String
        Get
            Return _TenSach
        End Get
        Set(value As String)
            _TenSach = value
        End Set
    End Property

    Dim _TacGia As String

    Public Property TacGia As String
        Get
            Return _TacGia
        End Get
        Set(value As String)
            _TacGia = value
        End Set
    End Property

    Dim _SoLuongTonCu As Integer

    Public Property SoLuongTonCu As Integer
        Get
            Return _SoLuongTonCu
        End Get
        Set(value As Integer)
            _SoLuongTonCu = value
        End Set
    End Property

    Dim _SoLuongNhap As Integer

    Public Property SoLuongNhap As Integer
        Get
            Return _SoLuongNhap
        End Get
        Set(value As Integer)
            _SoLuongNhap = value
        End Set
    End Property

    Dim _SoLuongTonMoi As Integer

    Public Property SoLuongTonMoi As Integer
        Get
            Return _SoLuongTonMoi
        End Get
        Set(value As Integer)
            _SoLuongTonMoi = value
        End Set
    End Property

End Class
