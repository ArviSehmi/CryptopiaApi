Public Class GetMarketOrderGroups
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub



    Public Class Parameters
        ''' <summary>Required (array of TradePairIds or MarketNames)</summary>
        Property Markets As IEnumerable(Of String)
        ''' <summary>optional (default: 100)</summary>
        Property OrderCount As Integer?

        Public Function GetURL() As String

            Dim b As New System.Text.StringBuilder("GetMarketOrders/")

            If CInt(Markets?.Count) = 0 Then Throw New ArgumentNullException("GetMarketOrderGroups must have at least one Market parameter")

            For Each m In Markets
                b.Append(m.ToUpper().Replace("/", "_").Replace("-", "_"))
                b.Append("-")
            Next
            b.Length -= 1


            If OrderCount.HasValue Then
                b.Append("/")
                b.Append(OrderCount.Value.ToString())
            End If

            Return b.ToString
        End Function

    End Class


    Public Class Result
        Property TradePairId As Integer
        Property Market As String

        Property Buy As GetMarketOrders.OrderDetails()
        Property Sell As GetMarketOrders.OrderDetails()
    End Class


    Public Function [Call](p As Parameters) As Task(Of Result())
        Return Me.CallFunction(Of Result())(p.GetURL, needsAuthorisation:=False)
    End Function

End Class
