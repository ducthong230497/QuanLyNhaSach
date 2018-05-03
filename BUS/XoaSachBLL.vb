Imports DAO
Public Class XoaSachBLL
    Public Shared Function XoaSach(ByVal MaSach As String) As Boolean
        Return XoaSachDAL.XoaSach(MaSach)
    End Function

End Class
