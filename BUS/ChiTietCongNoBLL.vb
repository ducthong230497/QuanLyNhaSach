Imports DAO
Imports DTO
Public Class ChiTietCongNoBLL
    Public Shared Function ThemChiTietCongNo(ByVal ChiTietCongNo As ChiTietCongNoDTO) As Boolean
        Return ChiTietCongNoDAL.ThemChiTietCongNo(ChiTietCongNo)
    End Function
    Public Shared Function SuaNoPhatSinh(ByVal MaKH As String, ByVal MaBaoCaoCongNo As String, ByVal NoPhatSinh As Integer, ByVal NoDau As Integer) As Boolean
        Return ChiTietCongNoDAL.SuaNoPhatSinh(MaKH, MaBaoCaoCongNo, NoPhatSinh, NoDau)
    End Function
    Public Shared Function Get_NoDau(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Integer
        Return ChiTietCongNoDAL.Get_NoDau(MaKhachHang, MaBaoCaoCongNo)
    End Function

    Public Shared Function Get_NoPhatSinh(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Decimal
        Return ChiTietCongNoDAL.Get_NoPhatSinh(MaKhachHang, MaBaoCaoCongNo)
    End Function

    Public Shared Function Get_NoCuoi(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Integer
        Return ChiTietCongNoDAL.Get_NoCuoi(MaKhachHang, MaBaoCaoCongNo)
    End Function

    Public Shared Function GetMaChiTietCongNo() As String
        Return ChiTietCongNoDAL.GetMaChiTietCongNo()
    End Function
End Class
