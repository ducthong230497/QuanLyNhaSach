Imports System.Windows
Imports System.Windows.Controls
Imports MySql.Data.MySqlClient
Imports DTO
Public Class BaoCaoTonDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)

    Public Shared Function ThemBaoCaoTon(ByVal BaoCaoTon As BaoCaoTonDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into baocaoton values(@MaBaoCaoTon, @Thang, @Nam)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", BaoCaoTon.MaBaoCaoTon)
            cmd.Parameters.AddWithValue("@Thang", BaoCaoTon.Thang)
            cmd.Parameters.AddWithValue("@Nam", BaoCaoTon.Nam)
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


    Public Shared Function LapBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As List(Of ChiTietTonDTO)
        Dim listChiTietTon As New List(Of ChiTietTonDTO)
        Dim stt = 0
        Try
            con.Open()
            Dim query = "select chitietton.MaSach, chitietton.TonDau, chitietton.TonPhatSinh, chitietton.TonCuoi from baocaoton join chitietton on baocaoton.MaBaoCaoTon = chitietton.MaBaoCaoTon where baocaoton.Thang = @Thang and baocaoton.Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Dim BaoCao As ChiTietTonDTO = New ChiTietTonDTO()
                BaoCao.MaSach = reader.GetString("MaSach")
                BaoCao.TonDau = reader.GetString("TonDau")
                BaoCao.TonPhatSinh = reader.GetString("TonPhatSinh")
                BaoCao.TonCuoi = reader.GetString("TonCuoi")
                listChiTietTon.Add(BaoCao)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listChiTietTon
    End Function

    Public Shared Function Get_TenSach(ByVal MaSach As String) As String
        Try
            con.Open()
            Dim query = "select TenSach from sach where MaSach = @MaSach"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("TenSach")
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
    ''' lấy mã báo cáo tồn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaBaoCaoTon() As String
        Try
            con.Open()
            Dim query = "select MaBaoCaoTon from baocaoton order by MaBaoCaoTon desc limit 1"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaBaoCaoTon")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function

    Public Shared Function Get_MaBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As String
        Try
            con.Open()
            Dim query = "select MaBaoCaoTon from baocaoton where Thang = @Thang and Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("MaBaoCaoTon")
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
