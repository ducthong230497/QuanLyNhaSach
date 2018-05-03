Imports System.Windows
Imports MySql.Data.MySqlClient
Imports DTO
Public Class ThemSachDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    Public Shared Function ThemSach(ByVal tblMaSach As String, ByVal txbTenSach As String, ByVal txbTheLoai As String, ByVal txbTacGia As String, ByVal DonGia As Single, ByRef ThemThanhCong As Boolean) As ThemSachDTO
        Dim Sach As ThemSachDTO = New ThemSachDTO()
        Sach.MaSach = tblMaSach
        Sach.TenSach = txbTenSach
        Sach.TheLoai = txbTheLoai
        Sach.TacGia = txbTacGia
        Sach.DonGia = Single.Parse(DonGia)
        Try
            con.Open()
            Dim query As String = String.Empty
            query &= "insert into sach (MaSach, TenSach, TheLoai, TacGia, SoLuongTon, DonGia)"
            query &= "values (@MaSach, @TenSach, @TheLoai, @TacGia, '0', @DonGia)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", tblMaSach)
            cmd.Parameters.AddWithValue("@TenSach", txbTenSach)
            cmd.Parameters.AddWithValue("@TheLoai", txbTheLoai)
            cmd.Parameters.AddWithValue("@TacGia", txbTacGia)
            cmd.Parameters.AddWithValue("DonGia", DonGia.ToString())
            Dim count = cmd.ExecuteNonQuery()
            If count > 0 Then
                ThemThanhCong = True
            Else
                ThemThanhCong = False
            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Sach
    End Function
    ''' <summary>
    ''' lấy mã sách mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getMaSach() As String
        Try
            con.Open()
            Dim query = "select MaSach from sach order by MaSach desc limit 1"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read
                Return reader.GetString("MaSach")
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
End Class
