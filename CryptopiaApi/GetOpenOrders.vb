Public Class GetOpenOrders
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters
        ''' <summary>The market symbol Of the orders To Return e.g. 'DOT/BTC' (not required if 'TradePairId' supplied)</summary>
        Property Market As String
        ''' <summary>The Cryptopia tradepair identifier Of the orders To Return e.g. '100' (not required if 'Market' supplied)</summary>
        Property TradePairId As Integer?

        ''' <summary>(optional) The maximum amount of orders to return e.g. '10' (default: 100)</summary>
        Property Count As Integer?

    End Class


    Public Class Result
        Public Property OrderId As Integer
        Public Property TradePairId As Integer
        Public Property Market As String
        Public Property Type As String
        Public Property Rate As Decimal
        Public Property Amount As Decimal
        Public Property Total As Decimal
        Public Property Remaining As Decimal
        Public Property TimeStamp As String
    End Class


    Public Function [Call](params As Parameters) As Task(Of Result())
        Return CallFunction(Of Result(), Parameters)("GetOpenOrders", params)
    End Function
End Class
