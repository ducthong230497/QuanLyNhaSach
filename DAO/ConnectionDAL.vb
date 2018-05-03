Imports MySql.Data.MySqlClient
Imports DTO
Imports System.Windows
Public Class ConnectionDAL
    Shared con As MySqlConnection = New MySqlConnection(ConnectionDTO.Connection)
    ''' <summary>
    ''' lấy dữ liệu của bảng báo cáo tồn
    ''' </summary>
    ''' <param name="Thang"></param>
    ''' <param name="Nam"></param>
    ''' <returns></returns>
    Public Shared Function Get_BangBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As DataTable
        Dim Table As DataTable = New DataTable()
        Try
            con.Open()
            Dim query = "select s.MaSach, s.TenSach, c.TonDau, c.TonPhatSinh, c.TonCuoi
                         from baocaoton as b join chitietton as c on b.MaBaoCaoTon = c.MaBaoCaoTon 
					                         join sach as s on c.MaSach = s.MaSach
                         where b.Thang = @Thang and b.Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim adt As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            adt.Fill(Table)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return Table
    End Function
    ''' <summary>
    ''' lấy dữ liệu bảng báo cáo công nợ
    ''' </summary>
    ''' <param name="Thang"></param>
    ''' <param name="Nam"></param>
    ''' <returns></returns>
    Public Shared Function Get_BangBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As DataTable
        Dim Table As DataTable = New DataTable()
        Try
            con.Open()
            Dim query = "select k.MaKhachHang, k.HoTenKhachHang, c.NoDau, c.NoPhatSinh, c.NoCuoi
                         from baocaocongno b join chitietcongno c on b.MaBaoCaoCongNo = c.MaBaoCaoCongNo
					                         join khachhang k on k.MaKhachHang = c.MaKhachHang
                         where b.Thang = @Thang and b.Nam = @Nam"
            Dim cmd As MySqlCommand = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Thang", Thang)
            cmd.Parameters.AddWithValue("@Nam", Nam)
            Dim adt As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            adt.Fill(Table)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try
        Return Table
    End Function
End Class
