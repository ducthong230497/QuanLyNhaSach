Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class ThayDoiQuyDinhDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    Public Shared Function ThayDoiQuyDinh() As Boolean
        Try
            con.Open()
            Dim query = "update thamso set SoLuongNhapToiThieu = @NhapMin, SoLuongTonToiDaDuocPhepNhap = @TonMax, SoLuongTonToiThieuSauKhiBan = @TonMinSauKhiBan, SoTienNoToiDa = @NoMax, SuDungQuyDinh4 = @QuyDinh4"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@NhapMin", ThamSoDTO.SoLuongNhapToiThieu)
            cmd.Parameters.AddWithValue("@TonMax", ThamSoDTO.SoLuongTonToiDaTruocKhiNhap)
            cmd.Parameters.AddWithValue("@TonMinSauKhiBan", ThamSoDTO.SoLuongTonToiThieuSauKhiBan)
            cmd.Parameters.AddWithValue("@NoMax", ThamSoDTO.SoTienNoToiDa)
            cmd.Parameters.AddWithValue("@QuyDinh4", ThamSoDTO.SuDungQuyDinh4)
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
