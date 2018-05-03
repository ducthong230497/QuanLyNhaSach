Imports DAO
Public Class XoaKhachHangBLL
    Public Shared Function XoaKhachHang(ByVal MaKhachHang As String) As Boolean
        Return XoaKhachHangDAL.XoaKhachHang(MaKhachHang)
    End Function
End Class
