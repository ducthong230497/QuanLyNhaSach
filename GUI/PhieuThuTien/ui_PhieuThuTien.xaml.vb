Imports BUS
Imports DTO
Public Class ui_PhieuThuTien
    ''' <summary>
    ''' thu tiền
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnXacNhan_Click(sender As Object, e As RoutedEventArgs) Handles btnXacNhan.Click
        'If ui_BanSach.HoanThanh = True Then
        Dim SoTienThu As Decimal
        Dim NoHienTai As Decimal
        If (txbMaKH.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập mã khách hàng!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End If

        If (txbSoTienThu.Text = String.Empty) Then
            MessageBox.Show("Đề nghị nhập số tiền thu!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        Else
            Try
                SoTienThu = Decimal.Parse(txbSoTienThu.Text)
                NoHienTai = Decimal.Parse(txbTienNo.Text)
                If NoHienTai <> 0 Then
                    If (ThamSoDTO.SuDungQuyDinh4 = True And SoTienThu > NoHienTai) Then ' kiểm tra sử dụng quy định 4
                        MessageBox.Show("Số tiền thu không không được vượt quá số tiền nợ!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                        Return
                    End If
                Else
                    MessageBox.Show("Khách hàng không nợ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                    Return
                End If
            Catch ex As Exception
                MessageBox.Show("Số tiền thu không hợp lệ!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                Return
            End Try
        End If

        Dim PhieuThu As PhieuThuTienDTO = New PhieuThuTienDTO() ' tạo phiếu thu
        PhieuThu.MaPhieuThu = GetMaPTT()
        PhieuThu.MaKhachHang = txbMaKH.Text
        PhieuThu.SoTienThu = txbSoTienThu.Text
        Try
            PhieuThu.NgayThu = Date.Parse(txbNgayThuTien.Text)
        Catch ex As Exception
            MessageBox.Show("Ngày thu tiền không hợp lệ", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            Return
        End Try


        If (ThuTienBLL.ThemPhieuThu(PhieuThu) = True) Then
            MessageBox.Show("Thu thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            If (ThuTienBLL.Update_TienNo(NoHienTai - SoTienThu, PhieuThu.MaKhachHang) = True) Then ' cập nhập lại tiền nợ cho khách hàng
                Dim MaBaoCaoCongNo As String = BaoCaoCongNoBLL.Get_MaBaoCaoCongNo()
                Dim NoDau = ChiTietCongNoBLL.Get_NoDau(PhieuThu.MaKhachHang, MaBaoCaoCongNo)
                Dim NoPhatSinh = ChiTietCongNoBLL.Get_NoPhatSinh(PhieuThu.MaKhachHang, MaBaoCaoCongNo)
                ChiTietCongNoBLL.SuaNoPhatSinh(PhieuThu.MaKhachHang, MaBaoCaoCongNo, NoPhatSinh - PhieuThu.SoTienThu, NoDau) ' sửa nợ phát sinh
                MessageBox.Show("Cập nhập tiền nợ thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
                txbSoTienThu.Text = String.Empty
                If NoHienTai - SoTienThu < 0 Then
                    txbTienNo.Text = "0"
                Else
                    txbTienNo.Text = (NoHienTai - SoTienThu).ToString()
                End If
            Else
                MessageBox.Show("Cập nhập tiền nợ không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            End If
        Else
            MessageBox.Show("Thu không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
        'Else
        'MessageBox.Show("Vui lòng hoàn thành hóa đơn bán sách trước khi thu tiền!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        'End If

    End Sub

    ''' <summary>
    ''' hàm sinh mã phiếu thu từ mã phiếu thu mới nhất
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaPTT() As String
        Dim temp = ThuTienBLL.GetMaPTT()
        If (temp <> "") Then
            temp = temp.Substring(temp.Length - 4)
            temp = (Integer.Parse(temp) + 1).ToString()
            Dim MaPTT As String = "0000"
            MaPTT += temp
            MaPTT = MaPTT.Substring(MaPTT.Length - 4)
            Return "PT" + MaPTT
        Else
            Return "PT0000"
        End If
    End Function
    ''' <summary>
    ''' lấy thông tin khách hàng bỏ vào các textbox
    ''' </summary>
    Private Sub GetKhachHang()
        Try
            Dim list As New List(Of String)
            Dim MaKH As String = txbMaKH.Text
            list = ThuTienBLL.getKhachHang(MaKH)
            txbHoTen.Text = list.Item(0)
            txbDiaChi.Text = list.Item(1)
            txbDienThoai.Text = list.Item(2)
            txbEmail.Text = list.Item(3)
            txbTienNo.Text = list.Item(4)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txbMaKH_TextChanged(sender As Object, e As TextChangedEventArgs)
        GetKhachHang()
    End Sub
End Class
