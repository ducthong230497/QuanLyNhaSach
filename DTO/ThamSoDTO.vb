Public Class ThamSoDTO
    Shared _SoLuongNhapToiThieu As Integer
    Shared _SoLuongTonToiDaTruocKhiNhap As Integer
    Shared _SoTienNoToiDa As Decimal
    Shared _SoLuongTonToiThieuSauKhiBan As Integer
    Shared _SuDungQuyDinh4 As Boolean

    Public Shared Property SoLuongNhapToiThieu As Integer
        Get
            Return _SoLuongNhapToiThieu
        End Get
        Set(value As Integer)
            _SoLuongNhapToiThieu = value
        End Set
    End Property

    Public Shared Property SoLuongTonToiDaTruocKhiNhap As Integer
        Get
            Return _SoLuongTonToiDaTruocKhiNhap
        End Get
        Set(value As Integer)
            _SoLuongTonToiDaTruocKhiNhap = value
        End Set
    End Property

    Public Shared Property SoTienNoToiDa As Decimal
        Get
            Return _SoTienNoToiDa
        End Get
        Set(value As Decimal)
            _SoTienNoToiDa = value
        End Set
    End Property

    Public Shared Property SoLuongTonToiThieuSauKhiBan As Integer
        Get
            Return _SoLuongTonToiThieuSauKhiBan
        End Get
        Set(value As Integer)
            _SoLuongTonToiThieuSauKhiBan = value
        End Set
    End Property

    Public Shared Property SuDungQuyDinh4 As Boolean
        Get
            Return _SuDungQuyDinh4
        End Get
        Set(value As Boolean)
            _SuDungQuyDinh4 = value
        End Set
    End Property
End Class
