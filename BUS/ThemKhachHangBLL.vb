Imports DAO
Imports DTO
Public Class ThemKhachHangBLL
    Public Shared Function ThemKhachHang(ByVal lblMaKH As String, ByVal txbTenKH As String, ByVal txbDiaChi As String, ByVal txbDienThoai As String, ByVal txbEmail As String, ByRef ThemThanhCong As Boolean) As KhachHangDTO
        Return ThemKhachHangDAL.ThemKhachHang(lblMaKH, txbTenKH, txbDiaChi, txbDienThoai, txbEmail, ThemThanhCong)
    End Function

    Public Shared Function getMaKH() As String
        Return ThemKhachHangDAL.GetMaKH()
    End Function
End Class
