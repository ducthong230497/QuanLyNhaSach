Imports DAO
Imports DTO
Public Class BaoCaoTonBLL
    Public Shared Function ThemBaoCaoTon(ByVal BaoCaoTon As BaoCaoTonDTO) As Boolean
        Return BaoCaoTonDAL.ThemBaoCaoTon(BaoCaoTon)
    End Function

    Public Shared Function LapBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As List(Of ChiTietTonDTO)
        Return BaoCaoTonDAL.LapBaoCaoTon(Thang, Nam)
    End Function

    Public Shared Function Get_MaBaoCaoTon() As String
        Return BaoCaoTonDAL.Get_MaBaoCaoTon()
    End Function

    Public Shared Function Get_MaBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As String
        Return BaoCaoTonDAL.Get_MaBaoCaoTon(Thang, Nam)
    End Function

    Public Shared Function Get_TenSach(ByVal MaSach As String) As String
        Return BaoCaoTonDAL.Get_TenSach(MaSach)
    End Function
End Class
