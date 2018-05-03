Imports System.Windows
Imports System.Windows.Controls
Imports MySql.Data.MySqlClient
Imports DTO
Public Class BaoCaoCongNoDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)

    Public Shared Function ThemBaoCaoCongNo(ByVal BaoCaoCongNo As BaoCaoCongNoDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into baocaocongno values(@MaBaoCaoCongNo, @Thang, @Nam)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaBaoCaoCongNo", BaoCaoCongNo.MaBaoCaoCongNo)
            cmd.Parameters.AddWithValue("@Thang", BaoCaoCongNo.Thang)
            cmd.Parameters.AddWithValue("@Nam", BaoCaoCongNo.Nam)
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


    Public Shared Function LapBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As List(Of ChiTietCongNoDTO)
        Dim listChiTietCongNo As New List(Of ChiTietCongNoDTO)
        Dim stt = 0
        Try
            con.Open()
            Dim query = "select chitietcongno.MaKhachHang, chitietcongno.NoDau, chitietcongno.NoPhatSinh, chitietcongno.NoCuoi from baocaocongno join chitietcongno on baocaocongno.MaBaoCaoCongNo = chitietcongno.MaBaoCaoCongNo where Thang = @Thang and Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Dim BaoCao As ChiTietCongNoDTO = New ChiTietCongNoDTO()
                BaoCao.MaKH = reader.GetString("MaKhachHang")
                BaoCao.NoDau = reader.GetString("NoDau")
                BaoCao.NoPhatSinh = reader.GetString("NoPhatSinh")
                BaoCao.NoCuoi = reader.GetString("NoCuoi")
                listChiTietCongNo.Add(BaoCao)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listChiTietCongNo
    End Function

    Public Shared Function Get_TenKhachHang(ByVal MaKhachHang As String) As String
        Try
            con.Open()
            Dim query = "select HoTenKhachHang from khachhang where MaKhachHang = @MaKhachHang"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("HoTenKhachHang")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function

    Public Shared Function Get_MaBaoCaoCongNo() As String
        Try
            con.Open()
            Dim query = "select MaBaoCaoCongNo from baocaocongno order by MaBaoCaoCongNo desc limit 1"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaBaoCaoCongNo")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function

    Public Shared Function Get_MaBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As String
        Try
            con.Open()
            Dim query = "select MaBaoCaoCongNo from baocaocongno where Thang = @Thang and Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("MaChiTietCongNo")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
End Class
