Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class ThuTienDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    Public Shared Function ThemPhieuThu(ByVal PhieuThu As PhieuThuTienDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into phieuthutien values(@MaPhieuThu, @SoTienThu, @NgayThuTien, @MaKhachHang)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaPhieuThu", PhieuThu.MaPhieuThu)
            cmd.Parameters.AddWithValue("@SoTienThu", PhieuThu.SoTienThu)
            cmd.Parameters.AddWithValue("@NgayThuTien", PhieuThu.NgayThu)
            cmd.Parameters.AddWithValue("@MaKhachHang", PhieuThu.MaKhachHang)
            Dim count = cmd.ExecuteNonQuery()
            If (count > 0) Then
                Return True
            End If
        Catch ex As Exception
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return False
    End Function
    ''' <summary>
    ''' cập nhập lại thông tin tiền nợ của khách hàng
    ''' </summary>
    ''' <param name="TienNoMoi"></param>
    ''' <param name="MaKhachHang"></param>
    ''' <returns></returns>
    Public Shared Function Update_TienNo(ByVal TienNoMoi As Decimal, ByVal MaKhachHang As String) As Boolean
        If TienNoMoi < 0 Then
            TienNoMoi = 0
        End If
        Try
            con.Open()
            Dim query = "update khachhang set SoTienNo = @TienNoMoi where MaKhachHang = @MaKH"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@TienNoMoi", TienNoMoi)
            cmd.Parameters.AddWithValue("@MaKH", MaKhachHang)
            Dim count = cmd.ExecuteNonQuery()
            If count > 0 Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return False
    End Function
    ''' <summary>
    ''' lấy thông tin khách hàng
    ''' </summary>
    ''' <param name="MaKH"></param>
    ''' <returns></returns>
    Public Shared Function getKhachHang(ByVal MaKH As String) As List(Of String)
        Dim KhachHang As New List(Of String)
        Try
            con.Open()
            Dim query = "select * from khachhang where MaKhachHang = @MaKhachHang"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKH)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            reader.Read()
            KhachHang.Add(reader.GetString("HoTenKhachHang"))
                KhachHang.Add(reader.GetString("DiaChi"))
                KhachHang.Add(reader.GetString("DienThoai"))
                KhachHang.Add(reader.GetString("Email"))
            KhachHang.Add(reader.GetString("SoTienNo"))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return KhachHang
    End Function
    ''' <summary>
    ''' lấy mã phiếu thu mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaPTT() As String
        Try
            con.Open()
            Dim query = "select MaPhieuThu from phieuthutien order by MaPhieuThu desc limit 1"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaPhieuThu")
            End While
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
End Class
