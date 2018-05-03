Public Class PhieuNhapDTO
    Dim _MaPhieuNhap As String
    Dim _NgayNhap As DateTime


    Public Property MaPhieuNhap As String
        Get
            Return _MaPhieuNhap
        End Get
        Set(value As String)
            _MaPhieuNhap = value
        End Set
    End Property

    Public Property NgayNhap As Date
        Get
            Return _NgayNhap
        End Get
        Set(value As Date)
            _NgayNhap = value
        End Set
    End Property
End Class
