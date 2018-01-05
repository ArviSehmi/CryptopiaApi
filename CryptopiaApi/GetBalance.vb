Public Class GetBalance
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters
        ''' <summary>(optional) The currency symbol of the balance to return e.g. 'DOT' (not required if 'CurrencyId' supplied) </summary>
        Property Currency As String
        ''' <summary>(optional) The Cryptopia currency identifier of the balance to return e.g. '2' (not required if 'Currency' supplied)</summary>
        Property CurrencyId As Integer?
    End Class


    Public Class Result
        Property CurrencyId As Integer
        Property Symbol As String
        Property Total As Double
        Property Available As Double
        Property Unconfirmed As Double
        Property HeldForTrades As Double
        Property PendingWithdraw As Double
        Property Address As String
        Property BaseAddress As String
        Property Status As String
        Property StatusMessage As String
    End Class


    Public Function [Call](params As Parameters) As Task(Of Result())
        Return CallFunction(Of Result(), Parameters)("GetBalance", params)
    End Function

End Class
