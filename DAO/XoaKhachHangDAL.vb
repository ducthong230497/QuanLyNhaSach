Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class XoaKhachHangDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' thêm mã khách hàng vào bảng khachhangdaxoa
    ''' </summary>
    ''' <param name="MaKhachHang"></param>
    ''' <returns></returns>
    Public Shared Function XoaKhachHang(ByRef MaKhachHang As String) As Boolean
        Try
            con.Open()
            Dim query = "insert into khachhangdaxoa values(@MaKhachHang)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang)
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
End Class
