Public Class Enemy

    Public Sub New(ByVal Name As String, ByVal X As Integer, ByVal Y As Integer, ByVal Score As Integer, ByVal MoveSpeed As Integer)
        _name = Name
        _X = X
        _Y = Y
        _Score = Score
        _moveSpeed = MoveSpeed
    End Sub

    Private _name As String
    Public Property Name
        Get
            Return _name
        End Get
        Set(ByVal value)
            _name = value
        End Set
    End Property

    Private _X As Integer
    Public Property X
        Get
            Return _X
        End Get
        Set(ByVal value)
            _X = value
        End Set
    End Property

    Private _Y As Integer
    Public Property Y
        Get
            Return _Y
        End Get
        Set(ByVal value)
            _Y = value
        End Set
    End Property

    Private _Score As Integer
    Public Property Score
        Get
            Return _Score
        End Get
        Set(ByVal value)
            _Score = value
        End Set
    End Property

    Private _moveSpeed As Integer
    Public Property MoveSpeed
        Get
            Return _moveSpeed
        End Get
        Set(ByVal value)
            _moveSpeed = value
        End Set
    End Property





End Class
