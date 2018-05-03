Imports MySql.Data.MySqlClient
Imports System.Windows
Imports DTO
Public Class XoaSachDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' thêm mã sách vào bảng sachdaxoa
    ''' </summary>
    ''' <param name="MaSach"></param>
    ''' <returns></returns>
    Public Shared Function XoaSach(ByVal MaSach As String) As Boolean
        Try
            con.Open()
            Dim query = "insert into sachdaxoa values(@MaSach)"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
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


End Class
