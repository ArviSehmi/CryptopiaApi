Public Class CancelTrade
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The type of cancellation, Valid Types: 'All',  'Trade', 'TradePair'</summary>
        Public Property Type As String

        ''' <summary>The order identifier of trade to cancel (required if type 'Trade')</summary>
        Public Property OrderId As Integer?

        ''' <summary>The Cryptopia tradepair identifier of trades to cancel e.g. '100' (required if type 'TradePair')</summary>
        Public Property TradePairId As Integer?


    End Class


    Public Class Result
        Inherits List(Of Integer)

    End Class


    Public Function [Call](params As Parameters) As Task(Of Result)
        Return CallFunction(Of Result, Parameters)("CancelTrade", params)
    End Function
End Class
