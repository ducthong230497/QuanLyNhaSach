Imports MySql.Data.MySqlClient
Imports DTO
Public Class TimSachDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy danh sách các sách thỏa điều kiện tìm kiếm
    ''' </summary>
    ''' <param name="txbMaSach"></param>
    ''' <param name="txbTenSach"></param>
    ''' <param name="txbTheLoai"></param>
    ''' <param name="txbTacGia"></param>
    ''' <param name="txbSLTu"></param>
    ''' <param name="txbSLDen"></param>
    ''' <param name="txbDGTu"></param>
    ''' <param name="txbDGDen"></param>
    ''' <returns></returns>
    Public Shared Function TimSach(ByVal txbMaSach As String, ByVal txbTenSach As String, ByVal txbTheLoai As String, txbTacGia As String, ByVal txbSLTu As Integer, ByVal txbSLDen As Integer, ByVal txbDGTu As Decimal, ByVal txbDGDen As Decimal) As List(Of SachDTO)
        Dim listSach As List(Of SachDTO) = New List(Of SachDTO)
        Dim query = "select * from Sach where MaSach like @MaSach and TenSach like @TenSach and TheLoai like @TheLoai and TacGia like @TacGia and (SoLuongTon >= @SoLuongTonTu and SoLuongTon <= @SoLuongTonDen) and (DonGia >= @DonGiaTu and DonGia <= @DonGiaDen) and MaSach not in(select * from SachDaXoa)"
        Dim reader As MySqlDataReader
        Try
            con.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", "%" + txbMaSach + "%")
            cmd.Parameters.AddWithValue("@TenSach", "%" + txbTenSach + "%")
            cmd.Parameters.AddWithValue("@TheLoai", "%" + txbTheLoai + "%")
            cmd.Parameters.AddWithValue("@TacGia", "%" + txbTacGia + "%")
            cmd.Parameters.AddWithValue("@SoLuongTonTu", txbSLTu)
            cmd.Parameters.AddWithValue("@SoLuongTonDen", txbSLDen)
            cmd.Parameters.AddWithValue("@DonGiaTu", txbDGTu)
            cmd.Parameters.AddWithValue("@DonGiaDen", txbDGDen)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim temp As SachDTO = New SachDTO(reader.GetString("MaSach"), reader.GetString("TenSach"), reader.GetString("TheLoai"), reader.GetString("TacGia"), reader.GetString("SoLuongTon"), reader.GetString("DonGia"))
                listSach.Add(temp)
            End While
        Catch ex As Exception

        Finally
            con.Close()
            con.Dispose()
        End Try

        Return listSach

    End Function
End Class
