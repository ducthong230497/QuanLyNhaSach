Imports MySql.Data.MySqlClient
Imports System.Windows
Imports DTO
Public Class BanSachDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy tên và nợ của khách hàng
    ''' </summary>
    ''' <param name="MaKH"></param>
    ''' <returns></returns>

    Public Shared Function getTen_No(ByVal MaKH As String) As List(Of String)
        Dim Ten_No As New List(Of String)
        Try
            con.Open()
            Dim query = "select HoTenKhachHang, SoTienNo from khachhang where MaKhachHang = @MaKhachHang"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKH)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Ten_No.Add(reader.GetString("HoTenKhachHang"))
                Ten_No.Add(reader.GetString("SoTienNo"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return Ten_No
    End Function

    ''' <summary>
    ''' cập nhập lại số sách trước khi bán
    ''' </summary>
    ''' <param name="MaSach"></param>
    ''' <param name="SoLuongTonBanDau">số lượng tòn trước khi bán</param>
    ''' <returns></returns>
    Public Shared Function XoaSachVuaBan(ByVal MaSach As String, ByVal SoLuongTonBanDau As Integer) As Boolean
        Try
            con.Open()
            Dim query = "update sach set SoLuongTon = @SoLuongTonBanDau where MaSach = @MaSach"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@SoLuongTonBanDau", SoLuongTonBanDau)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            Dim count = 0
            count = cmd.ExecuteNonQuery
            If (count > 0) Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function

    ''' <summary>
    ''' cập nhập lại số sách sau khi bán
    ''' </summary>
    ''' <param name="MaSach"></param>
    ''' <param name="SoLuongTonSauKhiBan"></param>
    ''' <returns></returns>
    Public Shared Function BanSach(ByVal MaSach As String, ByVal SoLuongTonSauKhiBan As Integer) As Boolean
        Try
            con.Open()
            Dim query = "update sach set SoLuongTon = @SoLuongTonSauKhiBan where MaSach = @MaSach"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@SoLuongTonSauKhiBan", SoLuongTonSauKhiBan)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            Dim count = 0
            count = cmd.ExecuteNonQuery()
            If (count > 0) Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function

    ''' <summary>
    ''' lấy mã hóa đơn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaHD() As String
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("select MaHoaDon from hoadon order by MaHoaDon desc limit 1", con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaHoaDon")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' lấy mã chi tiết hóa đơn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaCTHD() As String
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("select MaChiTietHoaDon from chitiethoadon order by MaChiTietHoaDon desc limit 1", con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaChiTietHoaDon")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function

    Public Shared Function ThemHD(ByVal HoaDon As HoaDonDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into hoadon values(@MaHoaDon, @MaKhachHang, @NgayLapHoaDon, @TongTien)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaHoaDon", HoaDon.MaHoaDon)
            cmd.Parameters.AddWithValue("@MaKhachHang", HoaDon.MaKhachHang)
            cmd.Parameters.AddWithValue("@NgayLapHoaDon", HoaDon.NgayLapHoaDon)
            cmd.Parameters.AddWithValue("@TongTien", HoaDon.TongTien)
            Dim count = 0
            count = cmd.ExecuteNonQuery
            If (count > 0) Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function

    Public Shared Function ThemCTHD(ByVal CTHD As ChiTietHoaDonDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into chitiethoadon values(@MaChiTietHoaDon, @MaHoaDon, @MaSach, @SoLuongBan, @ThanhTien)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaChiTietHoaDon", CTHD.MaChiTietHoaDon)
            cmd.Parameters.AddWithValue("@MaHoaDon", CTHD.MaHoaDon)
            cmd.Parameters.AddWithValue("@MaSach", CTHD.MaSach)
            cmd.Parameters.AddWithValue("@SoLuongBan", CTHD.SoLuongBan)
            cmd.Parameters.AddWithValue("@ThanhTien", CTHD.ThanhTien)
            Dim count = 0
            count = cmd.ExecuteNonQuery()
            If count > 0 Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function

    ''' <summary>
    ''' kiểm tra khách hàng có tồn tại hay không
    ''' </summary>
    ''' <param name="MaKH"></param>
    ''' <returns></returns>
    Public Shared Function CheckTonTaiKH(ByVal MaKH As String) As Boolean
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("Select * from khachhang", con).ExecuteReader
            While reader.Read
                If reader.GetString("MaKhachHang") = MaKH Then
                    Return True
                End If
            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return False
    End Function
End Class
