Imports System.Windows
Imports DTO
Imports MySql.Data.MySqlClient
Public Class KhachHangDaXoaDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy ra những khách hàng đã xóa
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadKHDaXoa() As List(Of KhachHangDTO)
        Dim listSachDaXoa As New List(Of KhachHangDTO)
        Try
            con.Open()
            Dim query = "select * from khachhangdaxoa join khachhang on khachhangdaxoa.MaKhachHangDaXoa = khachhang.MaKhachHang"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                listSachDaXoa.Add(New KhachHangDTO(reader.GetString("MaKhachHang"), reader.GetString("HoTenKhachHang"), reader.GetString("DiaChi"), reader.GetString("DienThoai"), reader.GetString("Email"), reader.GetString("SoTienNo")))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listSachDaXoa
    End Function

    Public Shared Function KhoiPhucKH(ByVal MaKH As String) As Boolean
        Try
            con.Open()
            Dim query = "delete from khachhangdaxoa where MaKhachHangDaXoa = @MaKH"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKH", MaKH)
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
    ''' kiểm tra mã khách hàng có trong bảng khách hàng đã xóa hay không
    ''' </summary>
    ''' <param name="MaKH"></param>
    ''' <returns></returns>
    Public Shared Function TimMaKHDaXoa(ByVal MaKH As String) As Boolean
        Dim listMaKHDaXoa As New List(Of String)
        Try
            con.Open()
            Dim query = "select * from khachhangdaxoa"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                If reader.GetString("MaKhachHangDaXoa") = MaKH Then
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
