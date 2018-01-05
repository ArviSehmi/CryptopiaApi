Public Class GetMarketHistory
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub



    Public Class Parameters
        ''' <summary>Required (TradePairId or MarketName)</summary>
        Property Market As String
        ''' <summary>optional (default: 24)</summary>
        Property Hours As Integer?

        Public Function GetURL() As String

            Dim b As New System.Text.StringBuilder("GetMarketHistory/")

            If String.IsNullOrWhiteSpace(Market) Then Throw New ArgumentNullException("GetMarketHistory must have a Market parameter")

            b.Append(Market.ToUpper())

            If Hours.HasValue Then
                b.Append("/")
                b.Append(Hours.Value.ToString())
            End If

            Return b.ToString
        End Function

    End Class


    Public Class Result
        Public Property TradePairId As Integer
        Public property Label As String
        Public Property Type As String
        Public property Price As Decimal
        Public Property Amount As Decimal
        Public property Total As Decimal
        Public Property Timestamp As Long
    End Class


    Public Function [Call](p As Parameters) As Task(Of Result())
        Return Me.CallFunction(Of Result())(p.GetURL, needsAuthorisation:=False)
    End Function

End Class
