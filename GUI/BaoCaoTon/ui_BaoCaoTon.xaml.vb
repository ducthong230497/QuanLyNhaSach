Imports BUS
Imports DTO
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.Win32
Imports System.IO.Directory
Imports WPFFolderBrowser
Imports Microsoft.Office.Interop.Excel

Public Class ui_BaoCaoTon
    Dim STT = 0
    Dim listdtgBaoCaoTon As New List(Of dtgBaoCaoTon)
    ''' <summary>
    ''' chọn tháng cần lập báo cáo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbbThang_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) 'alkjdklasjdlksajlasdlkjkd
        listdtgBaoCaoTon = New List(Of dtgBaoCaoTon)
        Dim listChiTietTon As New List(Of ChiTietTonDTO)
        Dim ThangNam As String = cbbThang.SelectedValue ' lấy tháng năm hiện tại
        Dim Thang As String = ThangNam.Substring(6, 1)
        Dim Nam As Integer = ThangNam.Substring(ThangNam.Length - 4)
        listChiTietTon = BaoCaoTonBLL.LapBaoCaoTon(Thang, Nam)
        For Each item In listChiTietTon ' load dữ liệu lên list
            STT = STT + 1
            Dim BaoCao As dtgBaoCaoTon = New dtgBaoCaoTon()
            BaoCao.STT = STT
            BaoCao.MaSach = item.MaSach
            BaoCao.TenSach = BaoCaoTonBLL.Get_TenSach(BaoCao.MaSach)
            BaoCao.TonDau = item.TonDau
            BaoCao.TonCuoi = item.TonCuoi
            BaoCao.TonPhatSinh = item.TonPhatSinh
            listdtgBaoCaoTon.Add(BaoCao)
        Next
        dtgBaoCaoTon.ItemsSource = listdtgBaoCaoTon
    End Sub
    ''' <summary>
    ''' hàm sinh mã báo cáo tồn tử mã báo cáo tồn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaBaoCaoTon() As String
        Dim temp = BaoCaoTonBLL.Get_MaBaoCaoTon()
        If (temp <> String.Empty) Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaMT As String = "0000"
            MaMT += temp
            MaMT = MaMT.Substring(MaMT.Length - 4)
            Return "BCT" + MaMT
        Else
            Return "BCT0000"
        End If
    End Function
    ''' <summary>
    ''' hàm sinh mã chi tiết tồn tử mã chi tiết tồn mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaChiTietTon() As String
        Dim temp = ChiTietTonBLL.GetMaChiTietTon()
        If temp <> String.Empty Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaCTT As String = "0000"
            MaCTT += temp
            MaCTT = MaCTT.Substring(MaCTT.Length - 4)
            Return "CTT" + MaCTT
        Else
            Return "CTT0000"
        End If
    End Function

    ''' <summary>
    ''' hàm xuất ra file excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXuatExcel_Click(sender As Object, e As RoutedEventArgs)
        Dim ThangNam As String = cbbThang.SelectedValue ' lấy tháng năm hiện tại
        If ThangNam <> Nothing Then
            Dim Thang As Integer = ThangNam.Substring(6, 1)
            Dim Nam As Integer = ThangNam.Substring(ThangNam.Length - 4)
            XuatFileExcel.XuatBaoCaoTonRaFileExcel(Thang, Nam)
            'XuatFileExcel.asd(dtgBaoCaoTon)
        End If
    End Sub

End Class

''' <summary>
''' class dùng để binding
''' </summary>
Public Class dtgBaoCaoTon
    Dim _STT As Integer
    Dim _MaSach As String
    Dim _TenSach As String
    Dim _TonDau As Integer
    Dim _TonCuoi As Integer
    Dim _TonPhatSinh As Integer

    Public Property STT As Integer
        Get
            Return _STT
        End Get
        Set(value As Integer)
            _STT = value
        End Set
    End Property

    Public Property MaSach As String
        Get
            Return _MaSach
        End Get
        Set(value As String)
            _MaSach = value
        End Set
    End Property

    Public Property TenSach As String
        Get
            Return _TenSach
        End Get
        Set(value As String)
            _TenSach = value
        End Set
    End Property

    Public Property TonDau As Integer
        Get
            Return _TonDau
        End Get
        Set(value As Integer)
            _TonDau = value
        End Set
    End Property

    Public Property TonCuoi As Integer
        Get
            Return _TonCuoi
        End Get
        Set(value As Integer)
            _TonCuoi = value
        End Set
    End Property

    Public Property TonPhatSinh As Integer
        Get
            Return _TonPhatSinh
        End Get
        Set(value As Integer)
            _TonPhatSinh = value
        End Set
    End Property
End Class
