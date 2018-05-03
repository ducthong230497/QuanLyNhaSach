Imports DAO
Imports DTO
Public Class ChiTietTonBLL
    Public Shared Function ThemChiTietTon(ByVal ChiTietTon As ChiTietTonDTO) As Boolean
        Return ChiTietTonDAL.ThemChiTietTon(ChiTietTon)
    End Function
    Public Shared Function Get_TonCuoi(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Return ChiTietTonDAL.Get_TonCuoi(MaSach, MaBaoCaoTon)
    End Function

    Public Shared Function Get_TonDau(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Return ChiTietTonDAL.Get_TonDau(MaSach, MaBaoCaoTon)
    End Function

    Public Shared Function Get_TonPhatSinh(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Return ChiTietTonDAL.Get_TonPhatSinh(MaSach, MaBaoCaoTon)
    End Function
    Public Shared Function GetMaChiTietTon() As String
        Return ChiTietTonDAL.GetMaChiTietTon()
    End Function
    Public Shared Function SuaTonPhatSinh(ByVal MaSach As String, ByVal MaBaoCaoTon As String, ByVal TonPhatSinh As Integer, ByVal TonDau As Integer) As Boolean
        Return ChiTietTonDAL.SuaTonPhatSinh(MaSach, MaBaoCaoTon, TonPhatSinh, TonDau)
    End Function
End Class
