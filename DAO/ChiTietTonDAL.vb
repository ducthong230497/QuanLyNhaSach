Imports System.Windows
Imports DTO
Imports MySql.Data.MySqlClient
Public Class ChiTietTonDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)

    Public Shared Function ThemChiTietTon(ByVal ChiTietTon As ChiTietTonDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into chitietton values (@MaChiTietTon, @MaBaoCaoTon, @MaSach, @TonDau, @TonPhatSinh, @TonCuoi)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaChiTietTon", ChiTietTon.MaChiTietTon)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", ChiTietTon.MaBaoCaoTon)
            cmd.Parameters.AddWithValue("@MaSach", ChiTietTon.MaSach)
            cmd.Parameters.AddWithValue("@TonDau", ChiTietTon.TonDau)
            cmd.Parameters.AddWithValue("@TonPhatSinh", ChiTietTon.TonPhatSinh)
            cmd.Parameters.AddWithValue("@TonCuoi", ChiTietTon.TonCuoi)
            Dim count = 0
            count = cmd.ExecuteNonQuery()
            If (count > 0) Then
                Return True
            End If
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function
    Public Shared Function Get_TonDau(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Try
            con.Open()
            Dim query = "select TonDau from chitietton where MaSach = @MaSach and MaBaoCaoTon = @MaBaoCaoTon"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", MaBaoCaoTon)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("TonDau")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function
    Public Shared Function Get_TonCuoi(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Try
            con.Open()
            Dim query = "select TonCuoi from chitietton where MaSach = @MaSach and MaBaoCaoTon = @MaBaoCaoTon"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", MaBaoCaoTon)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("TonCuoi")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function
    Public Shared Function Get_TonPhatSinh(ByVal MaSach As String, ByVal MaBaoCaoTon As String) As Integer
        Try
            con.Open()
            Dim query = "select TonPhatSinh from chitietton where MaSach = @MaSach and MaBaoCaoTon = @MaBaoCaoTon"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", MaBaoCaoTon)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("TonPhatSinh")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function

    ''' <summary>
    ''' lấy ra mã chi tiết tồn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetMaChiTietTon() As String
        Try
            con.Open()
            Dim query = "select MaChiTietTon from chitietton order by MaChiTietTon desc limit 1"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                Return reader.GetString("MaChiTietTon")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return ""
    End Function
    Public Shared Function SuaTonPhatSinh(ByVal MaSach As String, ByVal MaBaoCaoTon As String, ByVal TonPhatSinh As Integer, ByVal TonDau As Integer) As Boolean
        Dim TonCuoi As Integer = TonDau + TonPhatSinh
        Try
            con.Open()
            Dim query = "update chitietton set TonPhatSinh = @TonPhatSinh, TonCuoi = @TonCuoi where MaSach = @MaSach and MaBaoCaoTon = @MaBaoCaoTon"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@TonPhatSinh", TonPhatSinh)
            cmd.Parameters.AddWithValue("@MaBaoCaoTon", MaBaoCaoTon)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
            cmd.Parameters.AddWithValue("@TonCuoi", TonCuoi)
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

End Class
