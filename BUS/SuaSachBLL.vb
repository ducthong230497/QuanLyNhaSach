Imports DAO
Public Class SuaSachBLL
    Public Shared Function SuaSach(ByVal MaSach As String, ByVal TenSach As String, ByVal TheLoai As String, ByVal TacGia As String, ByVal DonGia As String) As Boolean
        Return SuaSachDAL.SuaSach(MaSach, TenSach, TheLoai, TacGia, DonGia)
    End Function
End Class
