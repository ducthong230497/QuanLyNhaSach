Imports DTO
Imports DAO
Public Class ThayDoiQuyDinhBLL
    Public Shared Function ThayDoiQuyDinh() As Boolean
        Return ThayDoiQuyDinhDAL.ThayDoiQuyDinh()
    End Function
End Class
