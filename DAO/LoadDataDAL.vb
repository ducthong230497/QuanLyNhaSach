Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class LoadDataDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy dữ liệu mã khách hàng
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadMaKH() As List(Of String)
        Dim listMaKH As New List(Of String)
        Try
            con.Open()
            Dim query = "select * from khachhang where MaKhachHang not in(select MaKhachHangDaXoa from KhachHangDaXoa)"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While (reader.Read)
                listMaKH.Add(reader.GetString("MaKhachHang"))
            End While
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listMaKH
    End Function
    ''' <summary>
    ''' lấy dữ liệu mã sách
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadMaSach() As List(Of String)
        Dim listMaSach As New List(Of String)
        Try
            con.Open()
            Dim query = "select * from sach where MaSach not in(select MaSachDaXoa from sachdaxoa)"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While (reader.Read)
                listMaSach.Add(reader.GetString("MaSach"))
            End While
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listMaSach
    End Function
    ''' <summary>
    ''' load các tháng và năm trong bảng báo cáo công nợ
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadThangBaoCaoCongNo() As List(Of String)
        Dim listBaoCaoCongNo As New List(Of String)
        Dim listDaTonTai As New List(Of String)
        Dim ThangNam As String
        Dim check = True
        Try
            con.Open()
            Dim query = "select * from baocaocongno"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                ThangNam = "Tháng " + reader.GetString("Thang") + " " + reader.GetString("Nam")
                If listDaTonTai.Count = 0 Then
                    listDaTonTai.Add(ThangNam)
                    listBaoCaoCongNo.Add(ThangNam)
                Else
                    For Each item In listDaTonTai
                        If item = ThangNam Then
                            check = False
                            Exit For
                        End If
                    Next
                    If check = True Then
                        listDaTonTai.Add(ThangNam)
                        listBaoCaoCongNo.Add(ThangNam)
                    End If
                    check = True
                End If
            End While
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listBaoCaoCongNo
    End Function

    ''' <summary>
    ''' kiểm tra tháng này có báo cáo công nợ chưa
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function checkBaoCaoCongNo() As Boolean
        Dim Thang As Integer = Date.Now.Month
        Dim Nam As Integer = Date.Now.Year
        Try
            con.Open()
            Dim cmd As MySqlCommand = New MySqlCommand("select * from baocaocongno where Thang = @Thang and Nam = @Nam", con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return True
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return False
    End Function
    ''' <summary>
    ''' load các tháng và năm trong bảng báo cáo tồn
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadThangBaoCaoTon() As List(Of String)
        Dim listBaoCaoTon As New List(Of String)
        Dim listDaTonTai As New List(Of String)
        Dim ThangNam As String
        Dim check = True
        Try
            con.Open()
            Dim query = "select Thang, Nam from baocaoton"
            Dim reader As MySqlDataReader = New MySqlCommand(query, con).ExecuteReader
            While reader.Read
                ThangNam = "Tháng " + reader.GetString("Thang") + " " + reader.GetString("Nam")
                If listDaTonTai.Count = 0 Then
                    listDaTonTai.Add(ThangNam)
                    listBaoCaoTon.Add(ThangNam)
                Else
                    For Each item In listDaTonTai
                        If item = ThangNam Then
                            check = False
                            Exit For
                        End If
                    Next
                    If check = True Then
                        listDaTonTai.Add(ThangNam)
                        listBaoCaoTon.Add(ThangNam)
                    End If
                    check = True
                End If
            End While
        Catch ex As Exception
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return listBaoCaoTon
    End Function



    ''' <summary>
    ''' kiểm tra tháng này có báo cáo tồn chưa
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function checkBaoCaoTon() As Boolean
        Dim Thang As Integer = Date.Now.Month
        Dim Nam As Integer = Date.Now.Year
        Try
            con.Open()
            Dim cmd As MySqlCommand = New MySqlCommand("select * from baocaoton where Thang = @Thang and Nam = @Nam", con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim reader As MySqlDataReader = cmd.ExecuteReader
            While reader.Read
                Return True
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
