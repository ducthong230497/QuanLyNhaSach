Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class ThemKhachHangDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    Public Shared Function ThemKhachHang(ByVal lblMaKH As String, ByVal txbTenKH As String, ByVal txbDiaChi As String, ByVal txbDienThoai As String, ByVal txbEmail As String, ByRef ThemThanhCong As Boolean) As KhachHangDTO
        Dim KhachHang As KhachHangDTO = New KhachHangDTO()
        KhachHang.MaKhachHang = lblMaKH
        KhachHang.HoTenKhachHang = txbTenKH
        KhachHang.DiaChi = txbDiaChi
        KhachHang.DienThoai = txbDienThoai
        KhachHang.Email = txbEmail
        Try
            con.Open()
            Dim query As String = String.Empty
            query &= "insert into khachhang (MaKhachHang, HoTenKhachHang, DiaChi, DienThoai, Email, SoTienNo)"
            query &= "values (@MaKH, @TenKH, @DiaChi, @DienThoai, @Email, 0)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKH", lblMaKH)
            cmd.Parameters.AddWithValue("@TenKH", txbTenKH)
            cmd.Parameters.AddWithValue("@DiaChi", txbDiaChi)
            cmd.Parameters.AddWithValue("@DienThoai", txbDienThoai)
            cmd.Parameters.AddWithValue("@Email", txbEmail)
            Dim count = cmd.ExecuteNonQuery()
            If count > 0 Then
                ThemThanhCong = True
            Else
                ThemThanhCong = False
            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return KhachHang
    End Function
    ''' <summary>
    ''' lấy mã khách hàng mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaKH() As String
        Using con
            Dim SoKH_hHienTai = 0
            Try
                con.Open()
                Dim query = "select MaKhachHang from khachhang order by MaKhachHang desc limit  1"
                Dim cmd As MySqlCommand = New MySqlCommand(query, con)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read
                    Return reader.GetString("MaKhachHang")
                End While
                con.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                con.Dispose()
                con.Close()
            End Try
            Return ""
        End Using
    End Function
End Class
