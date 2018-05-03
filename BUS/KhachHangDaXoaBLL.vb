Imports DTO
Imports DAO
Public Class KhachHangDaXoaBLL
    Public Shared Function LoadKHDaXoa() As List(Of KhachHangDTO)
        Return KhachHangDaXoaDAL.LoadKHDaXoa()
    End Function

    Public Shared Function KhoiPhucKH(ByVal MaKH As String) As Boolean
        Return KhachHangDaXoaDAL.KhoiPhucKH(MaKH)
    End Function

    Public Shared Function TimMaKHDaXoa(ByVal MaKH As String) As Boolean
        Return KhachHangDaXoaDAL.TimMaKHDaXoa(MaKH)
    End Function
End Class
