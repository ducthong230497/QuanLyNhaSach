Public Class BaoCaoCongNoDTO
    Dim _MaBaoCaoCongNo As String
    Dim _Thang As Integer
    Dim _Nam As Integer

    Public Sub New(_MaBaoCaoCongNo As String, _MaKH As String, _Thang As Integer, _Nam As Integer)
        Me._MaBaoCaoCongNo = _MaBaoCaoCongNo
        Me.Thang = _Thang
        Me.Nam = _Nam
    End Sub

    Public Sub New()

    End Sub

    Public Property MaBaoCaoCongNo As String
        Get
            Return _MaBaoCaoCongNo
        End Get
        Set(value As String)
            _MaBaoCaoCongNo = value
        End Set
    End Property

    Public Property Nam As Integer
        Get
            Return _Nam
        End Get
        Set(value As Integer)
            _Nam = value
        End Set
    End Property

    Public Property Thang As Integer
        Get
            Return _Thang
        End Get
        Set(value As Integer)
            _Thang = value
        End Set
    End Property
End Class
