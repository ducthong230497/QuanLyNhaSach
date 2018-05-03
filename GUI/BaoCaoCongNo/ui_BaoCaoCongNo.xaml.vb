Imports BUS
Imports DTO
Public Class ui_BaoCaoCongNo
    Dim STT = 0
    ''' <summary>
    ''' chọn tháng trong năm cần lập báo cáo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbbThang_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim listChiTietCongNo As New List(Of ChiTietCongNoDTO)
        Dim listdtgBaoCaoCongNo As New List(Of BaoCaoCongNo)
        Dim ThangNam As String = cbbThang.SelectedValue ' lấy tháng năm hiện tại
        Dim Thang As String = ThangNam.Substring(6, 1)
        Dim Nam As Integer = ThangNam.Substring(ThangNam.Length - 4)
        listChiTietCongNo = BaoCaoCongNoBLL.LapBaoCaoCongNo(Thang, Nam) ' load dữ liệu của tháng đó
        For Each item In listChiTietCongNo ' load dữ liệu lên list để hiển thị trên datagrid
            STT = STT + 1
            Dim BaoCao As BaoCaoCongNo = New BaoCaoCongNo()
            BaoCao.STT = STT
            BaoCao.MaKH = item.MaKH
            BaoCao.TenKhachHang = BaoCaoCongNoBLL.Get_TenKhachHang(BaoCao.MaKH)
            BaoCao.NoDau = item.NoDau
            BaoCao.NoCuoi = item.NoCuoi
            BaoCao.NoPhatSinh = item.NoPhatSinh
            listdtgBaoCaoCongNo.Add(BaoCao)
        Next

        dtgBaoCaoCongNo.ItemsSource = listdtgBaoCaoCongNo
    End Sub

    ''' <summary>
    ''' hàm sinh mã báo cáo công nợ từ mã báo cáo công nợ mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaBaoCaoCongNo() As String
        Dim temp = BaoCaoCongNoBLL.Get_MaBaoCaoCongNo()
        If (temp <> String.Empty) Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaBCCN As String = "0000"
            MaBCCN += temp
            MaBCCN = MaBCCN.Substring(MaBCCN.Length - 4)
            Return "BCCN" + MaBCCN
        Else
            Return "BCCN0000"
        End If
    End Function
    ''' <summary>
    ''' hàm sinh mã chi tiết công nợ từ mã chi tiết công nợ mới nhất
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Get_MaChiTietCongNo() As String
        Dim temp = ChiTietCongNoBLL.GetMaChiTietCongNo()
        If (temp <> String.Empty) Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaCTCN As String = "0000"
            MaCTCN += temp
            MaCTCN = MaCTCN.Substring(MaCTCN.Length - 4)
            Return "CTCN" + MaCTCN
        Else
            Return "CTCN0000"
        End If
    End Function
    ''' <summary>
    ''' xuất dữ liệu trên datagrid ra file excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXuatExcel_Click(sender As Object, e As RoutedEventArgs)
        Dim ThangNam As String = cbbThang.SelectedValue ' lấy tháng năm hiện tại
        If ThangNam <> Nothing Then
            Dim Thang As Integer = ThangNam.Substring(6, 1)
            Dim Nam As Integer = ThangNam.Substring(ThangNam.Length - 4)
            XuatFileExcel.XuatBaoCaoCongNoRaFileExcel(Thang, Nam)
        End If
    End Sub
End Class

''' <summary>
''' class để hiển thị trên datagrid
''' </summary>
Public Class BaoCaoCongNo
    Dim _STT As Integer
    Dim _MaKH As String
    Dim _TenKhachHang As String
    Dim _Thang As String
    Dim _NoDau As Decimal
    Dim _NoPhatSinh As Decimal
    Dim _NoCuoi As Decimal

    Public Property STT As Integer
        Get
            Return _STT
        End Get
        Set(value As Integer)
            _STT = value
        End Set
    End Property

    Public Property MaKH As String
        Get
            Return _MaKH
        End Get
        Set(value As String)
            _MaKH = value
        End Set
    End Property

    Public Property TenKhachHang As String
        Get
            Return _TenKhachHang
        End Get
        Set(value As String)
            _TenKhachHang = value
        End Set
    End Property

    Public Property NoDau As Decimal
        Get
            Return _NoDau
        End Get
        Set(value As Decimal)
            _NoDau = value
        End Set
    End Property

    Public Property NoPhatSinh As Decimal
        Get
            Return _NoPhatSinh
        End Get
        Set(value As Decimal)
            _NoPhatSinh = value
        End Set
    End Property

    Public Property NoCuoi As Decimal
        Get
            Return _NoCuoi
        End Get
        Set(value As Decimal)
            _NoCuoi = value
        End Set
    End Property

    Public Property Thang As String
        Get
            Return _Thang
        End Get
        Set(value As String)
            _Thang = value
        End Set
    End Property
End Class