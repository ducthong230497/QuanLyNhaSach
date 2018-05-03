Public Class ConnectionDTO
    Dim _Password As String
    Shared _Connection As String

    Public Sub New(ByVal Password As String)
        _Connection = "server=localhost;user=root;password=" + Password + ";database=quanlynhasach"
    End Sub

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public Shared Property Connection As String
        Get
            Return _Connection
        End Get
        Set(value As String)
            _Connection = value
        End Set
    End Property


End Class
