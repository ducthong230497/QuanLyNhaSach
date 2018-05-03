Imports DAO
Imports DTO
Public Class NhapSachBLL
    Public Shared Function TimSach(ByVal MS As String, ByRef checkFound As Boolean) As SachDTO
        Return DAO.NhapSachDAL.TimSach(MS, checkFound)
    End Function

    Public Shared Function NhapSach(ByVal NhapSachDTO As NhapSachDTO, ByVal SoLuongTonCu As Integer) As Boolean
        Return DAO.NhapSachDAL.NhapSach(NhapSachDTO, SoLuongTonCu)
    End Function

    Public Shared Function GetMaPN() As String
        Return NhapSachDAL.GetMaPN()
    End Function

    Public Shared Function ThemPhieuNhap(ByVal PhieuNhap As PhieuNhapDTO) As Boolean
        Return DAO.NhapSachDAL.ThemPhieuNhap(PhieuNhap)
    End Function

    Public Shared Function GetMaCTPN() As String
        Return NhapSachDAL.GetMaCTPN()
    End Function

    Public Shared Sub ThemChiTietPhieuNhap(ByVal CTPN As ChiTietPhieuNhapDTO)
        NhapSachDAL.ThemChiTietPhieuNhap(CTPN)
    End Sub
End Class
