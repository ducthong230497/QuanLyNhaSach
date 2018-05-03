Imports DAO
Imports DTO
Public Class ThemSachBLL
    Public Shared Function ThemSach(ByVal tblMaSach As String, ByVal txbTenSach As String, ByVal txbTheLoai As String, ByVal txbTacGia As String, ByVal DonGia As Single, ByRef ThemThanhCong As Boolean) As ThemSachDTO
        Return DAO.ThemSachDAL.ThemSach(tblMaSach, txbTenSach, txbTheLoai, txbTacGia, DonGia, ThemThanhCong)
    End Function

    Public Shared Function getMaSach() As String
        Return DAO.ThemSachDAL.getMaSach()
    End Function
End Class
