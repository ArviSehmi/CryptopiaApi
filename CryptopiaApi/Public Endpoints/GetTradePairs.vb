Public Class GetTradePairs
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub
    Public Class Result
        Public Property Id As Integer
        Public Property Label As String
        Public Property Currency As String
        Public Property Symbol As String
        Public Property BaseCurrency As String
        Public Property BaseSymbol As String
        Public Property Status As String
        Public Property StatusMessage As String
        Public Property TradeFee As Decimal
        Public Property MinimumTrade As Decimal
        Public Property MaximumTrade As Decimal
        Public Property MinimumBaseTrade As Decimal
        Public Property MaximumBaseTrade As Decimal
        Public Property MinimumPrice As Decimal
        Public Property MaximumPrice As Decimal
    End Class

    Public Function [Call]() As Task(Of Result())
        Return Me.CallFunction(Of Result())("GetTradePairs", needsAuthorisation:=False)
    End Function
End Class
