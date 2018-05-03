Imports System.Windows
Imports DTO
Imports MySql.Data.MySqlClient
Public Class SachDaXoaDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy dữ liệu các sách đã xóa
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadSachDaXoa() As List(Of SachDTO)
        Dim listSachDaXoa As New List(Of SachDTO)
        Try
            con.Open()
            Dim query = "select * from sachdaxoa join sach on sachdaxoa.MaSachDaXoa = sach.MaSach"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                listSachDaXoa.Add(New SachDTO(reader.GetString("MaSach"), reader.GetString("TenSach"), reader.GetString("TheLoai"), reader.GetString("TacGia"), reader.GetString("SoLuongTon"), reader.GetString("DonGia")))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listSachDaXoa
    End Function
    Public Shared Function KhoiPhucSach(ByVal MaSach As String) As Boolean
        Try
            con.Open()
            Dim query = "delete from sachdaxoa where MaSachDaXoa = @MaSach"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaSach", MaSach)
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
    ''' kiểm tra mã sách có tồn tại trong bảng sách đã xóa không
    ''' </summary>
    ''' <param name="MaSach"></param>
    ''' <returns></returns>
    Public Shared Function TimMaSachDaXoa(ByVal MaSach As String) As Boolean
        Try
            con.Open()
            Dim query = "select * from sachdaxoa"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                If reader.GetString("MaSachDaXoa") = MaSach Then
                    Return True
                End If
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function
End Class
