Imports System.Data
Imports MySql.Data.MySqlClient
'Imports MySql.Data.MySqlClient
Imports MahApps.Metro.Controls
Imports BUS
Imports DTO
Class MainWindow
    Dim _listMaKH As List(Of String) = Nothing

    Public Property ListMaKH As List(Of String)
        Get
            Return _listMaKH
        End Get
        Set(value As List(Of String))
            _listMaKH = value
        End Set
    End Property

    Public Property ListMaSach As List(Of String)
        Get
            Return _listMaSach
        End Get
        Set(value As List(Of String))
            _listMaSach = value
        End Set
    End Property

    Dim _listMaSach As List(Of String) = Nothing

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim con As ConnectionDTO = New ConnectionDTO("root") ' 806432#ae

        Set_ThamSo() 'Set giá trị cho class tham số khi chạy chương trình

        ui_ThemKhachHang.lblMaKH.Content = ui_ThemKhachHang.Get_MaKH()
        ui_ThemSach.tblMaSach.Text = ui_ThemSach.Get_MaSach()

        ui_bansach.dtgBanSach.CanUserAddRows = False
        ui_bansach.dtgBanSach.IsReadOnly = True


        ui_bansach.txbNgayLapHoaDon.Text = Date.Now.ToShortDateString()
        ui_NhapSach.txbNgayNhap.Text = Date.Now.ToShortDateString()
        ui_PhieuThuTien.txbNgayThuTien.Text = Date.Now.ToShortDateString()


        ui_ThayDoiQuyDinh.txbSoLuongNhapToiThieu.Text = ThamSoDTO.SoLuongNhapToiThieu.ToString()
        ui_ThayDoiQuyDinh.txbSoLuongTonTruocKhiNhap.Text = ThamSoDTO.SoLuongTonToiDaTruocKhiNhap.ToString()
        ui_ThayDoiQuyDinh.txbLuongTonToiThieuSauKhiBan.Text = ThamSoDTO.SoLuongTonToiThieuSauKhiBan.ToString()
        ui_ThayDoiQuyDinh.txbTienNoToiDa.Text = ThamSoDTO.SoTienNoToiDa.ToString()
        ui_ThayDoiQuyDinh.cxbQuyDInh4.IsChecked = ThamSoDTO.SuDungQuyDinh4


        ListMaKH = LoadDataBLL.LoadMaKH()
        ListMaSach = LoadDataBLL.LoadMaSach()

        TaoBaoCaoCongNo(ListMaKH)
        TaoBaoCaoTon(ListMaSach)

        Dim listBaoCaoTon As New List(Of String)
        listBaoCaoTon = LoadDataBLL.LoadThangBaoCaoTon()
        For Each item In listBaoCaoTon
            ui_BaoCaoTon.cbbThang.Items.Add(item)
        Next

        Dim listBaoCaoCongNo As New List(Of String)
        listBaoCaoCongNo = LoadDataBLL.LoadThangBaoCaoCongNo()
        For Each item In listBaoCaoCongNo
            ui_BaoCaoCongNo.cbbThang.Items.Add(item)
        Next


    End Sub

    Private Sub Set_ThamSo()
        ThamSoDTO.SoLuongNhapToiThieu = 150
        ThamSoDTO.SoLuongTonToiDaTruocKhiNhap = 300
        ThamSoDTO.SoTienNoToiDa = 20000
        ThamSoDTO.SoLuongTonToiThieuSauKhiBan = 20
        ThamSoDTO.SuDungQuyDinh4 = True
    End Sub

    Private Sub TaoBaoCaoCongNo(ByVal listMaKH)
        If LoadDataBLL.checkBaoCaoCongNo() = False Then
            Dim Nam = Date.Now.Year
            Dim NamTruoc As Integer = 0
            Dim ThangTruoc = ((Date.Now.Month + 11) Mod 12)
            If ThangTruoc = 0 Then
                ThangTruoc = 12
                NamTruoc = Nam - 1
            End If
            Dim Thang = Date.Now.Month

            Dim BaoCaoCongNo As BaoCaoCongNoDTO = New BaoCaoCongNoDTO()
            BaoCaoCongNo.MaBaoCaoCongNo = ui_BaoCaoCongNo.Get_MaBaoCaoCongNo()
            BaoCaoCongNo.Thang = Thang
            BaoCaoCongNo.Nam = Nam
            BaoCaoCongNoBLL.ThemBaoCaoCongNo(BaoCaoCongNo)

            For Each item In listMaKH
                Dim NoCuoiThangTruoc
                If ThangTruoc = 12 Then
                    NoCuoiThangTruoc = ChiTietCongNoBLL.Get_NoCuoi(item, BaoCaoCongNoBLL.Get_MaBaoCaoCongNo(ThangTruoc, NamTruoc))
                Else
                    NoCuoiThangTruoc = ChiTietCongNoBLL.Get_NoCuoi(item, BaoCaoCongNoBLL.Get_MaBaoCaoCongNo(ThangTruoc, Nam))
                End If
                Dim ChiTietCongNo = New ChiTietCongNoDTO()
                ChiTietCongNo.MaChiTietCongNo = ui_BaoCaoCongNo.Get_MaChiTietCongNo()
                ChiTietCongNo.MaBaoCaoCongNo = BaoCaoCongNoBLL.Get_MaBaoCaoCongNo()
                ChiTietCongNo.MaKH = item
                ChiTietCongNo.NoDau = NoCuoiThangTruoc
                ChiTietCongNo.NoPhatSinh = 0
                ChiTietCongNo.NoCuoi = NoCuoiThangTruoc
                ChiTietCongNoBLL.ThemChiTietCongNo(ChiTietCongNo)
            Next
        End If
    End Sub

    Private Sub TaoBaoCaoTon(ByVal listMaSach)
        If LoadDataBLL.checkBaoCaoTon() = False Then
            Dim Nam = Date.Now.Year
            Dim NamTruoc As Integer = 0
            Dim ThangTruoc = ((Date.Now.Month + 11) Mod 12)
            If ThangTruoc = 0 Then
                ThangTruoc = 12
                NamTruoc = Nam - 1
            End If
            Dim Thang = Date.Now.Month

            Dim BaoCaoTon = New BaoCaoTonDTO()
            BaoCaoTon.MaBaoCaoTon = ui_BaoCaoTon.Get_MaBaoCaoTon()
            BaoCaoTon.Thang = Thang
            BaoCaoTon.Nam = Nam
            BaoCaoTonBLL.ThemBaoCaoTon(BaoCaoTon)

            For Each item In listMaSach
                Dim TonCuoiThangTruoc
                If ThangTruoc = 12 Then
                    TonCuoiThangTruoc = ChiTietTonBLL.Get_TonCuoi(item, BaoCaoTonBLL.Get_MaBaoCaoTon(ThangTruoc, NamTruoc))
                Else
                    TonCuoiThangTruoc = ChiTietTonBLL.Get_TonCuoi(item, BaoCaoTonBLL.Get_MaBaoCaoTon(ThangTruoc, Nam))
                End If
                Dim ChiTietTon As ChiTietTonDTO = New ChiTietTonDTO()
                ChiTietTon.MaChiTietTon = ui_BaoCaoTon.Get_MaChiTietTon()
                ChiTietTon.MaBaoCaoTon = BaoCaoTon.MaBaoCaoTon
                ChiTietTon.MaSach = item
                ChiTietTon.TonDau = TonCuoiThangTruoc
                ChiTietTon.TonPhatSinh = 0
                ChiTietTon.TonCuoi = TonCuoiThangTruoc
                ChiTietTonBLL.ThemChiTietTon(ChiTietTon)
            Next
        End If
    End Sub

    Private Sub btnThuTien_Click(sender As Object, e As RoutedEventArgs)
        ui_PhieuThuTien.txbMaKH.Text = ui_bansach.txbMaKH.Text
        FlyoutPhieuThuTien.IsOpen = True
    End Sub

    Private Sub btnBaoCaoTonSach_Click(sender As Object, e As RoutedEventArgs)
        FlyoutBaoCaoTon.IsOpen = True
    End Sub

    Private Sub btnBaoCaoCongNo_Click(sender As Object, e As RoutedEventArgs)
        FlyoutBaoCaoCongNo.IsOpen = True
    End Sub

    Private Sub FlyoutPhieuThuTien_ClosingFinished(sender As Object, e As RoutedEventArgs)
        ui_bansach.txbTienNo.Text = ui_PhieuThuTien.txbTienNo.Text
    End Sub
End Class
