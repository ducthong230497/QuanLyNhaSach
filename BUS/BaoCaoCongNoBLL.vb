Imports DAO
Imports DTO
Public Class BaoCaoCongNoBLL
    Public Shared Function ThemBaoCaoCongNo(ByVal BaoCaoCongNo As BaoCaoCongNoDTO) As Boolean
        Return BaoCaoCongNoDAL.ThemBaoCaoCongNo(BaoCaoCongNo)
    End Function

    Public Shared Function LapBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As List(Of ChiTietCongNoDTO)
        Return BaoCaoCongNoDAL.LapBaoCaoCongNo(Thang, Nam)
    End Function

    Public Shared Function Get_TenKhachHang(ByVal MaKhachHang As String) As String
        Return BaoCaoCongNoDAL.Get_TenKhachHang(MaKhachHang)
    End Function

    Public Shared Function Get_MaBaoCaoCongNo() As String
        Return BaoCaoCongNoDAL.Get_MaBaoCaoCongNo()
    End Function

    Public Shared Function Get_MaBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As String
        Return BaoCaoCongNoDAL.Get_MaBaoCaoCongNo(Thang, Nam)
    End Function
End Class
