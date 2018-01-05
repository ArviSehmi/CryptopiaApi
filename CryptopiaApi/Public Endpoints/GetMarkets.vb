Public Class GetMarkets
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub



    Public Class Parameters
        ''' <summary>BaseMarket (optional, default: All)</summary>
        Property BaseMarket As String
        ''' <summary>Hours (optional, default: 24)</summary>
        Property Hours As Integer?

        Public Function GetURL() As String

            Dim b As New System.Text.StringBuilder("GetMarkets")

            If Not String.IsNullOrWhiteSpace(BaseMarket) Then
                b.Append("/")
                b.Append(BaseMarket.ToUpper())
            End If

            If Hours.HasValue Then
                b.Append("/")
                b.Append(Hours.Value.ToString())
            End If

            Return b.ToString
        End Function

    End Class



    Public Function [Call](p As Parameters) As Task(Of GetMarket.Result())
        Return Me.CallFunction(Of GetMarket.Result())(p.GetURL, needsAuthorisation:=False)
    End Function

End Class
