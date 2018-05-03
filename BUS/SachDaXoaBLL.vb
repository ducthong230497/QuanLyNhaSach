Imports DAO
Imports DTO
Public Class SachDaXoaBLL
    Public Shared Function LoadSachDaXoa() As List(Of SachDTO)
        Return SachDaXoaDAL.LoadSachDaXoa()
    End Function

    Public Shared Function KhoiPhucSach(ByVal MaSach As String) As Boolean
        Return SachDaXoaDAL.KhoiPhucSach(MaSach)
    End Function

    Public Shared Function TimMaSachDaXoa(ByVal MaSach As String) As Boolean
        Return SachDaXoaDAL.TimMaSachDaXoa(MaSach)
    End Function
End Class
