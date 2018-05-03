Imports System.Windows
Imports MySql.Data.MySqlClient
Imports DTO
Public Class ChiTietCongNoDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    Public Shared Function ThemChiTietCongNo(ByVal ChiTietCongNo As ChiTietCongNoDTO) As Boolean
        Try
            con.Open()
            Dim query = "insert into chitietcongno values(@MaChiTietCongNo, @MaBaoCaoCongNo, @MaKhachHang, @NoDau, @NoPhatSinh, @NoCuoi)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("MaChiTietCongNo", ChiTietCongNo.MaChiTietCongNo)
            cmd.Parameters.AddWithValue("MaBaoCaoCongNo", ChiTietCongNo.MaBaoCaoCongNo)
            cmd.Parameters.AddWithValue("MaKhachHang", ChiTietCongNo.MaKH)
            cmd.Parameters.AddWithValue("NoDau", ChiTietCongNo.NoDau)
            cmd.Parameters.AddWithValue("NoPhatSinh", ChiTietCongNo.NoPhatSinh)
            cmd.Parameters.AddWithValue("NoCuoi", ChiTietCongNo.NoCuoi)
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
    Public Shared Function SuaNoPhatSinh(ByVal MaKH As String, ByVal MaBaoCaoCongNo As String, ByVal NoPhatSinh As Integer, ByVal NoDau As Integer) As Boolean
        If NoPhatSinh < 0 Then
            NoPhatSinh = 0
        End If
        Dim NoCuoi As Integer = NoDau + NoPhatSinh
        Try
            con.Open()
            Dim query = "update chitietcongno set NoPhatSinh = @NoPhatSinh, NoCuoi = @NoCuoi where MaKhachHang = @MaKH and MaBaoCaoCongNo = @MaBaoCaoCongNo"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@NoPhatSinh", NoPhatSinh)
            cmd.Parameters.AddWithValue("@MaBaoCaoCongNo", MaBaoCaoCongNo)
            cmd.Parameters.AddWithValue("@MaKH", MaKH)
            cmd.Parameters.AddWithValue("@NoCuoi", NoCuoi)
            Dim count = 0
            count = cmd.ExecuteNonQuery()
            If count > 0 Then
                Return True
            End If
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function
    Public Shared Function Get_NoDau(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Integer
        Try
            con.Open()
            Dim query = "select NoDau from chitietcongno where MaKhachHang = @MaKhachHang and MaBaoCaoCongNo = @MaBaoCaoCongNo"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang)
            cmd.Parameters.AddWithValue("@MaBaoCaoCongNo", MaBaoCaoCongNo)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("NoDau")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function

    Public Shared Function Get_NoPhatSinh(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Decimal
        Try
            con.Open()
            Dim query = "select NoPhatSinh from chitietcongno where MaKhachHang = @MaKhachHang and MaBaoCaoCongNo = @MaBaoCaoCongNo"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang)
            cmd.Parameters.AddWithValue("@MaBaoCaoCongNo", MaBaoCaoCongNo)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("NoPhatSinh")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function

    Public Shared Function Get_NoCuoi(ByVal MaKhachHang As String, ByVal MaBaoCaoCongNo As String) As Integer
        Try
            con.Open()
            Dim query = "select NoCuoi from chitietcongno where MaKhachHang = @MaKhachHang and MaBaoCaoCongNo = @MaBaoCaoCongNo"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang)
            cmd.Parameters.AddWithValue("@MaBaoCaoCongNo", MaBaoCaoCongNo)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return reader.GetString("NoCuoi")
            End While
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return 0
    End Function
    Public Shared Function GetMaChiTietCongNo() As String
        Try
            con.Open()
            Dim query = "select MaChiTietCongNo from chitietcongno order by MaChiTietCongNo desc limit 1"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
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
