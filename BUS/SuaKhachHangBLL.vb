Imports DAO
Public Class SuaKhachHangBLL
    Public Shared Function SuaKhachHang(ByVal MaKH As String, ByVal TenKH As String, ByVal DienThoai As String, ByVal DiaChi As String, ByVal Email As String, ByVal SoTienNo As Single) As Boolean
        Return SuaKhachHangDAL.SuaKhachHang(MaKH, TenKH, DienThoai, DiaChi, Email, SoTienNo)
    End Function
End Class
