Public Class Client

    Private ReadOnly _Keys As ApiKeys

    Public Sub New(Keys As ApiKeys)
        Me._Keys = Keys
    End Sub


    Public ReadOnly Property GetBalance As GetBalance
        Get
            Static ep As New GetBalance(_Keys)
            Return ep
        End Get
    End Property
    Public ReadOnly Property GetCurrencies As GetCurrencies
        Get
            Static ep As New GetCurrencies(_Keys)
            Return ep
        End Get
    End Property

End Class
