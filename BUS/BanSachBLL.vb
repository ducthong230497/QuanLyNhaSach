Imports DAO
Imports DTO
Public Class BanSachBLL
    Public Shared Function getTen_No(ByVal MaKH As String) As List(Of String)
        Dim Ten_No As New List(Of String)
        Ten_No = BanSachDAL.getTen_No(MaKH)
        Return Ten_No
    End Function

    Public Shared Function BanSach(ByVal MaSach As String, ByVal SoLuongTonSauKhiBan As Integer) As Boolean
        Return BanSachDAL.BanSach(MaSach, SoLuongTonSauKhiBan)
    End Function

    Public Shared Function XoaSachVuaBan(ByVal MaSach As String, ByVal SoLuongTonBanDau As Integer) As Boolean
        Return BanSachDAL.XoaSachVuaBan(MaSach, SoLuongTonBanDau)
    End Function

    Public Shared Function GetMaHD() As String
        Return BanSachDAL.GetMaHD()
    End Function
    Public Shared Function GetMaCTHD() As String
        Return BanSachDAL.GetMaCTHD()
    End Function

    Public Shared Function ThemHD(ByVal HoaDon As HoaDonDTO) As Boolean
        Return BanSachDAL.ThemHD(HoaDon)
    End Function

    Public Shared Function ThemCTHD(ByVal CTHD As ChiTietHoaDonDTO) As Boolean
        Return BanSachDAL.ThemCTHD(CTHD)
    End Function

    Public Shared Function CheckTonTaiKH(ByVal MaKH As String) As Boolean
        Return BanSachDAL.CheckTonTaiKH(MaKH)
    End Function
End Class
