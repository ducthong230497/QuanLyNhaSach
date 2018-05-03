Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class TimKhachHangDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy danh sách các khách hàng thỏa điều kiện tìm kiếm
    ''' </summary>
    ''' <param name="txbMaKhachHang"></param>
    ''' <param name="txbTenKhachHang"></param>
    ''' <param name="txbDiaChi"></param>
    ''' <param name="txbSDT"></param>
    ''' <param name="txbEmail"></param>
    ''' <param name="txbSoTienNoTu"></param>
    ''' <param name="txbSoTienNoDen"></param>
    ''' <returns></returns>
    Public Shared Function TimKhachHang(ByVal txbMaKhachHang As String, ByVal txbTenKhachHang As String, ByVal txbDiaChi As String, ByVal txbSDT As String, ByVal txbEmail As String, ByVal txbSoTienNoTu As Decimal, ByVal txbSoTienNoDen As Decimal) As List(Of KhachHangDTO)
        Dim listKhachHang As List(Of KhachHangDTO) = New List(Of KhachHangDTO)
        Dim query = "select * from KhachHang where MaKhachHang like @MaKhachHang and HoTenKhachHang like @HoTenKhachHang and DiaChi like @DiaChi and DienThoai like @DienThoai and Email like @Email and (SoTienNo >= @SoTienNoTu and SoTienNo <= @SoTienNoDen) and MaKhachHang not in(select * from khachhangdaxoa)"
        Dim reader As MySqlDataReader
        Try
            con.Open()
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", "%" + txbMaKhachHang + "%")
            cmd.Parameters.AddWithValue("@HoTenKhachHang", "%" + txbTenKhachHang + "%")
            cmd.Parameters.AddWithValue("@DiaChi", "%" + txbDiaChi + "%")
            cmd.Parameters.AddWithValue("@DienThoai", "%" + txbSDT + "%")
            cmd.Parameters.AddWithValue("@Email", "%" + txbEmail + "%")
            cmd.Parameters.AddWithValue("@SoTienNoTu", txbSoTienNoTu)
            cmd.Parameters.AddWithValue("@SoTienNoDen", txbSoTienNoDen)
            reader = cmd.ExecuteReader
            While reader.Read
                Dim temp As KhachHangDTO = New KhachHangDTO(reader.GetString("MaKhachHang"), reader.GetString("HoTenKhachHang"), reader.GetString("DiaChi"), reader.GetString("DienThoai"), reader.GetString("Email"), reader.GetString("SoTienNo"))
                listKhachHang.Add(temp)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return listKhachHang

    End Function
End Class
