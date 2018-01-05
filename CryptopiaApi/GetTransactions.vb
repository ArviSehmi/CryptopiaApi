Public Class GetTransactions
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The type of transactions to return e.g. 'Deposit' or 'Withdraw'</summary>        
        Property Type As String

        ''' <summary>(optional) The maximum amount of orders to return e.g. '10' (default: 100)</summary>
        Property Count As Integer?

    End Class


    Public Class Result
        Public Property Id As Integer
        Public Property Currency As String
        Public Property TxId As String
        Public Property Type As String
        Public Property Amount As Decimal
        Public Property Fee As Decimal
        Public Property Status As String
        Public Property Confirmations As String
        Public Property TimeStamp As String
        Public Property Address As String
    End Class


    Public Function [Call](params As Parameters) As Task(Of Result())
        Return CallFunction(Of Result(), Parameters)("GetTransactions", params)
    End Function
End Class
