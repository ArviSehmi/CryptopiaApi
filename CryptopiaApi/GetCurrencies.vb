Public Class GetCurrencies

    Public Class Result
        Public Property Id As Integer
        Public property Name As String
        Public Property Symbol As String
        Public property Algorithm As String
        Public Property WithdrawFee As Decimal
        Public property MinWithdraw As Decimal
        Public Property MinBaseTrade As Decimal
        Public property IsTipEnabled As Boolean
        Public Property MinTip As Decimal
        Public property DepositConfirmations As Integer
        Public Property Status As String
        Public property StatusMessage As String
        Public Property ListingStatus As String
    End Class

    Public Shared Function [Call]() As Task(Of Result())
        Return Client.Default.CallFunction(Of Result())("GetCurrencies", needsAuthorisation:=False)
    End Function

End Class
