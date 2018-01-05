Public Class SubmitTrade
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The market symbol Of the trade e.g. 'DOT/BTC' (not required if 'TradePairId' supplied)</summary>
        Public Property Market As String

        ''' <summary>The Cryptopia tradepair identifier Of trade e.g. '100' (not required if 'Market' supplied)</summary>
        Public Property TradePairId As Integer?

        ''' <summary>the type Of trade e.g. 'Buy' or 'Sell'</summary>
        Public Property Type As String

        ''' <summary>the rate Or price To pay For the coins e.g. 0.00000034</summary>
        Public Property Rate As Decimal

        ''' <summary>the amount Of coins To buy e.g. 123.00000000</summary>
        Public Property Amount As Decimal


    End Class


    Public Class Result
        Public Property OrderId As Integer
        Public Property FilledOrders As Integer()
    End Class


    Public Function [Call](params As Parameters) As Task(Of Result())
        Return CallFunction(Of Result(), Parameters)("SubmitTrade", params)
    End Function
End Class
