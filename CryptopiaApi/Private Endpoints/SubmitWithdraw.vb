Public Class SubmitWithdraw
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The currency symbol Of the coins To withdraw e.g. 'DOT' (not required if 'CurrencyId' supplied)</summary>
        Public Property Currency As String

        ''' <summary>The Cryptopia currency identifier Of the coins To withdraw e.g. '2' (not required if 'Currency' supplied)</summary>
        Public Property CurrencyId As Integer?

        ''' <summary>The address To send the currency too. (Address must exist In you AddressBook, can be found In you Security settings page.)</summary>
        Public Property Address As String

        ''' <summary>The unique paimentid To identify the payment. (PaymentId For CryptoNote coins.)</summary>
        Public Property PaymentId As String

        ''' <summary>The amount Of coins To withdraw e.g. 123.00000000</summary>
        Public Property Amount As Decimal

    End Class



    Public Function [Call](params As Parameters) As Task(Of Integer)
        Return CallFunction(Of Integer, Parameters)("SubmitWithdraw", params)
    End Function
End Class

