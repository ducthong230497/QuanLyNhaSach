Imports System.Windows
Imports DTO
Imports MySql.Data.MySqlClient
Public Class NhapSachDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' kiểm tra mã sách có tồn tại trong database hay ko
    ''' </summary>
    ''' <param name="MS"></param>
    ''' <param name="checkFound"></param>
    ''' <returns></returns>
    Public Shared Function TimSach(ByVal MS As String, ByRef checkFound As Boolean) As SachDTO
        Dim sach As DTO.SachDTO = New SachDTO()
        checkFound = False
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("Select * from Sach", con).ExecuteReader
            While reader.Read
                sach = New SachDTO(reader.GetString("MaSach"), reader.GetString("TenSach"), reader.GetString("TheLoai"),
                                   reader.GetString("TacGia"), reader.GetString("SoLuongTon"), reader.GetString("DonGia"))
                If (sach.MaSach = MS) Then
                    checkFound = True
                    Exit While
                End If

            End While
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return sach
    End Function

    Public Shared Function NhapSach(ByVal NhapSachDTO As NhapSachDTO, ByVal SoluongTonCu As Integer) As Boolean
        Dim SoLuongTonMoi As Integer = NhapSachDTO.SoLuongNhap + SoluongTonCu
        Try
            con.Open()
            Dim query As String = "update sach set SoLuongTon=@SoLuongTonMoi where MaSach=@MaSach"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("SoLuongTonMoi", SoLuongTonMoi.ToString())
            cmd.Parameters.AddWithValue("@MaSach", NhapSachDTO.MaSach)
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
    ''' lấy mã phiếu nhập mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaPN() As String
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("select MaPhieuNhap from phieunhap order by MaPhieuNhap desc limit 1", con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaPhieuNhap")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
    Public Shared Function ThemPhieuNhap(ByVal PhieuNhap As PhieuNhapDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into phieunhap (MaPhieuNhap, NgayNhap) values (@Ma, @NgayNhap)"
            Dim cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Ma", PhieuNhap.MaPhieuNhap)
            cmd.Parameters.AddWithValue("@NgayNhap", PhieuNhap.NgayNhap)
            Dim count = cmd.ExecuteNonQuery()
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
    ''' lấy mã chi tiết phiếu nhập mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaCTPN() As String
        Try
            con.Open()
            Dim reader As MySqlDataReader = New MySqlCommand("select MaChiTietPhieuNhap from chitietphieunhap order by MaChiTietPhieuNhap desc limit 1", con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaChiTietPhieuNhap")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
    Public Shared Sub ThemChiTietPhieuNhap(ByVal CTPN As ChiTietPhieuNhapDTO)
        Dim count = 0
        Try
            con.Open()
            Dim query = "insert into chitietphieunhap (MaChiTietPhieuNhap, MaPhieuNhap, MaSach, SoLuongNhap) values (@MaChiTietPhieuNhap, @MaPhieuNhap, @MaSach, @SoLuongNhap)"
            Dim cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaChiTietPhieuNhap", CTPN.MaChiTietPhieuNhap)
            cmd.Parameters.AddWithValue("@MaPhieuNhap", CTPN.MaPhieuNhap)
            cmd.Parameters.AddWithValue("@MaSach", CTPN.MaSach)
            cmd.Parameters.AddWithValue("SoLuongNhap", CTPN.SoLuongNhap)
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
    End Sub
End Class
