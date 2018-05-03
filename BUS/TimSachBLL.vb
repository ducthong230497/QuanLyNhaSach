Imports MySql.Data.MySqlClient
Imports DAO
Imports DTO
Public Class TimSachBLL
    Public Shared Function TimSach(ByVal txbMaSach As String, ByVal txbTenSach As String, ByVal txbTheLoai As String, txbTacGia As String, ByVal txbSLTu As Integer, ByVal txbSLDen As Integer, ByVal txbDGTu As Decimal, ByVal txbDGDen As Decimal) As List(Of SachDTO)
        Return DAO.TimSachDAL.TimSach(txbMaSach, txbTenSach, txbTheLoai, txbTacGia, txbSLTu, txbSLDen, txbDGTu, txbDGDen)
    End Function
End Class
