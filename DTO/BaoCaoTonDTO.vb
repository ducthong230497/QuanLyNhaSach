Public Class BaoCaoTonDTO
    Dim _MaBaoCaoTon As String
    Dim _Thang As Integer
    Dim _Nam As Integer

    Public Sub New()

    End Sub

    Public Sub New(_MaBaoCaoTon As String, _Thang As Integer, _Nam As Integer)
        Me._MaBaoCaoTon = _MaBaoCaoTon
        Me._Thang = _Thang
        Me._Nam = _Nam
    End Sub

    Public Property MaBaoCaoTon As String
        Get
            Return _MaBaoCaoTon
        End Get
        Set(value As String)
            _MaBaoCaoTon = value
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

    Public Property Nam As Integer
        Get
            Return _Nam
        End Get
        Set(value As Integer)
            _Nam = value
        End Set
    End Property
End Class
