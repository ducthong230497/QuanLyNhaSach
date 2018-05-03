Imports DAO
Public Class ConnectionBLL
    Public Shared Function Get_BangBaoCaoTon(ByVal Thang As Integer, ByVal Nam As Integer) As DataTable
        Return ConnectionDAL.Get_BangBaoCaoTon(Thang, Nam)
    End Function

    Public Shared Function Get_BangBaoCaoCongNo(ByVal Thang As Integer, ByVal Nam As Integer) As DataTable
        Return ConnectionDAL.Get_BangBaoCaoCongNo(Thang, Nam)
    End Function
End Class
