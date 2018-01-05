Public Class GetMarketOrders
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub



    Public Class Parameters
        ''' <summary>Required (TradePairId or MarketName)</summary>
        Property Market As String
        ''' <summary>optional (default: 100)</summary>
        Property OrderCount As Integer?

        Public Function GetURL() As String

            Dim b As New System.Text.StringBuilder("GetMarketOrders/")

            If String.IsNullOrWhiteSpace(Market) Then Throw New ArgumentNullException("GetMarketOrders must have a Market parameter")

            b.Append(Market.ToUpper())

            If OrderCount.HasValue Then
                b.Append("/")
                b.Append(OrderCount.Value.ToString())
            End If

            Return b.ToString
        End Function

    End Class


    Public Class OrderDetails
        Public Property TradePairId As Integer
        Public Property Label As String
        Public Property Price As Decimal
        Public Property Volume As Decimal
        Public Property Total As Decimal

    End Class


    Public Class Result
        Property Buy As OrderDetails()
        Property Sell As OrderDetails()
    End Class


    Public Function [Call](p As Parameters) As Task(Of Result)
        Return Me.CallFunction(Of Result)(p.GetURL, needsAuthorisation:=False)
    End Function

End Class
