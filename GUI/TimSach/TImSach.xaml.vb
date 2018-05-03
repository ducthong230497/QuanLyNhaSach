Imports BUS
Imports DTO

Public Class TImSach
    Dim listSach As List(Of SachDTO) = New List(Of SachDTO)
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        listSach = New List(Of SachDTO)
        If (txbMaSach.Text <> String.Empty Or txbTacGia.Text <> String.Empty Or txbTenSach.Text <> String.Empty Or txbTheLoai.Text <> String.Empty) Then
            listSach = BUS.TimSachBLL.TimSach(txbMaSach.Text, txbTenSach.Text, txbTheLoai.Text, txbTacGia.Text, "", "", "", "")
            If listSach.Count <> 0 Then
                dtgTimSach.ItemsSource = listSach
            End If
        End If
    End Sub

    Private Sub dtgTimSach_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgTimSach.SelectionChanged
        btnSuaSach.IsEnabled = True
        btnXoaSach.IsEnabled = True
    End Sub

    Private Sub btnSuaSach_Click(sender As Object, e As RoutedEventArgs)
        Dim suasach As SuaSach = New SuaSach()
        suasach.DataContext = dtgTimSach.ItemsSource
        suasach.Show()
    End Sub

    Private Sub btnXoaSach_Click(sender As Object, e As RoutedEventArgs)
        Dim Temp As SachDTO = dtgTimSach.SelectedItem
        Dim check As Boolean = XoaSachBLL.XoaSach(Temp.MaSach)
        If (check = True) Then
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
            For Each item In listSach
                If (item.MaSach = Temp.MaSach) Then
                    listSach.Remove(item)
                    Exit For
                End If
            Next
            dtgTimSach.ItemsSource = Nothing
            dtgTimSach.Items.Clear()
            dtgTimSach.ItemsSource = listSach
        Else
            MessageBox.Show("Xóa không thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub
End Class

