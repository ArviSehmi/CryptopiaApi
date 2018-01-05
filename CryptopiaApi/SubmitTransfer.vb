Public Class SubmitTransfer
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The currency symbol Of the coins To transfer e.g. 'DOT' (not required if 'CurrencyId' supplied)</summary>
        Public Property Currency As String

        ''' <summary>The Cryptopia currency identifier Of the coins To transfer e.g. '2' (not required if 'Currency' supplied)</summary>
        Public Property CurrencyId As Integer?

        ''' <summary>The Cryptopia username Of the person To transfer the funds To.</summary>
        Public Property Username As String

        ''' <summary>the amount Of coins To transfer e.g. 123.00000000</summary>
        Public Property Amount As Decimal

    End Class



    Public Function [Call](params As Parameters) As Task(Of String)
        Return CallFunction(Of String, Parameters)("SubmitTransfer", params)
    End Function
End Class
