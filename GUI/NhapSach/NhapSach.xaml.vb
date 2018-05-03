Imports BUS
Imports DTO
Public Class LapPhieuNhapSach
    Dim listSach As New List(Of SachDTO)
    Dim listNhapSach As New List(Of NhapSachDTO)
    Dim STT As Integer = 0
    Dim nhapThanhCong As Boolean = False
    Private Sub btnNhap_Click(sender As Object, e As RoutedEventArgs) Handles btnNhap.Click
        Dim tsDTO As ThamSoDTO = New ThamSoDTO()
        Dim checkFound As Boolean
        Dim Sach As SachDTO = New DTO.SachDTO
        Dim nhapsachDTO As NhapSachDTO = New NhapSachDTO
        Dim sln As Integer
        Try
            sln = Integer.Parse(txbSoLuongNhap.Text)
            Sach = BUS.NhapSachBLL.TimSach(txbMaSach.Text, checkFound)
            If checkFound = True Then
                If (Sach.SoLuong >= tsDTO.SoLuongTonToiDaTruocKhiNhap) Then
                    MessageBox.Show("Số lượng tồn lớn hơn 300. Xin kiểm tra lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
                ElseIf sln < tsDTO.SoLuongNhapToiThieu Then
                    MessageBox.Show("Số lượng nhập nhỏ hơn 150. Xin kiểm tra lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
                Else
                    listSach.Add(Sach)
                    STT = STT + 1
                    nhapsachDTO.STT = STT
                    nhapsachDTO.MaSach = Sach.MaSach
                    nhapsachDTO.TenSach = Sach.TenSach
                    nhapsachDTO.TacGia = Sach.TacGia
                    nhapsachDTO.SoLuongTonCu = Sach.SoLuong
                    nhapsachDTO.SoLuongNhap = sln
                    nhapsachDTO.SoLuongTonMoi = nhapsachDTO.SoLuongTonCu + nhapsachDTO.SoLuongNhap
                    listNhapSach.Add(nhapsachDTO)
                    If (BUS.NhapSachBLL.NhapSach(nhapsachDTO, nhapsachDTO.SoLuongTonCu) = True) Then
                        dtgNhapSach.ItemsSource = Nothing
                        dtgNhapSach.Items.Clear()
                        dtgNhapSach.ItemsSource = listNhapSach
                        MessageBox.Show("Nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
                        nhapThanhCong = True
                    Else
                        MessageBox.Show("Nhập không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Số lượng nhập không hợp lệ. Xin kiểm tra lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        txbNgayNhap.Text = Date.Now.ToShortDateString()
        dtgNhapSach.ItemsSource = listNhapSach
    End Sub
End Class
