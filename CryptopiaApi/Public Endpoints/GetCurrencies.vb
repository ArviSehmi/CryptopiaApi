
Public Class GetCurrencies
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub
    Public Class Result
        Public Property Id As Integer
        Public Property Name As String
        Public Property Symbol As String
        Public Property Algorithm As String
        Public Property WithdrawFee As Decimal
        Public Property MinWithdraw As Decimal
        Public Property MinBaseTrade As Decimal
        Public Property IsTipEnabled As Boolean
        Public Property MinTip As Decimal
        Public Property DepositConfirmations As Integer
        Public Property Status As String
        Public Property StatusMessage As String
        Public Property ListingStatus As String
    End Class

    Public Function [Call]() As Task(Of Result())
        Return Me.CallFunction(Of Result())("GetCurrencies", needsAuthorisation:=False)
    End Function

End Class
