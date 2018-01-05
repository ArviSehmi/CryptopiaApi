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

    Public Function GetDepositAddress(p As GetDepositAddress.Parameters) As Task(Of GetDepositAddress.Result)
        Static ep As New GetDepositAddress(_Keys)
        Return ep.Call(p)
    End Function

    Public Function GetOpenOrders(p As GetOpenOrders.Parameters) As Task(Of GetOpenOrders.Result())
        Static ep As New GetOpenOrders(_Keys)
        Return ep.Call(p)
    End Function

    Public Function GetTradeHistory(p As GetTradeHistory.Parameters) As Task(Of GetTradeHistory.Result())
        Static ep As New GetTradeHistory(_Keys)
        Return ep.Call(p)
    End Function

    Public Function GetTransactions(p As GetTransactions.Parameters) As Task(Of GetTransactions.Result())
        Static ep As New GetTransactions(_Keys)
        Return ep.Call(p)
    End Function


    Public Function SubmitTrade(p As SubmitTrade.Parameters) As Task(Of SubmitTrade.Result())
        Static ep As New SubmitTrade(_Keys)
        Return ep.Call(p)
    End Function


End Class
