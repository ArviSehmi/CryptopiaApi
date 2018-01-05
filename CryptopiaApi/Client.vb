Public Class Client

    Private ReadOnly _Keys As ApiKeys

    Public Sub New(Keys As ApiKeys)
        Me._Keys = Keys
    End Sub


    Public Function GetBalance(p As GetBalance.Parameters) As Task(Of GetBalance.Result())
        Static ep As New GetBalance(_Keys)
        Return ep.Call(p)
    End Function

    Public Function GetCurrencies() As Task(Of GetCurrencies.Result())
        Static ep As New GetCurrencies(_Keys)
        Return ep.Call()
    End Function


End Class
