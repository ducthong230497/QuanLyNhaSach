Imports DAO
Imports DTO
Public Class LoadDataBLL
    Public Shared Function LoadMaKH() As List(Of String)
        Return LoadDataDAL.LoadMaKH()
    End Function

    Public Shared Function LoadMaSach() As List(Of String)
        Return LoadDataDAL.LoadMaSach()
    End Function

    Public Shared Function LoadThangBaoCaoTon() As List(Of String)
        Return LoadDataDAL.LoadThangBaoCaoTon()
    End Function

    Public Shared Function checkBaoCaoTon() As Boolean
        Return LoadDataDAL.checkBaoCaoTon()
    End Function

    Public Shared Function LoadThangBaoCaoCongNo() As List(Of String)
        Return LoadDataDAL.LoadThangBaoCaoCongNo()
    End Function

    Public Shared Function checkBaoCaoCongNo() As Boolean
        Return LoadDataDAL.checkBaoCaoCongNo()
    End Function
End Class
