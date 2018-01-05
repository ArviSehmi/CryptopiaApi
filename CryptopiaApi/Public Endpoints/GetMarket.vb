Public Class GetMarket
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub



    Public Class Parameters
        ''' <summary>(Required) (TradePairId or MarketName)</summary>
        Property Market As String

        Public Function GetURL() As String
            Dim b As New System.Text.StringBuilder("GetMarket/")
            b.Append(Market.ToUpper)
            Return b.ToString
        End Function

    End Class


    Public Class Result

        Public Property TradePairId As Integer
        Public Property Label As String
        Public Property AskPrice As Decimal
        Public Property BidPrice As Decimal
        Public Property Low As Decimal
        Public Property High As Decimal
        Public Property Volume As Decimal
        Public Property LastPrice As Decimal
        Public Property BuyVolume As Decimal
        Public Property SellVolume As Decimal
        Public Property Change As Decimal
        Public Property Open As Decimal
        Public Property Close As Decimal
        Public Property BaseVolume As Decimal
        Public Property BaseBuyVolume As Decimal
        Public Property BaseSellVolume As Decimal
    End Class

    Public Function [Call](p As Parameters) As Task(Of Result)
        Return Me.CallFunction(Of Result)(p.GetURL, needsAuthorisation:=False)
    End Function

End Class

