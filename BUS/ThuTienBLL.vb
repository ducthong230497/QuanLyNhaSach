Imports DAO
Imports DTO
Public Class ThuTienBLL
    Public Shared Function ThemPhieuThu(ByVal PhieuThu As PhieuThuTienDTO) As Boolean
        Return ThuTienDAL.ThemPhieuThu(PhieuThu)
    End Function

    Public Shared Function Update_TienNo(ByVal TienNoMoi As Decimal, ByVal MaKhachHang As String) As Boolean
        Return ThuTienDAL.Update_TienNo(TienNoMoi, MaKhachHang)
    End Function

    Public Shared Function getKhachHang(ByVal MaKH As String) As List(Of String)
        Return ThuTienDAL.getKhachHang(MaKH)
    End Function

    Public Shared Function GetMaPTT() As String
        Return ThuTienDAL.GetMaPTT()
    End Function

End Class
